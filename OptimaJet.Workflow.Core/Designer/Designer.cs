using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
# if !NETCOREAPP
using System.Web;
using System.Web.UI.WebControls;
#else
using System.Net;
#endif
using OptimaJet.Workflow.Core.CodeActions;
using OptimaJet.Workflow.Core.Fault;
using OptimaJet.Workflow.Core.Model;
using OptimaJet.Workflow.Core.Runtime;
using Newtonsoft.Json;
using OptimaJet.Workflow.Core.Builder;
using OptimaJet.Workflow.Core.Designer;
using OptimaJet.Workflow.Core.Subprocess;
using OptimaJet.Workflow.Core.License;
using OptimaJet.Workflow.Core.Runtime.CodeAutocomplete;
using Newtonsoft.Json.Serialization;

namespace OptimaJet.Workflow
{
    /// <summary>
    /// Extension which provides API for HTML5 Workflow Designer
    /// </summary>
    public static class Designer
    {
        [Obsolete("Use DesignerApi method with out hasError parameter")]
        public static string DesignerAPI(this WorkflowRuntime runtime,
            NameValueCollection form,
            Stream filestream = null,
            bool setIsObsoleForOperationSave = true
        )
        {
            return DesignerAPI(runtime, form, out _, filestream, setIsObsoleForOperationSave);
        }

