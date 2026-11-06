using System;
using System.Collections.Generic;

namespace OptimaJet.Workflow.Core.Runtime
{
    ///<summary>
    /// Represents parameters for creaition of an instance of a process
    /// </summary>
    public class SetStateParams
    {
        /// <summary>
        /// Constructor of CreateInstanceParams class
        /// </summary>
        /// <param name="stateName">State name to set forcibly</param>
        /// <param name="processId">Process id</param>
        public SetStateParams(Guid processId, string stateName)
        {
            StateName = stateName;
            ProcessId = processId;
        }
        /// <summary>
        /// Process id
        /// </summary>
        public Guid ProcessId { get; set; }
        /// <summary>
        /// The user id which execute operation
        /// </summary>
        public string IdentityId { get; set; }
        /// <summary>
        /// The user id for whom executes operation
        /// </summary>
        public string ImpersonatedIdentityId { get; set; }
        /// <summary>
        /// Code of the scheme
        /// </summary>
        public string StateName { get; set; }
        /// <summary>
        /// Actions due to transition process do not executed if true
        /// </summary>
        public bool PreventExecution { get; set; }
        /// <summary>
        /// Parameters to be passed to the process as the initial
        /// </summary>
        public IDictionary<string, object> ProcessParameters { get; set; }
        /// <summary>
        /// Names of persist parameters in <see cref="ProcessParameters"></see>
        /// </summary>
        public List<string> Persist { get; set; }
        /// <summary>
        /// Add new persistent initial process parameter
        /// </summary>
        /// <param name="name">Parameter name</param>
        /// <param name="value">Parameter value</param>
        /// <returns></returns>
        public SetStateParams AddPersistentParameter(string name, object value)
        {
            if (ProcessParameters == null)
                ProcessParameters = new Dictionary<string, object>();
            
            ProcessParameters.Add(name, value);
            
            if (Persist == null)
                Persist = new List<string>();
            
            Persist.Add(name);

            return this;
        }
        /// <summary>
        /// Add new temporary initial process parameter
        /// </summary>
        /// <param name="name">Parameter name</param>
        /// <param name="value">Parameter value</param>
        /// <returns></returns>
        public SetStateParams AddTemporaryParameter(string name, object value)
        {
            if (ProcessParameters == null)
                ProcessParameters = new Dictionary<string, object>();
            
            ProcessParameters.Add(name, value);
            
            return this;
        }
    }
}
