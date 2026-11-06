namespace OptimaJet.Workflow.Core.Model
{
    /// <summary>
    /// Activity type
    /// </summary>
    public enum ActivityType
    {
        /// <summary>
        /// Ordinary activity, belongs a scheme itself
        /// </summary>
        Ordinary,
        /// <summary>
        /// Activity with this type marks a place to inline another scheme
        /// </summary>
        Inline
        
    }
}