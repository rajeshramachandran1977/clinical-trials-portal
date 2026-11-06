using System;
using System.Linq;
using System.Threading.Tasks;
using OptimaJet.Workflow.Core.Model;
using OptimaJet.Workflow.Core.Persistence;
using OptimaJet.Workflow.Core.Runtime;

namespace OptimaJet.Workflow.Core.PredefinedActions
{
    /// <summary>
    /// Contains all predefined actions
    /// </summary>
    public static class PredefinedActions
    {
        /// <summary>
        /// Check that all subprocesses was completed
        /// </summary>
        /// <param name="processInstance"></param>
        /// <param name="runtime"></param>
        /// <returns>true - if there are no active suprocesses</returns>
        public static async Task<bool> CheckAllSubprocessesCompletedAsync(ProcessInstance processInstance, WorkflowRuntime runtime)
        {
            var processTree =  runtime.GetProcessInstancesTree(processInstance.ProcessId);

            if (processTree != null && processTree.Children.Any())
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Check that all subprocesses was completed
        /// </summary>
        /// <param name="processInstance"></param>
        /// <param name="runtime"></param>
        /// <returns></returns>
        public static bool CheckAllSubprocessesCompleted(ProcessInstance processInstance, WorkflowRuntime runtime)
        {
            return CheckAllSubprocessesCompletedAsync(processInstance, runtime).Result;
        }
    }
}