using System;

namespace OptimaJet.Workflow.Core.Fault
{
    public class ConfigurationException : Exception
    {
        public ConfigurationException(string message) : base(message) { }
    }
}