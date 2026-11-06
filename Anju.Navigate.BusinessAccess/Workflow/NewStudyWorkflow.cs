using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Anju.Navigate.DataAccess;
using Anju.Navigate.DataAccess.DataEntities;
using OptimaJet.Workflow.Core.Runtime;
using static Anju.Navigate.BusinessAccess.Workflow.WorkflowInit;

namespace Anju.Navigate.BusinessAccess.Workflow
{
    public class NewStudyWorkflow : IDisposable
    {
        private const string NewStudySubmissionWorkflow = "Submit New Study";
        private readonly Navigate30Context _context;

        public NewStudyWorkflow()
        {
            _context = new Navigate30Context();
        }

        public void CreateWorkFlow(int operationId, string userName, string proxyUser)
        {
            var operation = _context.Operation.SingleOrDefault(x => x.OperationId == operationId);

            if (operation == null)
            {
                var study = _context.NewStudy.SingleOrDefault(x => x.StudyId == operationId);

                if (study != null && (string.IsNullOrEmpty(study.State) || study.State != Utilities.Messages.CONCEPTSUBMITTED)) return;

                var processId = Guid.NewGuid();
                Runtime.CreateInstance(NewStudySubmissionWorkflow, processId, userName ?? proxyUser, proxyUser);

                var workFlow = new Operation
                {
                    Id = processId,
                    OperationId = operationId,
                    WorkflowName = NewStudySubmissionWorkflow,
                    UserName = userName ?? proxyUser,
                    ProxyUser = proxyUser ?? string.Empty,
                    TimeStamp = DateTime.Now,
                    OperationWorkflowLog = new List<OperationWorkflowLog>
                    {
                        new OperationWorkflowLog
                        {
                            ProcessId = processId,
                            Comment = $"Concept Submitted(New Study) with Study Id : {operationId}",
                            UserName = userName ?? proxyUser,
                            ProxyUser = proxyUser ?? string.Empty,
                            TimeStamp = DateTime.Now
                        }
                    }
                };
                _context.Operation.Add(workFlow);
                _context.SaveChanges();
                //WorkflowMessage.CreateWorkflowSuccessMail(processId);
            }
            else
            {
                var command = Runtime.GetAvailableCommands(operation.Id, userName ?? proxyUser)
                    .FirstOrDefault(c => c.CommandName.Trim() == "ResubmissionByPI");

                if (command != null)
                {
                    Runtime.ExecuteCommand(command, userName ?? proxyUser, proxyUser);
                    SaveWorkflowLog(operation.Id, $"Resubmission By PI to Study : { operation.OperationId}", userName, proxyUser);
                    //WorkflowMessage.ResubmissionByPiMail(operation);
                }

                var currentState = Runtime.GetCurrentStateName(operation.Id);

                SaveWorkflowLog(operation.Id, $"New state set to  Study: { operation.OperationId} => {currentState}", userName, proxyUser);
                //WorkflowMessage.ReviewAvailableToMslMail(operation);
            }
        }

        public void AssignMslAndPlToStudy(int operationId, string userName, string proxyUser)
        {
            var operation = _context.Operation.SingleOrDefault(x => x.OperationId == operationId);

            if (operation?.Id == null) return;
            var command = Runtime.GetAvailableCommands(operation.Id, userName ?? proxyUser)
                .FirstOrDefault(c => c.CommandName.Trim() == "AssignMSLAndPLToStudy");

            if (command != null)
            {
                Runtime.ExecuteCommand(command, userName ?? proxyUser, proxyUser);
                SaveWorkflowLog(operation.Id, $"MSL and PL is Assigned to Study : { operation.OperationId}", userName, proxyUser);
                //WorkflowMessage.AssignWorkflowToMslAndPLSuccessMail(operation);
            }

            var state = Runtime.GetAvailableStateToSet(operation.Id, Thread.CurrentThread.CurrentCulture)
                .SingleOrDefault(c => c.Name.Trim() == "MSLLOIReview");

            if (state == null) return;
            Runtime.SetState(new SetStateParams(operation.Id, state.Name));
            SaveWorkflowLog(operation.Id, $"New state set to  Study: { operation.OperationId} => {state.Name}", userName, proxyUser);
            //WorkflowMessage.ReviewAvailableToMslMail(operation);
        }