        /// <summary>
        /// API for HTML5 Workflow Designer. Contains following operations:
        /// - bool exists(schemecode, schemeid, processid) Checks existence of the scheme of the process with specific code, id or id of the process 
        /// - JSON load(schemecode, schemeid, processid) Returns the scheme of the process in JSON format by specific code, id or id of the process 
        /// - JSON save(schemecode, data) Saves the scheme with specified code. Ruturns updated scheme.
        /// - JSON uploadscheme(filestream) Converts scheme uploaded as XML file to JSON.
        /// - XML downloadscheme(data) Converts scheme from JSON object to XML.
        /// - object compile(data) Method for test compile of code actions
        /// - JSON getemptytype(typename) returns serialized empty type
        /// - array getautocompletesuggestions (category, value) returns a list of autocomplete suggestions
        /// - JSON uploadschemebpmn(filestream) Converts BPMN scheme uploaded as XML file to JSON.
        /// - XML downloadschemebpmn(data) Converts BPMN scheme from JSON object to XML.
        /// Type of the operation determined by "operation" parameter from request parameters 
        /// </summary>
        /// <param name="runtime">The instance of the runtime</param>
        /// <param name="form">Parameters from request. Allowed parameters is: "operation", "schemecode", "schemeid", "processid", "data"</param>
        /// <param name="hasError">If true the result contains info about an exception</param>
        /// <param name="filestream">Stream which represent uploaded file</param>
        /// <param name="setIsObsoleForOperationSave">If true and operation is "save" IsObsolete property will be set to all shemes of processes with specified code</param>
        /// <returns>Operation execution result</returns>
        public static string DesignerAPI(this WorkflowRuntime runtime,
            NameValueCollection form,
            out bool hasError,
            Stream filestream = null,
            bool setIsObsoleForOperationSave = true
        )
        {
            hasError = false;
            var operation = form[RequestElements.operation.ToString()].ToLower();
            var schemecode = form[RequestElements.schemecode.ToString()];
            var schemeid = form[RequestElements.schemeid.ToString()];
            var processid = form[RequestElements.processid.ToString()];
            Operations operationValue = Operations.notcorrect;

            if (!string.IsNullOrEmpty(operation))
                Enum.TryParse(operation, out operationValue);

            if (operationValue is Operations.notcorrect)
                return JsonConvert.SerializeObject(new {isError = true, errorMessage = "Operation with name " + operation + " is not found", operation});

            try
            {
                switch (operationValue)
                {
                    case Operations.exists:
                    {
                        bool exists = false;
                        try
                        {
                            InitializeProcessDefinition(runtime, schemecode, schemeid, processid);
                            exists = true;
                        }
                        catch (ProcessNotFoundException)
                        {
                        }
                        catch (SchemeNotFoundException)
                        {
                        }

                        return JsonConvert.SerializeObject(exists);
                    }
                    case Operations.load:
                    {
                        var newSchemeCode = form[RequestElements.newschemecode.ToString()];
                        return Load(runtime, schemecode, schemeid, processid, newSchemeCode);
                    }
                    case Operations.save:
                    {
                        return Save(runtime, form, setIsObsoleForOperationSave, processid, schemeid, schemecode);
                    }
                    case Operations.uploadscheme:
                    {
                        return Upload(runtime, filestream, processid, schemeid);
                    }
                    case Operations.downloadscheme:
                    {
                        return Download(runtime, form);
                    }
                    case Operations.uploadschemebpmn:
                    {
                        return UploadBPMN(runtime, filestream, processid, schemeid);
                    }
                    case Operations.downloadschemebpmn:
                    {
                        return DownloadBPMN(runtime, form);
                    }
                    case Operations.compile:
                    {
                        var codeAction = JsonConvert.DeserializeObject<CodeActionDefinition>(form[RequestElements.data.ToString()]);
                        if (string.IsNullOrEmpty(codeAction.Name))
                            codeAction.Name = string.Format("Test_{0}", Guid.NewGuid().ToString("N"));
                        var res = Compile(codeAction);
                        return JsonConvert.SerializeObject(res);
                    }
                    case Operations.getemptytype:
                    {
                        var typeName = JsonConvert.DeserializeObject<string>(form[RequestElements.data.ToString()]);
#if !NETCOREAPP
                        typeName = HttpUtility.UrlDecode(typeName);
#else
                        typeName = WebUtility.UrlDecode(typeName);
#endif
                        var parsedType = ParsedType.Parse(typeName);
                        var type = parsedType.ConvertToType();
                        if (type == null)
                            return string.Empty;
                        return JsonConvert.SerializeObject(Activator.CreateInstance(type));
                    }
                    case Operations.getautocompletesuggestions:
                    {
                        if (runtime.DesignerAutocompleteProvider == null)
                            return "[]";
                        var category = (SuggestionCategory)Enum.Parse(typeof(SuggestionCategory), form[RequestElements.category.ToString()], true);
                        var value = form[RequestElements.value.ToString()];
                        return JsonConvert.SerializeObject(runtime.DesignerAutocompleteProvider.GetAutocompleteSuggestions(category, value, schemecode) ??
                                                           new List<string>());
                    }
                    case Operations.getcodeactionparameter:
                    {
                        if (runtime.DesignerParameterFormatProvider == null)
                            return "[]";
                        var type = (CodeActionType)Enum.Parse(typeof(CodeActionType), form[RequestElements.type.ToString()], true);
                        var name = form[RequestElements.name.ToString()];
                        return JsonConvert.SerializeObject(runtime.DesignerParameterFormatProvider.GetFormat(type, name, schemecode) ??
                                                           new List<CodeActionParameterDefinition>());
                    }
                    case Operations.deleteglobalcodeaction:
                    {
                        return JsonConvert.SerializeObject(DeleteGlobalActions(runtime, form));
                    }
                    case Operations.getcodeautocomplete:
                    {
                        AutocompleteRequest request = JsonConvert.DeserializeObject<AutocompleteRequest>(form[RequestElements.data.ToString()]);
                        
                        //one time init
                        
                        runtime.CodeAutocompleteProvider.RunInitTask();//.InitCodeAutocomletersThatNoInitialized();
                        
                        HashSet<AutocompleteItem> suggestions = runtime.CodeAutocompleteProvider.Get(request.Pattern, request.Usings, request.Variables);

                        return JsonConvert.SerializeObject(new {data = suggestions, id = request.Id});
                    }
                }
            }
            catch (Exception exception)
            {
                hasError = true;
                return JsonConvert.SerializeObject(new {isError = true, errorMessage = exception.Message, stackTrace = exception.StackTrace});
            }

            return JsonConvert.SerializeObject(new {isError = true, errorMessage = "API return NULL"});
        }

        private static string Download(WorkflowRuntime runtime, NameValueCollection form)
        {
            var pd = JsonConvert.DeserializeObject<ProcessDefinition>(form[RequestElements.data.ToString()]);
            pd.CodeActions.ForEach(ca => ca.Decode());
            return runtime.Builder.Serialize(pd);
        }

