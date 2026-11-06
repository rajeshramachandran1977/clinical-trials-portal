using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using OptimaJet.Workflow.Core.Model;

namespace OptimaJet.Workflow.Core.Runtime
{
    public class AggregatingRuleProvider : BaseAggregatingProvider<IWorkflowRuleProvider>, IWorkflowRuleProvider
    {
        public List<string> GetRules(string schemeCode)
        {
            var ruleNames = new List<string>();

            foreach (var serverActionsProvider in GetProviders(schemeCode))
            {
                ruleNames.AddRange(serverActionsProvider.GetRules(schemeCode));
            }

            return ruleNames.Distinct().ToList();
        }

        public bool Check(ProcessInstance processInstance, WorkflowRuntime runtime, string identityId, string ruleName, string parameter)
        {
            string schemeCodeForActionCall = processInstance.ProcessScheme.GetSchemeCodeForActionCall();
            
            if (IsCheckAsync(ruleName, schemeCodeForActionCall))
                throw new NotImplementedException($"Sync Check for rule {ruleName} is not implemented for scheme {schemeCodeForActionCall}");

            foreach (var provider in GetOrderedProviders(schemeCodeForActionCall))
            {
                if ((provider.GetRules(schemeCodeForActionCall).Contains(ruleName)) && (!provider.IsCheckAsync(ruleName, schemeCodeForActionCall)))
                    return provider.Check(processInstance, runtime, identityId, ruleName, parameter);
            }

            throw new NotImplementedException($"Sync Check for rule {ruleName} is not implemented for scheme {schemeCodeForActionCall}");
        }

        public virtual async Task<bool> CheckAsync(ProcessInstance processInstance, WorkflowRuntime runtime, string identityId, string ruleName,
            string parameter, CancellationToken token)
        {
            string schemeCodeForActionCall = processInstance.ProcessScheme.GetSchemeCodeForActionCall();
            
            if (!IsCheckAsync(ruleName, schemeCodeForActionCall))
                throw new NotImplementedException($"Async Check for rule {ruleName} is not implemented for scheme {schemeCodeForActionCall}");

            foreach (var provider in GetOrderedProviders(schemeCodeForActionCall))
            {
                if ((provider.GetRules(schemeCodeForActionCall).Contains(ruleName)) && (provider.IsCheckAsync(ruleName, schemeCodeForActionCall)))
                    return await provider.CheckAsync(processInstance, runtime, identityId, ruleName, parameter, token).ConfigureAwait(false);
            }

            throw new NotImplementedException($"Async Check for rule {ruleName} is not implemented for scheme {schemeCodeForActionCall}");
        }

        public IEnumerable<string> GetIdentities(ProcessInstance processInstance, WorkflowRuntime runtime, string ruleName, string parameter)
        {
            string schemeCodeForActionCall = processInstance.ProcessScheme.GetSchemeCodeForActionCall();
            
            if (IsGetIdentitiesAsync(ruleName, schemeCodeForActionCall))
                throw new NotImplementedException($"Sync GetIdentities for rule {ruleName} is not implemented for scheme {schemeCodeForActionCall}");

            foreach (var provider in GetOrderedProviders(schemeCodeForActionCall))
            {
                if ((provider.GetRules(schemeCodeForActionCall).Contains(ruleName)) && (!provider.IsGetIdentitiesAsync(ruleName, schemeCodeForActionCall)))
                    return provider.GetIdentities(processInstance, runtime, ruleName, parameter);
            }

            throw new NotImplementedException($"Sync GetIdentities for rule {ruleName} is not implemented for scheme {schemeCodeForActionCall}");
        }

        public virtual async Task<IEnumerable<string>> GetIdentitiesAsync(ProcessInstance processInstance, WorkflowRuntime runtime, string ruleName,
            string parameter, CancellationToken token)
        {
            string schemeCodeForActionCall = processInstance.ProcessScheme.GetSchemeCodeForActionCall();
            
            if (!IsGetIdentitiesAsync(ruleName, schemeCodeForActionCall))
                throw new NotImplementedException($"Async GetIdentities for rule {ruleName} is not implemented for scheme {schemeCodeForActionCall}");

            foreach (var provider in GetOrderedProviders(schemeCodeForActionCall))
            {
                if ((provider.GetRules(schemeCodeForActionCall).Contains(ruleName)) && (provider.IsGetIdentitiesAsync(ruleName, schemeCodeForActionCall)))
                {
                    return await provider.GetIdentitiesAsync(processInstance, runtime, ruleName, parameter, token).ConfigureAwait(false);
                }
            }

            throw new NotImplementedException($"Async GetIdentities with name {ruleName} is not implemented for scheme {schemeCodeForActionCall}");
        }

        public bool IsCheckAsync(string ruleName, string schemeCode)
        {
            foreach (var provider in GetOrderedProviders(schemeCode))
            {
                if (provider.GetRules(schemeCode).Contains(ruleName))
                    return provider.IsCheckAsync(ruleName, schemeCode);
            }

            throw new NotImplementedException($"Rule with name {ruleName} is not implemented for scheme {schemeCode}");
        }

        public bool IsGetIdentitiesAsync(string ruleName, string schemeCode)
        {
            foreach (var provider in GetOrderedProviders(schemeCode))
            {
                if (provider.GetRules(schemeCode).Contains(ruleName))
                    return provider.IsGetIdentitiesAsync(ruleName, schemeCode);
            }

            throw new NotImplementedException($"Rule with name {ruleName} is not implemented for scheme {schemeCode}");
        }
    }
}