        public void ReviewByMsl(int studyId, string userName, string proxyUser)
        {
            var operation = _context.Operation.SingleOrDefault(x => x.OperationId == studyId);

            if (operation?.Id == null) return;
            if (Runtime.GetCurrentStateName(operation.Id) != "MSLLOIReview") return;

            var study = _context.NewStudy.SingleOrDefault(x => x.StudyId == studyId);
            if (study == null) return;
            var result = _context.StudyReview.SingleOrDefault(x => x.StudyId == studyId);
            if (result == null) return;
            var mslUser = _context.Users.SingleOrDefault(x => x.UserId == result.MsluserId && x.IsActive == true);

            switch (result.Decision)
            {
                case Utilities.Messages.DECISIONACCEPTED:
                    {
                        var plStudyReview = _context.PLStudyReview.SingleOrDefault(x => x.StudyId == studyId);

                        if (plStudyReview != null && plStudyReview.Decision == Utilities.Messages.DECISIONRESUBMIT && study.PITaskStatus == Utilities.Messages.RESUBMITPROPOSAL)
                        {
                            SaveWorkflowLog(operation.Id, $"Study : {operation.OperationId}  Resubmit by MSL", userName,
                                proxyUser);

                            var command = Runtime.GetAvailableCommands(operation.Id, userName ?? proxyUser)
                                .FirstOrDefault(c => c.CommandName.Trim() == "ResubmitByMSL");

                            var status = Runtime.ExecuteCommand(command, userName, proxyUser);

                            if (!status.WasExecuted) return;
                            var currentState = Runtime.GetCurrentStateName(operation.Id);

                            SaveWorkflowLog(operation.Id,
                                $"New state set to Study : {operation.OperationId} => {currentState}", userName,
                                proxyUser);
                            //WorkflowMessage.ReviewStatusMail(operation, mslUser, Utilities.Messages.DECISIONRESUBMIT);
                            return;
                        }

                        SaveWorkflowLog(operation.Id, $"Study : {operation.OperationId}  Accepted by MSL", userName,
                            proxyUser);
                        //WorkflowMessage.ReviewStatusMail(operation, mslUser, Utilities.Messages.DECISIONACCEPTED);

                        var state = Runtime
                            .GetAvailableStateToSet(operation.Id, Thread.CurrentThread.CurrentCulture)
                            .SingleOrDefault(c => c.Name.Trim() == "PLReview");

                        if (state != null)
                        {
                            Runtime.SetState(new SetStateParams(operation.Id, state.Name));
                            SaveWorkflowLog(operation.Id,
                                $"New state set to Study : {operation.OperationId} => {state.Name}", userName,
                                proxyUser);
                            //WorkflowMessage.ReviewAvailableToPlMail(operation);
                        }

                        break;
                    }
                case Utilities.Messages.DECISIONRESUBMIT:
                    {
                        SaveWorkflowLog(operation.Id, $"Study : {operation.OperationId}  Resubmit by MSL", userName, proxyUser);

                        var command = Runtime.GetAvailableCommands(operation.Id, userName ?? proxyUser)
                              .FirstOrDefault(c => c.CommandName.Trim() == "ResubmitByMSL");

                        var status = Runtime.ExecuteCommand(command, userName, proxyUser);

                        if (status.WasExecuted)
                        {
                            var currentState = Runtime.GetCurrentStateName(operation.Id);

                            SaveWorkflowLog(operation.Id, $"New state set to Study : {operation.OperationId} => {currentState}", userName,
                                proxyUser);
                            //WorkflowMessage.ReviewStatusMail(operation, mslUser, Utilities.Messages.DECISIONRESUBMIT);
                        }
                        break;
                    }
            }
        }

