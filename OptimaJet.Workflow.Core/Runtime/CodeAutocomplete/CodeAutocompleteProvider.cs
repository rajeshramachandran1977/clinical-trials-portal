using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OptimaJet.Workflow.Core.Logging;
using static OptimaJet.Workflow.Core.TestTrace.TestTracer;

namespace OptimaJet.Workflow.Core.Runtime.CodeAutocomplete
{
    /// <summary>
    /// Aggregator, storage, entry point to <see cref="ICodeAutocompleter"></see> implementations
    /// </summary>
    public class CodeAutocompleteProvider : ICodeAutocompleteProvider
    {
        protected IEnumerable<ICodeAutocompleter> _autocompleters;
        protected readonly Func<ILogger> _getLogger;
        protected readonly bool _allowParallel;

        protected Action<Exception, string> Log => (e, message) =>
        {
            Trace("was error " + message);
            _getLogger?.Invoke()?.Error(e, message);
        };

        /// <summary>
        /// Prepare providers but not init; automatically add <see cref="DefaultAutocompleter"></see> if not supress
        /// </summary>
        /// <param name="allowParallel">parallel get and init methods for platforms that >= .net standard 2.0</param>
        /// <param name="autocompleters">custom autocompleters (not <see cref="DefaultAutocompleter"></see>!)</param>
        public CodeAutocompleteProvider(Func<ILogger> getLogger, bool allowParallel = true, bool supressAutoAddDefaultAutocompleter = false,
            params ICodeAutocompleter[] autocompleters)
        {
            _getLogger = getLogger;
            _allowParallel = allowParallel;

            if (autocompleters == null)
            {
                autocompleters = new ICodeAutocompleter[0];
                Trace("CodeAutocompleteProvider: ctor: fill null autocompleters");
            }

            if (!supressAutoAddDefaultAutocompleter && autocompleters.All(x => x.GetType() != typeof(DefaultAutocompleter)) == true)
            {
                Trace("CodeAutocompleteProvider: ctor: add default autocompleter");
                autocompleters = autocompleters.Concat(new ICodeAutocompleter[] { new DefaultAutocompleter(Log) }).ToArray();
            }

            IEnumerable<ICodeAutocompleter> enumerableAutocompleters = UseParallelOption(allowParallel, autocompleters);
            _autocompleters = enumerableAutocompleters;
        }

        /// <summary>
        /// Prepare <see cref="DefaultAutocompleter"></see> but not init
        /// </summary>
        /// <param name="logger"></param>
        public CodeAutocompleteProvider(Func<ILogger> logger) : this(logger, true)
        {

        }

        /// <summary>
        /// Prepare <see cref="DefaultAutocompleter"></see> and custom providers but not init
        /// </summary>
        /// <param name="logger"></param>
        public CodeAutocompleteProvider(Func<ILogger> logger, params ICodeAutocompleter[] autocompleters) : this(logger, true, false, autocompleters)
        {

        }

        /// <summary>
        /// Run task with <see cref="InitCodeAutocomletersThatNoInitialized"></see>
        /// </summary>
        public virtual void RunInitTask()
        {
            Task.Run(() =>
            {
                try
                {
                    InitCodeAutocomletersThatNoInitialized();
                }
                catch (Exception ex)
                {
                    Log(ex, "RunInitTask");
                }
            });
        }

        public virtual void InitCodeAutocomletersThatNoInitialized()
        {
            foreach (ICodeAutocompleter autocompeter in _autocompleters)
            {
                Trace("CodeAutocompleteProvider: Init: autocompleter " + autocompeter.AutocompleterName);
                try
                {
                    autocompeter.InitIfNotInitialized();
                }
                catch (Exception ex)
                {
                    Log(ex, autocompeter.AutocompleterName);
                }
            }

        }

        /// <summary>
        /// add code autocompleters but not init
        /// </summary>
        /// <param name="completers"></param>
        public virtual void RegisterCodeAutocompleters(params ICodeAutocompleter[] completers)
        {
            if (completers == null)
            {
                return;
            }

            _autocompleters = UseParallelOption(_allowParallel, _autocompleters.Concat(completers));
            Trace("AddCodeAutocompleters: completers added");
        }

        /// <summary>
        /// add variables to <see cref="DefaultAutocompleter"></see>. 
        /// If <see cref="DefaultAutocompleter"></see> is suppressed, nothing will happen. 
        /// If <see cref="DefaultAutocompleter"></see> is not initialized, init method will be called. 
        /// </summary>
        public virtual void AddVariablesToDefaultCompleterIfEnable(IEnumerable<AutocompleteVariable> variables)
        {
            ICodeAutocompleter autocompleter = _autocompleters
                .SingleOrDefault(x => x.AutocompleterName == DefaultAutocompleter.DefaultAutocompleterName);

            if (autocompleter == null)
            {
                return;
            }

            autocompleter.InitIfNotInitialized();

            autocompleter.AddVariables(variables);
        }

        /// <summary>
        /// add variables to <see cref="DefaultAutocompleter"></see>. 
        /// If <see cref="DefaultAutocompleter"></see> is suppressed, nothing will happen. 
        /// If <see cref="DefaultAutocompleter"></see> is not initialized, init method will be called. 
        /// </summary>
        public virtual void AddVariablesToDefaultCompleterIfEnable(string varName, Type varType)
        {
            AddVariablesToDefaultCompleterIfEnable(
                new[] {
                    new AutocompleteVariable { Name = varName, Type = varType.FullName }
                });
        }

        /// <summary>
        /// Get autocomplete from all autocompleters that are already initialized
        /// </summary>
        /// <param name="pattern">text for search (like "System.Thr")</param>
        /// <param name="usings">list of usings (like "System", "System.Threading")</param>
        /// <param name="variables">list of allow variables to autocomplete</param>
        public virtual HashSet<AutocompleteItem> Get(string pattern, IEnumerable<string> usings, IEnumerable<AutocompleteVariable> variables)
        {
            var result = new List<AutocompleteItem>();

            foreach (ICodeAutocompleter autocompeter in _autocompleters)
            {
                if (!autocompeter.Initialized)
                {
                    continue;
                }

                try
                {
                    result.AddRange(autocompeter.Get(pattern, usings, variables));
                }
                catch (Exception ex)
                {
                    Log(ex, autocompeter.AutocompleterName);
                }
            }

            return new HashSet<AutocompleteItem>(result);
        }

        protected virtual IEnumerable<ICodeAutocompleter> UseParallelOption(bool allowParallel, IEnumerable<ICodeAutocompleter> autocompleters)
        {
            IEnumerable<ICodeAutocompleter> enumerableAutocompleters = autocompleters.AsEnumerable();

#if !NETSTANDARD1_6
            if (allowParallel)
            {
                Trace("CodeAutocompleteProvider: UseParallelOption: allowParallel");
                enumerableAutocompleters = enumerableAutocompleters.AsParallel();
            }
#endif
            return enumerableAutocompleters;

        }
    }
}
