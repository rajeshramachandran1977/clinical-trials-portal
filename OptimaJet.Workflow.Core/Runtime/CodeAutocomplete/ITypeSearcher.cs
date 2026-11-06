using System;

namespace OptimaJet.Workflow.Core.Runtime.CodeAutocomplete
{
    public interface ITypeSearcher
    {
        void InitIfNotInitialized();
        Type GetByFullName(string fullName);
        Type[] GetAllTypes();
        bool Initialized { get; }
    }
}
