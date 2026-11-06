using System;
using OptimaJet.Workflow.Core.Model;

namespace OptimaJet.Workflow.Core.Runtime
{
    /// <summary>
    /// Represent information about an activity which was set as a current acivity of process, contains ProcessInstance object
    /// </summary>
    public class ProcessActivityChangedEventArgs
    {
        /// <summary>
        /// Id of the process whose current activity was changed
        /// </summary>
        public Guid ProcessId => ProcessInstance.ProcessId;

        /// <summary>
        /// If true means that the current activity was changed for subprocess
        /// </summary>
        public bool IsSubprocess => ProcessInstance.IsSubprocess;

        /// <summary>
        /// Code of the scheme of the process
        /// </summary>
        public string SchemeCode => ProcessInstance.ProcessScheme.Name;


        /// <summary>
        /// Instance of the process
        /// </summary>
        public ProcessInstance ProcessInstance { get; private set; }

        /// <summary>
        /// Returns the name of previous activity.
        /// </summary>
        public string PreviousActivityName => ProcessInstance.PreviousActivityName;

        /// <summary>
        /// Returns the previous activity.
        /// </summary>
        public ActivityDefinition PreviousActivity => !string.IsNullOrEmpty(ProcessInstance.PreviousActivityName) ? ProcessInstance.ProcessScheme.FindActivity(PreviousActivityName) : null;


        /// <summary>
        /// Returns the current activity. Activity which was final for last executed transition <see cref="TransitionDefinition.From"/>
        /// </summary>
        public ActivityDefinition CurrentActivity => ProcessInstance.CurrentActivity;


        /// <summary>
        /// Returns the name of current activity. Activity which was final for last executed transition <see cref="TransitionDefinition.From"/>
        /// </summary>
        public string CurrentActivityName => ProcessInstance.CurrentActivityName;

        /// <summary>
        /// Returns true if a state of process was changed
        /// </summary>
        public bool StateWasChanged => ProcessInstance.PreviousState != ProcessInstance.CurrentState;

        /// <summary>
        /// Indicates that a transitional process was completed and a process will stop in current activity
        /// </summary>
        public bool TransitionalProcessWasCompleted { get; private set; }

        /// <summary>
        /// Returns the name of the current state. State which was final for last executed transition <see cref="TransitionDefinition.From"/>
        /// </summary>
        public string CurrentState => ProcessInstance.CurrentState;

        /// <summary>
        /// Returns the name of the state  which was initial for last executed direct transition <see cref="TransitionDefinition.From"/>
        /// </summary>
        public string PreviousState => ProcessInstance.PreviousState;


        /// <summary>
        /// Returns the executed transition.
        /// </summary>
        public TransitionDefinition ExecutedTransition => ProcessInstance.ExecutedTransition;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="processInstance">Instance of the process</param>
        /// <param name="transitionalProcessWasCompleted">Indicates that a transitional process was completed and a process will stop in current activity</param>
        public ProcessActivityChangedEventArgs(ProcessInstance processInstance, bool transitionalProcessWasCompleted)
        {
            ProcessInstance = processInstance;
            TransitionalProcessWasCompleted = transitionalProcessWasCompleted;
        }
    }
}
