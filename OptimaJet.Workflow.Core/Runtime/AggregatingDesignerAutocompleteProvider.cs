using System.Collections.Generic;

namespace OptimaJet.Workflow.Core.Runtime
{
    public class AggregatingDesignerAutocompleteProvider : BaseAggregatingProvider<IDesignerAutocompleteProvider>, IDesignerAutocompleteProvider
    {
        public List<string> GetAutocompleteSuggestions(SuggestionCategory category, string value, string schemeCode)
        {
            //combine
            var res = new List<string>();
            foreach (var provider in GetOrderedProviders(schemeCode))
            {
                var tmp = provider.GetAutocompleteSuggestions(category, value, schemeCode);
                if (tmp != null && tmp.Count > 0)
                {
                    res.AddRange(tmp);
                }
            }
            return res;
        }
    }
}
