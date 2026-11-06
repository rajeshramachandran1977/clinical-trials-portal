using System;
using System.Collections.Generic;
using System.Linq;
using OptimaJet.Workflow.Core.Cache;
using OptimaJet.Workflow.Core.CodeActions;
using OptimaJet.Workflow.Core.Fault;
using OptimaJet.Workflow.Core.Generator;
using OptimaJet.Workflow.Core.Model;
using OptimaJet.Workflow.Core.Parser;
using OptimaJet.Workflow.Core.Persistence;
using OptimaJet.Workflow.Core.Subprocess;

namespace OptimaJet.Workflow.Core.Builder
{
    /// <summary>
    /// Base workflow builder, which convert not parsed process scheme <see cref="SchemeDefinition{T}"/> to the object model of a scheme of a process <see cref="ProcessDefinition"/>
    /// </summary>
    /// <typeparam name="TSchemeMedium">Type of not parsed scheme <see cref="SchemeDefinition{T}"/></typeparam>
    public sealed class WorkflowBuilder<TSchemeMedium> : IWorkflowBuilder where TSchemeMedium : class
    {
        private class ProcessDefinitionAndSchemeDefinition
        {
            public ProcessDefinitionAndSchemeDefinition(ProcessDefinition processDefinition, SchemeDefinition<TSchemeMedium> schemeDefinition)
            {
                ProcessDefinition = processDefinition;
                SchemeDefinition = schemeDefinition;
            }
            public ProcessDefinition ProcessDefinition { get; private set; }
            public SchemeDefinition<TSchemeMedium> SchemeDefinition { get; private set; }
        }
        
        internal IWorkflowGenerator<TSchemeMedium> Generator;

        internal IWorkflowParser<TSchemeMedium> Parser;

        internal ISchemePersistenceProvider<TSchemeMedium> SchemePersistenceProvider;

        private bool _haveCache;

        private IParsedProcessCache _cache;
        
        private SortedDictionary<int,BuildStep> _buildSteps = new SortedDictionary<int, BuildStep>();

        internal WorkflowBuilder()
        {
            
        }

        /// <summary>
        /// Create WorkflowBuilder object
        /// </summary>
        /// <param name="generator">Not parsed scheme generator <see cref="IWorkflowGenerator{T}"/></param>
        /// <param name="parser">Parser from not parsed process scheme <see cref="SchemeDefinition{T}"/> to the object model of a scheme of a process <see cref="ProcessDefinition"/></param>
        /// <param name="schemePersistenceProvider">Scheme persistemce provider <see cref="ISchemePersistenceProvider{T}"/></param>
        public WorkflowBuilder (IWorkflowGenerator<TSchemeMedium> generator,
                               IWorkflowParser<TSchemeMedium> parser,
                               ISchemePersistenceProvider<TSchemeMedium> schemePersistenceProvider)
        {
            Generator = generator;
            Parser = parser;
            SchemePersistenceProvider = schemePersistenceProvider;
        }

        /// <summary>
        /// Returns process scheme by specific id, if scheme not exists creates it 
        /// </summary>
        /// <param name="schemeId">Id of the scheme</param>
        /// <returns>ProcessDefinition object</returns>
        public ProcessDefinition GetProcessScheme(Guid schemeId)
        {
            return GetProcessDefinition(SchemePersistenceProvider.GetProcessSchemeBySchemeId(schemeId));
        }

        /// <summary>
        /// Returns process scheme by specific name, if scheme not exists creates it
        /// </summary>
        /// <param name="schemeCode">Name of the scheme</param>
        /// <returns>ProcessDefinition object</returns>
        public ProcessDefinition GetProcessScheme(string schemeCode)
        {
            return GetProcessScheme(schemeCode, new Dictionary<string, object>());
        }

