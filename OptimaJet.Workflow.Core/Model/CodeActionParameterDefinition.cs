using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimaJet.Workflow.Core.Model
{
    /// <summary>
    /// Type of a code action parameter
    /// </summary>
    public enum ParameterType
    {
        /// <summary>
        /// Text parameter
        /// </summary>
        Text,
        /// <summary>
        /// Numeric parameter
        /// </summary>
        Number,
        /// <summary>
        /// Boolean parameter represented by checkbox
        /// </summary>
        Checkbox,
        /// <summary>
        /// List of name/value pair represented by dropdown control
        /// </summary>
        Dropdown,
        /// <summary>
        /// Date/Time parameter
        /// </summary>
        DateTime,
        /// <summary>
        /// JSON object parameter
        /// </summary>
        Json,
        /// <summary>
        /// Text parameter represented by textarea
        /// </summary>
        TextArea
    }

    /// <summary>
    /// Represents a parameter for code action
    /// </summary>
    public class CodeActionParameterDefinition
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public CodeActionParameterDefinition()
        {
            DropdownValues = new List<DropdownValue>();
        }

        /// <summary>
        /// Name of the parameter
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Type of the parameter <see cref="ParameterType"/>
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ParameterType Type { get; set; }

        /// <summary>
        /// Creates a copy of the parameter definition
        /// </summary>
        /// <returns>A copy of parameter definition</returns>
        public CodeActionParameterDefinition Clone()
        {
            var clone = MemberwiseClone() as CodeActionParameterDefinition;
            clone.DropdownValues = new List<DropdownValue>();
            DropdownValues.ForEach(a => clone.DropdownValues.Add(a.Clone()));

            return clone;
        }

        /// <summary>
        /// If false specifies that the parameter is optional
        /// </summary>
        public bool IsRequired { get; set; }

        /// <summary>
        /// A list of <see cref="DropdownValue"/> for a <see cref="ParameterType.Dropdown"/> parameter
        /// </summary>
        public List<DropdownValue> DropdownValues { get; set; }

        /// <summary>
        /// A default value of the parameter
        /// </summary>
        public string DefaultValue { get; set; }
    }

    /// <summary>
    /// A name-value pair for a <see cref="ParameterType.Dropdown"/> parameter
    /// </summary>
    public class DropdownValue
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Creates a shallow copy of this pair
        /// </summary>
        /// <returns></returns>
        public DropdownValue Clone()
        {
            var clone = MemberwiseClone() as DropdownValue;
            return clone;
        }
    }
}
