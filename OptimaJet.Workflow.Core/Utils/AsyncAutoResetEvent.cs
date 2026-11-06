using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OptimaJet.Workflow.Core.Utils
{
    internal class AsyncAutoResetEvent
    {
        readonly LinkedList<TaskCompletionSource<bool>> _waiters = new LinkedList<TaskCompletionSource<bool>>();

        bool _isSignaled;

        public AsyncAutoResetEvent(bool signaled)
        {
            _isSignaled = signaled;
        }

        public Task<bool> WaitAsync(TimeSpan timeout)
        {
            return WaitAsync(timeout, CancellationToken.None);
        }

        public void Reset()
        {
            lock (_waiters)
            {
                _isSignaled = false;
                _waiters.Clear();
            }
        }

        public async Task<bool> WaitAsync(TimeSpan timeout, CancellationToken cancellationToken)
        {
            TaskCompletionSource<bool> tcs;

            lock (_waiters)
            {
                if (_isSignaled)
                {
                    _isSignaled = false;
                    return true;
                }

                if (timeout == TimeSpan.Zero)
                {
                    return _isSignaled;
                }

                tcs = new TaskCompletionSource<bool>();
                _waiters.AddLast(tcs);
            }

            Task winner = await Task.WhenAny(tcs.Task, Task.Delay(timeout, cancellationToken)).ConfigureAwait(false);
            if (winner == tcs.Task)
            {
                // The task was signaled.
                return true;
            }

            // We timed-out; remove our reference to the task.
            // This is an O(n) operation since waiters is a LinkedList<T>.
            lock (_waiters)
            {
                _waiters.Remove(tcs);
                return false;
            }
        }

        public void Set()
        {
            TaskCompletionSource<bool> toRelease = null;
            lock (_waiters)
            {
                if (_waiters.Count > 0)
                {
                    toRelease = _waiters.First.Value;
                    _waiters.RemoveFirst();
                }
                else if (!_isSignaled)
                {
                    // No tasks are pending
                    _isSignaled = true;
                }
            }
            
            toRelease?.SetResult(true);
        }

        public override string ToString()
        {
            return $"Signaled: {_isSignaled.ToString()}, Waiters: {_waiters.Count.ToString()}";
        }
    }
}