        /// <summary>
        /// Returns process scheme by specific name and parameters for creating the scheme of the process, if scheme not exists creates it
        /// </summary>
        /// <param name="schemeCode">Name of the scheme</param>
        /// <param name="parameters">The parameters for creating the scheme of the process</param>
        /// <returns>ProcessDefinition object</returns>
        public ProcessDefinition GetProcessScheme(string schemeCode, IDictionary<string, object> parameters)
        {
            var definingParameters = DefiningParametersSerializer.Serialize(parameters);
            try
            {
                return
                    GetProcessDefinition(SchemePersistenceProvider.GetProcessSchemeWithParameters(schemeCode, definingParameters,
                        null, true));
            }
            catch (SchemeNotFoundException)
            {
                return GetProcessDefinition(CreateNewScheme(schemeCode, parameters));
            }
        }

        /// <summary>
        /// Create new instance of the process.
        /// </summary>
        /// <param name="schemeCode">Code of the scheme</param>
        /// <param name="processId">Process id</param>
        /// <param name="parameters">The parameters for creating the scheme of the process</param>
        /// <param name="processId">Tenant id</param>
        /// <returns>ProcessInstance object</returns>
        public ProcessInstance CreateNewProcess(Guid processId,
                                                string schemeCode,
                                                IDictionary<string, object> parameters,
                                                string tenantId)
        {
            var definingParameters = DefiningParametersSerializer.Serialize(parameters);
            SchemeDefinition<TSchemeMedium> schemeDefinition = null;
            try
            {
                schemeDefinition = SchemePersistenceProvider.GetProcessSchemeWithParameters(schemeCode,
                                                                                             definingParameters,
                                                                                             null,
                                                                                             true);
            }
            catch (SchemeNotFoundException)
            {
                schemeDefinition = CreateNewScheme(schemeCode, parameters);
            }

            var processInstance = ProcessInstance.Create(schemeDefinition.Id,
                                          processId,
                                          GetProcessDefinition(schemeDefinition),
                                          schemeDefinition.IsObsolete,
                                          schemeDefinition.IsDeterminingParametersChanged,
                                          tenantId);

            processInstance.RootProcessId = processInstance.ProcessId;

            return processInstance;
        }

        public ProcessInstance CreateNewSubprocess(Guid processId, ProcessInstance parentProcessInstance, TransitionDefinition startingTransition)
        {
            var parentProcessScheme = parentProcessInstance.ProcessScheme;

            //Scheme code for subprocess {RootSchemeCode}_{StartingTransition.Name}
            var schemeCode = GetSubprocessSchemeCode(startingTransition, parentProcessScheme);

            var rootSchemeId = parentProcessScheme.RootSchemeId ?? parentProcessScheme.Id;

            SchemeDefinition<TSchemeMedium> schemeDefinition = null;
            try
            {
                schemeDefinition = SchemePersistenceProvider.GetProcessSchemeWithParameters(schemeCode,
                    parentProcessScheme.DefiningParametersString, rootSchemeId, false);
            }
            catch (SchemeNotFoundException)
            {
                schemeDefinition = CreateSubprocessSchemeDefinition(schemeCode, rootSchemeId, startingTransition, parentProcessScheme);

                try
                {
                    SchemePersistenceProvider.SaveScheme(schemeDefinition);
                }
                catch (SchemeAlreadyExistsException)
                {
                    schemeDefinition = SchemePersistenceProvider.GetProcessSchemeWithParameters(schemeCode,
                        parentProcessScheme.DefiningParametersString, rootSchemeId, false);
                }
            }

            var processInstance = ProcessInstance.Create(schemeDefinition.Id,
                                        processId,
                                        GetProcessDefinition(schemeDefinition),
                                        schemeDefinition.IsObsolete, schemeDefinition.IsDeterminingParametersChanged);

            //All not system parameters copy to subprocess
            foreach (var parameter in parentProcessInstance.ProcessParameters.Where(p => p.Purpose != ParameterPurpose.System))
            {
                processInstance.SetParameter(parameter.Name, parameter.Value, parameter.Purpose);
            }

            processInstance.RootProcessId = parentProcessInstance.RootProcessId;
            processInstance.ParentProcessId = parentProcessInstance.ProcessId;

            return processInstance;
        }

