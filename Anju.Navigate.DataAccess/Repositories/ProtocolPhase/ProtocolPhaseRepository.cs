using Anju.Navigate.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anju.Navigate.DataAccess
{
    public class ProtocolPhaseRepository
    {
        #region Properties
        private readonly Navigate30Context dbContextNavigate;
        private readonly UnitOfWork unitOfWork;
        #endregion

        #region Constructor

        public ProtocolPhaseRepository(Navigate30Context dbContext)
        {
            this.dbContextNavigate = new Navigate30Context();

        }
        #endregion        

        #region Methods

        /// <summary>
        /// Update GMRCApproval Task Details
        /// </summary>
        /// <param name="objGMRCApprovalTask"></param>
        /// <returns>true/false</returns>
        public bool UpdateGMRCApprovalTaskDetails(Data.GMRCApprovalTask objGMRCApprovalTask)
        {
            int retVal = default(int);
            if (objGMRCApprovalTask != null)
            {
                var result = dbContextNavigate.GMRCApprovalTask.Where(x => x.StudyId == objGMRCApprovalTask.StudyId && x.TaskName == objGMRCApprovalTask.TaskName
                                                              && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();              

                if (result != null)
                {
                    result.IsTaskCompleted = objGMRCApprovalTask.IsTaskCompleted;
                    result.IsGearTaskCompleted = objGMRCApprovalTask.IsGearTaskCompleted;
                    result.Comments = objGMRCApprovalTask.Comments;
                    result.ContractType = objGMRCApprovalTask.ContractType;
                    result.ContractStatus = objGMRCApprovalTask.ContractStatus;                    
                    result.CurrentLocation = objGMRCApprovalTask.CurrentLocation;  
                    result.ContactName = objGMRCApprovalTask.ContactName; 
                    result.SubmissionDate = objGMRCApprovalTask.SubmissionDate; 
                    result.ExecutionDate = objGMRCApprovalTask.ExecutionDate; 
                    result.EffectiveDate = objGMRCApprovalTask.EffectiveDate; 
                    result.ExpirationDate = objGMRCApprovalTask.ExpirationDate;
                    result.Decision = objGMRCApprovalTask.Decision;
                    result.ANJU_ChangedBy = objGMRCApprovalTask.ANJU_ChangedBy;
                    result.ANJU_ChangeDate = DateTime.UtcNow;                   
                    retVal = dbContextNavigate.SaveChanges(result, new GMRCApprovalTask_H(), objGMRCApprovalTask.ANJU_ChangedBy, eAuditChangeType.Update);
                    if (retVal > 0)
                    {
                        if (objGMRCApprovalTask.TaskName == Utilities.Messages.SUBMITREQUIREDICFDOCUMENT)
                        {
                            var IsReviewICFExists = dbContextNavigate.GMRCApprovalTask.Where(x => x.StudyId == objGMRCApprovalTask.StudyId && x.TaskName == Utilities.Messages.REVIEWICF
                                                             && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                            if (IsReviewICFExists == null)
                            {
                                DataAccess.GMRCApprovalTask objInsertGMRCApprovalTask = new DataAccess.GMRCApprovalTask()
                                {
                                    StudyId = objGMRCApprovalTask.StudyId,
                                    TaskName = Utilities.Messages.REVIEWICF,
                                    IsTaskCompleted = false,
                                    AssignedTo = result.ANJU_AddedBy,
                                    IsActive = true,
                                    IsDeleted = false,
                                    ANJU_AddedBy = objGMRCApprovalTask.ANJU_AddedBy,
                                    ANJU_AddDate = DateTime.UtcNow
                                };                                
                                retVal = dbContextNavigate.SaveChanges(objInsertGMRCApprovalTask, new GMRCApprovalTask_H(), objGMRCApprovalTask.ANJU_AddedBy, eAuditChangeType.Insert);
                            }
                            else
                            {
                                IsReviewICFExists.IsTaskCompleted = false;
                                IsReviewICFExists.ANJU_ChangedBy = objGMRCApprovalTask.ANJU_ChangedBy;
                                IsReviewICFExists.ANJU_ChangeDate = DateTime.UtcNow;                                
                                retVal = dbContextNavigate.SaveChanges(IsReviewICFExists, new GMRCApprovalTask_H(), objGMRCApprovalTask.ANJU_ChangedBy, eAuditChangeType.Update);
                            }
                        }
                        else if(objGMRCApprovalTask.TaskName == Utilities.Messages.REVIEWICF)
                        {
                            if (objGMRCApprovalTask.Decision == Utilities.Messages.REVIEWICFDECISION)
                            {
                                var IsICFResubmissionExists = dbContextNavigate.GMRCApprovalTask.Where(x => x.StudyId == objGMRCApprovalTask.StudyId && x.TaskName == Utilities.Messages.ICFRESUBMISSIONREQUIRED
                                                              && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                                if (IsICFResubmissionExists == null)
                                {
                                    DataAccess.GMRCApprovalTask objInsertGMRCApprovalTask = new DataAccess.GMRCApprovalTask()
                                    {
                                        StudyId = objGMRCApprovalTask.StudyId,
                                        TaskName = Utilities.Messages.ICFRESUBMISSIONREQUIRED,
                                        IsTaskCompleted = false,
                                        AssignedTo = objGMRCApprovalTask.AssignedTo,
                                        IsActive = true,
                                        IsDeleted = false,
                                        ANJU_AddedBy = objGMRCApprovalTask.ANJU_AddedBy,
                                        ANJU_AddDate = DateTime.UtcNow
                                    };                                    
                                    retVal = dbContextNavigate.SaveChanges(objInsertGMRCApprovalTask, new GMRCApprovalTask_H(), objGMRCApprovalTask.ANJU_AddedBy, eAuditChangeType.Insert);
                                }
                                else
                                {
                                    IsICFResubmissionExists.IsTaskCompleted = false;
                                    IsICFResubmissionExists.ANJU_ChangedBy = objGMRCApprovalTask.ANJU_ChangedBy;
                                    IsICFResubmissionExists.ANJU_ChangeDate = DateTime.UtcNow;                                    
                                    retVal = dbContextNavigate.SaveChanges(IsICFResubmissionExists, new GMRCApprovalTask_H(), objGMRCApprovalTask.ANJU_ChangedBy, eAuditChangeType.Update);

                                }
                                if (retVal > 0)
                                {
                                    var ICFresult = dbContextNavigate.Documents.Where(x => x.StudyId == objGMRCApprovalTask.StudyId && x.SubModuleName == Utilities.Messages.ICFDocument
                                                              && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                                    if(ICFresult != null)
                                    {
                                        ICFresult.IsActive = false;
                                        ICFresult.IsDeleted = true;
                                        ICFresult.ANJU_ChangedBy = objGMRCApprovalTask.ANJU_ChangedBy;
                                        ICFresult.ANJU_ChangeDate = DateTime.UtcNow;                                       
                                        retVal = dbContextNavigate.SaveChanges(ICFresult, new Documents_H(), objGMRCApprovalTask.ANJU_ChangedBy, eAuditChangeType.Delete);
                                    }
                                    if(retVal > 0 )
                                    {
                                        var RedLindeICFresult = dbContextNavigate.Documents.Where(x => x.StudyId == objGMRCApprovalTask.StudyId && x.SubModuleName == Utilities.Messages.REDLINEDICFDOCUMENT
                                                              && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                                                                
                                        if (RedLindeICFresult != null)
                                        {
                                            RedLindeICFresult.SubModuleName = Utilities.Messages.ICFDocument;
                                            //RedLindeICFresult.IsSubmit = true;
                                            RedLindeICFresult.ANJU_ChangedBy = objGMRCApprovalTask.ANJU_ChangedBy;
                                            RedLindeICFresult.ANJU_ChangeDate = DateTime.UtcNow;                                            
                                            retVal = dbContextNavigate.SaveChanges(RedLindeICFresult, new Documents_H(), objGMRCApprovalTask.ANJU_ChangedBy, eAuditChangeType.Update);
                                        }

                                    }
                                }
                            }
                        }
                        else if (objGMRCApprovalTask.TaskName == Utilities.Messages.REVIEWPROTOCOL)
                        {
                            if (objGMRCApprovalTask.Decision == Utilities.Messages.REVIEWPROTOCOLDECISION)
                            {
                                var IsProtocolResubmissionExists = dbContextNavigate.GMRCApprovalTask.Where(x => x.StudyId == objGMRCApprovalTask.StudyId && x.TaskName == Utilities.Messages.RESUBMITPROTOCOL
                                                              && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                                if (IsProtocolResubmissionExists == null)
                                {
                                    DataAccess.GMRCApprovalTask objInsertGMRCApprovalTask = new DataAccess.GMRCApprovalTask()
                                    {
                                        StudyId = objGMRCApprovalTask.StudyId,
                                        TaskName = Utilities.Messages.RESUBMITPROTOCOL,
                                        IsTaskCompleted = false,
                                        AssignedTo = objGMRCApprovalTask.AssignedTo,
                                        IsActive = true,
                                        IsDeleted = false,
                                        ANJU_AddedBy = objGMRCApprovalTask.ANJU_AddedBy,
                                        ANJU_AddDate = DateTime.UtcNow
                                    };                                    
                                    retVal = dbContextNavigate.SaveChanges(objInsertGMRCApprovalTask, new GMRCApprovalTask_H(), objGMRCApprovalTask.ANJU_AddedBy, eAuditChangeType.Insert);
                                }
                                else
                                {
                                    IsProtocolResubmissionExists.IsTaskCompleted = false;
                                    IsProtocolResubmissionExists.ANJU_ChangedBy = objGMRCApprovalTask.ANJU_ChangedBy;
                                    IsProtocolResubmissionExists.ANJU_ChangeDate = DateTime.UtcNow;                                   
                                    retVal = dbContextNavigate.SaveChanges(IsProtocolResubmissionExists, new GMRCApprovalTask_H(), objGMRCApprovalTask.ANJU_ChangedBy, eAuditChangeType.Update);

                                }
                                if (retVal > 0)
                                {
                                    var Protocolresult = dbContextNavigate.Documents.Where(x => x.StudyId == objGMRCApprovalTask.StudyId && x.SubModuleName == Utilities.Messages.RequestedSupportProtocolDocuments
                                                              && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                                    if (Protocolresult != null)
                                    {
                                        Protocolresult.IsActive = false;
                                        Protocolresult.IsDeleted = true;
                                        Protocolresult.ANJU_ChangedBy = objGMRCApprovalTask.ANJU_ChangedBy;
                                        Protocolresult.ANJU_ChangeDate = DateTime.UtcNow;                                       
                                        retVal = dbContextNavigate.SaveChanges(Protocolresult, new Documents_H(), objGMRCApprovalTask.ANJU_ChangedBy, eAuditChangeType.Delete);
                                    }
                                    if (retVal > 0)
                                    {
                                        var RedLindeProtocolresult = dbContextNavigate.Documents.Where(x => x.StudyId == objGMRCApprovalTask.StudyId && x.SubModuleName == Utilities.Messages.REDLINEDREVIEWPROTOCOLDOCUMENT
                                                              && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();

                                        if (RedLindeProtocolresult != null)
                                        {
                                            //RedLindeProtocolresult.SubModuleName = Utilities.Messages.RequestedSupportProtocolDocuments;                                         
                                            RedLindeProtocolresult.ANJU_ChangedBy = objGMRCApprovalTask.ANJU_ChangedBy;
                                            RedLindeProtocolresult.ANJU_ChangeDate = DateTime.UtcNow;                                          
                                            retVal = dbContextNavigate.SaveChanges(RedLindeProtocolresult, new Documents_H(), objGMRCApprovalTask.ANJU_ChangedBy, eAuditChangeType.Update);
                                        }

                                    }
                                }
                            }
                            else
                            {
                                StudyTaskRepository objStudyTaskRepository = new StudyTaskRepository(dbContextNavigate);
                                bool taskcompletion = objStudyTaskRepository.UpdateMilestonecompletiondateDetails(objGMRCApprovalTask.StudyId, "Final Protocol", DateTime.UtcNow, objGMRCApprovalTask.ANJU_ChangedBy);
                                if (taskcompletion)
                                    retVal = 1;
                            }
                        }
                        else if (objGMRCApprovalTask.TaskName == Utilities.Messages.MANAGECONTRACTSTATUS)
                        {
                            if (result?.IsTaskCompleted == true)
                            {
                                StudyTaskRepository objStudyTaskRepository = new StudyTaskRepository(dbContextNavigate);
                                bool taskcompletion = objStudyTaskRepository.UpdateMilestonecompletiondateDetails(objGMRCApprovalTask.StudyId, "Contract Execution Date", DateTime.UtcNow, objGMRCApprovalTask.ANJU_ChangedBy);
                                if (taskcompletion)
                                    retVal = 1;
                            }

                        }
                            if ((objGMRCApprovalTask.TaskName != Utilities.Messages.FINALACTIVATIONREVIEW) && objGMRCApprovalTask.TaskName != Utilities.Messages.ACTIVATIONLETTER)
                        {
                            var TaskCount = dbContextNavigate.GMRCApprovalTask.Count(x => x.StudyId == objGMRCApprovalTask.StudyId && x.IsTaskCompleted == false && x.IsGearTaskCompleted == null);
                            if (TaskCount == 0)
                            {
                                DataAccess.GMRCApprovalTask objInsertGMRCApprovalTask = new DataAccess.GMRCApprovalTask()
                                {
                                    StudyId = objGMRCApprovalTask.StudyId,
                                    TaskName = Utilities.Messages.FINALACTIVATIONREVIEW,
                                    IsTaskCompleted = false,
                                    AssignedTo = objGMRCApprovalTask.ANJU_ChangedBy,
                                    IsActive = true,
                                    IsDeleted = false,
                                    ANJU_AddedBy = objGMRCApprovalTask.ANJU_ChangedBy,
                                    ANJU_AddDate = DateTime.UtcNow
                                };                                
                                retVal = dbContextNavigate.SaveChanges(objInsertGMRCApprovalTask, new GMRCApprovalTask_H(), objGMRCApprovalTask.ANJU_ChangedBy, eAuditChangeType.Insert);
                            }
                        }
                        else if (objGMRCApprovalTask.TaskName == Utilities.Messages.FINALACTIVATIONREVIEW)
                        {                  
                            if(retVal > 0)
                            {
                                var IsFinalActivationExists = dbContextNavigate.GMRCApprovalTask.Where(x => x.StudyId == objGMRCApprovalTask.StudyId && x.TaskName == Utilities.Messages.ACTIVATIONLETTER
                                                      && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                                if (IsFinalActivationExists == null)
                                {
                                    DataAccess.GMRCApprovalTask objInsertGMRCApprovalTask = new DataAccess.GMRCApprovalTask()
                                    {
                                        StudyId = objGMRCApprovalTask.StudyId,
                                        TaskName = Utilities.Messages.ACTIVATIONLETTER,
                                        IsTaskCompleted = false,
                                        AssignedTo = result.ANJU_AddedBy,
                                        IsActive = true,
                                        IsDeleted = false,
                                        ANJU_AddedBy = objGMRCApprovalTask.ANJU_AddedBy,
                                        ANJU_AddDate = DateTime.UtcNow
                                    };
                                    retVal = dbContextNavigate.SaveChanges(objInsertGMRCApprovalTask, new GMRCApprovalTask_H(), objGMRCApprovalTask.ANJU_AddedBy, eAuditChangeType.Insert);
                                }
                                else
                                {
                                    IsFinalActivationExists.IsTaskCompleted = false;
                                    IsFinalActivationExists.ANJU_ChangedBy = objGMRCApprovalTask.ANJU_ChangedBy;
                                    IsFinalActivationExists.ANJU_ChangeDate = DateTime.UtcNow;
                                    retVal = dbContextNavigate.SaveChanges(IsFinalActivationExists, new GMRCApprovalTask_H(), objGMRCApprovalTask.ANJU_ChangedBy, eAuditChangeType.Update);
                                }
                            }
                           

                        }                   
                      
                    }
                    if (retVal > 0)
                    {
                        var studyresult = dbContextNavigate.NewStudy.Where(x => x.StudyId == objGMRCApprovalTask.StudyId && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                        if (studyresult != null)
                        {
                            if (objGMRCApprovalTask.TaskName == Utilities.Messages.DRUGACTIVITIES)
                                studyresult.TaskStatus = Utilities.Messages.DRUGACTIVITIESCOMPLETED;
                            else if (objGMRCApprovalTask.TaskName == Utilities.Messages.FAIRMARKETDOCUMENT)
                                studyresult.TaskStatus = Utilities.Messages.FAIRMARKETDOCUMENTCOMPLETED;
                            else if (objGMRCApprovalTask.TaskName == Utilities.Messages.MANAGECONTRACTSTATUS)
                                studyresult.TaskStatus = Utilities.Messages.MANAGECONTRACTSTATUSCOMPLETED;
                            else if (objGMRCApprovalTask.TaskName == Utilities.Messages.SUBMITREQUIREDICFDOCUMENT)
                                studyresult.TaskStatus = Utilities.Messages.PENDINGREVIEWOFICF;
                            else if (objGMRCApprovalTask.TaskName == Utilities.Messages.REVIEWICF)
                            {
                                if (objGMRCApprovalTask.Decision == Utilities.Messages.REVIEWICFDECISION)                                
                                    studyresult.TaskStatus = Utilities.Messages.PENDINGREVIEWOFICF;                                
                                else                                
                                    studyresult.TaskStatus = Utilities.Messages.ICFAPPROVED;                                
                            }
                            else if (objGMRCApprovalTask.TaskName == Utilities.Messages.REVIEWPROTOCOL)
                            {
                                if (objGMRCApprovalTask.Decision == Utilities.Messages.REVIEWPROTOCOLDECISION)                                
                                    studyresult.TaskStatus = Utilities.Messages.PENDINGPROTOCOLRESUBMISSION;                                
                                else                                
                                    studyresult.TaskStatus = Utilities.Messages.PROTOCOLAPPROVED;                                
                            }
                            else if (objGMRCApprovalTask.TaskName == Utilities.Messages.FINALACTIVATIONREVIEW)
                            {
                                studyresult.TaskStatus = Utilities.Messages.PENDINGACTIVATIONLETTER;
                                studyresult.State = Utilities.Messages.FINALACTIVATIONREVIEWCOMPLETED;
                                studyresult.StudyActivationDate = objGMRCApprovalTask.SubmissionDate;
                            }
                            if (objGMRCApprovalTask.TaskName == Utilities.Messages.ACTIVATIONLETTER)
                            {
                                studyresult.Stage = Utilities.Messages.STUDYACTIVE;
                                studyresult.State = Utilities.Messages.STUDYACTIVESTATE;
                                studyresult.TaskStatus = Utilities.Messages.STUDYACTIVESTATUS;
                                studyresult.PITaskStatus = Utilities.Messages.STUDYACTIVE;

                                StudyTaskRepository objStudyTaskRepository = new StudyTaskRepository(dbContextNavigate);
                                bool taskcompletion = objStudyTaskRepository.UpdateMilestonecompletiondateDetails(objGMRCApprovalTask.StudyId, "Activation (Drug Shipment)", (DateTime)studyresult.StudyActivationDate, objGMRCApprovalTask.ANJU_ChangedBy);
                                if (taskcompletion)
                                    retVal = 1;
                            }                           

                            studyresult.ANJU_ChangedBy = objGMRCApprovalTask.ANJU_ChangedBy; ;
                            studyresult.ANJU_ChangeDate = DateTime.UtcNow;
                            retVal = dbContextNavigate.SaveChanges(studyresult, new NewStudy_H(), objGMRCApprovalTask.ANJU_ChangedBy, eAuditChangeType.Update);
                        }
                    }

                }
            }
            if (retVal > 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Update GMRCApproval Gear Task Details
        /// </summary>
        /// <param name="objGMRCApprovalTask"></param>
        /// <returns>true/false</returns>
        public bool UpdateGMRCApprovalGearTaskDetails(Data.GMRCApprovalTask objGMRCApprovalTask)
        {
            int retVal = default(int);
            if (objGMRCApprovalTask != null)
            {
                var result = dbContextNavigate.GMRCApprovalTask.Where(x => x.StudyId == objGMRCApprovalTask.StudyId && x.TaskName == objGMRCApprovalTask.TaskName
                                                              && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();

                if (result != null)
                {
                    result.IsTaskCompleted = objGMRCApprovalTask.IsTaskCompleted;
                    result.IsGearTaskCompleted = objGMRCApprovalTask.IsGearTaskCompleted;
                    result.Comments = objGMRCApprovalTask.Comments;
                    result.ContractType = objGMRCApprovalTask.ContractType;
                    result.ContractStatus = objGMRCApprovalTask.ContractStatus;
                    result.CurrentLocation = objGMRCApprovalTask.CurrentLocation;
                    result.ContactName = objGMRCApprovalTask.ContactName;
                    result.SubmissionDate = objGMRCApprovalTask.SubmissionDate;
                    result.ExecutionDate = objGMRCApprovalTask.ExecutionDate;
                    result.EffectiveDate = objGMRCApprovalTask.EffectiveDate;
                    result.ExpirationDate = objGMRCApprovalTask.ExpirationDate;
                    result.Decision = objGMRCApprovalTask.Decision;
                    result.IsClosureActivitiesCompleted = objGMRCApprovalTask.IsClosureActivitiesCompleted;
                    result.ANJU_ChangedBy = objGMRCApprovalTask.ANJU_ChangedBy;
                    result.ANJU_ChangeDate = DateTime.UtcNow;                   
                    retVal = dbContextNavigate.SaveChanges(result, new GMRCApprovalTask_H(), objGMRCApprovalTask.ANJU_ChangedBy, eAuditChangeType.Update);
                    if (retVal > 0)
                    {
                      
                        if (objGMRCApprovalTask.TaskName == Utilities.Messages.FINALSTUDYTASK || objGMRCApprovalTask.TaskName == Utilities.Messages.RESUBMITFINALSTUDYREPORT)
                        {

                            var IsdocumentsubmissionreviewExists = dbContextNavigate.GMRCApprovalTask.Where(x => x.StudyId == objGMRCApprovalTask.StudyId && x.TaskName == Utilities.Messages.DOCUMENTSUBMISSIONREVIEW
                                                          && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                            if (IsdocumentsubmissionreviewExists == null)
                            {
                                string TlUserName = dbContextNavigate.PLStudyReview.AsEnumerable()
                                               .Join(dbContextNavigate.Users.AsEnumerable(), pl => pl.TluserId, u => u.UserId,
                                               (pl, u) => new { pl, u })
                                               .Where(x => x.pl.StudyId == objGMRCApprovalTask.StudyId && x.pl.IsActive == true && x.pl.IsDeleted == false)
                                               .Select(x => x.u.UserName).FirstOrDefault();

                                DataAccess.GMRCApprovalTask objInsertGMRCApprovalTask = new DataAccess.GMRCApprovalTask()
                                {
                                    StudyId = objGMRCApprovalTask.StudyId,
                                    TaskName = Utilities.Messages.DOCUMENTSUBMISSIONREVIEW,
                                    IsTaskCompleted = false,
                                    IsGearTaskCompleted = null,
                                    AssignedTo = TlUserName,
                                    IsActive = true,
                                    IsDeleted = false,
                                    ANJU_AddedBy = objGMRCApprovalTask.ANJU_ChangedBy,
                                    ANJU_AddDate = DateTime.UtcNow
                                };                                
                                retVal = dbContextNavigate.SaveChanges(objInsertGMRCApprovalTask, new GMRCApprovalTask_H(), objGMRCApprovalTask.ANJU_ChangedBy, eAuditChangeType.Insert);
                            }
                            else
                            {
                                IsdocumentsubmissionreviewExists.IsTaskCompleted = false;
                                IsdocumentsubmissionreviewExists.IsGearTaskCompleted = null;
                                IsdocumentsubmissionreviewExists.ANJU_ChangedBy = objGMRCApprovalTask.ANJU_ChangedBy;
                                IsdocumentsubmissionreviewExists.ANJU_ChangeDate = DateTime.UtcNow;                               
                                retVal = dbContextNavigate.SaveChanges(IsdocumentsubmissionreviewExists, new GMRCApprovalTask_H(), objGMRCApprovalTask.ANJU_ChangedBy, eAuditChangeType.Update);

                            }
                            //if (objGMRCApprovalTask.TaskName == Utilities.Messages.RESUBMITFINALSTUDYREPORT)
                            //{
                            //    if (retVal > 0)
                            //    {
                            //        dbContextNavigate.Documents.Where(x => x.StudyId == objGMRCApprovalTask.StudyId && x.SubModuleName == Utilities.Messages.FINALSTUDYREPORT
                            //                             && x.IsActive == true && x.IsDeleted == false).ToList().ForEach(x => { x.ANJU_ChangedBy = objGMRCApprovalTask.ANJU_ChangedBy; x.ANJU_ChangeDate = DateTime.UtcNow; x.IsDeleted = true; x.IsActive = false; });
                            //    }
                            //}
                        }
                        else if (objGMRCApprovalTask.TaskName == Utilities.Messages.DOCUMENTSUBMISSIONREVIEW)
                        {
                            if (objGMRCApprovalTask.Decision == Utilities.Messages.DECISIONREJECTED)
                            {

                                var IsresubmitfinalstudyreportExists = dbContextNavigate.GMRCApprovalTask.Where(x => x.StudyId == objGMRCApprovalTask.StudyId && x.TaskName == Utilities.Messages.RESUBMITFINALSTUDYREPORT
                                                          && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();

                                if (IsresubmitfinalstudyreportExists == null)
                                {

                                    DataAccess.GMRCApprovalTask objInsertGMRCApprovalTask = new DataAccess.GMRCApprovalTask()
                                    {
                                        StudyId = objGMRCApprovalTask.StudyId,
                                        TaskName = Utilities.Messages.RESUBMITFINALSTUDYREPORT,
                                        IsTaskCompleted = false,
                                        IsGearTaskCompleted = null,
                                        AssignedTo = objGMRCApprovalTask.AssignedTo,
                                        IsActive = true,
                                        IsDeleted = false,
                                        ANJU_AddedBy = objGMRCApprovalTask.ANJU_ChangedBy,
                                        ANJU_AddDate = DateTime.UtcNow
                                    };                                    
                                    retVal = dbContextNavigate.SaveChanges(objInsertGMRCApprovalTask, new GMRCApprovalTask_H(), objGMRCApprovalTask.ANJU_ChangedBy, eAuditChangeType.Insert);
                                }
                                else
                                {
                                    IsresubmitfinalstudyreportExists.IsTaskCompleted = false;
                                    IsresubmitfinalstudyreportExists.IsGearTaskCompleted = null;
                                    IsresubmitfinalstudyreportExists.ANJU_ChangedBy = objGMRCApprovalTask.ANJU_ChangedBy;
                                    IsresubmitfinalstudyreportExists.ANJU_ChangeDate = DateTime.UtcNow;                              
                                    retVal = dbContextNavigate.SaveChanges(IsresubmitfinalstudyreportExists, new GMRCApprovalTask_H(), objGMRCApprovalTask.ANJU_ChangedBy, eAuditChangeType.Update);
                                }
                            }
                        }
                        if(objGMRCApprovalTask.TaskName == Utilities.Messages.TPSRRECONCILIATION)
                        {
                            StudyTaskRepository objStudyTaskRepository = new StudyTaskRepository(dbContextNavigate);
                            bool taskcompletion = objStudyTaskRepository.UpdateMilestonecompletiondateDetails(objGMRCApprovalTask.StudyId, "TPSR Reconciliation", DateTime.UtcNow, objGMRCApprovalTask.ANJU_ChangedBy);
                            if (taskcompletion)
                            {
                                var TaskCount = dbContextNavigate.GMRCApprovalTask.Count(x => x.StudyId == objGMRCApprovalTask.StudyId && x.IsTaskCompleted == false && x.IsGearTaskCompleted == true && x.IsActive == true && x.IsDeleted == false);
                                if (TaskCount == 0)
                                {
                                    string TlUserName = dbContextNavigate.PLStudyReview.AsEnumerable()
                                                 .Join(dbContextNavigate.Users.AsEnumerable(), pl => pl.TluserId, u => u.UserId,
                                                 (pl, u) => new { pl, u })
                                                 .Where(x => x.pl.StudyId == objGMRCApprovalTask.StudyId && x.pl.IsActive == true && x.pl.IsDeleted == false)
                                                 .Select(x => x.u.UserName).FirstOrDefault();
                                    var IsCloseStudyExist = dbContextNavigate.GMRCApprovalTask.Where(x => x.StudyId == objGMRCApprovalTask.StudyId && x.IsActive == true && x.IsDeleted == false && x.TaskName == Utilities.Messages.CLOSESTUDY).FirstOrDefault();

                                    if (IsCloseStudyExist == null)
                                    {
                                        DataAccess.GMRCApprovalTask objInsertGMRCApprovalTask = new DataAccess.GMRCApprovalTask()
                                        {
                                            StudyId = objGMRCApprovalTask.StudyId,
                                            TaskName = Utilities.Messages.CLOSESTUDY,
                                            IsTaskCompleted = false,
                                            IsGearTaskCompleted = true,
                                            AssignedTo = TlUserName,
                                            IsActive = true,
                                            IsDeleted = false,
                                            ANJU_AddedBy = objGMRCApprovalTask.ANJU_ChangedBy,
                                            ANJU_AddDate = DateTime.UtcNow
                                        };
                                        retVal = dbContextNavigate.SaveChanges(objInsertGMRCApprovalTask, new GMRCApprovalTask_H(), objGMRCApprovalTask.ANJU_ChangedBy, eAuditChangeType.Insert);
                                    }
                                    else
                                    {
                                        if (IsCloseStudyExist != null)
                                        {
                                            IsCloseStudyExist.IsGearTaskCompleted = true;
                                            IsCloseStudyExist.IsTaskCompleted = false;
                                            IsCloseStudyExist.ANJU_AddedBy = objGMRCApprovalTask.ANJU_ChangedBy;
                                            IsCloseStudyExist.ANJU_AddDate = DateTime.UtcNow;
                                            retVal = dbContextNavigate.SaveChanges(IsCloseStudyExist, new GMRCApprovalTask_H(), IsCloseStudyExist.ANJU_ChangedBy, eAuditChangeType.Update);
                                        }
                                    }
                                }
                            }
                            retVal = 1;
                        }
                        if (objGMRCApprovalTask.TaskName == Utilities.Messages.DRUGRECONCILIATION)
                        {
                            StudyTaskRepository objStudyTaskRepository = new StudyTaskRepository(dbContextNavigate);
                            bool taskcompletion = objStudyTaskRepository.UpdateMilestonecompletiondateDetails(objGMRCApprovalTask.StudyId, "Drug Reconciliation", DateTime.UtcNow, objGMRCApprovalTask.ANJU_ChangedBy);
                            if (taskcompletion)
                            {
                                var TaskCount = dbContextNavigate.GMRCApprovalTask.Count(x => x.StudyId == objGMRCApprovalTask.StudyId && x.IsTaskCompleted == false && x.IsGearTaskCompleted == true && x.IsActive == true && x.IsDeleted == false);
                                if (TaskCount == 0)
                                {
                                    string TlUserName = dbContextNavigate.PLStudyReview.AsEnumerable()
                                                 .Join(dbContextNavigate.Users.AsEnumerable(), pl => pl.TluserId, u => u.UserId,
                                                 (pl, u) => new { pl, u })
                                                 .Where(x => x.pl.StudyId == objGMRCApprovalTask.StudyId && x.pl.IsActive == true && x.pl.IsDeleted == false)
                                                 .Select(x => x.u.UserName).FirstOrDefault();
                                    var IsCloseStudyExist = dbContextNavigate.GMRCApprovalTask.Where(x => x.StudyId == objGMRCApprovalTask.StudyId && x.IsActive == true && x.IsDeleted == false && x.TaskName == Utilities.Messages.CLOSESTUDY).FirstOrDefault();

                                    if (IsCloseStudyExist == null)
                                    {
                                        DataAccess.GMRCApprovalTask objInsertGMRCApprovalTask = new DataAccess.GMRCApprovalTask()
                                        {
                                            StudyId = objGMRCApprovalTask.StudyId,
                                            TaskName = Utilities.Messages.CLOSESTUDY,
                                            IsTaskCompleted = false,
                                            IsGearTaskCompleted = true,
                                            AssignedTo = TlUserName,
                                            IsActive = true,
                                            IsDeleted = false,
                                            ANJU_AddedBy = objGMRCApprovalTask.ANJU_ChangedBy,
                                            ANJU_AddDate = DateTime.UtcNow
                                        };
                                        retVal = dbContextNavigate.SaveChanges(objInsertGMRCApprovalTask, new GMRCApprovalTask_H(), objGMRCApprovalTask.ANJU_ChangedBy, eAuditChangeType.Insert);
                                    }
                                    else
                                    {
                                        if (IsCloseStudyExist != null)
                                        {
                                            IsCloseStudyExist.IsGearTaskCompleted = true;
                                            IsCloseStudyExist.IsTaskCompleted = false;
                                            IsCloseStudyExist.ANJU_AddedBy = objGMRCApprovalTask.ANJU_ChangedBy;
                                            IsCloseStudyExist.ANJU_AddDate = DateTime.UtcNow;
                                            retVal = dbContextNavigate.SaveChanges(IsCloseStudyExist, new GMRCApprovalTask_H(), IsCloseStudyExist.ANJU_ChangedBy, eAuditChangeType.Update);
                                        }
                                    }
                                }
                            }
                                retVal = 1;
                        }
                        if (objGMRCApprovalTask.TaskName == Utilities.Messages.BUDGETRECONCILIATION)
                        {
                            StudyTaskRepository objStudyTaskRepository = new StudyTaskRepository(dbContextNavigate);
                            bool taskcompletion = objStudyTaskRepository.UpdateMilestonecompletiondateDetails(objGMRCApprovalTask.StudyId, "Budget Reconciliation", DateTime.UtcNow, objGMRCApprovalTask.ANJU_ChangedBy);
                            if (taskcompletion)
                            {
                                var TaskCount = dbContextNavigate.GMRCApprovalTask.Count(x => x.StudyId == objGMRCApprovalTask.StudyId && x.IsTaskCompleted == false && x.IsGearTaskCompleted == true && x.IsActive == true && x.IsDeleted == false);
                                if (TaskCount == 0)
                                {
                                    string TlUserName = dbContextNavigate.PLStudyReview.AsEnumerable()
                                                 .Join(dbContextNavigate.Users.AsEnumerable(), pl => pl.TluserId, u => u.UserId,
                                                 (pl, u) => new { pl, u })
                                                 .Where(x => x.pl.StudyId == objGMRCApprovalTask.StudyId && x.pl.IsActive == true && x.pl.IsDeleted == false)
                                                 .Select(x => x.u.UserName).FirstOrDefault();
                                    var IsCloseStudyExist = dbContextNavigate.GMRCApprovalTask.Where(x => x.StudyId == objGMRCApprovalTask.StudyId && x.IsActive == true && x.IsDeleted == false && x.TaskName == Utilities.Messages.CLOSESTUDY).FirstOrDefault();

                                    if (IsCloseStudyExist == null)
                                    {
                                        DataAccess.GMRCApprovalTask objInsertGMRCApprovalTask = new DataAccess.GMRCApprovalTask()
                                        {
                                            StudyId = objGMRCApprovalTask.StudyId,
                                            TaskName = Utilities.Messages.CLOSESTUDY,
                                            IsTaskCompleted = false,
                                            IsGearTaskCompleted = true,
                                            AssignedTo = TlUserName,
                                            IsActive = true,
                                            IsDeleted = false,
                                            ANJU_AddedBy = objGMRCApprovalTask.ANJU_ChangedBy,
                                            ANJU_AddDate = DateTime.UtcNow
                                        };
                                        retVal = dbContextNavigate.SaveChanges(objInsertGMRCApprovalTask, new GMRCApprovalTask_H(), objGMRCApprovalTask.ANJU_ChangedBy, eAuditChangeType.Insert);
                                    }
                                    else
                                    {
                                        if (IsCloseStudyExist != null)
                                        {
                                            IsCloseStudyExist.IsGearTaskCompleted = true;
                                            IsCloseStudyExist.IsTaskCompleted = false;
                                            IsCloseStudyExist.ANJU_AddedBy = objGMRCApprovalTask.ANJU_ChangedBy;
                                            IsCloseStudyExist.ANJU_AddDate = DateTime.UtcNow;
                                            retVal = dbContextNavigate.SaveChanges(IsCloseStudyExist, new GMRCApprovalTask_H(), IsCloseStudyExist.ANJU_ChangedBy, eAuditChangeType.Update);
                                        }
                                    }
                                }
                            }
                                retVal = 1;
                        }
                        if (objGMRCApprovalTask.TaskName == Utilities.Messages.POCLOSEOUTREQUESTED)
                        {
                            StudyTaskRepository objStudyTaskRepository = new StudyTaskRepository(dbContextNavigate);
                            bool taskcompletion = objStudyTaskRepository.UpdateMilestonecompletiondateDetails(objGMRCApprovalTask.StudyId, "PO Closeout Requested", DateTime.UtcNow, objGMRCApprovalTask.ANJU_ChangedBy);
                            if (taskcompletion)
                            {
                                var TaskCount = dbContextNavigate.GMRCApprovalTask.Count(x => x.StudyId == objGMRCApprovalTask.StudyId && x.IsTaskCompleted == false && x.IsGearTaskCompleted == true && x.IsActive == true && x.IsDeleted == false);
                                if (TaskCount == 0)
                                {
                                    string TlUserName = dbContextNavigate.PLStudyReview.AsEnumerable()
                                                 .Join(dbContextNavigate.Users.AsEnumerable(), pl => pl.TluserId, u => u.UserId,
                                                 (pl, u) => new { pl, u })
                                                 .Where(x => x.pl.StudyId == objGMRCApprovalTask.StudyId && x.pl.IsActive == true && x.pl.IsDeleted == false)
                                                 .Select(x => x.u.UserName).FirstOrDefault();
                                    var IsCloseStudyExist = dbContextNavigate.GMRCApprovalTask.Where(x => x.StudyId == objGMRCApprovalTask.StudyId && x.IsActive == true && x.IsDeleted == false && x.TaskName == Utilities.Messages.CLOSESTUDY).FirstOrDefault();

                                    if (IsCloseStudyExist == null)
                                    {
                                        DataAccess.GMRCApprovalTask objInsertGMRCApprovalTask = new DataAccess.GMRCApprovalTask()
                                        {
                                            StudyId = objGMRCApprovalTask.StudyId,
                                            TaskName = Utilities.Messages.CLOSESTUDY,
                                            IsTaskCompleted = false,
                                            IsGearTaskCompleted = true,
                                            AssignedTo = TlUserName,
                                            IsActive = true,
                                            IsDeleted = false,
                                            ANJU_AddedBy = objGMRCApprovalTask.ANJU_ChangedBy,
                                            ANJU_AddDate = DateTime.UtcNow
                                        };
                                        retVal = dbContextNavigate.SaveChanges(objInsertGMRCApprovalTask, new GMRCApprovalTask_H(), objGMRCApprovalTask.ANJU_ChangedBy, eAuditChangeType.Insert);
                                    }
                                    else
                                    {
                                        if (IsCloseStudyExist != null)
                                        {
                                            IsCloseStudyExist.IsGearTaskCompleted = true;
                                            IsCloseStudyExist.IsTaskCompleted = false;
                                            IsCloseStudyExist.ANJU_AddedBy = objGMRCApprovalTask.ANJU_ChangedBy;
                                            IsCloseStudyExist.ANJU_AddDate = DateTime.UtcNow;
                                            retVal = dbContextNavigate.SaveChanges(IsCloseStudyExist, new GMRCApprovalTask_H(), IsCloseStudyExist.ANJU_ChangedBy, eAuditChangeType.Update);
                                        }
                                    }
                                }
                            }
                                retVal = 1;
                        }
                        if (objGMRCApprovalTask.TaskName == Utilities.Messages.FINALSTUDYDATAREPORT)
                        {
                            StudyTaskRepository objStudyTaskRepository = new StudyTaskRepository(dbContextNavigate);
                            bool taskcompletion = objStudyTaskRepository.UpdateMilestonecompletiondateDetails(objGMRCApprovalTask.StudyId, "Final Study Data / Report", DateTime.UtcNow, objGMRCApprovalTask.ANJU_ChangedBy);
                            if (taskcompletion)
                                retVal = 1;
                        }
                    }
                    if (retVal > 0)
                    {
                        var studyresult = dbContextNavigate.NewStudy.Where(x => x.StudyId == objGMRCApprovalTask.StudyId && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                        if (studyresult != null)
                        {                          
                            if (objGMRCApprovalTask.TaskName == Utilities.Messages.DOCUMENTSUBMISSIONREVIEW)
                            {
                                if (objGMRCApprovalTask.Decision == Utilities.Messages.DECISIONREJECTED)
                                {
                                    studyresult.Stage = Utilities.Messages.STUDYCLOSEOUTINITIATED;
                                    studyresult.State = Utilities.Messages.CLOSEOUTACTIVITIESINPROGRESS;
                                    studyresult.TaskStatus = Utilities.Messages.RESUBMITFINALSTUDYREPORTSTATUS;                                   
                                }
                                else
                                {
                                    studyresult.Stage = Utilities.Messages.STUDYCLOSEOUTINITIATED;
                                    studyresult.State = Utilities.Messages.CLOSEOUTACTIVITIESINPROGRESS;
                                    studyresult.TaskStatus = Utilities.Messages.RESUBMITFINALSTUDYREPORTAPPROVALSTATUS;
                                }
                            }
                            else if(objGMRCApprovalTask.TaskName == Utilities.Messages.CLOSESTUDY)
                             {
                                studyresult.Stage = Utilities.Messages.CLOSEDSTUDYSTAGE;
                                studyresult.State = Utilities.Messages.CLOSEDSTUDYSTATE;
                                studyresult.TaskStatus = objGMRCApprovalTask.Decision;

                            }
                            else if(objGMRCApprovalTask.TaskName == Utilities.Messages.RESUBMITFINALSTUDYREPORT)
                            {
                                studyresult.Stage = Utilities.Messages.STUDYCLOSEOUTINITIATED;
                                studyresult.State = Utilities.Messages.CLOSEOUTACTIVITIESINPROGRESS;
                                studyresult.TaskStatus = Utilities.Messages.DOCUMENTRESUBMISSIONCOMPLETE;
                            }

                            studyresult.ANJU_ChangedBy = objGMRCApprovalTask.ANJU_ChangedBy; 
                            studyresult.ANJU_ChangeDate = DateTime.UtcNow;
                            retVal = dbContextNavigate.SaveChanges(studyresult, new NewStudy_H(), objGMRCApprovalTask.ANJU_ChangedBy, eAuditChangeType.Update);
                        }
                        if(retVal > 0 )
                        {
                            if (objGMRCApprovalTask.TaskName == Utilities.Messages.DOCUMENTSUBMISSIONREVIEW)
                            {
                                if (objGMRCApprovalTask.Decision == Utilities.Messages.DECISIONAPPROVED)
                                {                             
                                    var TaskCount = dbContextNavigate.GMRCApprovalTask.Count(x => x.StudyId == objGMRCApprovalTask.StudyId && x.IsTaskCompleted == false && x.IsGearTaskCompleted == true && x.IsActive == true && x.IsDeleted == false);
                                    if (TaskCount == 0)
                                    {
                                        string TlUserName = dbContextNavigate.PLStudyReview.AsEnumerable()
                                                     .Join(dbContextNavigate.Users.AsEnumerable(), pl => pl.TluserId, u => u.UserId,
                                                     (pl, u) => new { pl, u })
                                                     .Where(x => x.pl.StudyId == objGMRCApprovalTask.StudyId && x.pl.IsActive == true && x.pl.IsDeleted == false)
                                                     .Select(x => x.u.UserName).FirstOrDefault();
                                        var IsCloseStudyExist = dbContextNavigate.GMRCApprovalTask.Where(x => x.StudyId == objGMRCApprovalTask.StudyId && x.IsActive == true && x.IsDeleted == false && x.TaskName == Utilities.Messages.CLOSESTUDY).FirstOrDefault();

                                        if (IsCloseStudyExist == null)
                                        {
                                            DataAccess.GMRCApprovalTask objInsertGMRCApprovalTask = new DataAccess.GMRCApprovalTask()
                                            {
                                                StudyId = objGMRCApprovalTask.StudyId,
                                                TaskName = Utilities.Messages.CLOSESTUDY,
                                                IsTaskCompleted = false,
                                                IsGearTaskCompleted = true,
                                                AssignedTo = TlUserName,
                                                IsActive = true,
                                                IsDeleted = false,
                                                ANJU_AddedBy = objGMRCApprovalTask.ANJU_ChangedBy,
                                                ANJU_AddDate = DateTime.UtcNow
                                            };
                                            retVal = dbContextNavigate.SaveChanges(objInsertGMRCApprovalTask, new GMRCApprovalTask_H(), objGMRCApprovalTask.ANJU_ChangedBy, eAuditChangeType.Insert);
                                        }
                                        else
                                        {
                                            if (IsCloseStudyExist != null)
                                            {
                                                IsCloseStudyExist.IsGearTaskCompleted = true;
                                                IsCloseStudyExist.IsTaskCompleted = false;
                                                IsCloseStudyExist.ANJU_AddedBy = objGMRCApprovalTask.ANJU_ChangedBy;
                                                IsCloseStudyExist.ANJU_AddDate = DateTime.UtcNow;
                                                retVal = dbContextNavigate.SaveChanges(IsCloseStudyExist, new GMRCApprovalTask_H(), IsCloseStudyExist.ANJU_ChangedBy, eAuditChangeType.Update);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    var IsCloseStudyExist = dbContextNavigate.GMRCApprovalTask.Where(x => x.StudyId == objGMRCApprovalTask.StudyId && x.IsActive == true && x.IsDeleted == false && x.TaskName == Utilities.Messages.CLOSESTUDY).FirstOrDefault();
                                    if(IsCloseStudyExist != null)
                                    {
                                        IsCloseStudyExist.IsGearTaskCompleted = false;
                                        IsCloseStudyExist.IsTaskCompleted = false;
                                        IsCloseStudyExist.ANJU_AddedBy = objGMRCApprovalTask.ANJU_ChangedBy;
                                        IsCloseStudyExist.ANJU_AddDate = DateTime.UtcNow;
                                        retVal = dbContextNavigate.SaveChanges(IsCloseStudyExist, new GMRCApprovalTask_H(), IsCloseStudyExist.ANJU_ChangedBy, eAuditChangeType.Update);
                                    }                                    

                                }
                            }                       
                                                               
                        }
                    }

                }
            }
            if (retVal > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Update GMRCApproval task and Document details
        /// </summary>
        /// <param name="objGMRCApprovalTask"></param>
        /// <param name="objDocument"></param>
        /// <returns></returns>

        public bool UpdateGMRCApprovalTaskAndDocumentDetails(Data.GMRCApprovalTask objGMRCApprovalTask, Data.Documents objDocument)
        {
            int retVal = default(int);
            if (objGMRCApprovalTask != null)
            {
                var result = dbContextNavigate.GMRCApprovalTask.Where(x => x.StudyId == objGMRCApprovalTask.StudyId && x.TaskName == objGMRCApprovalTask.TaskName
                                                             && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                if(result != null)
                {
                    result.IsTaskCompleted = objGMRCApprovalTask.IsTaskCompleted;
                    result.ANJU_ChangedBy = objGMRCApprovalTask.ANJU_ChangedBy;
                    result.ANJU_ChangeDate = DateTime.UtcNow;                   
                    retVal = dbContextNavigate.SaveChanges(result, new GMRCApprovalTask_H(), objGMRCApprovalTask.ANJU_ChangedBy, eAuditChangeType.Update);
                    if (retVal > 0)
                    {
                        var Reviewresult = dbContextNavigate.GMRCApprovalTask.Where(x => x.StudyId == objGMRCApprovalTask.StudyId && x.TaskName == Utilities.Messages.REVIEWICF).FirstOrDefault();
                        if(Reviewresult != null)
                        {
                            Reviewresult.IsTaskCompleted = false;                            
                            retVal = dbContextNavigate.SaveChanges(Reviewresult, new GMRCApprovalTask_H(), objGMRCApprovalTask.ANJU_ChangedBy, eAuditChangeType.Update);

                        }

                        var ICFresult = dbContextNavigate.Documents.Where(x => x.StudyId == objGMRCApprovalTask.StudyId && x.SubModuleName == Utilities.Messages.ICFDocument && x.IsSubmit == null
                                                             && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                        if (ICFresult != null)
                        {
                            ICFresult.IsActive = false;
                            ICFresult.IsDeleted = true;
                            ICFresult.IsSubmit = null;
                            ICFresult.ANJU_ChangedBy = objGMRCApprovalTask.ANJU_ChangedBy;
                            ICFresult.ANJU_ChangeDate = DateTime.UtcNow;                          
                            retVal = dbContextNavigate.SaveChanges(ICFresult, new Documents_H(), objGMRCApprovalTask.ANJU_ChangedBy, eAuditChangeType.Delete);
                        }
                        if(retVal > 0 )
                        {
                            var ReUploadICFresult = dbContextNavigate.Documents.Where(x => x.StudyId == objGMRCApprovalTask.StudyId && x.SubModuleName == Utilities.Messages.ICFDocument && x.DocumentName == objDocument.DocumentName && x.IsSubmit == true
                                                           ).FirstOrDefault();
                            ReUploadICFresult.IsActive = objDocument.IsActive;
                            ReUploadICFresult.IsDeleted = objDocument.IsDeleted;
                            ReUploadICFresult.IsSubmit = null;
                            ReUploadICFresult.ANJU_ChangedBy = objDocument.ANJU_ChangedBy;
                            ReUploadICFresult.ANJU_ChangeDate = DateTime.UtcNow;                            
                            retVal = dbContextNavigate.SaveChanges(ReUploadICFresult, new Documents_H(), objGMRCApprovalTask.ANJU_ChangedBy, eAuditChangeType.Update);
                        }
                    }
                }
            }
            if (retVal > 0)
                return true;
            else
                return false;

        }

        /// <summary>
        /// Get Review Decision
        /// </summary>
        /// <returns></returns>
        public List<Data.SysCodeValues> GetReviewDecision()
        {
            var objAttribute = dbContextNavigate.SysCodeValues
                                .Where(x => x.ColumnName == Utilities.ConstDefaultValue.REVIEWDECISION)
                                .Select(x => new Data.SysCodeValues
                                {
                                    ColumnName =x.ColumnName,
                                    Code=x.Code
                                }).ToList();
            return objAttribute;
        }

        #endregion
    }
}
