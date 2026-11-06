using System;
using System.Collections.Generic;
using OptimaJet.Workflow.Core.Model;
using OptimaJet.Workflow.Core.Persistence;
using OptimaJet.Workflow.Core.Runtime;
using static Anju.Navigate.BusinessAccess.Workflow.WorkflowInit;

namespace Anju.Navigate.BusinessAccess.Workflow
{
    public class WorkflowObject
    {
        private IEnumerable<WorkflowCommand> InitialCommand { get; set; }
        private WorkflowState InitialState { get; set; }
        private string CurrentStateName { get; set; }
        private string CurrentActivityName { get; set; }
        private IEnumerable<WorkflowCommand> AvailableCommandsWithoutUser { get; set; }
        private IEnumerable<WorkflowCommand> AvailableCommandsWithUser { get; set; }
        private IEnumerable<WorkflowCommand> AvailableCommandsWithConditionCheck { get; set; }
        private IEnumerable<WorkflowState> AvailableStateToSet { get; set; }
        private IEnumerable<string> AllActorsForAllCommandTransitions { get; set; }
        private IEnumerable<string> AllActorsForDirectAndUndefinedCommandTransitions { get; set; }
        private IEnumerable<string> AllActorsForDirectCommandTransitions { get; set; }
        private IEnumerable<string> AllActorsForReverseCommandTransitions { get; set; }
        private List<ProcessHistoryItem> ProcessHistory { get; set; }
        private ProcessDefinition ProcessScheme { get; set; }
        private ProcessStatus ProcessStatus { get; set; }
        private IEnumerable<ProcessTimer> ProcessTimer { get; set; }

        public WorkflowObject GetDetails(Guid processId, string userName, string proxyUser)
        {
            var obj = new WorkflowObject();

            //current         
            obj.CurrentStateName = Runtime.GetCurrentStateName(processId) != null
                ? Runtime.GetCurrentStateName(processId)
                : null;
            obj.CurrentActivityName = Runtime.GetCurrentActivityName(processId) != null
                ? Runtime.GetCurrentActivityName(processId)
                : null;
            //Available
            obj.AvailableCommandsWithoutUser =
                Runtime.GetAvailableCommands(processId, string.Empty) != null
                    ? Runtime.GetAvailableCommands(processId, string.Empty)
                    : null;
            obj.AvailableCommandsWithUser = Runtime.GetAvailableCommands(processId, userName) != null
                ? Runtime.GetAvailableCommands(processId, userName)
                : null;
            obj.AvailableCommandsWithConditionCheck =
                Runtime.GetAvailableCommandsWithConditionCheck(processId, userName) != null
                    ? Runtime.GetAvailableCommandsWithConditionCheck(processId, userName)
                    : null;
            obj.AvailableStateToSet = Runtime.GetAvailableStateToSet(processId) != null
                ? Runtime.GetAvailableStateToSet(processId)
                : null;

            //Commands
            obj.AllActorsForAllCommandTransitions =
                Runtime.GetAllActorsForAllCommandTransitions(processId) != null
                    ? Runtime.GetAllActorsForAllCommandTransitions(processId)
                    : null;
            obj.AllActorsForDirectAndUndefinedCommandTransitions =
                Runtime.GetAllActorsForDirectAndUndefinedCommandTransitions(processId) != null
                    ? Runtime.GetAllActorsForDirectAndUndefinedCommandTransitions(processId)
                    : null;
            obj.AllActorsForDirectCommandTransitions =
                Runtime.GetAllActorsForDirectCommandTransitions(processId) != null
                    ? Runtime.GetAllActorsForDirectCommandTransitions(processId)
                    : null;
            obj.AllActorsForReverseCommandTransitions =
                Runtime.GetAllActorsForReverseCommandTransitions(processId) != null
                    ? Runtime.GetAllActorsForReverseCommandTransitions(processId)
                    : null;

            //Process Details
            obj.ProcessHistory = Runtime.GetProcessHistory(processId) != null
                ? Runtime.GetProcessHistory(processId)
                : null;
            obj.ProcessScheme = Runtime.GetProcessScheme(processId) != null
                    ? Runtime.GetProcessScheme(processId)
                    : null;
            obj.ProcessStatus = Runtime.GetProcessStatus(processId) != null
                ? Runtime.GetProcessStatus(processId)
                : null;
            obj.ProcessTimer = Runtime.GetProcessTimers(processId) != null
                ? Runtime.GetProcessTimers(processId)
                : null;

            //Initial
            if (ProcessScheme != null)
            {
                obj.InitialCommand = Runtime.GetInitialCommands(ProcessScheme.Name, userName) != null
                    ? Runtime.GetInitialCommands(ProcessScheme.Name, userName)
                    : null;
                obj.InitialState = Runtime.GetInitialState(ProcessScheme.Name) != null
                    ? Runtime.GetInitialState(ProcessScheme.Name)
                    : null;
            }



            //Check
            //var identity = WorkflowInit.Runtime.CheckIdentity()
            //var identityByActor = WorkflowInit.Runtime.CheckIdentityByActor()

            return obj;

        }
    }
}