        private SchemeDefinition<TSchemeMedium> CreateSubprocessSchemeDefinition(string schemeCode, Guid rootSchemeId,TransitionDefinition startingTransition,
            ProcessDefinition parentProcessScheme)
        {
            var processDefinition = parentProcessScheme.GetSubprocessDefinition(startingTransition);
            processDefinition.Name = schemeCode;
            processDefinition.Id = Guid.NewGuid();
            processDefinition.RootSchemeId = rootSchemeId;
            processDefinition.RootSchemeCode = parentProcessScheme.RootSchemeCode ?? parentProcessScheme.Name;
            processDefinition.StartingTransition = startingTransition.Name;
            processDefinition.IsObsolete = parentProcessScheme.IsObsolete;

            var schemeDefinition = new SchemeDefinition<TSchemeMedium>(processDefinition, Parser);
            return schemeDefinition;
        }

        private static string GetSubprocessSchemeCode(TransitionDefinition startingTransition, ProcessDefinition parentProcessScheme)
        {
            return $"{parentProcessScheme.RootSchemeCode ?? parentProcessScheme.Name}_{startingTransition.Name}";
        }

        private SchemeDefinition<TSchemeMedium> CreateNewScheme(string schemeCode, IDictionary<string, object> parameters)
        {
            var definingParameters = DefiningParametersSerializer.Serialize(parameters);
            var schemeId = Guid.NewGuid();
            var newScheme = Generator.Generate(schemeCode, schemeId, parameters);
            var schemeDefinition = new SchemeDefinition<TSchemeMedium>(schemeId, null, schemeCode, null, newScheme,
                false, false, null, null, definingParameters);

            ProcessDefinition processDefinition = null;
            if (_buildSteps.Any())
            {
                processDefinition = CreateProcessDefinition(schemeDefinition,true);
                processDefinition = ExecuteBuildSteps(parameters, processDefinition, out var errors, out var failedStep);
                if (errors != null && errors.Any())
                    throw new ProcessSchemeBuildException(schemeCode, errors, failedStep);

                newScheme = Parser.SerializeToSchemeMedium(processDefinition);
                schemeDefinition = new SchemeDefinition<TSchemeMedium>(schemeId, null, schemeCode, null, newScheme,
                    false, false, null, null, definingParameters);
                
            }

            try
            {
                SchemePersistenceProvider.SaveScheme(schemeDefinition);
                if (processDefinition != null)
                {
                    PrepareProcessDefinition(processDefinition);
                    CacheProcessDefinition(processDefinition);
                }
            }
            catch (SchemeAlreadyExistsException)
            {
                schemeDefinition = SchemePersistenceProvider.GetProcessSchemeWithParameters(schemeCode,
                    definingParameters, null,
                    true);
            }

            return schemeDefinition;
        }

        private ProcessDefinition ExecuteBuildSteps(IDictionary<string, object> parameters, ProcessDefinition processDefinition, out List<string> errors, out string failedStep)
        {
            foreach (var step in _buildSteps.Values)
            {
                var bsResult = step.Execute(processDefinition, parameters);
                if (bsResult.IsSuccess)
                {
                    processDefinition = bsResult.ProcessDefinition;
                }
                else
                {
                    failedStep = step.Name;
                    errors = bsResult.Errors.ToList();
                    return processDefinition;
                }
            }

            errors = null;
            failedStep = null;
            return processDefinition;
        }

        private ProcessDefinition GetProcessDefinition(SchemeDefinition<TSchemeMedium> schemeDefinition)
        {
            ProcessDefinition processDefinition;

            if (_haveCache)
            {
                var cachedDefinition = _cache.GetProcessDefinitionBySchemeId(schemeDefinition.Id);
                if (cachedDefinition != null)
                {
                    //IsObsolete could be changed externally. Need to change it.
                    cachedDefinition.IsObsolete = schemeDefinition.IsObsolete;
                    return cachedDefinition;
                }
                processDefinition = CreateProcessDefinition(schemeDefinition);
                _cache.AddProcessDefinition(schemeDefinition.Id, processDefinition);
                return processDefinition;
            }

            processDefinition = CreateProcessDefinition(schemeDefinition);

            
            return processDefinition;
        }

