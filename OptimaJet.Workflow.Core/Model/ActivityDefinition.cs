using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OptimaJet.Workflow.Core.Runtime;

namespace OptimaJet.Workflow.Core.Model
{
    /// <summary>
    /// Represent an activity in a process scheme
    /// </summary>
    public class ActivityDefinition : BaseDefinition, IInlineActivity, IOrdinaryActivity
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
        /// The name of the inline activity instead of which the object was inlined last time.
        /// </summary>
        public string LastTimeInlineName { get; set; }
        /// <summary>
        /// The name of the inline activity instead of which the object was inlined first time.
        /// </summary>
        public string FirstTimeInlineName { get; set; }
        /// <summary>
        /// Return true if the object was inlined.
        /// </summary>
        public bool WasInlined { get; set; }
       
        /// <summary>
        /// Type of the activity. Ordinary or Inline.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ActivityType ActivityType { get; set; }
        
        /// <summary>
        /// Inlined scheme name for inline activity.
        /// </summary>
        public string SchemeCode { get; set; }
        
        /// <summary>
        /// Name of the state
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// If true specifies that the activity is initial. There can be only one initial activity in scheme. Initial activity is the entry point of the process.
        /// </summary>
        public bool IsInitial { get; set; }

        /// <summary>
        /// If true specifies that the activity is final. The process is marked as finalized after execution of the activity marked as final.
        /// </summary>
        public bool IsFinal { get; set; }

        /// <summary>
        /// If true specifies that the activity is entry point for a state and possible to set the state with the <see cref="State"/> name via <see cref="WorkflowRuntime.SetState"/> method
        /// </summary>
        public bool IsForSetState { get; set; }

        /// <summary>
        /// If true specifies that  if process scheme obsolete than Workflow Runtime will try upgrade it automatically if this activity is current
        /// </summary>
        public bool IsAutoSchemeUpdate { get; set; }

        /// <summary>
        /// Specifies that activity have an implementation
        /// </summary>
        public bool HaveImplementation => Implementation != null && Implementation.Count > 0;

        /// <summary>
        /// Specifies that activity have a pre-execution implementation
        /// </summary>
        public bool HavePreExecutionImplementation => PreExecutionImplementation != null && PreExecutionImplementation.Count > 0;

        /// <summary>
        /// List of <see cref="ActionDefinitionReference"/> which are executed at standard workflow execution
        /// </summary>
        public List<ActionDefinitionReference> Implementation { get; set; }

        /// <summary>
        /// List of <see cref="ActionDefinitionReference"/> which are executed at pre-execution
        /// </summary>
        public List<ActionDefinitionReference> PreExecutionImplementation { get; set; }

        /// <summary>
        /// A List of <see cref="Annotation"/> attached to this activity.
        /// </summary>
        public List<Annotation> Annotations { get; set; }

        /// <summary>
        /// Specifies that state is assigned
        /// </summary>
        public bool IsState => !string.IsNullOrEmpty(State);

        /// <summary>
        ///  Create ActivityDefinition object
        /// </summary>
        /// <param name="name">Name of the activity</param>
        /// <param name="stateName">Name of the state</param>
        /// <param name="isInitial">If true specifies that the activity is final. The process is marked as finalized after execution of the activity marked as final.</param>
        /// <param name="isFinal">If true specifies that the activity is final. The process is marked as finalized after execution of the activity marked as final.</param>
        /// <param name="isForSetState">If true specifies that the activity is entry point for a state and possible to set the state with the <see cref="State"/> name via <see cref="WorkflowRuntime.SetState"/> method</param>
        /// <param name="isAutoSchemeUpdate">If true specifies that  if process scheme obsolete than Workflow Runtime will try upgrade it automatically if this activity is current</param>
        /// <returns>ActivityDefinition object</returns>
        public static ActivityDefinition Create(string name, string stateName, string isInitial, string isFinal, string isForSetState,
            string isAutoSchemeUpdate)
        {
            return new ActivityDefinition()
            {
                ActivityType = ActivityType.Ordinary,
                IsFinal = !string.IsNullOrEmpty(isFinal) && bool.Parse(isFinal),
                IsInitial = !string.IsNullOrEmpty(isInitial) && bool.Parse(isInitial),
                IsForSetState = !string.IsNullOrEmpty(isForSetState) && bool.Parse(isForSetState),
                IsAutoSchemeUpdate = !string.IsNullOrEmpty(isAutoSchemeUpdate) && bool.Parse(isAutoSchemeUpdate),
                Name = name,
                State = stateName,
                Implementation = new List<ActionDefinitionReference>(),
                PreExecutionImplementation = new List<ActionDefinitionReference>(),
                Annotations = new List<Annotation>()
            };
        }

