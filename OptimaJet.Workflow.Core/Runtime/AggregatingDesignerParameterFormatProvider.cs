using System.Collections.Generic;
using System.Linq;
using OptimaJet.Workflow.Core.Model;

namespace OptimaJet.Workflow.Core.Runtime
{
    public class AggregatingDesignerParameterFormatProvider : BaseAggregatingProvider<IDesignerParameterFormatProvider>, IDesignerParameterFormatProvider
    {
        public List<CodeActionParameterDefinition> GetFormat(CodeActionType type, string name, string schemeCode)
        {
            IDesignerParameterFormatProvider provider = GetOrderedProviders(schemeCode).FirstOrDefault();
            //override
            return provider?.GetFormat(type, name, schemeCode) ?? new List<CodeActionParameterDefinition>();
        }
    }
}
