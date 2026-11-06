using System.Collections.Generic;
using OptimaJet.Workflow.Core.Runtime;

namespace OptimaJet.Workflow.Core.Model
{
    /// <summary>
    /// Defines the properties available for ordinary activity
    /// </summary>
    public interface IOrdinaryActivity
    {
        /// <summary>
        /// If object was inlined, you can get its original name from this property
        /// </summary>
        string OriginalName { get; set; }
        /// <summary>
        /// The code of the scheme to which the inlined object originally belonged.
        /// </summary>
        string OriginalSchemeCode { get; set; }
        /// <summary>
        /// The name of the inline activity instead of which the object was inlined.
        /// </summary>
        string LastTimeInlineName { get; set; }
        /// <summary>
        /// Return true if the object was inlined.
        /// </summary>
        bool WasInlined { get; set; }
     /// <summary>
        /// Name of the activity
        /// </summary>
        string Name { get; set; }
        
        /// <summary>
        /// Name of the state
        /// </summary>
        string State { get; set; }

        /// <summary>
        /// If true specifies that the activity is initial. There can be only one initial activity in scheme. Initial activity is the entry point of the process.
        /// </summary>
        bool IsInitial { get; set; }

        /// <summary>
        /// If true specifies that the activity is final. The process is marked as finalized after execution of the activity marked as final.
        /// </summary>
        bool IsFinal { get; set; }

        /// <summary>
        /// If true specifies that the activity is entry point for a state and possible to set the state with the <see cref="State"/> name via <see cref="WorkflowRuntime.SetState"/> method
        /// </summary>
        bool IsForSetState { get; set; }

        /// <summary>
        /// If true specifies that  if process scheme obsolete than Workflow Runtime will try upgrade it automatically if this activity is current
        /// </summary>
        bool IsAutoSchemeUpdate { get; set; }
        
        
        /// <summary>
        /// List of <see cref="ActionDefinitionReference"/> which are executed at standard workflow execution
        /// </summary>
        List<ActionDefinitionReference> Implementation { get; set; }

        /// <summary>
        /// List of <see cref="ActionDefinitionReference"/> which are executed at pre-execution
        /// </summary>
        List<ActionDefinitionReference> PreExecutionImplementation { get; set; }

        /// <summary>
        /// A List of <see cref="Annotation"/> attached to this activity.
        /// </summary>
        List<Annotation> Annotations { get; set; }

        /// <summary>
        /// Specifies that state is assigned
        /// </summary>
        bool IsState { get; }

        /// <summary>
        /// Specifies that activity have an implementation
        /// </summary>
        bool HaveImplementation { get; }
  
        /// <summary>
        /// Specifies that activity have a pre-execution implementation
        /// </summary>
        bool HavePreExecutionImplementation { get; }

    }
}