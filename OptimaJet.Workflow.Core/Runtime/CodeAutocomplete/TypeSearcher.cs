using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using static OptimaJet.Workflow.Core.TestTrace.TestTracer;

namespace OptimaJet.Workflow.Core.Runtime.CodeAutocomplete
{
    public class TypeSearcher : ITypeSearcher
    {
        private Dictionary<string, Type> _types = new Dictionary<string, Type>();
        private string[] _excludeNamespaces;

        public TypeSearcher()
        {
            _excludeNamespaces = GetDefaultExcludeNamespaces();
        }

        public Type GetByFullName(string fullName)
        {
            if (!_types.ContainsKey(fullName))
            {
                return null;
            }

            return _types[fullName];
        }

        public void SetExcludeNamespaces(IEnumerable<string> excludeNamespaces)
        {
            AssertOnlyBeforeInit();

            _excludeNamespaces = excludeNamespaces?.ToArray();
        }

        public void AddExcludeNamespaces(IEnumerable<string> excludeNamespaces)
        {
            AssertOnlyBeforeInit();

            if (excludeNamespaces == null || !excludeNamespaces.Any())
            {
                return;
            }

            _excludeNamespaces = _excludeNamespaces.Concat(excludeNamespaces).ToArray();
        }



        private readonly object _initLocker = new object();

        public bool Initialized { get; private set; } = false;

        public void InitIfNotInitialized()
        {
            if (Initialized)
            {
                return;
            }
            lock (_initLocker)
            {
                if (Initialized)
                {
                    return;
                }
                Trace("TypeSearcher: Init: lock");

                Assembly[] assemblies;
#if NETSTANDARD1_6
                assemblies = AppDomainNetCore.CurrentDomain.GetAssemblies();
#else
                assemblies = AppDomain.CurrentDomain.GetAssemblies();
#endif
                bool AssembliesFilter(Assembly assembly)
                {
                    string assemblyName = assembly?.GetName()?.Name?.ToLower();
                    if (String.IsNullOrEmpty(assemblyName))
                    {
                        return false;
                    }

                    //todo filter must be related by namespaces registered in the compiler
                    return assemblyName.Contains("optimajet") || assemblyName.Contains("mscorlib") || assemblyName.Contains("system.runtime") ||
                           assemblyName.Contains("system.net") || assemblyName.Contains("netstandard") || assemblyName.Contains("system.private.corelib")
                           || assemblyName.Contains("system.collections");
                }
                
                _types = new Dictionary<string, Type>();
                
                foreach (Assembly assembly in assemblies.Where(AssembliesFilter))
                {
                    var selectedTypes = assembly.GetTypes().Where(t => t.FullName != "System.SR")
                        .Where(t => t.Namespace != null)
                        .Where(t => t.Namespace.StartsWith("System") || t.Namespace.StartsWith("OptimaJet"))
                        .Where(t => !t.Name.StartsWith("<") && !t.Name.StartsWith("_"))
                        .Where(t => !(t.FullName.Contains("`") || t.FullName.Contains("+")))
                        /*without auxiliary */
                        .Where(t => _excludeNamespaces.All(nmspc => !t.Namespace.StartsWith(nmspc))) //exclude
                        /*only one*/
                        .GroupBy(t => t.FullName)
                        .Select(t => t.First())
                        /*only one*/
                        .ToDictionary(x => x.FullName, x => x);

                    foreach (KeyValuePair<string,Type> selectedType in selectedTypes)
                    {
                        _types[selectedType.Key] = selectedType.Value;
                    }
                }
                
                
                // _types = assemblies.Where(a=>AssembliesFilter(a))
                //                 .SelectMany(t => t.GetTypes())
                //                 /*without auxiliary */
                //                 .Where(t => t.FullName != "System.SR")
                //                 .Where(t => t.Namespace != null)
                //                 .Where(t => t.Namespace.StartsWith("System") || t.Namespace.StartsWith("OptimaJet"))
                //                 .Where(t => !t.Name.StartsWith("<") && !t.Name.StartsWith("_"))
                //                 .Where(t => !(t.FullName.Contains("`") || t.FullName.Contains("+")))
                //                 /*without auxiliary */
                //                 .Where(t => _excludeNamespaces.All(nmspc => !t.Namespace.StartsWith(nmspc))) //exclude
                //                  /*only one*/
                //                 .GroupBy(t => t.FullName)
                //                 .Select(t => t.First())
                //                 /*only one*/
                //                 .ToDictionary(x => x.FullName, x => x);
                Trace("TypeSearcher: Init: lock end");

                Initialized = true;
            }
        }

        public Type[] GetAllTypes()
        {
            return _types.Select(x => x.Value).ToArray();
        }

        private string[] GetDefaultExcludeNamespaces()
        {
            return new[] {
                "System.Web.UI",
                "System.Deployment",
                "System.Media",
                "System.CodeDom",
                "System.Windows",
                "System.Security.Cryptography",
                "System.Runtime",
                "System.ComponentModel",
            };
        }

        private void AssertOnlyBeforeInit()
        {
            if (Initialized)
            {
                throw new InvalidOperationException($"this method should be called only before initialize");
            }
        }
    }
}
