using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimaJet.Workflow.Core.Model
{
    /// <summary>
    /// Represent an annotation than can be attached to <see cref="ActivityDefinition"/> or <see cref="TransitionDefinition"/>
    /// </summary>
    public class Annotation
    {
        /// <summary>
        /// Annotation name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Annotation value as a JSON string
        /// </summary>
        public string JsonValue { get; set; }

        /// <summary>
        /// Creates a copy of Annotation
        /// </summary>
        /// <returns>A copy of annotation</returns>
        public Annotation Clone()
        {
            return MemberwiseClone() as Annotation;
        }
    }
}
