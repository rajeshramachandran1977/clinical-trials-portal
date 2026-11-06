using System;
using System.Collections.Generic;

namespace OptimaJet.Workflow.Core.Fault
{
    public class ProcessSchemeBuildException : Exception
    {
        public List<string> BuildErrors;

        public string FailedStep;

        public ProcessSchemeBuildException(string schemeCode, List<string> buildErrors, string failedStep) : base(
            $"Can't build scheme {schemeCode}. {failedStep} build step was failed. See BuildErrors property for more details.")
        {
            BuildErrors = buildErrors;
            FailedStep = failedStep;
        }
    }
}