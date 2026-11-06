using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OptimaJet.Workflow.Core.Runtime;

namespace OptimaJet.Workflow.Core.Plugins
{
    public interface IWorkflowPlugin
    {
        string Name { get; }
        Dictionary<string,string> PluginSettings { get; }
        void OnPluginAdd(WorkflowRuntime runtime);
        void OnPluginRemove(WorkflowRuntime runtime);
    }
}
