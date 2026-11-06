using System;
using System.Collections.Generic;

namespace OptimaJet.Workflow.Core.Runtime
{
    ///<summary>
    /// Represents parameters for creaition of an instance of a process
    /// </summary>
    public class CreateInstanceParams
    {
        /// <summary>
        /// Constructor of CreateInstanceParams class
        /// </summary>
        /// <param name="schemeCode">Code of the scheme</param>
        /// <param name="processId">Process id</param>
        public CreateInstanceParams(string schemeCode, Guid processId)
        {
            SchemeCode = schemeCode;
            ProcessId = processId;
        }

        /// <summary>
        /// Code of the scheme
        /// </summary>
        public string SchemeCode { get; set; }

        /// <summary>
        /// Process id
        /// </summary>
        public Guid ProcessId { get; set; }

        /// <summary>
        /// The user id which execute initial command if command is available
        /// </summary>
        public string IdentityId { get; set; }

        /// <summary>
        /// The user id for whom executes initial command if command is available
        /// </summary>
        public string ImpersonatedIdentityId { get; set; }

        /// <summary>
        /// The parameters for creating scheme of process (defining parameters)
        /// </summary>
        public IDictionary<string, object> SchemeCreationParameters { get; set; }

        /// <summary>
        /// Parameters to be passed to the process as the initial
        /// </summary>
        public IDictionary<string, object> InitialProcessParameters { get; set; }
        /// <summary>
        /// Tenant's identifier (if exist)
        /// </summary>
        public string TenantId { get; set; }
        /// <summary>
        /// Names of persist parameters in <see cref="InitialProcessParameters"></see>
        /// </summary>
        public List<string> Persist { get; set; }

        /// <summary>
        /// Add new persistent initial process parameter
        /// </summary>
        /// <param name="name">Parameter name</param>
        /// <param name="value">Parameter value</param>
        /// <returns></returns>
        public CreateInstanceParams AddPersistentParameter(string name, object value)
        {
            if (InitialProcessParameters == null)
                InitialProcessParameters = new Dictionary<string, object>();
            
            InitialProcessParameters.Add(name, value);
            
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
        public CreateInstanceParams AddTemporaryParameter(string name, object value)
        {
            if (InitialProcessParameters == null)
                InitialProcessParameters = new Dictionary<string, object>();
            
            InitialProcessParameters.Add(name, value);
            
            return this;
        }
    }
}