        private static string Load(WorkflowRuntime runtime, string schemecode, string schemeid, string processid, string newschemecode)
        {
            List<CodeActionDefinition> globalActions;
            globalActions =
                runtime.PersistenceProvider.LoadGlobalParameters<CodeActionDefinition>(
                    WorkflowRuntime.CodeActionsGlobalParameterName);
            var pd = InitializeProcessDefinition(runtime, schemecode, schemeid, processid, newschemecode);
            pd.CodeActions.AddRange(globalActions);

            pd.CodeActions = pd.CodeActions.Select(ca => ca.Encode()).ToList();

            return JsonConvert.SerializeObject(pd);
        }

        private static string Upload(WorkflowRuntime runtime, Stream filestream, string processid, string schemeid)
        {
            ProcessDefinition pd;
            if (!string.IsNullOrWhiteSpace(processid) || !string.IsNullOrWhiteSpace(schemeid))
            {
                throw new Exception("The UploadScheme is available by scheme code only!");
            }

            StreamReader reader = new StreamReader(filestream);
            var text = reader.ReadToEnd();
            pd = runtime.Builder.Parse(text,SchemeParsingType.Soft);
            pd.CodeActions.ForEach(ca =>
            {
                if (!ca.WasEncoded())
                    ca.Encode();
            });
            InitializeAdditionalParams(runtime, pd);
            return JsonConvert.SerializeObject(pd);
        }

        private static string Save(WorkflowRuntime runtime, NameValueCollection form, bool setIsObsoleForOperationSave, string processid, string schemeid, string schemecode)
        {
            ProcessDefinition pd;
            List<CodeActionDefinition> globalActions;
            if (!string.IsNullOrWhiteSpace(processid) || !string.IsNullOrWhiteSpace(schemeid))
            {
                throw new Exception("The Save is available by scheme code only!");
            }

            try
            {
                pd = JsonConvert.DeserializeObject<ProcessDefinition>(form[RequestElements.data.ToString()]);
            }
            catch (TypeParsingException e)
            {
               throw new Exception("One of the parameters in your scheme has an incorrect type. Please check parameters in the scheme.");
            }

            if (pd.Parameters.Any(p=>p.Type == null))
            {
                throw new Exception("One of the parameters in your scheme has an incorrect type. Please check parameters in the scheme.");
            }
            
            pd.AdditionalParams = new Dictionary<string, object>();

            pd.CodeActions = pd.CodeActions.Select(ca => ca.Decode()).ToList();

            if (pd.CodeActions.Any(ca => ca.IsGlobal))
            {
                globalActions = pd.CodeActions.Where(ca => ca.IsGlobal).ToList();

                pd.CodeActions = pd.CodeActions.Where(ca => !ca.IsGlobal).ToList();

                globalActions.ForEach(
                    ga =>
                        runtime.PersistenceProvider.SaveGlobalParameter(
                            WorkflowRuntime.CodeActionsGlobalParameterName, ga.Name, ga));
            }

            var success = runtime.Builder.SaveProcessScheme(schemecode, pd, out var errors, out var failedStep);

            if (!success)
            {
                return JsonConvert.SerializeObject(new
                {
                    isError = true,
                    errorMessage = $"Scheme save failed. {failedStep} build step failed.",
                    errorDetails = errors
                });
            }
            
            if (setIsObsoleForOperationSave)
            {
                var codesForObsolete = runtime.Builder.GetRelatedByInliningSchemeCodes(schemecode);
                runtime.SetSchemeIsObsolete(schemecode);
                if (codesForObsolete != null)
                {
                    foreach (var code in codesForObsolete)
                    {
                        runtime.SetSchemeIsObsolete(code);
                    }
                }
            }

            pd = InitializeProcessDefinition(runtime, schemecode, schemeid, processid);
            globalActions = runtime.PersistenceProvider.LoadGlobalParameters<CodeActionDefinition>(WorkflowRuntime.CodeActionsGlobalParameterName);
            pd.CodeActions.AddRange(globalActions);
            pd.CodeActions = pd.CodeActions.Select(ca => ca.Encode()).ToList();
            return JsonConvert.SerializeObject(pd);
        }

