using OptimaJet.Workflow.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OptimaJet.Workflow.Core.Runtime
{
    /// <summary>
    /// Empty rule provider for system purpose
    /// </summary>
    public class EmptyWorkflowRuleProvider : IWorkflowRuleProvider
    {
        public List<string> GetRules(string schemeCode)
        {
            return new List<string>();
        }

        public bool Check(ProcessInstance processInstance, WorkflowRuntime runtime, string identityId, string ruleName, string parameter)
        {
            return false;
        }

        public IEnumerable<string> GetIdentities(ProcessInstance processInstance, WorkflowRuntime runtime, string ruleName, string parameter)
        {
            return new List<string>();
        }

        public Task<bool> CheckAsync(ProcessInstance processInstance, WorkflowRuntime runtime, string identityId, string ruleName, string parameter, CancellationToken token)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<string>> GetIdentitiesAsync(ProcessInstance processInstance, WorkflowRuntime runtime, string ruleName, string parameter, CancellationToken token)
        {
            throw new System.NotImplementedException();
        }

        public bool IsCheckAsync(string ruleName, string schemeCode)
        {
            return false;
        }

        public bool IsGetIdentitiesAsync(string ruleName, string schemeCode)
        {
            return false;
        }
    }
}
