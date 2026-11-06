using System;
using OptimaJet.Workflow.Core.Runtime;

namespace OptimaJet.Workflow.Core.Model
{
    /// <summary>
    /// Represent an actor in a process scheme
    /// </summary>
    public  class ActorDefinition : BaseDefinition
    {
        private ActorDefinition()
        { }
        
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
        /// Rule name which is associated with the actor
        /// </summary>
        public string Rule { get; set; }

        /// <summary>
        /// Additional parameter which is passed to the appropriate methods <see cref="IWorkflowRuleProvider"/>
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Create ActorDefinition object
        /// </summary>
        /// <param name="name">Name of the actor</param>
        /// <param name="rule">Rule name which is associated with the actor</param>
        /// <param name="value">Additional parameter which is passed to the appropriate methods <see cref="IWorkflowRuleProvider"/></param>
        /// <returns>ActorDefinition object</returns>
        public static ActorDefinition Create(string name, string rule, string value)
        {
            return new ActorDefinition() {Name = name, Rule = rule, Value = value};
        }

        public new ActorDefinition Clone()
        {
            return base.Clone() as ActorDefinition;
        }

    }

    
}
