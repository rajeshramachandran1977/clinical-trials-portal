using System;
using System.Collections.Generic;
using System.Linq;
using Anju.Navigate.DataAccess;
using Anju.Navigate.DataAccess.DataEntities;

namespace Anju.Navigate.BusinessAccess.Workflow
{

    public class WorkflowMessage
    {
        public List<string> To { get; set; }
        public List<string> Cc { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

        public static void AssignTlToRecordResultMail(Operation op)
        {
            var context = new Navigate30Context();
            var study = context.NewStudy.SingleOrDefault(x => x.StudyId == op.OperationId);
            var plStudyReview = context.PLStudyReview.SingleOrDefault(x => x.StudyId == op.OperationId);
            var pi = context.Users.SingleOrDefault(x => x.UserName == study.ANJU_AddedBy && x.IsActive == true);
            var tl = context.Users.SingleOrDefault(x => x.UserId == plStudyReview.TluserId && x.IsActive == true);

            var message = new WorkflowMessage
            {
                Subject = $"Study {GetFormattedStudy(study)} Submitted by user {GetFormattedUser(pi)} dated {study.ANJU_AddDate} " +
                            $"is available for review to Trial Leader on {plStudyReview.ANJU_AddDate}",
                Message = $"Study{GetFormattedStudy(study)} Submitted by user {GetFormattedUser(pi)} dated {study.ANJU_AddDate} " +
                            $"is available for review to {GetFormattedUser(tl)} on {plStudyReview.ANJU_AddDate}",
                To = new List<string> { },
                Cc = new List<string> { }
            };
            WorkflowMail.SendEmail(message);
            context.Dispose();
        }

        public static void ReviewAvailableToPlMail(Operation op)
        {
            var context = new Navigate30Context();
            var study = context.NewStudy.SingleOrDefault(x => x.StudyId == op.OperationId);
            var studyTask = context.StudyTask.SingleOrDefault(x => x.StudyId == op.OperationId);
            var user = context.Users.SingleOrDefault(x => x.UserName == study.ANJU_AddedBy && x.IsActive == true);
            var plUser = context.Users.SingleOrDefault(x => x.UserId == studyTask.PluserId && x.IsActive == true);

            var message = new WorkflowMessage
            {
                Subject = $"Study {GetFormattedStudy(study)} Submitted by user {GetFormattedUser(user)} dated {study.ANJU_AddDate} " +
                            $"is available for review to PL on {studyTask.ANJU_AddDate}",
                Message = $"Study{GetFormattedStudy(study)} Submitted by user {GetFormattedUser(user)} dated {study.ANJU_AddDate} " +
                            $"is available for review to {GetFormattedUser(plUser)} on {studyTask.ANJU_AddDate}",
                To = new List<string> { },
                Cc = new List<string> { }
            };
            WorkflowMail.SendEmail(message);
            context.Dispose();
        }

        public static void ReviewStatusMail(Operation op, Users approver, string reviewStatus)
        {
            var context = new Navigate30Context();
            var study = context.NewStudy.SingleOrDefault(x => x.StudyId == op.OperationId);
            var studyTask = context.StudyTask.SingleOrDefault(x => x.StudyId == op.OperationId);
            var pi = context.Users.SingleOrDefault(x => x.UserName == study.ANJU_AddedBy && x.IsActive == true);

            var message = new WorkflowMessage
            {
                To = new List<string> { },
                Cc = new List<string> { }
            };
            if (approver.UserType == "ProgramLeader")
            {
                if (reviewStatus == Utilities.Messages.DECISIONACCEPTED)
                {

                    message.Subject = $"Study {GetFormattedStudy(study)} Submitted by user {GetFormattedUser(pi)} dated {study.ANJU_AddDate} " +
                                $"is Approved by Program Leader on {studyTask.ANJU_AddDate}";
                    message.Message = $"Study{GetFormattedStudy(study)} Submitted by user {GetFormattedUser(pi)} dated {study.ANJU_AddDate} " +
                             $"is Approved by {GetFormattedUser(approver)} on {studyTask.ANJU_AddDate}";
                }
                else if (reviewStatus == Utilities.Messages.DECISIONRESUBMIT)
                {

                    //TO DO => Assign back to MSL
                    message.Subject = $"Study {GetFormattedStudy(study)} Submitted by user {GetFormattedUser(pi)} dated {study.ANJU_AddDate} " +
                                $"is not Approved by Program Leader & is open for Resubmit on {studyTask.ANJU_AddDate}";
                    message.Message = $"Study{GetFormattedStudy(study)} Submitted by user {GetFormattedUser(pi)} dated {study.ANJU_AddDate} " +
                             $"is not Approved by {GetFormattedUser(approver)} & is open for Resubmit on {studyTask.ANJU_AddDate}";
                }
            }
            else if (approver.UserType == "MSL")
            {
                if (reviewStatus == Utilities.Messages.DECISIONACCEPTED)
                {

                    message.Subject = $"Study {GetFormattedStudy(study)} Submitted by user {GetFormattedUser(pi)} dated {study.ANJU_AddDate} " +
                                $"is Approved by MSL on {studyTask.ANJU_AddDate}";
                    message.Message = $"Study{GetFormattedStudy(study)} Submitted by user {GetFormattedUser(pi)} dated {study.ANJU_AddDate} " +
                             $"is Approved by {GetFormattedUser(approver)} on {studyTask.ANJU_AddDate}";
                }
                else if (reviewStatus == Utilities.Messages.DECISIONRESUBMIT)
                {
                    message.Subject = $"Study {GetFormattedStudy(study)} Submitted by user {GetFormattedUser(pi)} dated {study.ANJU_AddDate} " +
                                $"is not Approved by MSL & is open for Resubmit on {studyTask.ANJU_AddDate}";
                    message.Message = $"Study{GetFormattedStudy(study)} Submitted by user {GetFormattedUser(pi)} dated {study.ANJU_AddDate} " +
                             $"is not Approved by {GetFormattedUser(approver)} & is open for Resubmit on {studyTask.ANJU_AddDate}";
                }
            }

            WorkflowMail.SendEmail(message);
            context.Dispose();
        }

        public static void ReviewStatusMailByTl(Operation op, Users approver, string reviewStatus)
        {
            var context = new Navigate30Context();
            var study = context.NewStudy.SingleOrDefault(x => x.StudyId == op.OperationId);
            var user = context.Users.SingleOrDefault(x => x.UserName == study.ANJU_AddedBy && x.IsActive == true);

            var message = new WorkflowMessage
            {
                To = new List<string> { },
                Cc = new List<string> { }
            };

            switch (reviewStatus)
            {
                case Utilities.Messages.DECISIONAPPROVED:
                    message.Subject = $"Study {GetFormattedStudy(study)} Submitted by user {GetFormattedUser(user)} dated {study.ANJU_AddDate} " +
                                        $"is Approved by Trial Leader on {study.ANJU_AddDate}";
                    message.Message = $"Study{GetFormattedStudy(study)} Submitted by user {GetFormattedUser(user)} dated {study.ANJU_AddDate} " +
                                        $"is Approved by {GetFormattedUser(approver)} on {study.ANJU_AddDate}";
                    break;
                case Utilities.Messages.DECISIONREJECTED:
                    message.Subject = $"Study {GetFormattedStudy(study)} Submitted by user {GetFormattedUser(user)} dated {study.ANJU_AddDate} " +
                                        $"is Rejected by Trial Leader on {study.ANJU_AddDate}";
                    message.Message = $"Study{GetFormattedStudy(study)} Submitted by user {GetFormattedUser(user)} dated {study.ANJU_AddDate} " +
                                        $"is Rejected by {GetFormattedUser(approver)} on {study.ANJU_AddDate}";
                    break;
                case Utilities.Messages.DECISIONCONDITIONALAPPROVAL:
                    message.Subject = $"Study {GetFormattedStudy(study)} Submitted by user {GetFormattedUser(user)} dated {study.ANJU_AddDate} " +
                                        $"is Conditionally Approved (Resubmission required) by Trial Leader on {study.ANJU_AddDate}";
                    message.Message = $"Study{GetFormattedStudy(study)} Submitted by user {GetFormattedUser(user)} dated {study.ANJU_AddDate} " +
                                        $"is Conditionally Approved (Resubmission required) by {GetFormattedUser(approver)} on {study.ANJU_AddDate}";
                    break;
                case Utilities.Messages.DECISIONWITHDRAWN:
                    message.Subject = $"Study {GetFormattedStudy(study)} Submitted by user {GetFormattedUser(user)} dated {study.ANJU_AddDate} " +
                                        $"is Withdrawn by Trial Leader on {study.ANJU_AddDate}";
                    message.Message = $"Study{GetFormattedStudy(study)} Submitted by user {GetFormattedUser(user)} dated {study.ANJU_AddDate} " +
                                        $"is Withdrawn by {GetFormattedUser(approver)} on {study.ANJU_AddDate}";
                    break;
                case Utilities.Messages.DECISIONTABLED:
                    message.Subject = $"Study {GetFormattedStudy(study)} Submitted by user {GetFormattedUser(user)} dated {study.ANJU_AddDate} " +
                                        $"is Tabled by Trial Leader on {study.ANJU_AddDate}";
                    message.Message = $"Study{GetFormattedStudy(study)} Submitted by user {GetFormattedUser(user)} dated {study.ANJU_AddDate} " +
                                        $"is Tabled by {GetFormattedUser(approver)} on {study.ANJU_AddDate}";
                    break;
            }

            WorkflowMail.SendEmail(message);
            context.Dispose();
        }

        public static void ReviewAvailableToMslMail(Operation op)
        {
            var context = new Navigate30Context();
            var study = context.NewStudy.SingleOrDefault(x => x.StudyId == op.OperationId);
            var studyTask = context.StudyTask.SingleOrDefault(x => x.StudyId == op.OperationId);
            var user = context.Users.SingleOrDefault(x => x.UserName == study.ANJU_AddedBy && x.IsActive == true);
            var mslUser = context.Users.SingleOrDefault(x => x.UserId == studyTask.MsluserId && x.IsActive == true);

            var message = new WorkflowMessage
            {
                Subject = $"Study {GetFormattedStudy(study)} Submitted by user {GetFormattedUser(user)} dated {study.ANJU_AddDate} " +
                            $"is available for review to MSL on {studyTask.ANJU_AddDate}",
                Message = $"Study{GetFormattedStudy(study)} Submitted by user {GetFormattedUser(user)} dated {study.ANJU_AddDate} " +
                            $"is available for review to {GetFormattedUser(mslUser)} on {studyTask.ANJU_AddDate}",
                To = new List<string> { },
                Cc = new List<string> { }
            };
            WorkflowMail.SendEmail(message);
            context.Dispose();
        }

        public static void AssignWorkflowToMslAndPLSuccessMail(Operation op)
        {
            var context = new Navigate30Context();
            var study = context.NewStudy.SingleOrDefault(x => x.StudyId == op.OperationId);
            var studyTask = context.StudyTask.SingleOrDefault(x => x.StudyId == op.OperationId);
            var user = context.Users.SingleOrDefault(x => x.UserName == study.ANJU_AddedBy && x.IsActive == true);
            var mslUser = context.Users.SingleOrDefault(x => x.UserId == studyTask.MsluserId && x.IsActive == true);
            var plUser = context.Users.SingleOrDefault(x => x.UserId == studyTask.PluserId && x.IsActive == true);

            var message = new WorkflowMessage
            {
                Subject = $"Study {GetFormattedStudy(study)} Submitted by user {GetFormattedUser(user)} dated {study.ANJU_AddDate} " +
                            $"was assigned to MSL and PL for Review on {studyTask.ANJU_AddDate}",
                Message = $"Study{GetFormattedStudy(study)} Submitted by user {GetFormattedUser(user)} dated {study.ANJU_AddDate} " +
                            $"was assigned to {GetFormattedUser(mslUser)} & {GetFormattedUser(plUser)} for Review on {studyTask.ANJU_AddDate}",
                To = new List<string> { },
                Cc = new List<string> { }
            };
            WorkflowMail.SendEmail(message);
            context.Dispose();
        }

        public static void ResubmissionByPiMail(Operation op)
        {
            var context = new Navigate30Context();
            var study = context.NewStudy.SingleOrDefault(x => x.StudyId == op.OperationId);
            var studyTask = context.StudyTask.SingleOrDefault(x => x.StudyId == op.OperationId);
            var user = context.Users.SingleOrDefault(x => x.UserName == study.ANJU_AddedBy && x.IsActive == true);
            var mslUser = context.Users.SingleOrDefault(x => x.UserId == studyTask.MsluserId && x.IsActive == true);


            var message = new WorkflowMessage
            {
                Subject = $"Study {GetFormattedStudy(study)} ReSubmitted by user {GetFormattedUser(user)} dated {study.ANJU_AddDate} " +
                          $"was assigned to MSL and PL for Review on {studyTask.ANJU_AddDate}",
                Message = $"Study{GetFormattedStudy(study)} ReSubmitted by user {GetFormattedUser(user)} dated {study.ANJU_AddDate} " +
                          $"was assigned to {GetFormattedUser(mslUser)}  for Review on {studyTask.ANJU_AddDate}",
                To = new List<string> { },
                Cc = new List<string> { }
            };
            WorkflowMail.SendEmail(message);
            context.Dispose();
        }

        public static void CreateWorkflowSuccessMail(Guid processId)
        {
            var context = new Navigate30Context();
            var operationDetails = context.Operation.SingleOrDefault(x => x.Id == processId);
            var study = context.NewStudy.SingleOrDefault(x => x.StudyId == operationDetails.OperationId);
            var user = context.Users.SingleOrDefault(x => x.UserName == study.ANJU_AddedBy && x.IsActive == true);

            var message = new WorkflowMessage
            {
                Subject = $"New Study Submitted By User {GetFormattedUser(user)}, dated {study.ANJU_AddDate}",
                Message = $"New Study Submitted By User {GetFormattedUser(user)}, Named: {GetFormattedStudy(study)} dated {study.ANJU_AddDate}",
                To = new List<string> { },
                Cc = new List<string> { }
            };
            WorkflowMail.SendEmail(message);
            context.Dispose();
        }

        private static string GetFormattedStudy(NewStudy study) => $"{study.StudyType}-{study.TitleofTrial}";

        private static string GetFormattedUser(Users user) => $"{user.Salutation} {user.FirstName} {user.LastName}";

    }



}
