using System;

namespace OptimaJet.Workflow.Core.Fault
{
    public class ImpossibleToUpdateSchemeTagsException:Exception
    {
        public ImpossibleToUpdateSchemeTagsException(string schemeCode, string reason)
            :base($"Impossible to update tags on scheme {schemeCode}. Reason: {reason}")
        {
        }
    }
}
