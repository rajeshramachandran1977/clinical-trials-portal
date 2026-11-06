using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OptimaJet.Workflow.Core.Runtime;

namespace OptimaJet.Workflow.Core.Model
{
    /// <summary>
    /// Type of a code action which determine a area of use of a code action
    /// </summary>
    public enum CodeActionType
    {
        /// <summary>
        /// Code action uses like an action <see cref="IWorkflowActionProvider.ExecuteAction"/>
        /// </summary>
        Action,
        /// <summary>
        /// Code action uses like a condition <see cref="IWorkflowActionProvider.ExecuteCondition"/>
        /// </summary>
        Condition,
        /// <summary>
        /// Code action uses like users get method <see cref="IWorkflowRuleProvider.GetIdentities"/>
        /// </summary>
        RuleGet,
        /// <summary>
        /// Code action uses like check rule method <see cref="IWorkflowRuleProvider.Check"/>
        /// </summary>
        RuleCheck
    }

    /// <summary>
    /// Represent a code action in a process scheme
    /// </summary>
    public class CodeActionDefinition : BaseDefinition
    {
        /// <summary>
        /// If object was inlined, you can get its original name from this property
        /// </summary>
        public string OriginalName { get; set; }
        /// <summary>
        /// The code of the scheme to which the inlined object originally belonged.
        /// </summary>
        public string OriginalSchemeCode { get; set; }
        /// <summary>
        /// Return true if the object was inlined.
        /// </summary>
        public bool WasInlined { get; set; }
        /// <summary>
        /// Source code of the code action
        /// </summary>
        public string ActionCode { get; set; }

        /// <summary>
        /// Type of the code action <see cref="CodeActionType"/>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public CodeActionType Type { get; set; }

        /// <summary>
        /// If true specifies that the code action stored in global parameters but not in scheme. In this case code action is shared between schemes
        /// </summary>
        public bool IsGlobal { get; set; }

        /// <summary>
        /// If true the code action should be called asynchronously
        /// </summary>
        public bool IsAsync { get; set; }

        /// <summary>
        /// List of usings separated by ;
        /// </summary>
        public string Usings { get; set; }

        /// <summary>
        /// List of <see cref="CodeActionParameterDefinition"/> for this code action
        /// </summary>
        public List<CodeActionParameterDefinition> ParameterDefinitions { get; set; }

        /// <summary>
        /// Create CodeActionDefinition object
        /// </summary>
        /// <param name="name">Name of the code action</param>
        /// <param name="usings">List of usings separated by ;</param>
        /// <param name="actionCode">Source code of the code action</param>
        /// <param name="isglobal">If true specifies that the code action stored in global parameters but not in scheme. In this case code action is shared between schemes</param>
        /// <param name="type">Type of the code action <see cref="CodeActionType"/></param>
        /// <param name="isAsync">if true the code action should be called asynchronously</param>
        /// <param name="parameterDefinitions">List of <see cref="CodeActionParameterDefinition"/> for this code action</param>
        /// <returns>CodeActionDefinition object</returns>
        public static CodeActionDefinition Create(string name, string usings, string actionCode, string isglobal, string type, 
            string isAsync, List<CodeActionParameterDefinition> parameterDefinitions)
        {
            return new CodeActionDefinition()
            {
                ActionCode = actionCode,
                Name = name,
                Usings = usings,
                Type = string.IsNullOrEmpty(type) ? CodeActionType.Action : (CodeActionType)Enum.Parse(typeof(CodeActionType),type,true) ,
                IsGlobal = !string.IsNullOrEmpty(isglobal) && bool.Parse(isglobal),
                IsAsync = !string.IsNullOrEmpty(isAsync) && bool.Parse(isAsync),
                ParameterDefinitions = parameterDefinitions
            };
        }

        public new CodeActionDefinition Clone()
        {
            var newAction = base.Clone() as CodeActionDefinition;
            newAction.ParameterDefinitions = new List<CodeActionParameterDefinition>();
            ParameterDefinitions?.ForEach(a => newAction.ParameterDefinitions.Add(a.Clone()));

            return newAction;
        }
    }
}
