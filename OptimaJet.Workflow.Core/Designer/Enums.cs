using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimaJet.Workflow.Core.Designer
{
    /// <summary>
    /// All Operations for DesignApi
    /// </summary>
    public enum Operations
    {
        notcorrect = 0,
        exists,
        load,
        save,
        uploadscheme,
        downloadscheme,
        uploadschemebpmn,
        downloadschemebpmn,
        compile,
        getemptytype,
        getautocompletesuggestions,
        getcodeactionparameter,
        deleteglobalcodeaction,
        getcodeautocomplete
    };

    /// <summary>
    /// Elements from Request
    /// </summary>
    public enum RequestElements
    {
        notcorrect = 0,
        operation,
        schemecode,
        schemeid,
        processid,
        data,
        category,
        type,
        value,
        name,
        newschemecode
    }
}
