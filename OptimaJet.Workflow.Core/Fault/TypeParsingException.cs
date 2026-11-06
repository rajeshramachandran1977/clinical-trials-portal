using System;

namespace OptimaJet.Workflow.Core.Fault
{
    public class TypeParsingException : Exception
    {
        public TypeParsingException(string message) : base(message)
        {}
        
        public TypeParsingException(string message, Exception ex) : base(message, ex)
        {}
    }
}