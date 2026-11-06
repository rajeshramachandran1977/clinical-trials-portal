using System;
using System.Threading;
using System.Threading.Tasks;
using OptimaJet.Workflow.Core.Fault;
using OptimaJet.Workflow.Core.Model;
using OptimaJet.Workflow.Core.Persistence;
using OptimaJet.Workflow.Core.Utils;

namespace OptimaJet.Workflow.Core.Runtime
{

    internal static class MultiThreadProcessExecutor
    {
        public static async Task Execute(WorkflowRuntime runtime, ProcessInstance processInstance, ProcessStatus status, TransitionDefinition executedTransition,
            Func<Task<bool>> needNewThreadCheck,Func<bool,Task> action)
        {
            var needDiffThread = await needNewThreadCheck.Invoke().ConfigureAwait(false);
            if (needDiffThread)
            {
                ExecuteOnDifferentThread(runtime, processInstance, status, executedTransition, action);
            }
            else
            {
                await action.Invoke(false).ConfigureAwait(false);
            }
        }

        private static async void ExecuteOnDifferentThread(WorkflowRuntime runtime, ProcessInstance processInstance, ProcessStatus status, TransitionDefinition executedTransition,
           Func<bool, Task> action)
        {
            try
            {
                await action.Invoke(true).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                runtime.InvokeOnWorkflowError(new WorkflowErrorEventArgs(processInstance, status, executedTransition, e));
            }
        }


    }

    public sealed class ProcessStatusWait : IDisposable
    {
        private bool _isDisposed;
        private readonly WorkflowRuntime _runtime;
        private readonly Guid _processToWaitId;
        private readonly Guid _calleeProcessId;
        private AsyncAutoResetEvent _handle = new AsyncAutoResetEvent(false);

        public ProcessStatusWait(WorkflowRuntime runtime, Guid processToWaitId, Guid calleeProcessId)
        {
            _runtime = runtime;
            _processToWaitId = processToWaitId;
            _calleeProcessId = calleeProcessId;
        }
        
        public Task<bool> LockOrStartWaiting()
        {
            return LockOrStartWaiting(TimeSpan.FromSeconds(30));
        }

        public Task<bool> LockOrStartWaiting(CancellationToken cancellationToken)
        {
            return LockOrStartWaiting(Timeout.InfiniteTimeSpan, cancellationToken);
        }

        public Task<bool> LockOrStartWaiting(TimeSpan timeout)
        {
            return LockOrStartWaiting(timeout, CancellationToken.None);
        }

        public async Task<bool> LockOrStartWaiting(TimeSpan timeout, CancellationToken cancellationToken)
        {
            return await LockOrStartWaitingInternal(timeout, cancellationToken,3).ConfigureAwait(false);
        }

        private async Task<bool> LockOrStartWaitingInternal(TimeSpan timeout, CancellationToken cancellationToken, int maxAttempts, int attemptNumber = 0)
        {
            _handle.Reset();
            
            try
            {
                #region Debug output
                //Console.WriteLine($"Try_Lock_FirstTime_[{_processToWaitId}]_by_[{_calleeProcessId}]_attempt{attemptNumber}");
                #endregion
                _runtime.PersistenceProvider.SetProcessStatus(_processToWaitId, ProcessStatus.Running);
                return true;
            }
            catch (ImpossibleToSetStatusException e)
            {
                #region Debug output
                //Console.WriteLine($"Failed_to_Lock_FirstHandled_[{_processToWaitId}]_by_[{_calleeProcessId}]_attempt{attemptNumber}");
                #endregion
                if (attemptNumber > maxAttempts)
                    return false;

                if (attemptNumber == 0)
                {
                    _runtime.ProcessStatusChanged += RuntimeProcessStatusChanged;

                    //try to get lock again
                    try
                    {
                        #region Debug output
                        //Console.WriteLine($"Try_Lock_SecondTime_[{_processToWaitId}]_by_[{_calleeProcessId}]_attempt{attemptNumber}");
                        #endregion
                        _runtime.PersistenceProvider.SetProcessStatus(_processToWaitId, ProcessStatus.Running);
                        return true;
                    }
                    catch (ImpossibleToSetStatusException)
                    {
                        #region Debug output
                        //Console.WriteLine($"Failed_to_Lock_SecondHandled_[{_processToWaitId}]_by_[{_calleeProcessId}]_attempt{attemptNumber}");
                        #endregion
                    }
                }

                var result = await _handle.WaitAsync(timeout, cancellationToken).ConfigureAwait(false);
                if (result)
                {
                    //try to get lock (it could be concurrency between 2 simultaneously merged subprocesses)
                    try
                    {
                        #region Debug output
                        //Console.WriteLine($"Try_Lock_ThirdTime_[{_processToWaitId}]_by_[{_calleeProcessId}]_attempt{attemptNumber}");
                        #endregion
                        _runtime.PersistenceProvider.SetProcessStatus(_processToWaitId, ProcessStatus.Running);
                        return true;
                    }
                    catch (ImpossibleToSetStatusException)
                    {
                        #region Debug output
                        //Console.WriteLine($"Failed_to_Lock_ThirdHandled_[{_processToWaitId}]_by_[{_calleeProcessId}]_attempt{attemptNumber}");
                        #endregion
                    }
                }

                return await LockOrStartWaitingInternal(timeout, cancellationToken, maxAttempts, attemptNumber + 1).ConfigureAwait(false);
            }
        }

        private void RuntimeProcessStatusChanged(object sender, ProcessStatusChangedEventArgs e)
        {
            #region Debug output
//            Console.WriteLine("____________________");
//            Console.WriteLine("ProcessStatusChanged_ExecutedFor_" + e.ProcessId.ToString());
//            Console.WriteLine("ProcessStatusChanged_WaitFor_" + _processToWaitId.ToString());
//            Console.WriteLine("Status_Is_" + e.NewStatus.Id);
//            Console.WriteLine("_____________________");
            #endregion
            
            if (e.ProcessId != _processToWaitId)
                return;
            
            if (!e.ProcessInstance.SyncSign)
            {
                if (e.NewStatus == ProcessStatus.Idled || e.NewStatus == ProcessStatus.Finalized)
                {
                    //the event handlers are executed consequentially so it is valid to set and check this property
                    e.ProcessInstance.SyncSign = true; 
                    #region Debug output
                    //Console.WriteLine("HandleSET_For_" + _calleeProcessId);
                    #endregion
                    _handle.Set();
                }
            }
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                _runtime.ProcessStatusChanged -= RuntimeProcessStatusChanged;
                _isDisposed = true;
                _handle.Reset();
                _handle = null;
            }
        }
    }
}