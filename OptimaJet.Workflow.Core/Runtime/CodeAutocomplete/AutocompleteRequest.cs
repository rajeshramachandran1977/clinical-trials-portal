using System.Collections.Generic;
using Newtonsoft.Json;

namespace OptimaJet.Workflow.Core.Runtime.CodeAutocomplete
{
    public class AutocompleteRequest
    {
        /// <summary>
        /// text for search (like "System.Thr")
        /// </summary>
        [JsonProperty("pattern")]
        public string Pattern { get; set; }
        /// <summary>
        /// list of usings (like "System", "System.Threading")
        /// </summary>
        [JsonProperty("usings")]
        public List<string> Usings { get; set; }
        /// <summary>
        /// list of allow variables to autocomplete
        /// </summary>
        [JsonProperty("variables")]
        public List<AutocompleteVariable> Variables { get; set; }
        /// <summary>
        /// id that will be returned in response (to working with signalR)
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
