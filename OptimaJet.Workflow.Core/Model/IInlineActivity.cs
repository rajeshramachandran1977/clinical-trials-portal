namespace OptimaJet.Workflow.Core.Model
{
    /// <summary>
    /// Defines the properties available for inline activity
    /// </summary>
    public interface IInlineActivity
    {
        /// <summary>
        /// Name of the inline
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Type of the activity. Ordinary or Inline.
        /// </summary>
        ActivityType ActivityType { get; set; }
        
        /// <summary>
        /// Inlined scheme name for inline activity.
        /// </summary>
        string SchemeCode { get; set; }
    }
}