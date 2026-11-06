using System;
using System.Collections.Generic;

namespace OptimaJet.Workflow.Core.Runtime.CodeAutocomplete
{
    public interface ICodeAutocompleteProvider
    {
        /// <summary>
        /// add variables to <see cref="DefaultAutocompleter"></see>. 
        /// If <see cref="DefaultAutocompleter"></see> is suppressed, nothing will happen. 
        /// If <see cref="DefaultAutocompleter"></see> is not initialized, init method will be called. 
        /// </summary>
        void AddVariablesToDefaultCompleterIfEnable(IEnumerable<AutocompleteVariable> variables);
        /// <summary>
        /// add variables to <see cref="DefaultAutocompleter"></see>. 
        /// If <see cref="DefaultAutocompleter"></see> is suppressed, nothing will happen. 
        /// If <see cref="DefaultAutocompleter"></see> is not initialized, init method will be called. 
        /// </summary>
        void AddVariablesToDefaultCompleterIfEnable(string varName, Type varType);
        /// <summary>
        /// Get autocomplete from all autocompleters that are already initialized
        /// </summary>
        /// <param name="pattern">text for search (like "System.Thr")</param>
        /// <param name="usings">list of usings (like "System", "System.Threading")</param>
        /// <param name="variables">list of allow variables to autocomplete</param>
        HashSet<AutocompleteItem> Get(string pattern, IEnumerable<string> usings, IEnumerable<AutocompleteVariable> variables);
        void InitCodeAutocomletersThatNoInitialized();
        /// <summary>
        /// add code autocompleters but not init
        /// </summary>
        /// <param name="completers"></param>
        void RegisterCodeAutocompleters(params ICodeAutocompleter[] completers);

        /// <summary>
        /// Run task with <see cref="InitCodeAutocomletersThatNoInitialized"></see>
        /// </summary>
        void RunInitTask();
    }
}
