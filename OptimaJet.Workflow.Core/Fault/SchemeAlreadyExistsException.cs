using System;

namespace OptimaJet.Workflow.Core.Fault
{
    public class SchemeAlreadyExistsException : Exception
    {
        [Obsolete("Use SchemeAlredyExistsException.Create methods")]
        public SchemeAlreadyExistsException()
        {
        }

        private SchemeAlreadyExistsException(string message) : base(message)
        {
        }

        public static SchemeAlreadyExistsException Create(string code, SchemeLocation location, string definingParameters = null)
        {
            return !string.IsNullOrEmpty(definingParameters) && !definingParameters.Equals("{}")
                ? new SchemeAlreadyExistsException(string.Format("Scheme with the code = \"{0}\" already exists in {1}", code, location))
                : new SchemeAlreadyExistsException(string.Format("Scheme with the code = \"{0}\" parameters = \"{1}\" already exists in {2}", code, definingParameters, location));
        }
    }
}