        private static ProcessDefinition GetProcessDefinitionById(this WorkflowRuntime runtime, Guid processId)
        {
            ProcessDefinition pd = null;

            var pi = runtime.Builder.GetProcessInstance(processId);
            runtime.PersistenceProvider.FillProcessParameters(pi);
            pd = pi.ProcessScheme.Clone();
            pd.AdditionalParams.Clear();
            if (!pd.AdditionalParams.ContainsKey("ProcessParameters"))
                pd.AdditionalParams.Add("ProcessParameters", pi.ProcessParameters);

            var processHistory = runtime.GetProcessHistory(processId);
            pd.AdditionalParams.Add("ProcessHistory", processHistory.OrderByDescending(x => x.TransitionTime));

            pd.AdditionalParams.Add("ProcessTimers", runtime.GetProcessTimers(processId));

            return pd;
        }

        private static ProcessDefinition InitializeProcessDefinition(this WorkflowRuntime runtime, string schemecode, string schemeid, string processid, string newschemecode = null)
        {  
            ProcessDefinition pd = null;
            if (!string.IsNullOrWhiteSpace(processid))
            {
                var processId = new Guid(processid);
                pd = runtime.GetProcessDefinitionById(processId);

                var subprocessActivities = new List<string>();
                var processTree = runtime.GetProcessInstancesTree(processId);
   
                if (processTree != null)
                {
                    var subprocessesInfo = new Dictionary<Tuple<string, int>, Dictionary<string, object>>();

                    void AddSubprocessActivity (ProcessInstancesTree tree, List<string> acc, bool includeCurrent, int level)
                    {
                        if (includeCurrent)
                        {
                            var name = runtime.GetCurrentActivityName(tree.Id);
                            acc.Add(name);

                            var subprocessInfo = new Dictionary<string, object>();

                            var subprocessDefinition = runtime.GetProcessDefinitionById(tree.Id);

                            subprocessInfo["ProcessParameters"] = subprocessDefinition.AdditionalParams["ProcessParameters"];
                            subprocessInfo["ProcessHistory"] = subprocessDefinition.AdditionalParams["ProcessHistory"];
                            subprocessInfo["ProcessTimers"] = subprocessDefinition.AdditionalParams["ProcessTimers"];

                            subprocessesInfo.Add(new Tuple<string, int>(tree.Name, level), subprocessInfo);

                        }

                        foreach (var child in tree.Children)
                        {
                            try
                            {
                                AddSubprocessActivity(child, acc, true, level + 1);
                            }
                            catch (ProcessNotFoundException ex)
                            {
                                throw new Exception(string.Format("Subprocess {0} is not exist", child.Id), ex);
                            }
                        }
                    }
                    
                    AddSubprocessActivity(processTree,subprocessActivities,false, 0);

                    pd.AdditionalParams.Add("SubprocessInfo", subprocessesInfo.OrderBy(x => x.Key.Item2)
                                                                              .ThenBy(x => x.Key.Item1)
                                                                              .ToDictionary(k => k.Key.Item1, v => v.Value));
                }

                if (pd.AdditionalParams.ContainsKey("SubprocessCurrentActivities"))
                    pd.AdditionalParams.Remove("SubprocessCurrentActivities");
                pd.AdditionalParams.Add("SubprocessCurrentActivities",subprocessActivities);

               

            }
            else if (!string.IsNullOrWhiteSpace(schemeid))
            {
                pd = runtime.Builder.GetProcessScheme(new Guid(schemeid));
                pd.AdditionalParams.Clear();
            }
            else if(!string.IsNullOrEmpty(schemecode))
            {
                pd = runtime.Builder.GetProcessSchemeForDesigner(schemecode);
                pd.AdditionalParams.Clear();
            }
            else
            {
                pd = new ProcessDefinition();
                if (!string.IsNullOrEmpty(newschemecode))
                {
                    pd.Name = newschemecode;
                }
            }

            InitializeAdditionalParams(runtime, pd);
            return pd;
        }

