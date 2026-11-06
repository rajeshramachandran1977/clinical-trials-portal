using System.Collections.Generic;
using System.Collections.ObjectModel;
using OptimaJet.Workflow.Core.Model;

namespace OptimaJet.Workflow.Core.Builder
{
    /// <summary>
    /// Represents the result of a build step execution 
    /// </summary>
    public sealed class BuildStepResult
    {
        private BuildStepResult()
        {
        }

        public bool IsSuccess { get; private set; }

        private List<string> _errors;

        public ProcessDefinition ProcessDefinition { get; private set; }

        public ReadOnlyCollection<string> Errors => _errors?.AsReadOnly();

        public static BuildStepResult Fail(List<string> errors)
        {
            return new BuildStepResult()
            {
                IsSuccess = false,
                _errors = errors
            };
        }

        public static BuildStepResult Fail(string error)
        {
            return new BuildStepResult()
            {
                IsSuccess = false,
                _errors = new List<string> {error}
            };
        }

        public static BuildStepResult Success(ProcessDefinition processDefinition)
        {
            return new BuildStepResult()
            {
                IsSuccess = true,
                ProcessDefinition = processDefinition
            };
        }
    }


    /// <summary>
    /// Represents a scheme build step
    /// </summary>
    public abstract class BuildStep
    {
        protected IWorkflowBuilder Builder { get; private set; }

        public BuildStep(){}

        internal BuildStep(IWorkflowBuilder builder)
        {
            Builder = builder;
        }

        internal bool IsBuilderNull => Builder == null;

        internal void SetBuilder(IWorkflowBuilder builder)
        {
            Builder = builder;
        }

        public abstract string Name { get; }

        public abstract BuildStepResult Execute(ProcessDefinition processDefinition, IDictionary<string, object> parameters);
    }

}