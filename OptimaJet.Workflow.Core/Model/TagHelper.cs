using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using OptimaJet.Workflow.Core.Builder;

namespace OptimaJet.Workflow.Core.Model
{
    public static class TagHelper
    {
        private const string DefaultSeparator = ",";

        public static string ToTagStringForDatabase(List<string> tags)
        {
            if (!tags.Any())
                return null;
            return JsonConvert.SerializeObject(PrepareTagsList(tags));
        }

        public static string ToTagString(List<string> tags)
        {
            return String.Join(DefaultSeparator, PrepareTagsList(tags));
        }

        public static List<string> PrepareTagsList(List<string> tags)
        {
            return tags.Distinct().Select(t => t.Trim()).Where(t=>!String.IsNullOrEmpty(t)).OrderBy(t => t).ToList();
        }

        public static List<string> FromTagStringForDatabase(string value)
        {
            return String.IsNullOrEmpty(value) ? new List<string>() : JsonConvert.DeserializeObject<List<string>>(value);
        }

        public static List<string> FromTagString(string value)
        {
            return String.IsNullOrEmpty(value) ? new List<string>() : value.Split(DefaultSeparator.ToCharArray()).ToList();
        }

        public static string ReplaceTagsInScheme(this IWorkflowBuilder workflowBuilder,
            string schemeText, IEnumerable<string> tags)
        {
            ProcessDefinition pd = workflowBuilder.Parse(schemeText);
            pd.Tags = tags.ToList();
            return pd.Serialize();
        }
    }
}
