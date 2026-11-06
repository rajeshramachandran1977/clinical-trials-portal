using System;

namespace OptimaJet.Workflow.Core.Fault
{
    public class ActivityNotFoundException : Exception
    {
        public ActivityNotFoundException(string message) : base(message)
        {
            
        }
        public static ActivityNotFoundException CreateByActivityName(string activityName, string schemeCode)
        {
            return new ActivityNotFoundException($"Activity with name = {activityName} was not found in {schemeCode} scheme.");
        }

        public static ActivityNotFoundException CreateByStateName(string stateName, bool isForSetState, string schemeCode)
        {
            return new ActivityNotFoundException($"Activity with state = {stateName} and isForSetState = {isForSetState} was not found in {schemeCode} scheme.");
        }
    }

    public class CommandNotFoundException : Exception
    {
        public CommandNotFoundException(string message) : base(message)
        {

        }
        public static CommandNotFoundException Create(string commandName, string schemeCode)
        {
            return new CommandNotFoundException($"Command with name = {commandName} was not found in {schemeCode} scheme.");
        }
    }

    public class ActorNotFoundException : Exception
    {
        public ActorNotFoundException(string message) : base(message)
        {

        }
        public static ActorNotFoundException Create(string actorName, string schemeCode)
        {
            return new ActorNotFoundException($"Actor with name = {actorName} was not found in {schemeCode} scheme.");
        }
    }
}