        private void CacheProcessDefinition(ProcessDefinition processDefinition)
        {
            if (_haveCache)
            {
                _cache.AddProcessDefinition(processDefinition.Id, processDefinition);
            }
        }

        private ProcessDefinition CreateProcessDefinition(SchemeDefinition<TSchemeMedium> schemeDefinition, bool dontPrepare = false)
        {
            var processDefinition = Parser.Parse(schemeDefinition.Scheme);

            //additional parameters for designer
            if (!string.IsNullOrWhiteSpace(schemeDefinition.DefiningParameters))
                processDefinition.AdditionalParams.Add("DefiningParameters", schemeDefinition.DefiningParameters);
            processDefinition.AdditionalParams.Add("IsObsolete", schemeDefinition.IsObsolete);
            processDefinition.Name = schemeDefinition.SchemeCode;
            processDefinition.DefiningParametersString = schemeDefinition.DefiningParameters;
            processDefinition.RootSchemeCode = schemeDefinition.RootSchemeCode;
            processDefinition.RootSchemeId = schemeDefinition.RootSchemeId;
            processDefinition.AllowedActivities = schemeDefinition.AllowedActivities;
            processDefinition.Id = schemeDefinition.Id;
            processDefinition.IsObsolete = schemeDefinition.IsObsolete;
            if (!dontPrepare)
            {
                PrepareProcessDefinition(processDefinition);
            }

            return processDefinition;
        }

        private static void PrepareProcessDefinition(ProcessDefinition processDefinition)
        {
            //code actions compile
            if (!processDefinition.IsSubprocessScheme)
                processDefinition.CodeActionsInvoker = CodeActionsCompiller.CompileCodeActions(processDefinition,
                    processDefinition.Id);
            //scheme markup
            processDefinition.MarkupSubprocesses();
        }

        /// <summary>
        /// Returns existing process instance
        /// </summary>
        /// <param name="processId">Process id</param>
        /// <returns>ProcessInstance object</returns>
        public ProcessInstance GetProcessInstance(Guid processId)
        {
            var schemeDefinition = SchemePersistenceProvider.GetProcessSchemeByProcessId(processId);
            var pd = GetProcessDefinition(schemeDefinition);
            pd.Name = schemeDefinition.SchemeCode;
            return ProcessInstance.Create(schemeDefinition.Id,
                                          processId,
                                          pd,
                                          schemeDefinition.IsObsolete,schemeDefinition.IsDeterminingParametersChanged);
        }


        /// <summary>
        /// Create new scheme for existing process
        /// </summary>
        /// <param name="schemeCode">Code of the scheme</param>
        /// <param name="parameters">The parameters for creating scheme of process</param>
        /// <returns>ProcessDefinition object</returns>
        public ProcessDefinition CreateNewProcessScheme(string schemeCode, IDictionary<string, object> parameters)
        {

            #region oldCode
//            SchemeDefinition<TSchemeMedium> schemeDefinition = null;
//            var definingParameters = DefiningParametersSerializer.Serialize(parameters);
//            var schemeId = Guid.NewGuid();
//            var newScheme = Generator.Generate(schemeCode, schemeId, parameters);
//            try
//            {
//                schemeDefinition = new SchemeDefinition<TSchemeMedium>(schemeId, null, schemeCode, null, newScheme,
//                    false, false, null, null, definingParameters);
//                SchemePersistenceProvider.SaveScheme(schemeDefinition);
//            }
//            catch (SchemeAlreadyExistsException)
//            {
//                schemeDefinition = SchemePersistenceProvider.GetProcessSchemeWithParameters(schemeCode,
//                    definingParameters, null, true);
//            }

#endregion

            return GetProcessDefinition(CreateNewScheme(schemeCode,parameters));
        }



