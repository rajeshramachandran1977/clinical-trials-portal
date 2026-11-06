#if NETCOREAPP
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyModel;

namespace OptimaJet.Workflow.Core
{
    public class AppDomainNetCore
    {
        public static AppDomainNetCore CurrentDomain { get; private set; }

        private ConcurrentDictionary<string, Assembly> _assemblies = new ConcurrentDictionary<string, Assembly>();
        private ConcurrentDictionary<string, byte> _notLoadedAssemblies = new ConcurrentDictionary<string, byte>();

        static AppDomainNetCore()
        {
            CurrentDomain = new AppDomainNetCore();
            var privateCoreLib = typeof(object).GetTypeInfo().Assembly;
            CurrentDomain._assemblies.AddOrUpdate(privateCoreLib.FullName, privateCoreLib, (s, a) => privateCoreLib);
            var mscorlib = Assembly.Load(new AssemblyName("mscorlib"));
            CurrentDomain._assemblies.AddOrUpdate(mscorlib.FullName, mscorlib, (s, a) => mscorlib);
            var workflowCoreLib = typeof(AppDomainNetCore).GetTypeInfo().Assembly;
            CurrentDomain._assemblies.AddOrUpdate(workflowCoreLib.FullName, workflowCoreLib, (s, a) => workflowCoreLib);
        }

        public Assembly[] GetAssemblies()
        {
            var dependencies = DependencyContext.Default.RuntimeLibraries;
            foreach (var library in dependencies)
            {
                var name = library.Name;
                if (!_assemblies.ContainsKey(name) && !_notLoadedAssemblies.ContainsKey(name))
                {
                    try
                    {
                        var assembly = Assembly.Load(new AssemblyName(library.Name));
                        _assemblies.AddOrUpdate(name, assembly, (s, a) => a);
                    }
                    catch (Exception)
                    {
                        _notLoadedAssemblies.AddOrUpdate(name, 0, (s, b) => 0);
                    }
                }
            }
            return _assemblies.Values.ToArray();
        }
    }
}
#endif
