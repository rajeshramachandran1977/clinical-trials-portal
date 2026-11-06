namespace OptimaJet.Workflow.Core.Builder
{
   
    /// <summary>
    ///  Determines the order of the build steps
    /// </summary>
   public enum BuildStepPosition
    {
        /// <summary>
        /// The step will be executed before system build steps
        /// </summary>
        BeforeSystemSteps,
        /// <summary>
        /// The step will be executed as system build step  
        /// </summary>
        SystemSteps,
        /// <summary>
        /// The step will be executed after system build steps
        /// </summary>
        AfterSystemSteps
    }
}