        public ProcessDefinition CreateNewSubprocessScheme(ProcessDefinition parentProcessScheme,TransitionDefinition startingTransition)
        {
             //Scheme code for subprocess {RootSchemeCode}_{StartingTransition.Name}
            var schemeCode = GetSubprocessSchemeCode(startingTransition, parentProcessScheme);

            var rootSchemeId = parentProcessScheme.RootSchemeId ?? parentProcessScheme.Id;

            var scheme = CreateSubprocessSchemeDefinition(schemeCode, rootSchemeId, startingTransition,
                parentProcessScheme);

            try
            {
                SchemePersistenceProvider.SaveScheme(scheme);
            }
            catch (SchemeAlreadyExistsException)
            {
                scheme = SchemePersistenceProvider.GetProcessSchemeWithParameters(schemeCode,
                    parentProcessScheme.DefiningParametersString,rootSchemeId,true);
            }

            return GetProcessDefinition(scheme);
        }

        /// <summary>
        /// Sets the cache to store parsed ProcessDefinition objects <see cref="ProcessDefinition"/> 
        /// </summary>
        /// <param name="cache">Instance of cache object</param>
        public void SetCache(IParsedProcessCache cache)
        {
            _cache = cache;
            _haveCache = true;
        }

        /// <summary>
        /// Removes the cache to store parsed ProcessDefinition objects <see cref="ProcessDefinition"/> 
        /// </summary>
        public void RemoveCache()
        {
            _haveCache = false;
            _cache.Clear();
            _cache = null;
        }

        /// <summary>
        /// Set IsObsolete sign to the scheme with specific name and parameters for creating the scheme of the process
        /// </summary>
        /// <param name="schemeCode">Name of the scheme</param>
        /// <param name="parameters">The parameters for creating the scheme of the process</param>
        public void SetSchemeIsObsolete(string schemeCode, Dictionary<string, object> parameters)
        {
            SchemePersistenceProvider.SetSchemeIsObsolete(schemeCode,parameters);
        }

        /// <summary>
        /// Set IsObsolete sign to the scheme with specific name
        /// </summary>
        /// <param name="schemeCode">Name of the scheme</param>
        public void SetSchemeIsObsolete(string schemeCode)
        {
            SchemePersistenceProvider.SetSchemeIsObsolete(schemeCode);
        }

        /// <summary>
        /// Returns existing process scheme directly from scheme persistence store
        /// </summary>
        /// <param name="code">Name of the scheme</param>
        /// <returns>ProcessDefinition object</returns>
        public ProcessDefinition GetProcessSchemeForDesigner(string code)
        {
            var xe = SchemePersistenceProvider.GetScheme(code);
            return Parser.Parse(xe);
        }

        /// <summary>
        /// Saves process scheme to scheme persistence store
        /// </summary>
        /// <param name="schemeCode">Code of the scheme</param>
        /// <param name="pd">Object representation of the scheme</param>
        /// <param name="errors">Validation errors</param>
        /// <returns>True if scheme validation was success</returns>
        public bool SaveProcessScheme(string schemeCode, ProcessDefinition pd, out List<string> errors, out string failedStep)
        {
            pd.Name = schemeCode; //name can be missed, it equal the scheme code
            
            var clonedPd = pd.Clone();
            var builtPd = ExecuteBuildSteps(new Dictionary<string, object>(), clonedPd, out errors, out failedStep);
            if (errors != null && errors.Any())
                return false;

            var inlinedSchemes = builtPd.Activities.Where(a => a.WasInlined).Select(a => a.OriginalSchemeCode).Distinct().ToList();
            
            SchemePersistenceProvider.SaveScheme(schemeCode, pd.CanBeInlined, inlinedSchemes, Parser.SerializeToString(pd), pd.Tags);

            return true;
        }