        /// <summary>
        ///  Create ActivityDefinition object
        /// </summary>
        /// <param name="name">Name of the activity</param>
        /// <param name="stateName">Name of the state</param>
        /// <param name="isInitial">If true specifies that the activity is final. The process is marked as finalized after execution of the activity marked as final.</param>
        /// <param name="isFinal">If true specifies that the activity is final. The process is marked as finalized after execution of the activity marked as final.</param>
        /// <param name="isForSetState">If true specifies that the activity is entry point for a state and possible to set the state with the <see cref="State"/> name via <see cref="WorkflowRuntime.SetState"/> method</param>
        /// <param name="isAutoSchemeUpdate">If true specifies that  if process scheme obsolete than Workflow Runtime will try upgrade it automatically if this activity is current</param>
        /// <returns>ActivityDefinition object</returns>
        public static ActivityDefinition Create(string name, string stateName, bool isInitial, bool isFinal, bool isForSetState, bool isAutoSchemeUpdate)
        {
            return new ActivityDefinition()
            {
                ActivityType = ActivityType.Ordinary,
                IsFinal = isFinal,
                IsInitial = isInitial,
                IsForSetState = isForSetState,
                IsAutoSchemeUpdate = isAutoSchemeUpdate,
                Name = name,
                State = stateName,
                Implementation = new List<ActionDefinitionReference>(),
                PreExecutionImplementation = new List<ActionDefinitionReference>(),
                Annotations = new List<Annotation>()
            };
        }

        /// <summary>
        /// Creates inline activity
        /// </summary>
        /// <param name="name"></param>
        /// <param name="schemeCode"></param>
        /// <returns></returns>
        public static ActivityDefinition CreateInlineActivity(string name, string schemeCode)
        {
            return new ActivityDefinition
            {
                ActivityType = ActivityType.Inline,
                Name = name,
                SchemeCode = schemeCode
            };
        }

        /// <summary>
        /// Add <see cref="ActionDefinitionReference"/> to implementation list
        /// </summary>
        /// <param name="action">Action reference</param>
        public void AddAction(ActionDefinitionReference action)
        {
            Implementation.Add(action);
        }

        /// <summary>
        /// Add <see cref="ActionDefinitionReference"/> to pre-execution implementation list
        /// </summary>
        /// <param name="action">Action reference</param>
        public void AddPreExecutionAction(ActionDefinitionReference action)
        {
            PreExecutionImplementation.Add(action);
        }

        /// <summary>
        /// Nesting level of subprocess, 0 - root process, 1-... -subprocesses, null - not assigned
        /// </summary>
        public int? NestingLevel { get; set; }

        public new ActivityDefinition Clone()
        {
            var newActivity = base.Clone() as ActivityDefinition;

            if (newActivity == null)
                throw new Exception("Cloning of ActivityDefinition fails");

            newActivity.Implementation = new List<ActionDefinitionReference>();
            Implementation?.ForEach(a => newActivity.Implementation.Add(a.Clone()));

            newActivity.PreExecutionImplementation = new List<ActionDefinitionReference>();
            PreExecutionImplementation?.ForEach(a => newActivity.PreExecutionImplementation.Add(a.Clone()));

            newActivity.Annotations = new List<Annotation>();
            Annotations?.ForEach(a => newActivity.Annotations.Add(a.Clone()));


            return newActivity;
        }

        #region Annotations

        /// <summary>
        /// Get an annotation attached to this activity
        /// </summary>
        /// <typeparam name="T">Annotation's type</typeparam>
        /// <param name="name">Annotation's name</param>
        /// <returns>Annotation value</returns>
        public T GetAnnotation<T>(string name)
        {
            return JsonConvert.DeserializeObject<T>(GetAnnotation(name));
        }

        /// <summary>
        /// Get a JSON representation of annotation's value
        /// </summary>
        /// <param name="name">Annotation's name</param>
        /// <returns>JSON representation of annotation's value</returns>
        public string GetAnnotation(string name)
        {
            return Annotations.FirstOrDefault(x => x.Name == name)?.JsonValue;
        }

        #endregion // Annotations

    }
}