        private static void InitializeAdditionalParams(WorkflowRuntime runtime, ProcessDefinition pd)
        {
            if (!pd.AdditionalParams.ContainsKey("Rules"))
                pd.AdditionalParams.Add("Rules", runtime.RuleProvider.GetRules(pd.Name));
            if (!pd.AdditionalParams.ContainsKey("TimerTypes"))
                pd.AdditionalParams.Add("TimerTypes", Enum.GetValues(typeof(TimerType)).Cast<TimerType>().Select(t => t.ToString()));

            if (!pd.AdditionalParams.ContainsKey("Conditions"))
            {
                List<string> conditions;
                try //Do not transfer try/catch to Java Version
                {
                    conditions = runtime.ActionProvider.GetConditions(pd.Name);
                }
                catch (NotImplementedException)
                {
                    conditions = runtime.ActionProvider.GetActions(pd.Name);
                }

                pd.AdditionalParams.Add("Conditions", conditions);
            }

            if (!pd.AdditionalParams.ContainsKey("Actions"))
                pd.AdditionalParams.Add("Actions", runtime.ActionProvider.GetActions(pd.Name));

            if (!pd.AdditionalParams.ContainsKey("Usings"))
                pd.AdditionalParams.Add("Usings", CodeActionsCompiller.Usings);
            if (!pd.AdditionalParams.ContainsKey("Types"))
                pd.AdditionalParams.Add("Types", _registeredTypeNames);
            
            
            var license = Licensing.GetLicenseRestrictions<WorkflowEngineNetRestrictions>();
            
            if (!pd.AdditionalParams.ContainsKey("MaxNumberOfActivities"))
            {
                pd.AdditionalParams.Add("MaxNumberOfActivities", license.MaxNumberOfActivities);
            }

            if (!pd.AdditionalParams.ContainsKey("MaxNumberOfTransitions"))
            {
                pd.AdditionalParams.Add("MaxNumberOfTransitions", license.MaxNumberOfTransitions);
            }

            if (!pd.AdditionalParams.ContainsKey("MaxNumberOfCommands"))
            {
                pd.AdditionalParams.Add("MaxNumberOfCommands", license.MaxNumberOfCommands);
            }

            if (!pd.AdditionalParams.ContainsKey("MaxNumberOfSchemes"))
            {
                pd.AdditionalParams.Add("MaxNumberOfSchemes", license.MaxNumberOfSchemes);
            }

            if (!pd.AdditionalParams.ContainsKey("MaxNumberOfThreads"))
            {
                pd.AdditionalParams.Add("MaxNumberOfThreads", license.MaxNumberOfThreads);
            }

            if (!pd.AdditionalParams.ContainsKey("InlinedSchemeCodes"))
            {
                pd.AdditionalParams.Add("InlinedSchemeCodes", runtime.Builder.GetInlinedSchemeCodes());
            }


        }

        private static List<string> _registeredTypeNames = new List<string> {"String", "Char", "Byte", "Int16", "Int32", "Int64", "Single", "Double", "Decimal", "DateTime"};

        public static void RegisterTypesFromAssembly(Assembly assembly, Func<Type, bool> filter = null)
        {
            var typeNames = assembly.GetTypes().Where(t => t.GetTypeInfo().IsPublic && (filter == null || filter(t))).Select(t =>
            {
                try
                {
                    return ParsedType.GetFriendlyName(t);
                }
                catch (Exception)
                {
                    //Just for designer purpose
                    return null;
                }
            }).Where(s => !string.IsNullOrEmpty(s)).ToList();
            typeNames.AddRange(_registeredTypeNames);
            _registeredTypeNames = typeNames.Distinct().ToList();
        }

        private static dynamic Compile(CodeActionDefinition codeActionDefinition)
        {
            if (!CodeActionsCompiller.CompillationEnable)
                return new { Success = false, Message = "Code actions compilation disabled." };

            codeActionDefinition = codeActionDefinition.Decode();

            try
            {
                CodeActionsCompiller.CompileCodeActions(new List<CodeActionDefinition> { codeActionDefinition }, string.Format("TestCompile_{0}", Guid.NewGuid().ToString("N")));
            }
            catch (Exception ex)
            {
                return new {Success = false, Message = ex.Message.Replace("\n","<br/>")};
            }

            return new { Success = true};
        }