        public void ReviewByProgramLead(int studyId, string userName, string proxyUser)
        {
            var operation = _context.Operation.SingleOrDefault(x => x.OperationId == studyId);
            if (operation?.Id == null) return;

            var state = Runtime.GetCurrentState(operation.Id, Thread.CurrentThread.CurrentCulture);

            if (state.Name != "PLReview") return;
            var result = _context.PLStudyReview.SingleOrDefault(x => x.StudyId == studyId);
            var plUser = _context.Users.SingleOrDefault(x => x.UserId == result.PLuserId && x.IsActive == true);

            if (result == null) return;
            switch (result.Decision)
            {
                case Utilities.Messages.DECISIONACCEPTED:
                    {
                        SaveWorkflowLog(operation.Id,
                            $"Study : {operation.OperationId}  approved by Program Lead", userName, proxyUser);
                        //WorkflowMessage.ReviewStatusMail(operation, plUser, Utilities.Messages.DECISIONACCEPTED);

                        state = Runtime
                            .GetAvailableStateToSet(operation.Id, Thread.CurrentThread.CurrentCulture)
                            .SingleOrDefault(c => c.Name.Trim() == "RecordLocalMRCResult");

                        if (state != null)
                        {
                            Runtime.SetState(new SetStateParams(operation.Id, state.Name));
                            SaveWorkflowLog(operation.Id,
                                $"New state set to Study : {operation.OperationId} => {state.Name}", userName,
                                proxyUser);
                            // WorkflowMessage.AssignTlToRecordResultMail(operation);
                        }

                        break;
                    }
                case Utilities.Messages.DECISIONRESUBMIT:
                    {
                        SaveWorkflowLog(operation.Id, $"Study : {operation.OperationId}  Resubmit by PL", userName, proxyUser);

                        var command = Runtime.GetAvailableCommands(operation.Id, userName ?? proxyUser)
                            .FirstOrDefault(c => c.CommandName.Trim() == "ResubmitByPL");
                        var status = Runtime.ExecuteCommand(command, userName, proxyUser);

                        if (status.WasExecuted)
                        {
                            var currentState = Runtime.GetCurrentStateName(operation.Id);
                            SaveWorkflowLog(operation.Id,
                                $"New state set to Study : {operation.OperationId} => {currentState}", userName,
                                proxyUser);
                            //WorkflowMessage.ReviewStatusMail(operation, plUser, Utilities.Messages.DECISIONRESUBMIT);
                        }

                        break;
                    }
            }

        }

        public void RecordMrcResults(int studyId, string userName, string proxyUser)
        {
            var operation = _context.Operation.SingleOrDefault(x => x.OperationId == studyId);

            if (operation?.Id == null) return;

            var state = Runtime.GetCurrentState(operation.Id, Thread.CurrentThread.CurrentCulture);

            if (state?.Name == "RecordLocalMRCResult")
            {
                var result = _context.MRCStudyReview.FirstOrDefault(x => x.StudyId == studyId && x.RecordType == Utilities.Messages.LocalMRC);
                var plStudyReview = _context.PLStudyReview.SingleOrDefault(x => x.StudyId == studyId);
                var tl = _context.Users.SingleOrDefault(x => x.UserId == plStudyReview.TluserId && x.IsActive == true);
                var comment = string.Empty;

                if (result == null || result.RecordType != Utilities.Messages.LocalMRC) return;

                switch (result.LocalMrcdecision)
                {
                    case Utilities.Messages.DECISIONAPPROVED:
                        comment = $"Study : {operation.OperationId}  Approved by TL";

                        state = Runtime
                            .GetAvailableStateToSet(operation.Id, Thread.CurrentThread.CurrentCulture)
                            .SingleOrDefault(c => c.Name.Trim() == "RecordGlobalMRCResult");

                        if (state != null)
                        {
                            Runtime.SetState(new SetStateParams(operation.Id, state.Name));
                        }

                        break;
                    case Utilities.Messages.DECISIONWITHDRAWN:
                        comment = $"Study : {operation.OperationId}  Withdrawn by TL";
                        break;
                    case Utilities.Messages.DECISIONREJECTED:
                        comment = $"Study : {operation.OperationId}  Rejected by TL";
                        break;
                    case Utilities.Messages.DECISIONTABLED:
                        comment = $"Study : {operation.OperationId}  Tabled by TL";
                        break;
                    case Utilities.Messages.DECISIONCONDITIONALAPPROVAL:
                        comment =
                            $"Study : {operation.OperationId}  Conditionally Approved(Resubmission required) by TL";
                        break;
                }

                SaveWorkflowLog(operation.Id, comment, userName, proxyUser);
                //WorkflowMessage.ReviewStatusMailByTl(operation, tl, result.LocalMrcdecision);

                var currentState = Runtime.GetCurrentStateName(operation.Id);

                SaveWorkflowLog(operation.Id, $"New state set to  Study: { operation.OperationId} => {currentState}", userName, proxyUser);
            }

            if (state?.Name == "RecordGlobalMRCResult")
            {
                var result = _context.MRCStudyReview.FirstOrDefault(x => x.StudyId == studyId && x.RecordType == Utilities.Messages.GlobalMRC);
                var plStudyReview = _context.PLStudyReview.SingleOrDefault(x => x.StudyId == studyId);
                var tl = _context.Users.SingleOrDefault(x => x.UserId == plStudyReview.TluserId && x.IsActive == true);
                var comment = string.Empty;

                if (result == null || result.RecordType != Utilities.Messages.GlobalMRC) return;

                switch (result.GlobalMrcdecision)
                {
                    case Utilities.Messages.DECISIONAPPROVED:
                        comment = $"Study : {operation.OperationId}  Approved by TL";

                        state = Runtime
                            .GetAvailableStateToSet(operation.Id, Thread.CurrentThread.CurrentCulture)
                            .SingleOrDefault(c => c.Name.Trim() == "CreateOrDeliverApprovalLetter");

                        if (state != null)
                        {
                            Runtime.SetState(new SetStateParams(operation.Id, state.Name));
                        }

                        break;
                    case Utilities.Messages.DECISIONWITHDRAWN:
                        comment = $"Study : {operation.OperationId}  Withdrawn by TL";
                        break;
                    case Utilities.Messages.DECISIONREJECTED:
                        comment = $"Study : {operation.OperationId}  Rejected by TL";
                        break;
                    case Utilities.Messages.DECISIONTABLED:
                        comment = $"Study : {operation.OperationId}  Tabled by TL";
                        break;
                    case Utilities.Messages.CONDITIONALLYAPPROVED:
                        comment = $"Study : {operation.OperationId}  Conditionally Approved by TL";
                        break;
                    case Utilities.Messages.DECISIONCONDITIONALAPPROVAL:
                        comment = $"Study : {operation.OperationId}  Conditionally Approved(Resubmission required) by TL";
                        break;
                }

                SaveWorkflowLog(operation.Id, comment, userName, proxyUser);
                // WorkflowMessage.ReviewStatusMailByTl(operation, tl, result.GlobalMrcdecision);

                var currentState = Runtime.GetCurrentStateName(operation.Id);

                SaveWorkflowLog(operation.Id, $"New state set to  Study: { operation.OperationId} => {currentState}", userName, proxyUser);
            }
        }

