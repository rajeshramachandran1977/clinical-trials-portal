using System;
using System.Collections.Generic;
using static OptimaJet.Workflow.Core.TestTrace.TestTracer;

namespace OptimaJet.Workflow.Core.Runtime.CodeAutocomplete
{
    public class DefaultAutocompleter : ICodeAutocompleter
    {
        public string AutocompleterName => DefaultAutocompleterName;
        public bool Initialized { get; private set; } = false;

        private readonly object _rootChangeLock = new object();

        public static string DefaultAutocompleterName = "DefaultAutocompleter";

        private readonly ITypeSearcher _typeSearcher;
        private readonly Action<Exception, string> _log;
        private AutocompleteItem _root;

        public DefaultAutocompleter(Action<Exception, string> log)
            :this (log, new TypeSearcher())
        {
        }

        public DefaultAutocompleter(Action<Exception, string> log, ITypeSearcher typeSearcher)
        {
            _log = log;
            _typeSearcher = typeSearcher;
        }

        public HashSet<AutocompleteItem> Get(string pattern, IEnumerable<string> usings, IEnumerable<AutocompleteVariable> variables)
        {
            return _root.Get(pattern, usings, variables);
        }

        public void InitIfNotInitialized()
        {
            if (Initialized)
            {
                return;
            }

            lock (_rootChangeLock)
            {
                Trace("DefaultAutocompleter: Init: lock");

                if (Initialized)
                {
                    Trace("DefaultAutocompleter: Init: lock end");
                    return;
                }

                _typeSearcher.InitIfNotInitialized();

                Trace("DefaultAutocompleter: Init: type searcher init");

                _root = AutocompleteItem.MakeRootWithTypes(_log, _typeSearcher);

                Trace("DefaultAutocompleter: Init: lock end");

                Initialized = true;
            }

        }

        public void AddVariables(IEnumerable<AutocompleteVariable> variables)
        {
            lock (_rootChangeLock)
            {
                Trace("DefaultAutocompleter: AddVariables: lock");
                _root.AddVariablesIfNotExists(variables);
                Trace("DefaultAutocompleter: AddVariables: lock end");
            }
        }
    }
}
