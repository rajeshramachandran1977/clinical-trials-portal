using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using static OptimaJet.Workflow.Core.TestTrace.TestTracer;

namespace OptimaJet.Workflow.Core.Runtime.CodeAutocomplete
{
    /// <summary>
    /// Autocomplete code suggestion item
    /// </summary>
    public class AutocompleteItem: IEquatable<AutocompleteItem>
    {
        private readonly Action<Exception, string> _log;
        private readonly ITypeSearcher _typeSearcher;
        private string _fullName;

        #region data
        /// <summary>
        /// namespace or class or ...
        /// </summary>
        [JsonProperty("kind")]
        public virtual AutocompleteKind Kind { get; set; }
        /// <summary>
        /// name with namespace (like "System.Console")
        /// </summary>
        [JsonProperty("fullName")]
        public virtual string FullName
        {
            get => _fullName;
            set
            {
                _fullName = value;
                Name = value?.Split('.')?.LastOrDefault() ?? "";
            }
        }
        /// <summary>
        /// name without namespace (like "Console")
        /// </summary>
        [JsonProperty("name")]
        public virtual string Name { get; protected set; }
        /// <summary>
        /// Return type. Can be null (for namespace or class or other)
        /// </summary>
        [JsonProperty("type")]
        public virtual string Type { get; protected set; }
        /// <summary>
        /// Childs. Classes and children namespaces for namespace, members for classes, etc
        /// </summary>
        [JsonProperty("childs")]
        public virtual List<AutocompleteItem> Childs { get; protected set; } = new List<AutocompleteItem>();
        /// <summary>
        /// overrides of method parameters (not null or empty only for methods.
        /// </summary>
        [JsonProperty("parameters")]
        public virtual List<List<AutocompleteItem>> Parameters { get; protected set; }
        #endregion data

        #region constructors
        public AutocompleteItem(AutocompleteKind kind, Action<Exception, string> log, ITypeSearcher typeSearcher)
        {
            Kind = kind;
            _log = log;
            _typeSearcher = typeSearcher;
        }

        public static AutocompleteItem MakeRootWithTypes(Action<Exception, string> log, ITypeSearcher typeSearcher)
        {
            var root = new AutocompleteItem(AutocompleteKind.Root, log, typeSearcher);

            foreach(Type t in typeSearcher.GetAllTypes()
                .Where(x=>x?.FullName!=null)
                .OrderBy(x=>x.FullName))
            {
                Trace($"AutocompleteItem: MakeRootWithTypes: {t.FullName}");

                try
                {
                    root.AddType(t);
                }
                catch (Exception ex)
                {
                    root._log(ex, t?.FullName);
                }
            }

            return root;
        }

        #endregion

        #region count
        public int GetCount()
        {
            return Childs == null || Childs.Count == 0
                ? 1
                : 1 + Childs.Sum(x => x.GetCount()); 
        }
        #endregion count

        #region toString
        public override string ToString()
        {
            return $"{Kind} {FullName}";
        }
        #endregion toString

        #region instance
        public void AddInstance(string instanceName, Type t)
        {
            try
            {
                var instance = new AutocompleteItem(AutocompleteKind.FrameworkVariable, _log, _typeSearcher)
                {
                    Type = t.Name,
                    FullName = instanceName,
                };
                instance.AddInstanceMembers(t, instanceName);

                Childs.Add(instance);
            }
            catch (Exception ex)
            {
                _log(ex, nameof(AddInstance));
            }
        }
        #endregion instance

        #region get

        public HashSet<AutocompleteItem> Get(string pattern, IEnumerable<string> usings, IEnumerable<AutocompleteVariable> variables)
        {
            if (variables == null)
            {
                variables = new AutocompleteVariable[0];
                Trace("AutocompleteItem: Get: variables was null");
            }

            AddVariablesIfNotExists(variables);

            if (String.IsNullOrWhiteSpace(pattern))
            {
                pattern = "";
                Trace("AutocompleteItem: Get: pattern set empty");
            }

            usings = AddRootUsing(usings);

            IEnumerable<string> patternsCombine = usings.Select(u => JoinNames(u, pattern));

            IEnumerable<string[]> patterns = patternsCombine.Select(x => x.Split('.'));

            HashSet<AutocompleteItem> searchResult = Search(patterns, variables);

            return searchResult;
        }