        public void MarkMileStoneComplete(int studyId, string userName, string proxyUser)
        {
            var operation = _context.Operation.SingleOrDefault(x => x.OperationId == studyId);
            if (operation?.Id == null) return;

            var state = Runtime.GetCurrentState(operation.Id, Thread.CurrentThread.CurrentCulture);

            if (state.Name != "CreateOrDeliverApprovalLetter") return;
            var study = _context.NewStudy.SingleOrDefault(x => x.StudyId == studyId);
            var mrcStudyReview = _context.MRCStudyReview.SingleOrDefault(x => x.StudyId == studyId && x.GlobalMrcdecision.Trim() == Utilities.Messages.DECISIONAPPROVED);

            if (mrcStudyReview == null || study == null) return;
            SaveWorkflowLog(operation.Id, $"Study : {operation.OperationId}  Milestone completed", userName, proxyUser);
            //WorkflowMessage.MileStoneCompletedMail(operation, plUser, Utilities.Messages.DECISIONACCEPTED);
            state = Runtime
                .GetAvailableStateToSet(operation.Id, Thread.CurrentThread.CurrentCulture)
                .SingleOrDefault(c => c.Name.Trim() == "MileStoneComplete");

            if (state == null) return;
            Runtime.SetState(new SetStateParams(operation.Id, state.Name));
            SaveWorkflowLog(operation.Id, $"New state set to Study : {operation.OperationId} => {state.Name}", userName, proxyUser);
            //WorkflowMessage.AssignTlToRecordResultMail(operation);

        }

        private void SaveWorkflowLog(Guid id, string comment, string userName, string proxyUser)
        {
            _context.OperationWorkflowLog.Add(new OperationWorkflowLog
            {
                ProcessId = id,
                Comment = comment,
                UserName = userName ?? proxyUser,
                ProxyUser = proxyUser ?? string.Empty,
                TimeStamp = DateTime.Now
            });
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }


    }
}