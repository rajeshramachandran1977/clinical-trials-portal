using Anju.Navigate.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Anju.Navigate.DataAccess
{
    public class StudyTaskRepository
    {
        #region Properties
        private readonly Navigate30Context dbContextNavigate;

        private DateTime PreviousTaskDate;
        #endregion

        #region Constructor       
        public StudyTaskRepository(Navigate30Context dbContext)
        {
            dbContextNavigate = new Navigate30Context();

        }
        #endregion

        #region Methods
        /// <summary>
        /// Create and Update TaskDetails
        /// </summary>
        /// <param name="studyTask"></param>
        /// <param name="userName"></param>
        /// <param name="taskstatus"></param>
        /// <returns></returns>
        public bool CreateUpdateTaskDetails(Data.StudyTask studyTask, string userName, string taskstatus)
        {
            int retVal = default(int);
            if (studyTask != null)
            {
                DataAccess.StudyTask objStudyTask = new DataAccess.StudyTask()
                {
                    StudyId = studyTask.StudyId,
                    MsluserId = studyTask.MsluserId,
                    PluserId = studyTask.PluserId,
                    UpcomingTask = studyTask.UpcomingTask,
                    IsActive = true,
                    IsDeleted = false,
                    ANJU_AddedBy= userName,
                    ANJU_AddDate = DateTime.UtcNow
                };                             
                retVal = dbContextNavigate.SaveChanges(objStudyTask, new StudyTask_H(), userName, eAuditChangeType.Insert);
                if (retVal > 0)
                {
                    var result = dbContextNavigate.NewStudy.Where(x => x.StudyId == studyTask.StudyId).SingleOrDefault();
                    if (result != null)
                    {
                        result.State = Utilities.Messages.MSLPLASSIGNEMENTCOMPLETE;
                        result.TaskStatus = Utilities.Messages.PENDINGMSLCONCEPTREVIEW;
                        result.TaskName = Utilities.Messages.MSLLOIREVIEW;
                        result.ANJU_ChangedBy = userName;
                        result.ANJU_ChangeDate = DateTime.UtcNow;
                        retVal = dbContextNavigate.SaveChanges(result, new NewStudy_H(), userName, eAuditChangeType.Update);
                    }
                }

            }
            if (retVal > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        ///  Get the study Review Details
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns>searchResult</returns>        
        public List<Data.StudyReview> GetStudyReviewDetails(int studyId)
        {

            List<Data.StudyReview> lstStudyReviewData = new List<Data.StudyReview>();
            if (studyId > 0)
            {
                var searchResult = dbContextNavigate.NewStudy
                                   .Join(dbContextNavigate.StudyReview, Ns => Ns.StudyId, Sr => Sr.StudyId,
                                   (Ns, Sr) => new { Ns, Sr })
                                   .Join(dbContextNavigate.Users, t => t.Sr.MsluserId, u => u.UserId,
                                   (t, u) => new { t, u })
                                   .Where(w => w.t.Ns.StudyId == studyId && w.t.Ns.IsActive == true && w.t.Ns.IsDeleted == false)
                                   .Select(x => new Data.StudyReview
                                   {
                                       MsluserId = x.t.Sr.MsluserId,
                                       Franchise = x.t.Sr.Franchise ?? null,
                                       PrimaryIndication = x.t.Sr.PrimaryIndication ?? null,
                                       SecondaryIndication = x.t.Sr.SecondaryIndication ?? null,
                                       Institution = x.t.Sr.Institution ?? null,
                                       Decision = x.t.Sr.Decision ?? null,
                                       MsluserName = x.u.UserName
                                   }).ToList();

                return searchResult;

            }
            return lstStudyReviewData;
        }

        /// <summary>
        /// Create and Update MSLReview
        /// </summary>
        /// <param name="studyReview"></param>
        /// <returns>true/false</returns>
        public bool CreateUpdateMSLReview(Data.StudyReview studyReview)
        {
            int retVal = default(int);
            int ReviewId = 0;

            if (studyReview != null)
            {
                var result = dbContextNavigate.StudyReview.Where(x => x.StudyId == studyReview.StudyId).SingleOrDefault();
                if (result != null)
                {
                    ReviewId = result.ReviewId;
                    var userid = dbContextNavigate.Users.Where(x => x.UserName == studyReview.MsluserName).Select(y => y.UserId).FirstOrDefault();
                    result.Franchise = studyReview.Franchise;
                    result.MsluserId = Convert.ToInt32(userid);
                    result.PrimaryIndication = studyReview.PrimaryIndication;
                    result.SecondaryIndication = studyReview.SecondaryIndication;
                    result.Institution = studyReview.Institution;
                    result.Decision = studyReview.Decision;
                    result.ANJU_ChangedBy = studyReview.ANJU_AddedBy;
                    result.ANJU_ChangeDate = DateTime.UtcNow;
                    //dbContextNavigate.StudyReview.Update(result);
                    retVal = dbContextNavigate.SaveChanges(result, new StudyReview_H(), studyReview.ANJU_AddedBy, eAuditChangeType.Update);
                }
                else
                {
                    DataAccess.StudyReview objstudyReview = new DataAccess.StudyReview()
                    {
                        StudyId = studyReview.StudyId,
                        MsluserId = dbContextNavigate.Users.Where(x => x.UserName == studyReview.MsluserName).Select(y => y.UserId).FirstOrDefault(),
                        Franchise = studyReview.Franchise,
                        PrimaryIndication = studyReview.PrimaryIndication,
                        SecondaryIndication = studyReview.SecondaryIndication,
                        Institution = studyReview.Institution,
                        Decision = studyReview.Decision,
                        IsActive = true,
                        IsDeleted = false,
                        ANJU_AddedBy = studyReview.ANJU_AddedBy,
                        ANJU_AddDate = DateTime.UtcNow
                    };
                    //dbContextNavigate.StudyReview.Add(objstudyReview);
                    retVal = dbContextNavigate.SaveChanges(objstudyReview, new StudyReview_H(), studyReview.ANJU_AddedBy, eAuditChangeType.Insert);
                    ReviewId = objstudyReview.ReviewId;

                }
                if (ReviewId >= 1)
                {
                    var newStudyresult = dbContextNavigate.NewStudy.Where(x => x.StudyId == studyReview.StudyId).FirstOrDefault();
                    if (newStudyresult != null)
                    {
                        if (studyReview.Decision == Utilities.Messages.DECISIONRESUBMIT)
                        {
                            // newStudyresult.TaskName = Utilities.Messages.RETURNRESUBMITPROPOSAL;
                            newStudyresult.TaskName = "";
                             newStudyresult.PITaskStatus = Utilities.Messages.RESUBMITPROPOSAL;
                            newStudyresult.State = Utilities.Messages.PENDINGRESUBMISSION;
                            newStudyresult.TaskStatus = Utilities.Messages.MSLREQUESTEDRESUBMISSION;
                        }
                        else if (studyReview.Decision == Utilities.Messages.DECISIONACCEPTED)
                        {
                            newStudyresult.TaskName = Utilities.Messages.PLREVIEW;
                            newStudyresult.TaskStatus = Utilities.Messages.PENDINGPLCONCEPTREVIEW;
                            newStudyresult.State = Utilities.Messages.STATEMSLACCEPTED;
                        }

                        newStudyresult.ANJU_ChangedBy = studyReview.ANJU_AddedBy;
                        newStudyresult.ANJU_ChangeDate = DateTime.UtcNow;
                        retVal = dbContextNavigate.SaveChanges(newStudyresult, new NewStudy_H(), studyReview.ANJU_AddedBy, eAuditChangeType.Update);
                    }
                }
            }
            if (retVal > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Get list of document subtype according to typeid
        /// </summary>
        /// <param name="countryID"></param>
        /// <returns>list of states</returns>
        public List<Data.DocumentSubTypes> GetDocumentSubtypeByTypeID(int DocumentTypeId)
        {
            if (DocumentTypeId > 0)
            {
                var lstdocumentsubtypes = dbContextNavigate.DocumentSubTypes.Where(x => (x.DocumentTypeId == DocumentTypeId) && (x.IsActive == true) && (x.IsDeleted == false))
                                                        .Select(x => new Data.DocumentSubTypes
                                                        {
                                                            DocumentTypeId = x.DocumentTypeId,
                                                            Code = x.Code
                                                        }).ToList();
                return lstdocumentsubtypes;
            }
            else
                return new List<Data.DocumentSubTypes>();
        }
        /// <summary>
        /// Update Document Details
        /// </summary>
        /// <param name="document"></param>
        /// <returns>true/false</returns>
        public bool UpdateDocumentDetails(Data.Documents document)
        {
            int retVal = default(int);
            if (document != null)
            {
                var result = dbContextNavigate.Documents.Where(x => x.StudyId == document.StudyId && x.DocumentId == document.DocumentId
                                                              && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                if (result != null)
                {

                    result.DocumentName = document.DocumentName;
                    result.DocumentNameWithOutExtension = document.DocumentNameWithOutExtension;
                    result.DocumentStatus = document.DocumentStatus;
                    result.DocumentType = document.DocumentType;
                    result.DocumentSubType = document.DocumentSubType;
                    result.DocumentVersion = document.DocumentVersion;
                    result.OriginalDate = document.OriginalDate;
                    result.ExpirationDate = document.ExpirationDate;
                    result.ANJU_ChangedBy = document.ANJU_AddedBy;
                    result.ANJU_ChangeDate = DateTime.UtcNow;                    
                    retVal = dbContextNavigate.SaveChanges(result, new Documents_H(), document.ANJU_AddedBy, eAuditChangeType.Update);
                }
            }
            if (retVal > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Get Document Details
        /// </summary>
        /// <param name="document"></param>
        /// <returns>List</returns>
        public List<Data.Documents> GetDocumentDetails()
        {
            //var result = dbContextNavigate.Documents.Where(x => (x.StudyId ==studyId) )
            //                                                   .Select(x => new Data.Documents
            //                                                   {
            //                                                       DocumentName = x.DocumentName,
            //                                                       DocumentType = x.DocumentType,                                                                   
            //                                                   }).ToList();
            var result = dbContextNavigate.SysCodeValues.Where(x => x.ColumnName.ToUpper() == Utilities.ConstDefaultValue.ACTIVATIONDOCUMENT.ToUpper())
                                                            .Select(x => new Data.Documents
                                                            {
                                                                DocumentName = x.Code,
                                                                DocumentType = x.Description

                                                            }).ToList();
            
            return result;
        }

        /// <summary>
        /// Get Document by name Details
        /// </summary>
        /// <param name="document"></param>
        /// <returns>List</returns>
        public List<Data.Documents> GetDocumentbyName(string documentname, int studyid)
        {
            var result = dbContextNavigate.Documents.Where(x => (x.StudyId == studyid && x.DocumentName== documentname))
                                                               .Select(x => new Data.Documents
                                                               {
                                                                   DocumentName = x.DocumentName,
                                                                   DocumentType = x.DocumentType,
                                                                   SubModuleName=x.SubModuleName,
                                                                   Path=x.Path,
                                                                   StudyId=x.StudyId

                                                               }).ToList();


            return result;
        }

        /// <summary>
        /// Get DrugorCompounddetails Details by StudyId
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns>list of drugorcompound</returns>
        public List<Data.NewStudy> GetDrugorCompounddetailsDetailsByStudyId(int studyId)
        {
            if (studyId > 0)
            {
                var searchResult = dbContextNavigate.NewStudy.AsEnumerable()
                                  .GroupJoin(dbContextNavigate.DrugorCompounddetails.AsEnumerable(), Ns => Ns.StudyId, dc => dc.StudyId,
                                   (Ns, dc) => new { Ns, dc }).ToList()
                                   .Where(w => w.Ns.StudyId == studyId && w.Ns.IsActive == true && w.Ns.IsDeleted == false)
                                   .Select(x => new Data.NewStudy
                                   {
                                       StudyId = x.Ns.StudyId,
                                       DrugorCompounddetailsId = x.dc.Select(c => (int)c.DrugorCompounddetailsId).FirstOrDefault(),
                                       Primarydrug = x.dc?.Select(c => c.Primarydrug).FirstOrDefault() ?? null,
                                       Secondarydrug = x.dc?.Select(c => c.Secondarydrug).FirstOrDefault() ?? null,
                                       Tertiarydrug = x.dc?.Select(c => c.Tertiarydrug).FirstOrDefault() ?? null,
                                       SecondaryType = x.dc?.Select(c => c.SecondaryType).FirstOrDefault() ?? null,
                                       TertiaryaryType = x.dc?.Select(c => c.TertiaryaryType).FirstOrDefault() ?? null,

                                   }).ToList();
                return searchResult;
            }
            else
                return new List<Data.NewStudy>();
        }

        /// <summary>
        ///  Get the PL study Review Details
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns>searchResult</returns>        
        public List<Data.PLStudyReview> GetPLStudyReviewDetails(int studyId)
        {

            List<Data.PLStudyReview> lstPLStudyReviewData = new List<Data.PLStudyReview>();
            if (studyId > 0)
            {
                var searchResult = dbContextNavigate.NewStudy
                                   .Join(dbContextNavigate.PLStudyReview, Ns => Ns.StudyId, Sr => Sr.StudyId,
                                   (Ns, Sr) => new { Ns, Sr })
                                   .Join(dbContextNavigate.Users, t => t.Sr.PLuserId, u => u.UserId,
                                   (t, u) => new { t, u })
                                   .Where(w => w.t.Ns.StudyId == studyId && w.t.Ns.IsActive == true && w.t.Ns.IsDeleted == false)
                                   .Select(x => new Data.PLStudyReview
                                   {
                                       StudyId = x.t.Ns.StudyId,
                                       PLuserId = x.t.Sr.PLuserId?? 0,
                                       StudyDescriptors = x.t.Sr.StudyDescriptors ?? null,
                                       CompoundCategory1 = x.t.Sr.CompoundCategory1 ?? null,
                                       CompoundCategory2 = x.t.Sr.CompoundCategory2 ?? null,
                                       CompoundCategory3 = x.t.Sr.CompoundCategory3 ?? null,
                                       CompoundType1 = x.t.Sr.CompoundType1 ?? null,
                                       CompoundType2 = x.t.Sr.CompoundType2 ?? null,
                                       CompoundType3 = x.t.Sr.CompoundType3 ?? null,
                                       TrialCategorization = x.t.Sr.TrialCategorization ?? null,
                                       MonitoringInterval = x.t.Sr.MonitoringInterval ?? null,
                                       MaximumAllowableVists = x.t.Sr.MaximumAllowableVists ?? null,
                                       TluserId = x.t.Sr.TluserId,
                                       Comments = x.t.Sr.Comments ?? null,
                                       Decision = x.t.Sr.Decision ?? null,
                                       PLuserName = x.u.UserName
                                   }).ToList();

                return searchResult;

            }
            return lstPLStudyReviewData;
        }

        /// <summary>
        /// Create and Update PLReview
        /// </summary>
        /// <param name="plstudyReview"></param>
        /// <returns>true/false</returns>
        public bool CreateUpdatePLReview(Data.PLStudyReview plstudyReview)
        {
            int retVal = default(int);
            int plreviewId = 0;

            if (plstudyReview != null)
            {
                var result = dbContextNavigate.PLStudyReview.Where(x => x.StudyId == plstudyReview.StudyId).SingleOrDefault();
                if (result != null)
                {
                    plreviewId = result.PLreviewId;
                    var userid = dbContextNavigate.Users.Where(x => x.UserName == plstudyReview.PLuserName).Select(y => y.UserId).FirstOrDefault();
                    result.StudyDescriptors = plstudyReview.StudyDescriptors;
                    result.PLuserId = Convert.ToInt32(userid);
                    result.CompoundCategory1 = plstudyReview.CompoundCategory1;
                    result.CompoundCategory2 = plstudyReview.CompoundCategory2;
                    result.CompoundCategory3 = plstudyReview.CompoundCategory3;
                    result.CompoundType1 = plstudyReview.CompoundType1;
                    result.CompoundType2 = plstudyReview.CompoundType2;
                    result.CompoundType3 = plstudyReview.CompoundType3;
                    result.MonitoringInterval = plstudyReview.MonitoringInterval;
                    result.MaximumAllowableVists = plstudyReview.MaximumAllowableVists;
                    result.TluserId = plstudyReview.TluserId;
                    result.Comments = plstudyReview.Comments;
                    result.Decision = plstudyReview.Decision;
                    result.TrialCategorization = plstudyReview.TrialCategorization;
                    result.ANJU_ChangedBy = plstudyReview.ANJU_AddedBy;
                    result.ANJU_ChangeDate = DateTime.UtcNow;                   
                    retVal = dbContextNavigate.SaveChanges(result, new PLStudyReview_H(), plstudyReview.ANJU_AddedBy, eAuditChangeType.Update);
                }
                else
                {
                    DataAccess.PLStudyReview objPLstudyReview = new DataAccess.PLStudyReview()
                    {
                        StudyId = plstudyReview.StudyId,
                        PLuserId = dbContextNavigate.Users.Where(x => x.UserName == plstudyReview.PLuserName).Select(y => y.UserId).FirstOrDefault(),
                        StudyDescriptors = plstudyReview.StudyDescriptors,
                        CompoundCategory1 = plstudyReview.CompoundCategory1,
                        CompoundCategory2 = plstudyReview.CompoundCategory2,
                        CompoundCategory3 = plstudyReview.CompoundCategory3,
                        CompoundType1 = plstudyReview.CompoundType1,
                        CompoundType2 = plstudyReview.CompoundType2,
                        CompoundType3 = plstudyReview.CompoundType3,
                        MonitoringInterval = plstudyReview.MonitoringInterval,
                        MaximumAllowableVists = plstudyReview.MaximumAllowableVists,
                        TluserId = plstudyReview.TluserId,
                        Comments = plstudyReview.Comments,
                        Decision = plstudyReview.Decision,
                        TrialCategorization = plstudyReview.TrialCategorization,
                        IsActive = true,
                        IsDeleted = false,
                        ANJU_AddedBy = plstudyReview.ANJU_AddedBy,
                        ANJU_AddDate = DateTime.UtcNow
                    };                    
                    retVal = dbContextNavigate.SaveChanges(objPLstudyReview, new PLStudyReview_H(), plstudyReview.ANJU_AddedBy, eAuditChangeType.Insert);
                    plreviewId = objPLstudyReview.PLreviewId;

                }
                if (plreviewId >= 1)
                {
                    var newStudyresult = dbContextNavigate.NewStudy.Where(x => x.StudyId == plstudyReview.StudyId).FirstOrDefault();
                    if (newStudyresult != null)
                    {
                        if (plstudyReview.Decision == Utilities.Messages.DECISIONRESUBMIT)
                        {
                            newStudyresult.TaskName = Utilities.Messages.RETURNRESUBMITPROPOSAL;
                            //newStudyresult.PITaskStatus = Utilities.Messages.RESUBMITPROPOSAL;
                            newStudyresult.State = Utilities.Messages.PLRESUBMITSTATE;
                            newStudyresult.TaskStatus = Utilities.Messages.PLRESUBMITSTATUS;
                        }
                        else if (plstudyReview.Decision == Utilities.Messages.DECISIONACCEPTED)
                        {
                            newStudyresult.TaskName = Utilities.Messages.PLTASKNAME;
                            newStudyresult.TaskStatus = Utilities.Messages.PLACCEPTEDSTATUS;
                            newStudyresult.State = Utilities.Messages.PLACCEPTEDSTATE;
                        }

                        newStudyresult.ANJU_ChangedBy = plstudyReview.ANJU_AddedBy;
                        newStudyresult.ANJU_ChangeDate = DateTime.UtcNow;
                        retVal = dbContextNavigate.SaveChanges(newStudyresult, new NewStudy_H(), plstudyReview.ANJU_AddedBy, eAuditChangeType.Update);
                    }
                }
            }
            if (retVal > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Update PI Resubmission
        /// </summary>
        /// <param name="newStudy"></param>
        /// <returns>true/false</returns>
        public bool UpdatePIResubmission(Data.NewStudy newStudy)
        {
            int retVal = default(int);

            if (newStudy != null)
            {
                var newStudyresult = dbContextNavigate.NewStudy.Where(x => x.StudyId == newStudy.StudyId).FirstOrDefault();
                if (newStudyresult != null)
                {
                    if(newStudy.TaskName == Utilities.Messages.RETURNRESUBMITPROPOSAL && newStudy.State == Utilities.Messages.PLRESUBMITSTATE)
                    {
                        newStudyresult.PITaskStatus = Utilities.Messages.RESUBMITPROPOSAL;
                        newStudyresult.TaskName = Utilities.Messages.PENDINGRESUBMITPROPOSAL;
                        newStudyresult.State = Utilities.Messages.PENDINGRESUBMISSION;
                        newStudyresult.TaskStatus = Utilities.Messages.MSLREQUESTEDRESUBMISSION;
                    }
                    else if (newStudy.TaskName == Utilities.Messages.RETURNRESUBMITPROPOSAL && newStudy.State == Utilities.Messages.LMRCREQUESTEDRESUBMISSION)
                    {
                        newStudyresult.PITaskStatus = Utilities.Messages.RESUBMITPROPOSAL;
                        newStudyresult.TaskName = Utilities.Messages.RESUBMITPROPOSAL;
                        newStudyresult.State = Utilities.Messages.LMRCREQUESTEDRESUBMISSION;
                        newStudyresult.TaskStatus = Utilities.Messages.PENDINGRESUBMISSIONBYPI;
                    }
                    else if(newStudy.TaskName == Utilities.Messages.RETURNRESUBMITPROPOSAL && newStudy.State == Utilities.Messages.LMRCDECISIONREJECTEDSTATE)
                    {
                        
                        newStudyresult.TaskName = Utilities.Messages.LMRCDECISIONREJECTEDTASKNAME;
                        newStudyresult.State = Utilities.Messages.LMRCDECISIONREJECTEDSTATE;
                        newStudyresult.TaskStatus = Utilities.Messages.REJECTEDLMRCRESUBMISSION;
                    }
                    else if (newStudy.TaskName == Utilities.Messages.RETURNRESUBMITPROPOSALTOGMRC && newStudy.State == Utilities.Messages.GMRCREQUESTEDRESUBMISSION)
                    {
                        newStudyresult.PITaskStatus = Utilities.Messages.RESUBMITPROPOSAL;
                        newStudyresult.TaskName = Utilities.Messages.RESUBMITPROPOSAL;
                        newStudyresult.State = Utilities.Messages.GMRCREQUESTEDRESUBMISSION;
                        newStudyresult.TaskStatus = Utilities.Messages.PENDINGRESUBMISSIONBYPI;
                    }
                    else if (newStudy.TaskName == Utilities.Messages.RETURNRESUBMITPROPOSALTOGMRC && newStudy.State == Utilities.Messages.GMRCDECISIONREJECTEDSTATE)
                    {

                        newStudyresult.TaskName = Utilities.Messages.LMRCDECISIONREJECTEDTASKNAME;
                        newStudyresult.State = Utilities.Messages.GMRCDECISIONREJECTEDSTATE;
                        newStudyresult.TaskStatus = Utilities.Messages.REJECTEDGMRCRESUBMISSION; 
                    }
                    else if (newStudy.TaskName == Utilities.Messages.CONDITIONALLYAPPROVEDTASKNAME && newStudy.State == Utilities.Messages.GMRCAPPROVEDSTATE)
                    {
                        newStudyresult.TaskName = Utilities.Messages.GMRCAPPROVEDTASKNAME;
                        newStudyresult.State = Utilities.Messages.GMRCAPPROVEDSTATE;
                        newStudyresult.TaskStatus = Utilities.Messages.GMRCAPPROVEDSTATUS;
                    }
                    else if (newStudy.TaskName == Utilities.Messages.CONDITIONALLYAPPROVEDTASKNAME && newStudy.State == Utilities.Messages.LMRCRESUMEMETTING)
                    {
                        newStudyresult.State = Utilities.Messages.LMRCDECISIONAPPROVEDSTATE;
                        newStudyresult.TaskStatus = Utilities.Messages.LMRCDECISIONAPPROVEDSTATUS;
                        newStudyresult.TaskName = Utilities.Messages.LMRCDECISIONAPPROVEDTASKNAME;
                    }

                    else if (newStudy.TaskName == Utilities.Messages.RESUBMITPROPOSAL )
                    {
                        newStudyresult.PITaskStatus = Utilities.Messages.RESUBMITPROPOSAL;
                        newStudyresult.TaskName = Utilities.Messages.PENDINGRESUBMITPROPOSAL;
                    }
                    else if (newStudy.TaskName == Utilities.Messages.LMRCDECISIONREJECTEDTASKNAME)
                    {
                        // newStudyresult.PITaskStatus = Utilities.Messages.RESUBMITPROPOSAL;
                        newStudyresult.State = Utilities.Messages.LMRCDECISIONREJECTEDCONFIRMEDSTATE;
                        newStudyresult.TaskStatus = Utilities.Messages.LMRCDECISIONREJECTEDCONFIRMEDSTATUS;
                        newStudyresult.TaskName = Utilities.Messages.LMRCDECISIONREJECTEDCONFIRMEDTASKNAME;
                    }
                    else if(newStudy.TaskName == Utilities.Messages.LMRCRESUMEMETTING && newStudy.RecordType == "LocalMRC")
                    {
                        newStudyresult.State = Utilities.Messages.PLACCEPTEDSTATE;
                        newStudyresult.TaskStatus = Utilities.Messages.PLACCEPTEDSTATUS;
                        newStudyresult.TaskName = Utilities.Messages.PLTASKNAME;
                    }
                    else if (newStudy.TaskName == Utilities.Messages.LMRCRESUMEMETTING && newStudy.RecordType == "GlobalMRC")
                    {
                        newStudyresult.State = Utilities.Messages.LMRCDECISIONAPPROVEDSTATE;
                        newStudyresult.TaskStatus = Utilities.Messages.LMRCDECISIONAPPROVEDSTATUS;
                        newStudyresult.TaskName = Utilities.Messages.LMRCDECISIONAPPROVEDTASKNAME;
                    }

                    newStudyresult.ANJU_ChangedBy = newStudy.ANJU_ChangedBy;
                    newStudyresult.ANJU_ChangeDate = DateTime.UtcNow;
                    retVal = dbContextNavigate.SaveChanges(newStudyresult, new NewStudy_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Update);
                    if (retVal > 0)
                    {
                        if (newStudy.TaskName == Utilities.Messages.RETURNRESUBMITPROPOSAL && newStudy.State == Utilities.Messages.PLRESUBMITSTATE)
                        {
                            var result = dbContextNavigate.StudyReview.Where(x => x.StudyId == newStudy.StudyId ).SingleOrDefault();
                            if (result != null)
                            {
                               
                                result.ANJU_ChangedBy = newStudy.ANJU_ChangedBy;
                                result.ANJU_ChangeDate = DateTime.UtcNow;
                                //dbContextNavigate.StudyReview.Update(result);
                                retVal = dbContextNavigate.SaveChanges(result, new StudyReview_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Update);
                            }

                        }
                        else {
                            if (newStudy.RecordType == "LocalMRC")
                            {
                                var result = dbContextNavigate.MRCStudyReview.Where(x => x.StudyId == newStudy.StudyId && x.RecordType == "LocalMRC").SingleOrDefault();
                                if (result != null)
                                {
                                    if (newStudy.TaskName == Utilities.Messages.LMRCRESUMEMETTING && newStudy.RecordType == "LocalMRC")
                                        result.LocalMrcdecision = "";

                                    result.ANJU_ChangedBy = newStudy.ANJU_ChangedBy;
                                    result.ANJU_ChangeDate = DateTime.UtcNow;
                                    retVal = dbContextNavigate.SaveChanges(result, new MRCStudyReview_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Update);                                  
                                }
                            }
                            else if(newStudy.RecordType == "GlobalMRC")
                            {
                                var result = dbContextNavigate.MRCStudyReview.Where(x => x.StudyId == newStudy.StudyId && x.RecordType == "GlobalMRC").SingleOrDefault();
                                if (result != null)
                                {
                                    if (newStudy.TaskName == Utilities.Messages.LMRCRESUMEMETTING && newStudy.RecordType == "GlobalMRC")
                                        result.GlobalMrcdecision = "";

                                    result.ANJU_ChangedBy = newStudy.ANJU_ChangedBy;
                                    result.ANJU_ChangeDate = DateTime.UtcNow;
                                    retVal = dbContextNavigate.SaveChanges(result, new MRCStudyReview_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Update);
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
        ///  Get the MRC budget Details
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns>searchResult</returns>        
        public List<Data.MRCStudyReview> GetMRCBudgetDetails(int studyId)
        {

            List<Data.MRCStudyReview> lstMRCStudyReviewData = new List<Data.MRCStudyReview>();
            if (studyId > 0)
            {
                var searchResult = dbContextNavigate.NewStudy
                                   .Join(dbContextNavigate.PlannedTrialMilestoneDatesandEnrollment, Ns => Ns.StudyId, ptmd => ptmd.StudyId,
                                   (Ns, ptmd) => new { Ns, ptmd })
                                   .Join(dbContextNavigate.StudyReview, w => w.Ns.StudyId, sr => sr.StudyId, (w, sr) => new { w.Ns, sr, w.ptmd })
                                   .Join(dbContextNavigate.Users, t => t.sr.MsluserId, u => u.UserId,
                                   (t, u) => new { t, u })
                                   .Where(w => w.t.Ns.StudyId == studyId && w.t.Ns.IsActive == true && w.t.Ns.IsDeleted == false)
                                   .Select(x => new Data.MRCStudyReview
                                   {
                                       StudyId = x.t.Ns.StudyId,
                                       TotalPlannedNumberofPatients = x.t.ptmd.TotalPlannedNumberofPatients,
                                       MslUserName = x.u.UserName,
                                       AmountRequested = x.t.Ns.BudgetRequestedForTrial
                                   }).ToList();

                return searchResult;

            }
            return lstMRCStudyReviewData;
        }

        /// <summary>
        /// Create and Update MRCStudyReview
        /// </summary>
        /// <param name="mrcStudyReview"></param>
        /// <returns>true/false</returns>
        public bool CreateUpdateMRCStudyReview(Data.MRCStudyReview mrcStudyReview)
        {

            int retVal = default(int);
            int ReviewId = 0;

            if (mrcStudyReview != null)
            {
                var result = dbContextNavigate.MRCStudyReview.Where(x => x.StudyId == mrcStudyReview.StudyId && x.RecordType == mrcStudyReview.RecordType).FirstOrDefault();
                if (result != null)
                {
                    ReviewId = result.MRCReviewId;
                    result.RecordType = mrcStudyReview.RecordType;
                    result.LocalMrcdecision = mrcStudyReview.LocalMrcdecision;
                    result.LocalMrcdecisionComments = mrcStudyReview.LocalMrcdecisionComments;
                    result.LocalMrcdateOfDecision = mrcStudyReview.LocalMrcdateOfDecision;
                    result.LocalMrcdecisionMadeBy = mrcStudyReview.LocalMrcdecisionMadeBy;
                    result.GlobalMrcdecision = mrcStudyReview.GlobalMrcdecision;
                    result.GlobalMrcdecisionDate = mrcStudyReview.GlobalMrcdecisionDate;
                    result.Macsnumber = mrcStudyReview.Macsnumber;
                    result.StudyNumber = mrcStudyReview.StudyNumber;
                    result.ANJU_ChangedBy = mrcStudyReview.ANJU_ChangedBy;
                    result.ANJU_ChangeDate = DateTime.UtcNow;
                    retVal = dbContextNavigate.SaveChanges(result, new MRCStudyReview_H(), mrcStudyReview.ANJU_ChangedBy, eAuditChangeType.Update);
                }
                else
                {
                    DataAccess.MRCStudyReview objMRCStudyReview = new DataAccess.MRCStudyReview()
                    {
                        StudyId = mrcStudyReview.StudyId,
                        RecordType = mrcStudyReview.RecordType,
                        SaereconciliationFrequency = mrcStudyReview.SaereconciliationFrequency,
                        LocalMrcdecision = mrcStudyReview.LocalMrcdecision,
                        LocalMrcdecisionComments = mrcStudyReview.LocalMrcdecisionComments,
                        LocalMrcdateOfDecision = mrcStudyReview.LocalMrcdateOfDecision,
                        LocalMrcdecisionMadeBy = mrcStudyReview.LocalMrcdecisionMadeBy,
                        GlobalMrcdecision = mrcStudyReview.GlobalMrcdecision,
                        GlobalMrcdecisionDate = mrcStudyReview.GlobalMrcdecisionDate,
                        Macsnumber = mrcStudyReview.Macsnumber,
                        StudyNumber = mrcStudyReview.StudyNumber,
                        IsActive = true,
                        IsDeleted = false,
                        ANJU_AddedBy = mrcStudyReview.ANJU_AddedBy,
                        ANJU_AddDate = DateTime.UtcNow
                    };
                    retVal = dbContextNavigate.SaveChanges(objMRCStudyReview, new MRCStudyReview_H(), mrcStudyReview.ANJU_AddedBy, eAuditChangeType.Insert);
                    ReviewId = objMRCStudyReview.MRCReviewId;

                }
                if (ReviewId >= 1)
                {
                    if(mrcStudyReview.RecordType == Utilities.Messages.LocalMRC) {
                        var newStudyresult = dbContextNavigate.NewStudy.Where(x => x.StudyId == mrcStudyReview.StudyId).FirstOrDefault();
                        if (newStudyresult != null)
                        {
                            if (mrcStudyReview.LocalMrcdecision == Utilities.Messages.DECISIONREJECTED)
                            {
                                newStudyresult.TaskName = Utilities.Messages.LMRCDECISIONREJECTEDTASKNAME;
                                newStudyresult.State = Utilities.Messages.LMRCDECISIONREJECTEDSTATE;
                                newStudyresult.TaskStatus = Utilities.Messages.LMRCDECISIONREJECTEDSTATUS;
                            }
                            else if (mrcStudyReview.LocalMrcdecision == Utilities.Messages.DECISIONCONDITIONALAPPROVAL)
                            {
                                newStudyresult.TaskName = Utilities.Messages.RETURNRESUBMITPROPOSAL;
                                newStudyresult.TaskStatus = Utilities.Messages.PLRESUBMITSTATUS;
                                newStudyresult.State = Utilities.Messages.LMRCDECISIONCONDITIONALAPPROVALSTATE;
                            }
                            else if (mrcStudyReview.LocalMrcdecision == Utilities.Messages.DECISIONWITHDRAWN)
                            {
                                newStudyresult.TaskName = Utilities.Messages.LMRCDECISIONWITHDRAWNTASKNAME;
                                newStudyresult.State = Utilities.Messages.LMRCDECISIONWITHDRAWNSTATE;
                                newStudyresult.TaskStatus = Utilities.Messages.LMRCDECISIONWITHDRAWNSTATUS;
                            }
                            else if (mrcStudyReview.LocalMrcdecision == Utilities.Messages.DECISIONTABLED)
                            {
                                newStudyresult.TaskName = Utilities.Messages.LMRCDECISIONTABLEDTASKNAME;
                                newStudyresult.State = Utilities.Messages.LMRCDECISIONTABLEDSTATE;
                                newStudyresult.TaskStatus = Utilities.Messages.LMRCDECISIONTABLEDSTATUS;
                            }
                            else if (mrcStudyReview.LocalMrcdecision == Utilities.Messages.DECISIONAPPROVED)
                            {
                                newStudyresult.TaskName = Utilities.Messages.LMRCDECISIONAPPROVEDTASKNAME;
                                newStudyresult.TaskStatus = Utilities.Messages.LMRCDECISIONAPPROVEDSTATUS;
                                newStudyresult.State = Utilities.Messages.LMRCDECISIONAPPROVEDSTATE;
                            }

                            newStudyresult.ANJU_ChangedBy = mrcStudyReview.ANJU_AddedBy;
                            newStudyresult.ANJU_ChangeDate = DateTime.UtcNow;
                            retVal = dbContextNavigate.SaveChanges(newStudyresult, new NewStudy_H(), mrcStudyReview.ANJU_AddedBy, eAuditChangeType.Update);
                        }
                    }
                    else if(mrcStudyReview.RecordType == Utilities.Messages.GlobalMRC)
                    {
                        var newStudyresult = dbContextNavigate.NewStudy.Where(x => x.StudyId == mrcStudyReview.StudyId).FirstOrDefault();
                        if (newStudyresult != null)
                        {
                            if (mrcStudyReview.GlobalMrcdecision == Utilities.Messages.DECISIONREJECTED)
                            {
                                newStudyresult.TaskName = Utilities.Messages.LMRCDECISIONREJECTEDTASKNAME;
                                newStudyresult.State = Utilities.Messages.GMRCDECISIONREJECTEDSTATE;
                                newStudyresult.TaskStatus = Utilities.Messages.LMRCDECISIONREJECTEDSTATUS;
                            }
                            else if (mrcStudyReview.GlobalMrcdecision == Utilities.Messages.DECISIONWITHDRAWN)
                            {
                                newStudyresult.TaskName = Utilities.Messages.LMRCDECISIONWITHDRAWNTASKNAME;
                                newStudyresult.State = Utilities.Messages.GMRCDECISIONWITHDRAWNSTATE;
                                newStudyresult.TaskStatus = Utilities.Messages.LMRCDECISIONWITHDRAWNSTATUS;
                            }
                            else if (mrcStudyReview.GlobalMrcdecision == Utilities.Messages.DECISIONTABLED)
                            {
                                newStudyresult.TaskName = Utilities.Messages.LMRCDECISIONTABLEDTASKNAME;
                                newStudyresult.State = Utilities.Messages.GMRCDECISIONTABLEDSTATE;
                                newStudyresult.TaskStatus = Utilities.Messages.GMRCDECISIONTABLEDSTATUS;
                            }
                            else if (mrcStudyReview.GlobalMrcdecision == Utilities.Messages.DECISIONCONDITIONALAPPROVAL)
                            {
                                newStudyresult.TaskName = Utilities.Messages.RETURNRESUBMITPROPOSALTOGMRC;
                                newStudyresult.TaskStatus = Utilities.Messages.LMRCDECISIONREJECTEDSTATUS;
                                newStudyresult.State = Utilities.Messages.GMRCDECISIONCONDITIONALAPPROVALRESUBIMISSIONSTATE;
                                DataAccess.StudyProtocol objStudyProtocols = new DataAccess.StudyProtocol()
                                {
                                    StudyId = mrcStudyReview.StudyId,
                                    StudyProtocolnos = mrcStudyReview.Macsnumber,
                                    Organization = ConstDefaultValue.MACS,
                                    Module=ConstDefaultValue.RGMRC,
                                    IsActive = true,
                                    IsDeleted = false,
                                    ANJU_AddedBy = mrcStudyReview.ANJU_AddedBy ?? mrcStudyReview.ANJU_ChangedBy,
                                    ANJU_AddDate = DateTime.UtcNow,
                                };
                                retVal = dbContextNavigate.SaveChanges(objStudyProtocols, new StudyProtocol_H(), objStudyProtocols.ANJU_AddedBy, eAuditChangeType.Insert);

                            }
                            else if (mrcStudyReview.GlobalMrcdecision == Utilities.Messages.CONDITIONALLYAPPROVED)
                            {
                                newStudyresult.TaskName = Utilities.Messages.CONDITIONALLYAPPROVEDTASKNAME;
                                newStudyresult.TaskStatus = Utilities.Messages.LMRCDECISIONREJECTEDSTATUS;
                                newStudyresult.State = Utilities.Messages.CONDITIONALLYAPPROVEDSTATE;
                                PreviousTaskDate = (DateTime)mrcStudyReview.GlobalMrcdecisionDate;
                                InsertMileStoneDetails(newStudyresult.StudyId, PreviousTaskDate, mrcStudyReview.ANJU_AddedBy);
                                DataAccess.StudyProtocol objStudyProtocols = new DataAccess.StudyProtocol()
                                {
                                    StudyId = mrcStudyReview.StudyId,
                                    StudyProtocolnos = mrcStudyReview.StudyNumber,
                                    Organization = Utilities.ConfigValues.appName,
                                    Module = ConstDefaultValue.RGMRC,
                                    IsActive = true,
                                    IsDeleted = false,
                                    ANJU_AddedBy = mrcStudyReview.ANJU_AddedBy ?? mrcStudyReview.ANJU_ChangedBy,
                                    ANJU_AddDate = DateTime.UtcNow,
                                };
                                retVal = dbContextNavigate.SaveChanges(objStudyProtocols, new StudyProtocol_H(), objStudyProtocols.ANJU_AddedBy, eAuditChangeType.Insert);
                            }
                            else if (mrcStudyReview.GlobalMrcdecision == Utilities.Messages.DECISIONAPPROVED)
                            {                               
                                newStudyresult.State = Utilities.Messages.GMRCAPPROVEDSTATE;
                                newStudyresult.TaskStatus = Utilities.Messages.GMRCAPPROVEDSTATUS;
                                newStudyresult.TaskName = Utilities.Messages.GMRCAPPROVEDTASKNAME;
                                PreviousTaskDate = (DateTime)mrcStudyReview.GlobalMrcdecisionDate;
                                InsertMileStoneDetails(newStudyresult.StudyId, PreviousTaskDate, mrcStudyReview.ANJU_AddedBy);
                                DataAccess.StudyProtocol objStudyProtocols = new DataAccess.StudyProtocol()
                                {
                                    StudyId = mrcStudyReview.StudyId,
                                    StudyProtocolnos = mrcStudyReview.StudyNumber,
                                    Organization = Utilities.ConfigValues.appName,
                                    Module = ConstDefaultValue.RGMRC,
                                    IsActive = true,
                                    IsDeleted = false,
                                    ANJU_AddedBy = mrcStudyReview.ANJU_AddedBy ?? mrcStudyReview.ANJU_ChangedBy,
                                    ANJU_AddDate = DateTime.UtcNow,
                                };
                                retVal = dbContextNavigate.SaveChanges(objStudyProtocols, new StudyProtocol_H(), objStudyProtocols.ANJU_AddedBy, eAuditChangeType.Insert);
                            }

                            newStudyresult.ANJU_ChangedBy = mrcStudyReview.ANJU_AddedBy;
                            newStudyresult.ANJU_ChangeDate = DateTime.UtcNow;
                            retVal = dbContextNavigate.SaveChanges(newStudyresult, new NewStudy_H(), mrcStudyReview.ANJU_AddedBy, eAuditChangeType.Update);


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
        /// Insert Milestone details
        /// </summary>
        /// <param name="studyId"></param>
        /// <param name="decisionDate"></param>
        /// <param name="userName"></param>
        /// <returns>true/false</returns>
        public bool InsertMileStoneDetails(int studyId,DateTime decisionDate,string userName)
        {
            int retVal = default(int);
            var lstDefaultMileStone = dbContextNavigate.DefaultMileStone.Where(x => (x.IsActive == true) && (x.IsDeleted == false))
                                                              .Select(x => new Data.DefaultMileStone
                                                              {
                                                                  MilestoneType = x.MilestoneType,
                                                                  MilestoneName = x.MilestoneName,
                                                                  StudyPhase = x.StudyPhase,
                                                                  BusinessDays = x.BusinessDays,
                                                                  Dependency = x.Dependency
                                                              }).ToList();


            var IsExistCount = dbContextNavigate.Milestones.Count(x => x.StudyId == studyId && x.IsActive == true && x.IsDeleted == false);
            if(IsExistCount == 0 && lstDefaultMileStone.Count > 0) {
                for (int i = 0; i < lstDefaultMileStone.Count; i++)
                {
                    DataAccess.Milestones objMileStoneDetails = new DataAccess.Milestones()
                    {
                        StudyId = studyId,
                        Name = lstDefaultMileStone[i].MilestoneName?.Trim(),
                        Type = lstDefaultMileStone[i].MilestoneType?.Trim(),
                        Parameters = lstDefaultMileStone[i].BusinessDays.ToString(),
                        Phase = lstDefaultMileStone[i].StudyPhase.ToString(),
                        Dependency = lstDefaultMileStone[i].Dependency,
                        Milestonecompletiondate = lstDefaultMileStone[i].Dependency == 0 ? (DateTime?)decisionDate : null,
                        Estimatedcompletiondate = lstDefaultMileStone[i].MilestoneType?.Trim() == "Enrollment" ? CalculateEstimatedcompletiondateForEnrollment(PreviousTaskDate, studyId):CalculateEstimatedcompletiondate(decisionDate, lstDefaultMileStone[i].Dependency, lstDefaultMileStone[i].BusinessDays), 
                        MilestoneStatus = i== 0? Utilities.Messages.MILESTONESTATUS: Utilities.Messages.MILESTONEPENDINGSTATUS,
                        IsActive = true,
                        IsDeleted = false,
                        ANJU_AddedBy = userName,
                        ANJU_AddDate = DateTime.UtcNow
                    };                   
                    retVal = dbContextNavigate.SaveChanges(objMileStoneDetails, new Milestones_H(), userName, eAuditChangeType.Insert);
                }
                if (retVal > 0)
                    return true;
                else
                    return false;
            } 
            return true;
        }

        /// <summary>
        /// Calculate Estimated completion date
        /// </summary>
        /// <param name="decisionDate"></param>
        /// <param name="dependency"></param>
        /// <param name="businessDays"></param>
        /// <returns>DateTime</returns>
        private DateTime? CalculateEstimatedcompletiondate(DateTime decisionDate,int dependency,int businessDays)
        {
            var globalSettingsInfo = dbContextNavigate.GlobalSettings.Where(x => (x.IsActive == true && x.IsDeleted == false) && (x.GlobalKey.ToUpper() == Utilities.ConstDefaultValue.MTC_ENABLE_ESTIMATION_DATE_CALCULATION)).Select(x => new Data.GlobalSettings
                                                                   {
                                                                       GlobalKey = x.GlobalKey,
                                                                       GlobalValue = x.GlobalValue

                                                                   }).FirstOrDefault();

            var Holidays = new List<DateTime>();           
            var list = dbContextNavigate.GlobalSettings.Where(x => (x.IsActive == true && x.IsDeleted == false) && (x.GlobalKey.ToUpper() == Utilities.ConstDefaultValue.HOLIDAYDATELIST)).Select(x => new Data.GlobalSettings
            {
                GlobalValue = x.GlobalValue

            }).FirstOrDefault();
            if (!string.IsNullOrEmpty(list?.GlobalValue))
                Holidays = list.GlobalValue.Split(',').Select(d => Convert.ToDateTime(d)).Select(dt => dt.ToUniversalTime()).ToList();

            if (Convert.ToBoolean(globalSettingsInfo.GlobalValue) == true)
            {
                if (dependency == 0)
                {
                    PreviousTaskDate = DateTime.UtcNow;
                    return PreviousTaskDate;
                }
                else
                {
                    if (PreviousTaskDate != null)
                    {
                        var BusinessInfo = dbContextNavigate.GlobalSettings.Where(x => (x.IsActive == true && x.IsDeleted == false) && (x.GlobalKey.ToUpper() == Utilities.ConstDefaultValue.ENABLE_BUSINESS_DAY_CALCULATION)).Select(x => new Data.GlobalSettings
                        {
                            GlobalKey = x.GlobalKey,
                            GlobalValue = x.GlobalValue

                        }).FirstOrDefault();

                        if (Convert.ToBoolean(BusinessInfo.GlobalValue) == true)
                            PreviousTaskDate = PreviousTaskDate.AddBusinessDays(businessDays, Holidays);
                        else
                            PreviousTaskDate = PreviousTaskDate.AddCalenderDays(businessDays, Holidays);

                        return PreviousTaskDate;
                    }
                    return PreviousTaskDate;
                }
            }
            else
                return PreviousTaskDate;
        }

        /// <summary>
        /// Calculate Estimated completion date For Enrollment
        /// </summary>
        /// <param name="decisionDate"></param>
        /// <param name="studyId"></param>
        /// <returns>Datetime</returns>
        private DateTime? CalculateEstimatedcompletiondateForEnrollment(DateTime decisionDate, int studyId)
        {
            int? days = 0;

            List<DateTime> Holidays = new List<DateTime>();          

            var list = dbContextNavigate.GlobalSettings.Where(x => (x.IsActive == true && x.IsDeleted == false) && (x.GlobalKey.ToUpper() == Utilities.ConstDefaultValue.HOLIDAYDATELIST)).Select(x => new Data.GlobalSettings
            {
                GlobalValue = x.GlobalValue

            }).FirstOrDefault();

            if(!string.IsNullOrEmpty(list?.GlobalValue))
                Holidays = list.GlobalValue.Split(',').Select(d => Convert.ToDateTime(d)).Select(dt => dt.ToUniversalTime()).ToList();


            var plannedTrialMilestoneDetails = dbContextNavigate.PlannedTrialMilestoneDatesandEnrollment.Where(x => x.StudyId == studyId).FirstOrDefault();
            var patientAccrualDetails = dbContextNavigate.PatientAccrual.Where(x => x.StudyId == studyId && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
            var BusinessInfo = dbContextNavigate.GlobalSettings.Where(x => (x.IsActive == true && x.IsDeleted == false) && (x.GlobalKey.ToUpper() ==  Utilities.ConstDefaultValue.ENABLE_BUSINESS_DAY_CALCULATION)).Select(x => new Data.GlobalSettings
            {
                GlobalKey = x.GlobalKey,
                GlobalValue = x.GlobalValue

            }).FirstOrDefault();

            if (plannedTrialMilestoneDetails != null )
            {
                int? enrollmentrate = CalculateEnrollmentRate(studyId);
                if (enrollmentrate != null && enrollmentrate == 0)
                    enrollmentrate = 1;

                if (patientAccrualDetails != null && patientAccrualDetails?.LastPatientFirstVisit != null && patientAccrualDetails?.LastPatientLastVisit != null)
                    days = (((plannedTrialMilestoneDetails?.TotalPlannedNumberofPatients) -( patientAccrualDetails.TreatedPatients)) / enrollmentrate ) * 30;
                else
                    days = ((plannedTrialMilestoneDetails?.TotalPlannedNumberofPatients) / enrollmentrate) * 30;

                if (Convert.ToBoolean(BusinessInfo.GlobalValue) == true)
                    PreviousTaskDate = decisionDate.AddBusinessDays(days, Holidays);
                else
                    PreviousTaskDate = decisionDate.AddCalenderDays(days, Holidays);
            }          
            return PreviousTaskDate;
        }

        /// <summary>
        /// Calculate Enrollment Rate
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns>int</returns>
        private int? CalculateEnrollmentRate(int studyId)
        {
            int? rate = 0;
            int? monthdifference = 0;

            var plannedTrialMilestoneDetails = dbContextNavigate.PlannedTrialMilestoneDatesandEnrollment.Where(x => x.StudyId == studyId).FirstOrDefault();
            var patientAccrualDetails = dbContextNavigate.PatientAccrual.Where(x => x.StudyId == studyId && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
            if(patientAccrualDetails != null && patientAccrualDetails?.LastPatientFirstVisit != null && patientAccrualDetails?.LastPatientLastVisit != null)
            {                
                monthdifference = patientAccrualDetails?.LastPatientFirstVisit.DiffMonths(patientAccrualDetails?.LastPatientLastVisit);
                return rate = plannedTrialMilestoneDetails?.TotalPlannedNumberofPatients / (monthdifference);
            }
            else
            {
                monthdifference = plannedTrialMilestoneDetails?.TrialStart.DiffMonths(plannedTrialMilestoneDetails?.TrialEnd);
                return rate = plannedTrialMilestoneDetails?.TotalPlannedNumberofPatients / (monthdifference);
            }       

        }

        /// <summary>
        /// Update Milestone completion date Details
        /// </summary>
        /// <param name="studyID"></param>
        /// <param name="TaskName"></param>
        /// <param name="Milestonecompletiondate"></param>
        /// <returns>true/false</returns>
        public bool UpdateMilestonecompletiondateDetails(int studyID,string TaskName,DateTime Milestonecompletiondate,string userName)
        {
            int retVal = default(int);
            if (studyID > 0  && !string.IsNullOrEmpty(TaskName) && Milestonecompletiondate != null)
            {
                var result = dbContextNavigate.Milestones.Where(x => x.StudyId == studyID && x.Name == TaskName
                                                              && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                if (result != null)
                {

                    result.Milestonecompletiondate = Milestonecompletiondate;
                    result.MilestoneStatus = Utilities.Messages.MILESTONESTATUS;
                    result.ANJU_ChangedBy = userName;
                    result.ANJU_ChangeDate = DateTime.UtcNow;              
                    retVal = dbContextNavigate.SaveChanges(result, new Milestones_H(), userName, eAuditChangeType.Update);
                }
                PreviousTaskDate = Milestonecompletiondate;
                if (retVal > 0)
                {
                    var list = dbContextNavigate.GlobalSettings.Where(x => (x.IsActive == true && x.IsDeleted == false) && (x.GlobalKey.ToUpper() == Utilities.ConstDefaultValue.MTC_ENABLE_REALTIME_EDC)).Select(x => new Data.GlobalSettings
                    {
                        GlobalValue = x.GlobalValue

                    }).FirstOrDefault();

                    if (!string.IsNullOrEmpty(list?.GlobalValue) == true)
                    {
                        var incompletedtasks = dbContextNavigate.Milestones.Where(x => x.StudyId == studyID && !(x.Milestonecompletiondate.HasValue)
                                                              && x.IsActive == true && x.IsDeleted == false).OrderBy(x => x.MilestoneId).Select(x => new DataAccess.Milestones
                                                              {
                                                                  StudyId = x.StudyId,                                                                 
                                                                  Name = x.Name,
                                                                  Type = x.Type,
                                                                  Phase = x.Phase,
                                                                  Parameters = x.Parameters,
                                                                  Dependency = x.Dependency,
                                                                  Milestonecompletiondate = x.Milestonecompletiondate,
                                                                  Estimatedcompletiondate = x.Estimatedcompletiondate
                                                              }).ToList();

                        for (int i = 0; i < incompletedtasks.Count; i++)
                        {

                            var task = dbContextNavigate.Milestones.Where(x => x.StudyId == studyID && x.Name == incompletedtasks[i].Name
                                                             && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();
                            if (task != null)
                            {
                                task.Estimatedcompletiondate = task.Type?.Trim() == "Enrollment" ? CalculateEstimatedcompletiondateForEnrollment(PreviousTaskDate, studyID) : CalculateEstimatedcompletiondate(PreviousTaskDate, (int)task.Dependency, Convert.ToInt32(task.Parameters));
                                PreviousTaskDate = (DateTime)task.Estimatedcompletiondate;
                                task.ANJU_ChangedBy = userName;
                                task.ANJU_ChangeDate = DateTime.UtcNow;                                
                                retVal = dbContextNavigate.SaveChanges(task, new Milestones_H(), userName, eAuditChangeType.Update);
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
        /// Get the MRC  Details
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns>searchResult</returns>        
        public List<Data.MRCStudyReview> GetMRCDetails(int studyId)
        {

            List<Data.MRCStudyReview> lstMRCReviewData = new List<Data.MRCStudyReview>();
            if (studyId > 0)
            {
                var searchResult = dbContextNavigate.NewStudy
                                   .Join(dbContextNavigate.MRCStudyReview, Ns => Ns.StudyId, mrc => mrc.StudyId,
                                   (Ns, mrc) => new { Ns, mrc })
                                   .Where(w => w.Ns.StudyId == studyId && w.Ns.IsActive == true && w.Ns.IsDeleted == false && w.mrc.IsActive == true && w.mrc.RecordType == "LocalMRC")
                                   .Select(x => new Data.MRCStudyReview
                                   {
                                       StudyId = x.Ns.StudyId,
                                       LocalMrcdecision = x.mrc.LocalMrcdecision,
                                       MRCDecisionRejectedBy = x.mrc.MRCDecisionRejectedBy,
                                       MRCRejectedDeliveryMethod = x.mrc.MRCRejectedDeliveryMethod,
                                       MRCDecisionWithdrawalBy = x.mrc.MRCDecisionWithdrawalBy,
                                       LocalMrcdecisionMadeBy = x.mrc.LocalMrcdecisionMadeBy,
                                       MRCWithdrawalDeliveryMethod = x.mrc.MRCWithdrawalDeliveryMethod

                                   }).ToList();

                return searchResult;

            }
            return lstMRCReviewData;
        }

        /// <summary>
        /// Create Rejected MRC StudyReview
        /// </summary>
        /// <param name="mrcStudyReview"></param>
        /// <returns></returns>
        public bool CreateRejectedMRCStudyReview(Data.MRCStudyReview mrcStudyReview)
        {
            int retVal = default(int);            

            if (mrcStudyReview != null)
            {
                var result = dbContextNavigate.MRCStudyReview.Where(x => x.StudyId == mrcStudyReview.StudyId && x.RecordType == mrcStudyReview.RecordType).SingleOrDefault();
                if (result != null)
                {
                    result.MRCDecisionRejectedBy = mrcStudyReview.MRCDecisionRejectedBy;
                    result.MRCRejectedDeliveryMethod = mrcStudyReview.MRCRejectedDeliveryMethod;                   
                    result.ANJU_ChangedBy = mrcStudyReview.ANJU_ChangedBy;
                    result.ANJU_ChangeDate = DateTime.UtcNow;
                    retVal = dbContextNavigate.SaveChanges(result, new MRCStudyReview_H(), mrcStudyReview.ANJU_ChangedBy, eAuditChangeType.Update);
                    if (retVal > 0)
                    {
                        var newStudyresult = dbContextNavigate.NewStudy.Where(x => x.StudyId == mrcStudyReview.StudyId).FirstOrDefault();
                        if (newStudyresult != null)
                        {
                            if (newStudyresult.TaskName == Utilities.Messages.LMRCDECISIONREJECTEDCONFIRMEDTASKNAME)
                            {
                                newStudyresult.Stage = Utilities.Messages.LMRCDECISIONREJECTEDSTAGE;
                                newStudyresult.State = Utilities.Messages.LMRCDECISIONREJECTEDSTATECONFIRMED;
                                newStudyresult.TaskStatus = Utilities.Messages.LMRCDECISIONREJECTEDSTATUSCONFIRMED;
                                newStudyresult.PITaskStatus = Utilities.Messages.LMRCDECISIONREJECTEDSTAGE;
                                newStudyresult.TaskName = Utilities.Messages.LMRCDECISIONREJECTEDSTAGE;
                            }
                            newStudyresult.ANJU_ChangedBy = mrcStudyReview.ANJU_ChangedBy;
                            newStudyresult.ANJU_ChangeDate = DateTime.UtcNow;
                            retVal = dbContextNavigate.SaveChanges(newStudyresult, new NewStudy_H(), mrcStudyReview.ANJU_ChangedBy, eAuditChangeType.Update);
                        }
                    }
                }
                if (retVal > 0)
                    return true;
                else
                    return false;

            }
            else
                return false;
        }

        /// <summary>
        /// Create Withdrawal MRC StudyReview
        /// </summary>
        /// <param name="mrcStudyReview"></param>
        /// <returns></returns>
        public bool CreateWithdrawalMRCStudyReview(Data.MRCStudyReview mrcStudyReview)
        {
            int retVal = default(int);

            if (mrcStudyReview != null)
            {
                var result = dbContextNavigate.MRCStudyReview.Where(x => x.StudyId == mrcStudyReview.StudyId && x.RecordType == mrcStudyReview.RecordType).SingleOrDefault();
                if (result != null)
                {
                    result.MRCDecisionWithdrawalBy = mrcStudyReview.MRCDecisionWithdrawalBy;
                    result.MRCWithdrawalDeliveryMethod = mrcStudyReview.MRCWithdrawalDeliveryMethod;
                    result.ANJU_ChangedBy = mrcStudyReview.ANJU_ChangedBy;
                    result.ANJU_ChangeDate = DateTime.UtcNow;
                    retVal = dbContextNavigate.SaveChanges(result, new MRCStudyReview_H(), mrcStudyReview.ANJU_ChangedBy, eAuditChangeType.Update);
                    if (retVal > 0)
                    {
                        var newStudyresult = dbContextNavigate.NewStudy.Where(x => x.StudyId == mrcStudyReview.StudyId).FirstOrDefault();
                        if (newStudyresult != null)
                        {
                            if (newStudyresult.TaskName == Utilities.Messages.LMRCDECISIONWITHDRAWNTASKNAME)
                            {
                                newStudyresult.Stage = Utilities.Messages.DECISIONWITHDRAWN;
                                newStudyresult.State = Utilities.Messages.LMRCDECISIONWITHDRAWNCONFIRMEDSTATE;
                                newStudyresult.TaskStatus = Utilities.Messages.LMRCDECISIONWITHDRAWNCONFIRMEDSTATUS;
                                newStudyresult.PITaskStatus = Utilities.Messages.DECISIONWITHDRAWN;
                                newStudyresult.TaskName = Utilities.Messages.DECISIONWITHDRAWN;
                            }
                            newStudyresult.ANJU_ChangedBy = mrcStudyReview.ANJU_ChangedBy;
                            newStudyresult.ANJU_ChangeDate = DateTime.UtcNow;
                            retVal = dbContextNavigate.SaveChanges(newStudyresult, new NewStudy_H(), mrcStudyReview.ANJU_ChangedBy, eAuditChangeType.Update);
                        }
                    }
                }
                if (retVal > 0)
                    return true;
                else
                    return false;

            }
            else
                return false;
        }
        
        /// <summary>
        /// Update MRC StudyReview
        /// </summary>
        /// <param name="mrcStudyReview"></param>
        /// <returns></returns>
        public bool UpdateMRCStudyReview(Data.MRCStudyReview mrcStudyReview,string piUserName)
        {
            int retVal = default(int);
            int? budget = 0;

            if (mrcStudyReview != null)
            {
                var result = dbContextNavigate.MRCStudyReview.Where(x => x.StudyId == mrcStudyReview.StudyId && x.RecordType == mrcStudyReview.RecordType).FirstOrDefault();
                if (result != null)
                {
                    result.GlobalMrcdecision = mrcStudyReview.GlobalMrcdecision;
                    result.MRCWithdrawalDeliveryMethod = mrcStudyReview.MRCWithdrawalDeliveryMethod;
                    result.ANJU_ChangedBy = mrcStudyReview.ANJU_ChangedBy;
                    result.ANJU_ChangeDate = DateTime.UtcNow;
                    retVal = dbContextNavigate.SaveChanges(result, new MRCStudyReview_H(), mrcStudyReview.ANJU_ChangedBy, eAuditChangeType.Update);
                    if (retVal > 0)
                    {
                        var lstApprovaldocuments = dbContextNavigate.SysCodeValues.Where(x => (x.ColumnName.ToUpper().Trim() == Utilities.Messages.GMRCAPPROVALTASKS) && (x.IsActive == true) && (x.IsDeleted == false))
                                                               .Select(x => new Data.SysCodeValues
                                                               {
                                                                   CodeId = x.CodeId,
                                                                   Code = x.Code.Trim(),
                                                                   Description = x.Description.Trim()
                                                               }).ToList();


                        foreach (string taskName in lstApprovaldocuments.Select(Code => Code.Code).ToList())
                        {
                            if (taskName == Utilities.Messages.FAIRMARKETDOCUMENT)
                            {
                                var study = dbContextNavigate.NewStudy.Where(x => x.StudyId == mrcStudyReview.StudyId).FirstOrDefault();
                                budget = study.BudgetRequestedForTrial;

                                if (Convert.ToInt64(study.BudgetRequestedForTrial) > 0)
                                {
                                    DataAccess.GMRCApprovalTask objGMRCApprovalTask = new DataAccess.GMRCApprovalTask()
                                    {
                                        StudyId = mrcStudyReview.StudyId,
                                        TaskName = taskName,
                                        IsTaskCompleted = false,
                                        AssignedTo = mrcStudyReview.ANJU_ChangedBy,
                                        IsActive = true,
                                        IsDeleted = false,
                                        ANJU_AddedBy = mrcStudyReview.ANJU_AddedBy,
                                        ANJU_AddDate = result.GlobalMrcdecisionDate
                                    };                                    
                                    retVal = dbContextNavigate.SaveChanges(objGMRCApprovalTask, new GMRCApprovalTask_H(), mrcStudyReview.ANJU_AddedBy, eAuditChangeType.Insert);
                                }
                            }
                            else
                            {
                                DataAccess.GMRCApprovalTask objGMRCApprovalTask = new DataAccess.GMRCApprovalTask()
                                {
                                    StudyId = mrcStudyReview.StudyId,
                                    TaskName = taskName,
                                    IsTaskCompleted = false,
                                    AssignedTo = mrcStudyReview.ANJU_ChangedBy,
                                    IsActive = true,
                                    IsDeleted = false,
                                    ANJU_AddedBy = mrcStudyReview.ANJU_AddedBy,
                                    ANJU_AddDate = result.GlobalMrcdecisionDate
                                };                                
                                retVal = dbContextNavigate.SaveChanges(objGMRCApprovalTask, new GMRCApprovalTask_H(), mrcStudyReview.ANJU_AddedBy, eAuditChangeType.Insert);
                            }
                        }
                        if (retVal > 0)
                        {
                            var lstpidocuments = dbContextNavigate.SysCodeValues.Where(x => (x.ColumnName.ToUpper().Trim() == Utilities.Messages.PIAPPROVALTASKS) && (x.IsActive == true) && (x.IsDeleted == false))
                                                     .Select(x => new Data.SysCodeValues
                                                     {
                                                         CodeId = x.CodeId,
                                                         Code = x.Code.Trim(),
                                                         Description = x.Description.Trim()
                                                     }).ToList();

                            foreach (string taskName in lstpidocuments.Select(Code => Code.Code).ToList())
                            {
                                DataAccess.GMRCApprovalTask objGMRCApprovalTask = new DataAccess.GMRCApprovalTask()
                                {
                                    StudyId = mrcStudyReview.StudyId,
                                    TaskName = taskName,
                                    IsTaskCompleted = false,
                                    AssignedTo = piUserName,
                                    IsActive = true,
                                    IsDeleted = false,
                                    ANJU_AddedBy = mrcStudyReview.ANJU_AddedBy,
                                    ANJU_AddDate = result.GlobalMrcdecisionDate
                                };                                
                                retVal = dbContextNavigate.SaveChanges(objGMRCApprovalTask, new GMRCApprovalTask_H(), mrcStudyReview.ANJU_AddedBy, eAuditChangeType.Insert);
                            }
                        }

                        if (retVal > 0)
                            {
                            var newStudyresult = dbContextNavigate.NewStudy.Where(x => x.StudyId == mrcStudyReview.StudyId).FirstOrDefault();
                            if (newStudyresult != null)
                            {
                                if (newStudyresult.TaskName == Utilities.Messages.GMRCAPPROVEDTASKNAME)
                                {
                                    newStudyresult.Stage = Utilities.Messages.DECISIONAPPROVED;
                                    newStudyresult.State = Utilities.Messages.GMRCPREACTIVITIESINPROGRESS;
                                    if (budget > 0)
                                        newStudyresult.TaskStatus = Utilities.Messages.GMRCPENDINGSUBMISSIONOFFMVACTIVITIES;
                                    else
                                    newStudyresult.TaskStatus = Utilities.Messages.GMRCPENDINGSUBMISSIONOFDRUGSUPPLYACTIVITIES;

                                    newStudyresult.PITaskStatus = Utilities.Messages.DECISIONAPPROVED;
                                    newStudyresult.TaskName = "";

                                }
                                newStudyresult.ANJU_ChangedBy = mrcStudyReview.ANJU_ChangedBy;
                                newStudyresult.ANJU_ChangeDate = DateTime.UtcNow;
                                retVal = dbContextNavigate.SaveChanges(newStudyresult, new NewStudy_H(), mrcStudyReview.ANJU_ChangedBy, eAuditChangeType.Update);
                                bool decisionresult = true;
                                if(mrcStudyReview.GlobalMrcdecision.Trim() == Utilities.Messages.DECISIONAPPROVED)
                                {
                                    decisionresult =  UpdateMilestonecompletiondateDetails(mrcStudyReview.StudyId, "Create / Deliver Approval Letter", DateTime.Now, mrcStudyReview.ANJU_ChangedBy);
                                    if (decisionresult == true)
                                        return true;
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
            else
                return false;
        }

        /// <summary>
        /// Update GMRC ConditionalApproval Details
        /// </summary>
        /// <param name="mrcStudyReview"></param>
        /// <returns>true/false</returns>
        public bool UpdateGMRCConditionalApprovalDetails(Data.MRCStudyReview mrcStudyReview)
        {
            int retVal = default(int);
            if (mrcStudyReview != null)
            {
                var result = dbContextNavigate.MRCStudyReview.Where(x => x.StudyId == mrcStudyReview.StudyId && x.RecordType == mrcStudyReview.RecordType).FirstOrDefault();
                if (result != null)
                {
                    result.CAResubmissionDecision = mrcStudyReview.CAResubmissionDecision;
                    result.CAResubmissionComments = mrcStudyReview.CAResubmissionComments;
                    result.ANJU_ChangedBy = mrcStudyReview.ANJU_ChangedBy;
                    result.ANJU_ChangeDate = DateTime.UtcNow;
                    retVal = dbContextNavigate.SaveChanges(result, new MRCStudyReview_H(), mrcStudyReview.ANJU_ChangedBy, eAuditChangeType.Update);
                }
                if (retVal > 0)
                {
                    var newStudyresult = dbContextNavigate.NewStudy.Where(x => x.StudyId == mrcStudyReview.StudyId).FirstOrDefault();
                    if (newStudyresult != null)
                    {
                        if (mrcStudyReview.CAResubmissionDecision == Utilities.Messages.DECISIONAPPROVED)
                        {
                           
                            newStudyresult.State = Utilities.Messages.LMRCDECISIONAPPROVEDSTATE;
                            newStudyresult.TaskStatus = Utilities.Messages.LMRCDECISIONAPPROVEDSTATUS;
                            newStudyresult.TaskName = Utilities.Messages.LMRCDECISIONAPPROVEDTASKNAME;
                        }
                        else
                        if (mrcStudyReview.CAResubmissionDecision == Utilities.Messages.DECISIONREJECTED)
                        {

                            newStudyresult.State = Utilities.Messages.GMRCDECISIONCONDITIONALAPPROVALRESUBIMISSIONSTATE;
                            newStudyresult.TaskStatus = Utilities.Messages.PENDINGRESUBMISSIONBYPI;
                            newStudyresult.TaskName = Utilities.Messages.RESUBMITPROPOSAL;
                            newStudyresult.PITaskStatus = Utilities.Messages.RESUBMITPROPOSAL;
                        }
                        newStudyresult.ANJU_ChangedBy = mrcStudyReview.ANJU_ChangedBy;
                        newStudyresult.ANJU_ChangeDate = DateTime.UtcNow;
                        retVal = dbContextNavigate.SaveChanges(newStudyresult, new NewStudy_H(), mrcStudyReview.ANJU_ChangedBy, eAuditChangeType.Update);
                    }
                }


                if (retVal > 0)
                    return true;
                else
                    return false;

            }
            else
                return false;

        }

        /// <summary>
        /// Get Review Activation Document Details
        /// </summary>
        /// <param name="document"></param>
        /// <returns>List</returns>
        public List<Data.Documents> GetReviewActivationDocuments(int studyId)
        {
            var result = dbContextNavigate.Documents.Where(x => (x.StudyId == studyId && x.SubModuleName== Utilities.ConstDefaultValue.ACTIVATIONDOCUMENT  && x.IsActivated==false))
                                                               .Select(x => new Data.Documents
                                                               {
                                                                   DocumentName = x.DocumentName,
                                                                   DocumentType = x.DocumentType,
                                                                   StudyId=x.StudyId,
                                                                   Path=x.Path
                                                               }).ToList();


            return result;
        }

        /// <summary>
        /// Get Review Updated Document Details
        /// </summary>
        /// <param name="document"></param>
        /// <returns>List</returns>
        public List<Data.Documents> GetReviewUpdatedDocuments(int studyId)
        {
            var result = dbContextNavigate.Documents.Where(x => (x.StudyId == studyId && x.SubModuleName == Utilities.Messages.UPDATEDDOCUMENTS && x.IsActivated == false && x.IsActive == true))
                                                               .Select(x => new Data.Documents
                                                               {
                                                                   DocumentName = x.DocumentName,
                                                                   DocumentType = x.DocumentType,
                                                                   StudyId = x.StudyId,
                                                                   Path = x.Path
                                                               }).ToList();


            return result;
        }

        /// <summary>
        /// Get Review Updated Document Details
        /// </summary>
        /// <param name="document"></param>
        /// <returns>List</returns>
        public List<Data.Documents> GetReviewAmendmentDocuments(int studyId)
        {
            var result = dbContextNavigate.Documents.Where(x => (x.StudyId == studyId && x.SubModuleName == Utilities.Messages.AMENDMENTMANDATORYDOCUMENTS && x.IsActivated == false))
                                                               .Select(x => new Data.Documents
                                                               {
                                                                   DocumentName = x.DocumentName,
                                                                   DocumentType = x.DocumentType,
                                                                   StudyId = x.StudyId,
                                                                   Path = x.Path
                                                               }).ToList();


            return result;
        }
        /// <summary>
        /// Get Activated Activation Document Details
        /// </summary>
        /// <param name="document"></param>
        /// <returns>List</returns>
        /// 
        public bool ActivateActivationDocuments(int studyId, string documentname, string status,string loginuser)
        {
            int retVal = default(int);
            var result = dbContextNavigate.Documents.Where(x => (x.StudyId == studyId && x.IsSubmit == true && x.DocumentName == documentname)).FirstOrDefault();
            if (result != null)
            {
                if (status == Utilities.Messages.DECISIONAPPROVED)
                {                  
                    result.IsActivated = true;
                    result.ANJU_ChangeDate = DateTime.UtcNow;
                    result.ANJU_ChangedBy = loginuser;
                } 
                else
                {                    
                    result.IsActivated = false;
                    //result.IsSubmit = false;
                    result.ANJU_ChangeDate = DateTime.UtcNow;
                    result.ANJU_ChangedBy = loginuser;
                }               
                retVal = dbContextNavigate.SaveChanges(result, new Documents_H(), loginuser, eAuditChangeType.Update);
                if (retVal > 0)
                    return true;
                else
                    return false;
            }
            return true;


            
        }

        /// <summary>
        /// Get Activated Updated Document Details
        /// </summary>
        /// <param name="document"></param>
        /// <returns>List</returns>
        /// 
        public bool ActivateUpdatedDocuments(int studyId, string documentname, string status, string loginuser)
        {
            int retVal = default(int);
            var result = dbContextNavigate.Documents.Where(x => (x.StudyId == studyId && x.IsSubmit == true && x.DocumentName == documentname && x.IsActive == true)).FirstOrDefault();
            if (result != null)
            {
                if (status == Utilities.Messages.DECISIONAPPROVED)
                {
                    result.IsActivated = true;                    
                    result.ANJU_ChangeDate = DateTime.UtcNow;
                    result.ANJU_ChangedBy = loginuser;
                }
                else
                {
                    result.IsActivated = false;
                    //result.IsSubmit = false;                    
                    result.ANJU_ChangeDate = DateTime.UtcNow;
                    result.ANJU_ChangedBy = loginuser;
                }                
                retVal = dbContextNavigate.SaveChanges(result, new Documents_H(), loginuser, eAuditChangeType.Update);
                if (retVal > 0)
                    return true;
                else
                    return false;
            }
            return true;



        }

        /// <summary> NIRAJ
        /// Get Rejected Activation Document Details  
        /// </summary>
        /// <param name="document"></param>
        /// <returns>List</returns>
        public bool AddRejectedActivationDocument(int studyId, string studyowner, string loginuser, string comment)
        {
            int retVal = default(int);
            var result = dbContextNavigate.GMRCApprovalTask.Where(x => x.StudyId == studyId && x.TaskName == Utilities.Messages.REVIEWACTIVATIONDOCUMENTS && x.IsTaskCompleted == false).FirstOrDefault();
            if(result!=null)
            {
                result.IsTaskCompleted = true;
                result.Comments = comment;
                result.IsActive = false;
                result.IsDeleted = true;
                result.ANJU_ChangedBy = loginuser;
                result.ANJU_ChangeDate = DateTime.UtcNow;               
                retVal = dbContextNavigate.SaveChanges(result, new GMRCApprovalTask_H(), loginuser, eAuditChangeType.Delete);
                if (retVal > 0)
                {
                    var results = dbContextNavigate.Documents.Where(x => x.StudyId == studyId && x.IsActivated == true).ToList();
                    if (results.Count > 0)
                    {
                        foreach (var item in results)
                        {
                            item.IsActive = false;
                            item.IsDeleted = true;                           
                            retVal = dbContextNavigate.SaveChanges(item, new Documents_H(), loginuser, eAuditChangeType.Delete);
                        }
                    }

                    if (retVal > 0)
                    {
                        int rejecteddocument = dbContextNavigate.Documents.Count(x => (x.StudyId == studyId && x.IsActivated == false));
                        if (rejecteddocument > 0)
                        {
                            var resubmit = dbContextNavigate.Documents.Where(x => (x.StudyId == studyId && x.IsActivated == false)).ToList();
                            if(resubmit!=null)
                            {
                                foreach(var item in resubmit)
                                {
                                    item.IsSubmit = false;                                   
                                    retVal = dbContextNavigate.SaveChanges(item, new Documents_H(), loginuser, eAuditChangeType.Update);
                                }
                                if (retVal > 0)
                                {
                                    DataAccess.GMRCApprovalTask objGMRCApproved = new DataAccess.GMRCApprovalTask()
                                    {
                                        TaskName = Utilities.Messages.RESUBMITACTIVATIONDOCUMENTS,
                                        AssignedTo = studyowner,
                                        StudyId = studyId,
                                        IsTaskCompleted = false,
                                        IsActive = true,
                                        IsDeleted = false,
                                        ANJU_AddDate = DateTime.UtcNow,
                                        ANJU_AddedBy = loginuser
                                    };                                    
                                    retVal = dbContextNavigate.SaveChanges(objGMRCApproved, new GMRCApprovalTask_H(), loginuser, eAuditChangeType.Insert);

                                    if (retVal > 0)
                                        return true;
                                    else
                                        return false;
                                }
                                else
                                    return false;
                            }                            
                        }
                        if (rejecteddocument == 0)
                        {
                            var TaskCount = dbContextNavigate.GMRCApprovalTask.Count(x => x.StudyId == studyId && x.IsTaskCompleted == false);
                            if (TaskCount == 0)
                            {
                                string TlUserName = dbContextNavigate.PLStudyReview.AsEnumerable()
                                                              .Join(dbContextNavigate.Users.AsEnumerable(), pl => pl.TluserId, u => u.UserId,
                                                              (pl, u) => new { pl, u })
                                                              .Where(x => x.pl.StudyId == studyId && x.pl.IsActive == true && x.pl.IsDeleted == false)
                                                              .Select(x => x.u.UserName).FirstOrDefault();

                                DataAccess.GMRCApprovalTask objInsertGMRCApprovalTask = new DataAccess.GMRCApprovalTask()
                                {
                                    StudyId = studyId,
                                    TaskName = Utilities.Messages.FINALACTIVATIONREVIEW,
                                    IsTaskCompleted = false,
                                    AssignedTo = TlUserName,
                                    IsActive = true,
                                    IsDeleted = false,
                                    ANJU_AddedBy = loginuser,
                                    ANJU_AddDate = DateTime.UtcNow
                                };                                
                                retVal = dbContextNavigate.SaveChanges(objInsertGMRCApprovalTask, new GMRCApprovalTask_H(), loginuser, eAuditChangeType.Insert);
                                if (retVal > 0)
                                    return true;
                                else
                                    return false;
                            }
                        }
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            
            return true;



        }

        /// <summary> 
        /// Get Rejected Updated Document Details  
        /// </summary>
        /// <param name="document"></param>
        /// <returns>List</returns>
        public bool AddRejectedUpdatedDocument(int studyId, string studyowner, string loginuser, string comment)
        {
            int retVal = default(int);
            var result = dbContextNavigate.GMRCApprovalTask.Where(x => x.StudyId == studyId && x.TaskName == Utilities.Messages.REVIEWUPDATEDDOCUMENTS && x.IsTaskCompleted == false).FirstOrDefault();
            if (result != null)
            {
                result.IsTaskCompleted = true;
                result.Comments = comment;
                result.IsActive = false;
                result.IsDeleted = true;
                result.ANJU_ChangedBy = loginuser;
                result.ANJU_ChangeDate = DateTime.UtcNow;
                retVal = dbContextNavigate.SaveChanges(result, new GMRCApprovalTask_H(), loginuser, eAuditChangeType.Delete);
                if (retVal > 0)
                {
                    var results = dbContextNavigate.Documents.Where(x => x.StudyId == studyId && x.IsActivated != null && x.SubModuleName == Utilities.Messages.UPDATEDDOCUMENTS && x.IsActive ==true).ToList();
                    if (results.Count > 0)
                    {
                        foreach (var item in results)
                        {
                            item.IsActive = false;
                            item.IsDeleted = true;
                            retVal = dbContextNavigate.SaveChanges(item, new Documents_H(), loginuser, eAuditChangeType.Delete);
                        }
                    }

                    if (retVal > 0)
                    {
                        var removeTaskFromlist = dbContextNavigate.Documents.Where(x => x.StudyId == studyId && x.IsActivated == null && x.SubModuleName ==Utilities.Messages.UPDATEDDOCUMENTS && x.IsActive == true).ToList();
                        if (removeTaskFromlist.Count == 0)
                        {
                            DataAccess.GMRCApprovalTask objGMRCApproved = new DataAccess.GMRCApprovalTask()
                            {
                                TaskName = Utilities.Messages.REVIEWUPDATEDDOCUMENTS,
                                AssignedTo = loginuser,
                                StudyId = studyId,
                                IsTaskCompleted = true,
                                IsActive = false,
                                IsDeleted = true,
                                ANJU_AddDate = DateTime.UtcNow,
                                ANJU_AddedBy = loginuser
                            };
                            retVal = dbContextNavigate.SaveChanges(objGMRCApproved, new GMRCApprovalTask_H(), loginuser, eAuditChangeType.Insert);

                            if (retVal > 0)
                                return true;
                            else
                                return false;
                        }
                        else {
                            DataAccess.GMRCApprovalTask objGMRCApproved = new DataAccess.GMRCApprovalTask()
                            {
                                TaskName = Utilities.Messages.REVIEWUPDATEDDOCUMENTS,
                                AssignedTo = loginuser,
                                StudyId = studyId,
                                IsTaskCompleted = false,
                                IsActive = true,
                                IsDeleted = false,
                                ANJU_AddDate = DateTime.UtcNow,
                                ANJU_AddedBy = loginuser
                            };
                            retVal = dbContextNavigate.SaveChanges(objGMRCApproved, new GMRCApprovalTask_H(), loginuser, eAuditChangeType.Insert);

                            if (retVal > 0)
                                return true;
                            else
                                return false;
                        }
                    }
                    else
                        return false;
                }
                else
                    return false;
            }

            return true;



        }

        /// <summary>
        /// Get Activated Activation Document Details
        /// </summary>
        /// <param name="document"></param>
        /// <returns>List</returns>
        public List<Data.Documents> GetActivatedActivationdocument(int studyId)
        {
           var result=dbContextNavigate.Documents.AsEnumerable().Where(x=>x.StudyId== studyId && x.SubModuleName==Utilities.ConstDefaultValue.ACTIVATIONDOCUMENT && x.IsActivated==true && x.IsActive==true)
                                              .GroupJoin(dbContextNavigate.SysCodeValues.AsEnumerable(),
                                                       D => new { DocumentType = D.DocumentType.ToString() },
                                                       Sy => new { DocumentType = Sy.Code.ToString() },
                                                       (D, Sy) => new { D, Sy }).ToList()
                                                        .Select(x => new Data.Documents
                                                        {
                                                            DocumentId = x.D.DocumentId,
                                                            DocumentName = x.D.DocumentName,
                                                            DocumentNameWithOutExtension = x.D.DocumentNameWithOutExtension,
                                                            DocumentExtension = x.D.DocumentExtension,
                                                            DocumentStatus = x.D.DocumentStatus,
                                                            DocumentType = x.D.DocumentType,
                                                            DocumentSubType = x.D.DocumentSubType,
                                                            DocumentVersion = x.D.DocumentVersion,
                                                            SubModuleName = x.D.SubModuleName,
                                                            DocumentTypeId = x.Sy.Select(c => c.CodeId).FirstOrDefault(),
                                                            StudyId = x.D.StudyId,
                                                            OriginalDate = x.D.OriginalDate,
                                                            ExpirationDate = x.D.ExpirationDate,
                                                            Path = x.D.Path

                                                        }).ToList();

            return result;



        }

        /// <summary>
        /// Get Activated Activation Document Details
        /// </summary>
        /// <param name="document"></param>
        /// <returns>List</returns>
        public List<Data.Documents> GetActivatedUpdatedocument(int studyId)
        {
            var result = dbContextNavigate.Documents.AsEnumerable().Where(x => x.StudyId == studyId && x.SubModuleName == Utilities.Messages.UPDATEDDOCUMENTS && x.IsActivated == true && x.IsActive == true)
                                               .GroupJoin(dbContextNavigate.SysCodeValues.AsEnumerable(),
                                                        D => new { DocumentType = D.DocumentType?.ToString() },
                                                        Sy => new { DocumentType = Sy.Code?.ToString() },
                                                        (D, Sy) => new { D, Sy }).ToList()
                                                         .Select(x => new Data.Documents
                                                         {
                                                             DocumentId = x.D.DocumentId,
                                                             DocumentName = x.D.DocumentName,
                                                             DocumentNameWithOutExtension = x.D.DocumentNameWithOutExtension,
                                                             DocumentExtension = x.D.DocumentExtension,
                                                             DocumentStatus = x.D.DocumentStatus,
                                                             DocumentType = x.D.DocumentType,
                                                             DocumentSubType = x.D.DocumentSubType,
                                                             DocumentVersion = x.D.DocumentVersion,
                                                             SubModuleName = x.D.SubModuleName,
                                                             DocumentTypeId = x.Sy.Select(c => c.CodeId).FirstOrDefault(),
                                                             StudyId = x.D.StudyId,
                                                             OriginalDate = x.D.OriginalDate,
                                                             ExpirationDate = x.D.ExpirationDate,
                                                             Path = x.D.Path

                                                         }).ToList();

            return result;



        }

        #endregion
    }
}
