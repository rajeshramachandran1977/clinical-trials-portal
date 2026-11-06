using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimaJet.Workflow.Core.Runtime.CodeAutocomplete
{
    public enum AutocompleteKind
    {
        Namespace = 10,
        Class = 20,
        Struct = 30,
        Method = 40,
        Parameter = 50,
        FrameworkVariable = 60,
        Property = 70,
        Field = 80,
        Const = 90,
        Event = 100,

        Root = 1000,
    }
}