        protected readonly object _addVariablesLock = new object();
        public void AddVariablesIfNotExists(IEnumerable<AutocompleteVariable> variables)
        {
            if (variables == null || !Childs.Any(c => variables.All(v => v.Name != c.Name)))
            {
                return;
            }

            lock (_addVariablesLock)
            {
                foreach (AutocompleteVariable var in variables.Where(v => v!=null && Childs.All(c => c.Name != v.Name)))
                {
                    Type type = _typeSearcher.GetByFullName(var.Type);
                    if (type == null)
                    {
                        //_log(new Exception("Autocomplete: not found type " + var.Type), var.Name);
                        continue;
                    }

                    AddInstance(var.Name, type);
                }
            }
        }

        protected IEnumerable<string> AddRootUsing(IEnumerable<string> usings)
        {
            if (usings == null || !usings.Any())
            {
                usings = new[] { "" };
            }
            else
            {
                usings = usings.Union(new[] { "" });
            }

            Trace("AutocompleteItem: AddRootUsings");

            return usings;
        }

        protected HashSet<AutocompleteItem> Search(IEnumerable<string[]> patterns, IEnumerable<AutocompleteVariable> allowVariables)
        {
            var childrenSet = new HashSet<AutocompleteItem>();

            foreach (string[] pattern in patterns)
            {
                string p = pattern[0];
                Trace("AutocompleteItem: Search: "+p);

                IEnumerable<AutocompleteItem> childs = pattern.Length == 1
                    ? ProcessLastPattern(p, allowVariables)
                    : Childs
                        .Where(x => x.Name == p)
                        .SelectMany(x => x
                            .Search(new[] { pattern.Skip(1)
                                                   .ToArray() }, null));

                childs.ToList()
                    .ForEach(c => childrenSet.Add(c));
            }

            return childrenSet;
        }

        protected IEnumerable<AutocompleteItem> ProcessLastPattern(string p, IEnumerable<AutocompleteVariable> allowVariables)
        {
            Trace("AutocompleteItem: ProcessLastPattern: " + p);

            IEnumerable<AutocompleteItem> childs;
            if (String.IsNullOrEmpty(p))
            {
                childs = Childs.Select(x => x.MakeFieldsCopy());
            }
            else
            {
                IEnumerable<AutocompleteItem> patternChilds = Childs
                    .Where(x => String.Equals(x.Name, p, StringComparison.CurrentCultureIgnoreCase));

                if (!patternChilds.Any())
                {
                    Trace("AutocompleteItem: ProcessLastPattern: not found pattern childs");
                    patternChilds = Childs
                        .Where(x => x.Name.StartsWith(p, StringComparison.CurrentCultureIgnoreCase));
                }

                childs = patternChilds.Select(x => x.MakeFieldsCopy());
            }

            if (allowVariables != null)
            {
                Trace("AutocompleteItem: ProcessLastPattern: allow variables is not null");
                childs = childs.Where(c => c.Kind != AutocompleteKind.FrameworkVariable
                                            || allowVariables.Any(v => v.Name == c.Name));
            }

            return childs;
        }

        protected AutocompleteItem MakeFieldsCopy()
        {
            return new AutocompleteItem(Kind, null, null)
            {
                FullName = FullName,
                Type = Type,
                Parameters = Parameters,
            };
        }