        private static dynamic DeleteGlobalActions(WorkflowRuntime runtime, NameValueCollection form)
        {
            var names = form["names"];
            if (string.IsNullOrWhiteSpace(names))
            {
                return new { Success = false, Message = "names parameter is required." };
            }

            try
            {
                var namesArray = JsonConvert.DeserializeObject<string[]>(names);
                foreach (var name in namesArray)
                    runtime.PersistenceProvider.DeleteGlobalParameters(WorkflowRuntime.CodeActionsGlobalParameterName, name);
            }
            catch (Exception ex)
            {
                return new { Success = false, Message = ex.Message.Replace("\n", "<br/>") };
            }

            return new { Success = true };
        }

        private static CodeActionDefinition Decode(this CodeActionDefinition codeActionDefinition)
        {
#if !NETCOREAPP
            codeActionDefinition.ActionCode = HttpUtility.UrlDecode(codeActionDefinition.ActionCode);
            codeActionDefinition.Usings = HttpUtility.UrlDecode(codeActionDefinition.Usings);
#else
            codeActionDefinition.ActionCode = WebUtility.UrlDecode(codeActionDefinition.ActionCode);
            codeActionDefinition.Usings = WebUtility.UrlDecode(codeActionDefinition.Usings);
#endif
            return codeActionDefinition;
        }

        private static CodeActionDefinition Encode(this CodeActionDefinition codeActionDefinition)
        {
#if !NETCOREAPP
            codeActionDefinition.ActionCode = HttpUtility.UrlEncode(codeActionDefinition.ActionCode).Replace("+", "%20");
            codeActionDefinition.Usings = HttpUtility.UrlEncode(codeActionDefinition.Usings).Replace("+", "%20");
#else
            codeActionDefinition.ActionCode = WebUtility.UrlEncode(codeActionDefinition.ActionCode).Replace("+", "%20");
            codeActionDefinition.Usings = WebUtility.UrlEncode(codeActionDefinition.Usings).Replace("+", "%20");
#endif
            return codeActionDefinition;
        }

        private static bool WasEncoded(this CodeActionDefinition codeActionDefinition)
        {
            if (!string.IsNullOrEmpty(codeActionDefinition.Usings))
            {
                var oldUsings = codeActionDefinition.Usings;
#if !NETCOREAPP
                var newUsings = HttpUtility.UrlDecode(codeActionDefinition.Usings);
#else
                var newUsings = WebUtility.UrlDecode(codeActionDefinition.Usings);
#endif
                return oldUsings != newUsings;

            }

            var oldCode = codeActionDefinition.ActionCode;
#if !NETCOREAPP
            var newCode = HttpUtility.UrlDecode(codeActionDefinition.ActionCode);
#else
            var newCode = WebUtility.UrlDecode(codeActionDefinition.ActionCode);
#endif
            return oldCode != newCode;
        }

        #region BPMN
        private static string DownloadBPMN(WorkflowRuntime runtime, NameValueCollection form)
        {
            var pd = JsonConvert.DeserializeObject<ProcessDefinition>(form[RequestElements.data.ToString()]);
            pd.CodeActions.ForEach(ca => ca.Decode());

            var bpmnScheme = new Core.BPMN.Definition(pd);
            return bpmnScheme.Serialize();
        }

        private static string UploadBPMN(WorkflowRuntime runtime, Stream filestream, string processid, string schemeid)
        {
            ProcessDefinition pd;
            if (!string.IsNullOrWhiteSpace(processid) || !string.IsNullOrWhiteSpace(schemeid))
            {
                throw new Exception("The UploadSchemeBPMN is available by schemecode only!");
            }

            StreamReader reader = new StreamReader(filestream);
            var text = reader.ReadToEnd();

            var bpmnScheme = new Core.BPMN.Definition(text);

            pd = bpmnScheme.ConvertToComplexProcessDefinitions();
            InitializeAdditionalParams(runtime, pd);
            return JsonConvert.SerializeObject(pd);
        }
        #endregion
    }
}
