using System.Collections.Generic;

namespace OptimaJet.Workflow.Core.Runtime.CodeAutocomplete
{
    public interface ICodeAutocompleter
    {
        /// <summary>
        /// Get autocomplete from all autocompleters that yet initialized
        /// </summary>
        /// <param name="pattern">text for search (like "System.Thr")</param>
        /// <param name="usings">list of usings (like "System", "System.Threading")</param>
        /// <param name="variables">list of allow variables to autocomplete</param>
        HashSet<AutocompleteItem> Get(string pattern, IEnumerable<string> usings, IEnumerable<AutocompleteVariable> variables);
        /// <summary>
        /// Unique name
        /// </summary>
        string AutocompleterName { get; }
        void InitIfNotInitialized();
        void AddVariables(IEnumerable<AutocompleteVariable> variables);
        bool Initialized { get; }
    }
}