        /// <summary>
        /// Parses process scheme from the string
        /// </summary>
        /// <param name="scheme">String representation of not parsed scheme</param>
        /// <returns>ProcessDefinition object</returns>
        public ProcessDefinition Parse(string scheme, SchemeParsingType schemeParsingType = SchemeParsingType.Strict)
        {
            return Parser.Parse(scheme, schemeParsingType);
        }

        /// <summary>
        /// Serialize process scheme to the string
        /// </summary>
        /// <param name="processDefinition">SProcessDefinition object</param>
        /// <returns>String representation of not parsed scheme</returns>
        public string Serialize(ProcessDefinition processDefinition)
        {
            return Parser.SerializeToString(processDefinition);
        }


        /// <summary>
        /// Adds a build step into workflow builder
        /// </summary>
        /// <param name="order">Order in position</param>
        /// <param name="buildStepPosition">Indicates whether the build step is added after the system steps or before the system steps.</param>
        /// <param name="step">Build step</param>
        public void AddBuildStep(int order, BuildStepPosition buildStepPosition, BuildStep step)
        {
            if (step.IsBuilderNull)
            {
                step.SetBuilder(this);
            }
            
            var limit = 10000;
            if (buildStepPosition == BuildStepPosition.SystemSteps && (order > limit || order < 0))
            {
                throw new ConfigurationException($"The build step order must be between 0 and 10,000. The build step {step.Name} order is {order}");
            }

            if (buildStepPosition == BuildStepPosition.BeforeSystemSteps)
            {
                _buildSteps.Add(int.MinValue + order, step);
            }
            else if (buildStepPosition == BuildStepPosition.AfterSystemSteps)
            {
                _buildSteps.Add(limit + order, step);
            }
            else if (buildStepPosition == BuildStepPosition.SystemSteps)
            {
                _buildSteps.Add(order, step);
            }
            else
            {
                throw new ConfigurationException($"Unknown buildStepPosition {buildStepPosition:G}");
            }
        }

        public bool ContainsBuildStep(string name)
        {
            return _buildSteps.Values.Any(bs => bs.Name.Equals(name, StringComparison.Ordinal));
        }

        public List<string> GetInlinedSchemeCodes()
        {
            return SchemePersistenceProvider.GetInlinedSchemeCodes();
        }

        public List<string> GetRelatedByInliningSchemeCodes(string schemeCode)
        {
            return SchemePersistenceProvider.GetRelatedByInliningSchemeCodes(schemeCode);
        }

        /// <summary>
        /// Generates new Process Definition, doesn't save it in a database, doesn't use cache, doesn't execute build steps
        /// </summary>
        /// <param name="schemeCode">Name of the scheme</param>
        /// <param name="parameters">The parameters for creating the scheme of the process</param>
        /// <returns>Generated process definition</returns>
        public ProcessDefinition GenerateProcessDefinition(string schemeCode, IDictionary<string, object> parameters)
        {
            var generatedScheme = Generator.Generate(schemeCode, Guid.Empty, parameters);
            return Parser.Parse(generatedScheme);
        }

        /// <summary>
        /// Add tags to scheme with the given schemeCode
        /// </summary>
        public void AddSchemeTags(string schemeCode, IEnumerable<string> tags)
        {
            SchemePersistenceProvider.AddSchemeTags(schemeCode,tags);
        }

        /// <summary>
        /// Remove tags from scheme with the given schemeCode
        /// </summary>
        public void RemoveSchemeTags(string schemeCode, IEnumerable<string> tags)
        {
            SchemePersistenceProvider.RemoveSchemeTags(schemeCode,tags);
        }
        /// <summary>
        /// Set tags to scheme with the given schemeCode
        /// </summary>
        public void SetSchemeTags(string schemeCode, IEnumerable<string> tags)
        {
            SchemePersistenceProvider.SetSchemeTags(schemeCode,tags);
        }

        /// <summary>
        /// Returns the list of scheme codes into which the scheme with the given tags
        /// </summary>
        public List<string> SearchSchemesByTags(IEnumerable<string> tags)
        {
            return SchemePersistenceProvider.SearchSchemesByTags(tags);
        }
    }
}
