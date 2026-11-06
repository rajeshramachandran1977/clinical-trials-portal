using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using OptimaJet.Workflow.Core.Model;

namespace OptimaJet.Workflow.Core.Runtime
{
    public class AggregatingActionProvider : BaseAggregatingProvider<IWorkflowActionProvider>, IWorkflowActionProvider
    {
        public void ExecuteAction(string name, ProcessInstance processInstance, WorkflowRuntime runtime, string actionParameter)
        {
            string schemeCodeForActionCall = processInstance.ProcessScheme.GetSchemeCodeForActionCall();
            if (IsActionAsync(name, schemeCodeForActionCall))
                throw new NotImplementedException($"Sync action with name {name} is not implemented for scheme {schemeCodeForActionCall}");

            foreach (var provider in GetOrderedProviders(schemeCodeForActionCall))
            {
                if (provider.GetActions(schemeCodeForActionCall).Contains(name) && !provider.IsActionAsync(name,schemeCodeForActionCall))
                {
                    provider.ExecuteAction(name, processInstance, runtime, actionParameter);
                    return;
                }
            }

            throw new NotImplementedException($"Sync action with name {name} is not implemented for scheme {schemeCodeForActionCall}");
        }

        public async Task ExecuteActionAsync(string name, ProcessInstance processInstance, WorkflowRuntime runtime, string actionParameter, CancellationToken token)
        {
            string schemeCodeForActionCall = processInstance.ProcessScheme.GetSchemeCodeForActionCall();
            
            if (!IsActionAsync(name, schemeCodeForActionCall))
                throw new NotImplementedException($"Async action with name {name} is not implemented for scheme {schemeCodeForActionCall}");


            foreach (var provider in GetOrderedProviders(schemeCodeForActionCall))
            {
                if (provider.GetActions(schemeCodeForActionCall).Contains(name) && provider.IsActionAsync(name,schemeCodeForActionCall))
                {
                    await provider.ExecuteActionAsync(name, processInstance, runtime, actionParameter, token).ConfigureAwait(false);
                    return;
                }
            }

            throw new NotImplementedException($"Async action with name {name} is not implemented for scheme {schemeCodeForActionCall}");
        }

        public bool ExecuteCondition(string name, ProcessInstance processInstance, WorkflowRuntime runtime, string actionParameter)
        {
            string schemeCodeForActionCall = processInstance.ProcessScheme.GetSchemeCodeForActionCall();
            
            if (IsConditionAsync(name, schemeCodeForActionCall))
                throw new NotImplementedException($"Sync condition with name {name} is not implemented for scheme {schemeCodeForActionCall}");

            foreach (var provider in GetOrderedProviders(schemeCodeForActionCall))
            {
                if (provider.GetConditions(schemeCodeForActionCall).Contains(name) && !provider.IsConditionAsync(name, schemeCodeForActionCall))
                    return provider.ExecuteCondition(name, processInstance, runtime, actionParameter);
            }

            throw new NotImplementedException($"Sync condition with name {name} is not implemented for scheme {schemeCodeForActionCall}");
        }

        public async Task<bool> ExecuteConditionAsync(string name, ProcessInstance processInstance, WorkflowRuntime runtime, string actionParameter, CancellationToken token)
        {
            string schemeCodeForActionCall = processInstance.ProcessScheme.GetSchemeCodeForActionCall();
            
            if (!IsConditionAsync(name, schemeCodeForActionCall))
                throw new NotImplementedException($"Async condition with name {name} is not implemented for scheme {schemeCodeForActionCall}");

            foreach (var provider in GetOrderedProviders(schemeCodeForActionCall))
            {
                if (provider.GetConditions(schemeCodeForActionCall).Contains(name) && provider.IsConditionAsync(name, schemeCodeForActionCall))
                    return await provider.ExecuteConditionAsync(name, processInstance, runtime, actionParameter, token).ConfigureAwait(false);
            }

            throw new NotImplementedException($"Async condition with name {name} is not implemented for scheme {schemeCodeForActionCall}");
        }

        public bool IsActionAsync(string name, string schemeCode)
        {
            foreach (var provider in GetOrderedProviders(schemeCode))
            {
                if (provider.GetActions(schemeCode).Contains(name))
                    return provider.IsActionAsync(name, schemeCode);
            }

            throw new NotImplementedException($"Action with name {name} is not implemented for scheme {schemeCode}");
        }

        public bool IsConditionAsync(string name, string schemeCode)
        {
            foreach (var provider in GetOrderedProviders(schemeCode))
            {
                if (provider.GetConditions(schemeCode).Contains(name))
                    return provider.IsConditionAsync(name, schemeCode);
            }

            throw new NotImplementedException($"Condition with name {name} is not implemented for scheme {schemeCode}");
        }

        public List<string> GetActions(string schemeCode)
        {
            var actionNames = new List<string>();

            foreach (var serverActionsProvider in GetProviders(schemeCode))
            {
                actionNames.AddRange(serverActionsProvider.GetActions(schemeCode));
            }

            return actionNames.Distinct().ToList();
        }

        public List<string> GetConditions(string schemeCode)
        {
            var conditionNames = new List<string>();

            foreach (var serverActionsProvider in GetProviders(schemeCode))
            {
                conditionNames.AddRange(serverActionsProvider.GetConditions(schemeCode));
            }

            return conditionNames.Distinct().ToList();
        }
    }
}
