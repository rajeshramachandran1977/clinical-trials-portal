using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimaJet.Workflow.Core.Runtime
{
    /// <summary>
    /// Describes the way of handling <see cref="System.Threading.CancellationToken"> after activity execution.
    /// </summary>
    public enum CancellationTokenHandling
    {
        /// <summary>
        /// The state of <see cref="System.Threading.CancellationToken"> will be ignored
        /// </summary>
        Ignore = 0,
        /// <summary>
        /// If cancellation was requested <see cref="OperationCanceledException"> will be thrown.
        /// </summary>
        Throw
    }
}
