using Newtonsoft.Json;

namespace OptimaJet.Workflow.Core.Runtime.CodeAutocomplete
{
    public class AutocompleteVariable
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