        public static string JoinNames(params string[] parts)
        {
            string res = "";
            for (int i = 0; i < parts.Length; i++)
            {
                string p = parts[i];
                bool last = i == parts.Length - 1;

                if (String.IsNullOrWhiteSpace(p))
                {
                    if (last)//skip in other cases
                    {
                        if (res == "")
                        {
                            return res;
                        }
                        return res + ".";
                    }
                }
                else
                {
                    if (res == "")
                    {
                        res = p;
                    }
                    else
                    {
                        res += "." + p;
                    }
                }
                Trace("AutocompleteItem: JoinNames: " + res);
            }

            return res;
        }

        #endregion get

        #region namespaces

        protected AutocompleteItem AddChildNamespaces(string @namespace)
        {
            string[] parts = @namespace.Split('.');
            return AddChildNamespaces(null, parts);
        }

        protected AutocompleteItem AddChildNamespaces(string prev, string[] parts)
        {
            string first = parts[0];

            AutocompleteItem child = SearchOrAddNamespacePart(prev, first);

            if (parts.Length == 1)
            {
                return child;
            }

            return child.AddChildNamespaces(JoinNames(prev, first), parts.Skip(1).ToArray());
        }

        protected AutocompleteItem SearchOrAddNamespacePart(string prev, string val)
        {
            if (GetNamespacePart(val) == null)
            {
                Childs.Add(MakeNamespacePart(prev, val));
            }
            return GetNamespacePart(val);
        }

        protected AutocompleteItem[] ChildsNamespaceParts => Childs.Where(x => x.Kind == AutocompleteKind.Namespace).ToArray();
        protected AutocompleteItem GetNamespacePart(string name)
        {
            return ChildsNamespaceParts.SingleOrDefault(x => x.Name == name);
        }

        protected AutocompleteItem MakeNamespacePart(string prev, string val)
        {
            return new AutocompleteItem(Kind = AutocompleteKind.Namespace, _log, _typeSearcher)
            {
                FullName = JoinNames(prev, val)
            };
        }
        #endregion namespaces

        #region types
        public void AddType(Type t)
        {
            AutocompleteItem @namespace = AddChildNamespaces(t.Namespace);
            AutocompleteItem type = @namespace.AddTypeWithoutMembers(t);
            type.AddStaticMembers(t);
        }
        protected AutocompleteItem AddTypeWithoutMembers(Type t)
        {
            bool isClass = false;
#if NETSTANDARD1_6
            isClass = t.GetTypeInfo().IsClass;
#else
            isClass = t.IsClass;
#endif

            var type = new AutocompleteItem(isClass ? AutocompleteKind.Class : AutocompleteKind.Struct, _log, _typeSearcher)
            {
                FullName = t.FullName,
            };

            Childs.Add(type);

            return type;
        }

        protected void AddStaticMembers(Type t)
        {
            AddMembers(t, isStatic: true, variableName: null);
        }

        protected void AddInstanceMembers(Type t, string varName)
        {
            AddMembers(t, isStatic: false, variableName: varName);
        }

        protected void AddMembers(Type t, bool isStatic, string variableName)
        {
            Assert();

            BindingFlags flag = isStatic 
                ? BindingFlags.Static 
                : BindingFlags.Instance;

            flag |= BindingFlags.FlattenHierarchy | BindingFlags.Public;

            AddProperties(t, flag, GetName);
            AddMethodsAndEvents(t, flag, GetName);
            AddFields(t, flag, GetName);

            string GetName(string name)
            {
                if (isStatic)
                {
                    return JoinNames(t.FullName, name);
                }
                else
                {
                    return JoinNames(variableName, name);
                }
            }

            void Assert()
            {
                if (isStatic && variableName != null)
                {
                    throw new ArgumentException($"if {nameof(isStatic)} then {nameof(variableName)} should be null");
                }

                if (!isStatic && String.IsNullOrWhiteSpace(variableName))
                {
                    throw new ArgumentException($"if not {nameof(isStatic)} then {nameof(variableName)} should be filled");
                }
            }
        }

