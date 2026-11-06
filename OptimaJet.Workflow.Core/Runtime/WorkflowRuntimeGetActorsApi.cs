using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using OptimaJet.Workflow.Core.Fault;
using OptimaJet.Workflow.Core.Model;
using OptimaJet.Workflow.Core.Subprocess;

namespace OptimaJet.Workflow.Core.Runtime
{
    /// <summary>
    /// Workflow Runtime API extension for GetActors methods
    /// </summary>
    public static class WorkflowRuntimeGetActorsApi
    {
        #region Async API

        /// <summary>
        /// Get the list of user ids which can execute any command for specified process activity (async version)
        /// </summary>
        /// <param name="runtime">Workflow runtime instance</param>
        /// <param name="processId">Process id</param>
        /// <param name="beginningWithRoot">If true the list of actors will be obtained from the root process, even if you passed Id of the subprocess</param>
        /// <param name="activityName">Activity name in which transitions are checked. Current activity if null.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>List of user ids</returns>
        public static async Task<IEnumerable<string>> GetAllActorsForAllCommandTransitionsAsync(this WorkflowRuntime runtime, Guid processId,
            bool beginningWithRoot = false, string activityName = null, CancellationToken token = default)
        {
            return await GetAllActorsForCommandTransitionsAsync(runtime, processId, null, beginningWithRoot, activityName, token).ConfigureAwait(false);
        }

        /// <summary>
        /// Get the list of user ids which can execute any command bound with direct transitions (by transition classifier) for specified process activity (async version)
        /// </summary>
        /// <param name="runtime">Workflow runtime instance</param>
        /// <param name="processId">Process id</param>
        /// <param name="beginningWithRoot">If true the list of actors will be obtained from the root process, even if you passed Id of the subprocess</param>
        /// <param name="activityName">Activity name in which transitions are checked. Current activity if null.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>List of user ids</returns>
        public static async Task<IEnumerable<string>> GetAllActorsForDirectCommandTransitionsAsync(this WorkflowRuntime runtime, Guid processId,
            bool beginningWithRoot = false, string activityName = null, CancellationToken token = default)
        {
            return await GetAllActorsForCommandTransitionsAsync(runtime, processId, new List<TransitionClassifier> {TransitionClassifier.Direct},
                beginningWithRoot, activityName, token).ConfigureAwait(false);
        }

