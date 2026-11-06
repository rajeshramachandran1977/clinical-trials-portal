using System;

namespace OptimaJet.Workflow.Core.Model
{
    /// <summary>
    /// Represent settings used by Workflow Designer
    /// </summary>
    public class DesignerSettings
    {
        public string X { get; set; }
        public string Y { get; set; }
        public string Bending { get; set; }
        public string Scale { get; set; }

        public string Group { get; set; }

        public DesignerSettings InlineElementSettings { get; set; }

        public static DesignerSettings Empty => new DesignerSettings();

        public DesignerSettings Clone()
        {
            var cloned = MemberwiseClone() as DesignerSettings;
            if (InlineElementSettings != null)
                cloned.InlineElementSettings = InlineElementSettings.Clone();

            return cloned;
        }
    }
}