        protected void AddFields(Type t, BindingFlags flag, Func<string, string> getName)
        {
            FieldInfo[] fieldInfos = t.GetFields(flag);

            foreach (FieldInfo fi in fieldInfos)
            {
                bool isConst = fi.IsLiteral && !fi.IsInitOnly;

                Childs.Add(new AutocompleteItem(isConst 
                    ? AutocompleteKind.Const 
                    : AutocompleteKind.Field, 
                    _log, _typeSearcher)
                {
                    FullName = getName(fi.Name),
                    Type = fi.FieldType.Name,
                });

            }
        }

        protected void AddProperties(Type t,
           BindingFlags flag,
           Func<string, string> getName)
        {
            PropertyInfo[] properties = t.GetProperties(flag);

            foreach (PropertyInfo property in properties)
            {
                MethodInfo get = property.GetMethod;
                MethodInfo set = property.SetMethod;

                if (get == null)
                {
                    continue;
                }

                Childs.Add(new AutocompleteItem(AutocompleteKind.Property, _log, _typeSearcher)
                {
                    Type = property.PropertyType.Name,
                    FullName = getName(property.Name),
                });
            }
        }

        protected void AddMethodsAndEvents(Type t,
            BindingFlags flag,
            Func<string, string> getName)
        {
            var methods = new List<MethodInfo>();

            MethodInfo[] tMethods = t.GetMethods(flag);
            EventInfo[] tEvents = t.GetEvents(flag);

            AddMethods(getName, tMethods.Where(m=>!m.IsSpecialName).ToList());
            AddEvents(getName, tEvents);

        }

        private void AddEvents(Func<string, string> getName, EventInfo[] tEvents)
        {
            foreach(EventInfo @event in tEvents)
            {
                Childs.Add(new AutocompleteItem(AutocompleteKind.Event, _log, _typeSearcher)
                {
                    FullName = getName(@event.Name),
                    Type = @event.EventHandlerType.Name,
                });
            }
        }

        private void AddMethods(Func<string, string> getName, List<MethodInfo> methods)
        {
            foreach (IGrouping<string, MethodInfo> group in methods.GroupBy(x => x.Name))
            {
                List<List<AutocompleteItem>> parameters = ProcessMethodOverrides(group);

                MethodInfo method = group.First();

                Childs.Add(new AutocompleteItem(AutocompleteKind.Method, _log, _typeSearcher)
                {
                    Type = method.ReturnType.Name,
                    Parameters = parameters,
                    FullName = getName(method.Name),
                });
            }
        }

        private List<List<AutocompleteItem>> ProcessMethodOverrides(IEnumerable<MethodInfo> group)
        {
            return group.Select(x => x
                .GetParameters()
                    .Select(par => new AutocompleteItem(AutocompleteKind.Parameter, _log, _typeSearcher)
                    {
                        Type = par.ParameterType.Name,
                        FullName = par.Name
                    })
                    .ToList())
                .ToList();
        }

        private void ProcessEvent(HashSet<AutocompleteItem> events, Func<string, string> getName,
                    MethodInfo method)
        {
            const string prefix = "remove_";

            ParameterInfo[] parameters = method.GetParameters();

            if (parameters.Count() == 1 &&
                parameters.ElementAt(0).ParameterType == typeof(EventHandler) &&
                method.Name.StartsWith(prefix))
            {
                List<List<AutocompleteItem>> autocompleteParams = ProcessMethodOverrides(new[] { method });

                events.Add(new AutocompleteItem(AutocompleteKind.Event, _log, _typeSearcher)
                {
                    FullName = getName(method.Name.Substring(prefix.Length)),
                    Parameters = autocompleteParams
                });
            }
        }

        #endregion types

        #region equality
        public bool Equals(AutocompleteItem other)
        {
            return !String.IsNullOrWhiteSpace(FullName) && other?.FullName == FullName;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as AutocompleteItem);
        }

        public override int GetHashCode()
        {
            return FullName?.GetHashCode() ?? 0;
        }
        #endregion equality
    }
}