        /// <summary>
        /// Get the list of user ids which can execute any command bound whith direct or undefined transitions (by transition classifier) for specified process activity (async version)
        /// </summary>
        /// <param name="runtime">Workflow runtime instance</param>
        /// <param name="processId">Process id</param>
        /// <param name="beginningWithRoot">If true the list of actors will be obtained from the root process, even if you passed Id of the subprocess</param> 
        /// <param name="activityName">Activity name in which transitions are checked. Current activity if null.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>List of user ids</returns>
        public static async Task<IEnumerable<string>> GetAllActorsForDirectAndUndefinedCommandTransitionsAsync(this WorkflowRuntime runtime, Guid processId,
            bool beginningWithRoot = false, string activityName = null, CancellationToken token = default)
        {
            return await GetAllActorsForCommandTransitionsAsync(runtime, processId,
                    new List<TransitionClassifier> {TransitionClassifier.Direct, TransitionClassifier.NotSpecified}, beginningWithRoot, activityName, token)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Get the list of user ids which can execute any command bound whith reverse transitions (by transition classifier) for specified process activity (async version)
        /// </summary>
        /// <param name="runtime">Workflow runtime instance</param>
        /// <param name="processId">Process id</param>
        /// <param name="beginningWithRoot">If true the list of actors will be obtained from the root process, even if you passed Id of the subprocess</param>
        /// <param name="activityName">Activity name in which transitions are checked. Current activity if null.</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>List of user ids</returns>
        public static async Task<IEnumerable<string>> GetAllActorsForReverseCommandTransitionsAsync(this WorkflowRuntime runtime, Guid processId,
            bool beginningWithRoot = false,
            string activityName = null, CancellationToken token = default)
        {
            return await GetAllActorsForCommandTransitionsAsync(runtime, processId, new List<TransitionClassifier> {TransitionClassifier.Reverse},
                beginningWithRoot, activityName, token).ConfigureAwait(false);
        }

        /// <summary>
        /// Get the list of user ids which can execute any command bound whith a transitions selected by filter (by transition classifier) for specified process activity Async
        /// </summary>
        /// <param name="runtime">Workflow runtime instance</param>
        /// <param name="processId">Process id</param>
        /// <param name="classifiers">Filter for transitions by transition classifier</param>
        /// <param name="token">Cancellation token</param>
        /// <param name="beginningWithRoot">If true the list of actors will be obtained from the root process, even if you passed Id of the subprocess</param>
        /// <param name="activityName">Activity name in which transitions are checked. Current activity if null.</param>
        /// <returns>List of user ids</returns>
        public static async Task<IEnumerable<string>> GetAllActorsForCommandTransitionsAsync(this WorkflowRuntime runtime, Guid processId,
            List<TransitionClassifier> classifiers,
            bool beginningWithRoot = false, string activityName = null, CancellationToken token = default)
        {
            var processInstance = runtime.Builder.GetProcessInstance(processId);
            runtime.PersistenceProvider.FillSystemProcessParameters(processInstance);

            return await GetAllActorsForCommandTransitionsInternalAsync(runtime, processInstance, classifiers, beginningWithRoot, activityName, token)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Get the list of user ids which can execute any command bound whith a transitions selected by filter (by transition classifier)
        /// for executed activity (inside of a transitional process) or for current activity (when a process is idled). (async version)
        /// Using of this method is preferable for notification of users which can execute next commands.
        /// </summary>
        /// <param name="runtime">Workflow runtime instance</param>
        /// <param name="processInstance">Process instance</param>
        /// <param name="classifiers">Filter for transitions by transition classifier</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>List of user ids</returns>
        // ReSharper disable once MemberCanBePrivate.Global
        public static async Task<IEnumerable<string>> GetAllActorsForCommandTransitionsAsync(this WorkflowRuntime runtime, ProcessInstance processInstance,
            List<TransitionClassifier> classifiers = null, CancellationToken token = default)
        {
            return await GetAllActorsForCommandTransitionsInternalAsync(runtime, processInstance, classifiers, false,
                    processInstance.ExecutedActivity != null ? processInstance.ExecutedActivity.Name : processInstance.CurrentActivityName, token)
                .ConfigureAwait(false);
        }


        /// <summary>
        /// Get the list of user ids which can execute any command bound whith a transitions selected by filter. This method is prefearable to use when you are using subprocesses (async version)
        /// </summary>
        /// <param name="runtime">Workflow runtime instance</param>
        /// <param name="filter">Sets the current process and the method of searching in the Process Instances tree</param>
        /// <param name="classifiers">Filter for transitions by transition classifier</param>
        /// <param name="token">Cancellation token</param>
        /// <returns>List of user ids</returns>
        public static async Task<IEnumerable<string>> GetAllActorsForCommandTransitionsAsync(this WorkflowRuntime runtime, TreeSearchFilter filter,
            List<TransitionClassifier> classifiers = null,
            CancellationToken token = default)
        {
            var processInstance = filter.ProcessInstance;

            if (processInstance == null)
            {
                processInstance = runtime.Builder.GetProcessInstance(filter.ProcessId);
                runtime.PersistenceProvider.FillSystemProcessParameters(processInstance);
            }

            var result = new List<string>();

            var tree = runtime.GetProcessInstancesTree(processInstance);

            var transitionsToExclude = tree.Root.GetAllChildrenNames(); //Exclude all subpocess transitions

            var processInstancesCache = new Dictionary<Guid, ProcessInstance>() {{processInstance.ProcessId, processInstance}};

            var startPoint = tree.GetNodeById(processInstance.ProcessId);

            if (filter.StartFrom == TreeSearchStart.FromParent && processInstance.ParentProcessId.HasValue)
            {
                startPoint = tree.GetNodeById(processInstance.ParentProcessId.Value);
            }
            else if (filter.StartFrom == TreeSearchStart.FromRoot)
            {
                startPoint = tree.Root;
            }

            var searchProcessIds = new List<Guid>();

            if (filter.Include == TreeSearchInclude.AllUpIncludeStartPoint || filter.Include == TreeSearchInclude.AllUpExcludeWithoutStartPoint)
            {
                var current = startPoint;
                while (!current.IsRoot)
                {
                    current = current.Parent;
                    searchProcessIds.Add(current.Id);
                }
            }
            else if (filter.Include == TreeSearchInclude.AllDownIncludeStartPoint || filter.Include == TreeSearchInclude.AllDownExcludeStartPoint)
            {
                searchProcessIds = startPoint.GetAllChildrenIds();
            }

            if (filter.Include == TreeSearchInclude.OnlyStartPoint || filter.Include == TreeSearchInclude.AllUpIncludeStartPoint ||
                filter.Include == TreeSearchInclude.AllDownIncludeStartPoint)
            {
                result.AddRange(await GetAllActorsInternalAsync(runtime, startPoint.Id, processInstancesCache, null, classifiers, transitionsToExclude, token)
                    .ConfigureAwait(false));
            }

            foreach (var anotherId in searchProcessIds)
            {
                result.AddRange(await GetAllActorsInternalAsync(runtime, anotherId, processInstancesCache, null, classifiers, transitionsToExclude, token)
                    .ConfigureAwait(false));
            }

            return result.Distinct();
        }

        #endregion

        #region Sync API

        /// <summary>
        /// Get the list of user ids which can execute any command for specified process activity
        /// </summary>
        /// <param name="runtime">Workflow runtime instance</param>
        /// <param name="processId">Process id</param>
        /// <param name="beginningWithRoot">If true the list of actors will be obtained from the root process, even if you passed Id of the subprocess</param>
        /// <param name="activityName">Activity name in which transitions are checked. Current activity if null.</param>
        /// <returns>List of user ids</returns>
        public static IEnumerable<string> GetAllActorsForAllCommandTransitions(this WorkflowRuntime runtime, Guid processId, bool beginningWithRoot = false,
            string activityName = null)
        {
            return GetAllActorsForAllCommandTransitionsAsync(runtime, processId, beginningWithRoot, activityName).Result;
        }

        /// <summary>
        /// Get the list of user ids which can execute any command bound whith direct transitions (by transition classifier) for specified process activity
        /// </summary>
        /// <param name="runtime">Workflow runtime instance</param>
        /// <param name="processId">Process id</param>
        /// <param name="beginningWithRoot">If true the list of actors will be obtained from the root process, even if you passed Id of the subprocess</param>
        /// <param name="activityName">Activity name in which transitions are checked. Current activity if null.</param>
        /// <returns>List of user ids</returns>
        public static IEnumerable<string> GetAllActorsForDirectCommandTransitions(this WorkflowRuntime runtime, Guid processId, bool beginningWithRoot = false,
            string activityName = null)
        {
            return GetAllActorsForDirectCommandTransitionsAsync(runtime, processId, beginningWithRoot, activityName, CancellationToken.None).Result;
        }

        /// <summary>
        /// Get the list of user ids which can execute any command bound whith direct or undefined transitions (by transition classifier) for specified process activity
        /// </summary>
        /// <param name="runtime">Workflow runtime instance</param>
        /// <param name="processId">Process id</param>
        /// <param name="beginningWithRoot">If true the list of actors will be obtained from the root process, even if you passed Id of the subprocess</param> 
        /// <param name="activityName">Activity name in which transitions are checked. Current activity if null.</param>
        /// <returns>List of user ids</returns>
        public static IEnumerable<string> GetAllActorsForDirectAndUndefinedCommandTransitions(this WorkflowRuntime runtime, Guid processId,
            bool beginningWithRoot = false,
            string activityName = null)
        {
            return GetAllActorsForDirectAndUndefinedCommandTransitionsAsync(runtime, processId, beginningWithRoot, activityName).Result;
        }

        /// <summary>
        /// Get the list of user ids which can execute any command bound whith reverse transitions (by transition classifier) for specified process activity
        /// </summary>
        /// <param name="runtime">Workflow runtime instance</param>
        /// <param name="processId">Process id</param>
        /// <param name="beginningWithRoot">If true the list of actors will be obtained from the root process, even if you passed Id of the subprocess</param>
        /// <param name="activityName">Activity name in which transitions are checked. Current activity if null.</param>
        /// <returns>List of user ids</returns>
        public static IEnumerable<string> GetAllActorsForReverseCommandTransitions(this WorkflowRuntime runtime, Guid processId, bool beginningWithRoot = false,
            string activityName = null)
        {
            return GetAllActorsForReverseCommandTransitionsAsync(runtime, processId, beginningWithRoot, activityName).Result;
        }

        /// <summary>
        /// Get the list of user ids which can execute any command bound whith a transitions selected by filter (by transition classifier) for specified process activity
        /// </summary>
        /// <param name="runtime">Workflow runtime instance</param>
        /// <param name="processId">Process id</param>
        /// <param name="classifiers">Filter for transitions by transition classifier</param>
        /// <param name="beginningWithRoot">If true the list of actors will be obtained from the root process, even if you passed Id of the subprocess</param>
        /// <param name="activityName">Activity name in which transitions are checked. Current activity if null.</param>
        /// <returns>List of user ids</returns>
        public static IEnumerable<string> GetAllActorsForCommandTransitions(this WorkflowRuntime runtime, Guid processId,
            List<TransitionClassifier> classifiers, bool beginningWithRoot = false,
            string activityName = null)
        {
            return GetAllActorsForCommandTransitionsAsync(runtime, processId, classifiers, beginningWithRoot, activityName).Result;
        }

        /// <summary>
        /// Get the list of user ids which can execute any command bound whith a transitions selected by filter (by transition classifier)
        /// for executed activity (inside of a transitional process) or for current activity (when a process is idled).
        /// Using of this method is preferable for notification of users which can execute next commands.
        /// </summary>
        /// <param name="runtime">Workflow runtime instance</param>
        /// <param name="processInstance">Process instance</param>
        /// <param name="classifiers">Filter for transitions by transition classifier</param>
        /// <returns>List of user ids</returns>
        public static IEnumerable<string> GetAllActorsForCommandTransitions(this WorkflowRuntime runtime, ProcessInstance processInstance,
            List<TransitionClassifier> classifiers = null)
        {
            return GetAllActorsForCommandTransitionsAsync(runtime, processInstance, classifiers).Result;
        }

        /// <summary>
        /// Get the list of user ids which can execute any command bound whith a transitions selected by filter. This method is prefearable to use when you are using subprocesses
        /// </summary>
        /// <param name="runtime">Workflow runtime instance</param>
        /// <param name="filter">Sets the current process and the method of searching in the Process Instances tree</param>
        /// <param name="classifiers">Filter for transitions by transition classifier</param>
        /// <returns>List of user ids</returns>
        public static IEnumerable<string> GetAllActorsForCommandTransitions(this WorkflowRuntime runtime, TreeSearchFilter filter,
            List<TransitionClassifier> classifiers = null)
        {
            return GetAllActorsForCommandTransitionsAsync(runtime, filter, classifiers).Result;
        }

        #endregion

        #region Private

        private static async Task<IEnumerable<string>> GetAllActorsForCommandTransitionsInternalAsync(WorkflowRuntime runtime, ProcessInstance processInstance,
            List<TransitionClassifier> classifiers, bool beginningWithRoot, string activityName, CancellationToken token)
        {
            var result = new List<string>();

            var tree = runtime.GetProcessInstancesTree(processInstance);

            var childrenIds = beginningWithRoot ? tree.Root.GetAllChildrenIds() : tree.GetNodeById(processInstance.ProcessId).GetAllChildrenIds();
            if (beginningWithRoot)
                childrenIds.Add(processInstance.RootProcessId);
            var transitionsToExclude = tree.Root.GetAllChildrenNames();

            var activity = string.IsNullOrEmpty(activityName)
                ? processInstance.ProcessScheme.FindActivity(processInstance.CurrentActivityName)
                : processInstance.ProcessScheme.FindActivity(activityName);

            if (activity.NestingLevel == processInstance.ProcessScheme.InitialActivity.NestingLevel)
            {
                result.AddRange(await GetAllActorsForCommandTransitionsInternalAsync(runtime, processInstance, activity, classifiers, transitionsToExclude, token)
                    .ConfigureAwait(false));
            }

            childrenIds = childrenIds.Distinct().ToList();
            childrenIds.Remove(processInstance.ProcessId);


            foreach (var childId in childrenIds)
            {
                //GetAvailableCommands doesn't block main and children processes
                //A child might be removed during the process
                try
                {
                    result.AddRange(await GetAllActorsForCommandTransitionsAsync(runtime, activityName, classifiers, childId, transitionsToExclude, token)
                        .ConfigureAwait(false));
                }
                catch (ProcessNotFoundException)
                {
                }
            }

            return result.Distinct();
        }

        private static async Task<List<string>> GetAllActorsInternalAsync(WorkflowRuntime runtime, Guid processId, Dictionary<Guid, ProcessInstance> cache,
            string specificActivityName,
            List<TransitionClassifier> classifiers, List<string> transitionsToExclude, CancellationToken token)
        {
            ProcessInstance processInstance;
            if (!cache.ContainsKey(processId))
            {
                processInstance = runtime.Builder.GetProcessInstance(processId);
                runtime.PersistenceProvider.FillSystemProcessParameters(processInstance);
                cache.Add(processId, processInstance);
            }
            else
            {
                processInstance = cache[processId];
            }

            var activityToSearch = processInstance.ExecutedActivity ?? processInstance.CurrentActivity;

            if (!string.IsNullOrEmpty(specificActivityName))
            {
                ActivityDefinition newActivityToSearch = null;

                try
                {
                    newActivityToSearch = processInstance.ProcessScheme.FindActivity(specificActivityName);
                }
                catch (ActivityNotFoundException)
                {
                }

                if (newActivityToSearch != null && newActivityToSearch.NestingLevel == processInstance.ProcessScheme.InitialActivity.NestingLevel)
                {
                    activityToSearch = newActivityToSearch;
                }
            }

            return await GetAllActorsForCommandTransitionsInternalAsync(runtime, processInstance, activityToSearch, classifiers, transitionsToExclude, token)
                .ConfigureAwait(false);

        }

        private static async Task<List<string>> GetAllActorsForCommandTransitionsAsync(WorkflowRuntime runtime, string activityName,
            List<TransitionClassifier> classifiers, Guid childId,
            List<string> transitionsToExclude, CancellationToken token)
        {
            var childProcess = runtime.Builder.GetProcessInstance(childId);
            runtime.PersistenceProvider.FillSystemProcessParameters(childProcess);

            var childProcessActivity = string.IsNullOrEmpty(activityName)
                ? childProcess.ProcessScheme.FindActivity(childProcess.CurrentActivityName)
                : childProcess.ProcessScheme.FindActivity(activityName);

            if (childProcessActivity.NestingLevel == childProcess.ProcessScheme.InitialActivity.NestingLevel)
            {
                return await GetAllActorsForCommandTransitionsInternalAsync(runtime, childProcess, childProcessActivity, classifiers, transitionsToExclude, token)
                    .ConfigureAwait(false);
            }

            return new List<string>(0);
        }

        private static async Task<List<string>> GetAllActorsForCommandTransitionsInternalAsync(WorkflowRuntime runtime, ProcessInstance processInstance,
            ActivityDefinition selectedActivity,
            List<TransitionClassifier> classifiers, List<string> transitionsToExclude, CancellationToken token)
        {
            var result = new List<string>();
            runtime.PersistenceProvider.FillPersistedProcessParameters(processInstance);

            var commandTransitions =
                processInstance.ProcessScheme.GetCommandTransitions(selectedActivity)
                    .Where(
                        ct =>
                            (classifiers == null || classifiers.Contains(ct.Classifier)) &&
                            !transitionsToExclude.Contains(ct.Name))
                    .ToList();

            foreach (var ct in commandTransitions)
            {
                result.AddRange(await runtime.GetActorsAsync(processInstance, ct, token).ConfigureAwait(false));
            }

            return result;
        }

        #endregion
    }
}
