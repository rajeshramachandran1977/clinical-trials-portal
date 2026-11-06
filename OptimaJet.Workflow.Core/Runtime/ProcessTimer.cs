using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimaJet.Workflow.Core.Runtime
{
    /// <summary>
    /// Timer of a process
    /// </summary>
    public class ProcessTimer
    {
        /// <summary>
        /// Timer name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Next execution time of this timer
        /// </summary>
        public DateTime NextExecutionDateTime { get; set; }
    }
}
