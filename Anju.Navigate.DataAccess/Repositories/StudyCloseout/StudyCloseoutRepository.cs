using Anju.Navigate.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Anju.Navigate.DataAccess
{
    public class StudyCloseoutRepository
    {
        #region Properties
        private readonly Navigate30Context dbContextNavigate;
        #endregion

        #region Constructor
        public StudyCloseoutRepository(Navigate30Context dbContext)
        {
            dbContextNavigate = new Navigate30Context();
        }
        #endregion

        #region Variables
        #endregion

        #region Methods
        /// <summary>
        /// Update Initiate Study Closeout
        /// </summary>
        /// <param name="objGMRCApprovalTask"></param>      
        public bool UpdateInitiateCloseout(Data.GMRCApprovalTask objGMRCApprovalTask)
        {
            int retVal = default(int);
            var result = dbContextNavigate.GMRCApprovalTask.Where(x => x.StudyId == objGMRCApprovalTask.StudyId && x.TaskName == objGMRCApprovalTask.TaskName && x.IsActive == true && x.IsDeleted == false).FirstOrDefault();

            if (result != null)
            {
                result.ANJU_ChangeDate = DateTime.UtcNow;
                result.ANJU_ChangedBy = objGMRCApprovalTask.ANJU_ChangedBy;
                result.IsTaskCompleted = true;
                result.IsActive = false;
                result.IsDeleted = true;
                result.IsGearTaskCompleted = objGMRCApprovalTask.IsGearTaskCompleted;               
                retVal = dbContextNavigate.SaveChanges(result, new GMRCApprovalTask_H(), objGMRCApprovalTask.ANJU_ChangedBy, eAuditChangeType.Delete);
                if (retVal > 0)
                {
                    using (var db = new Navigate30Context())
                    {
                        db.GMRCApprovalTask
                         .Where(x => x.StudyId == objGMRCApprovalTask.StudyId && x.IsActive == true && x.IsDeleted == false && x.IsTaskCompleted == false).ToList()
                         .ForEach(x => { x.ANJU_ChangedBy = objGMRCApprovalTask.ANJU_ChangedBy; x.ANJU_ChangeDate = DateTime.UtcNow; x.IsDeleted = true; x.IsActive = false; x.IsTaskCompleted = true; });

                         db.SaveChanges();
                    }
                    if (retVal > 0)
                        {
                            var studyresult = dbContextNavigate.NewStudy.Where(x => x.StudyId == objGMRCApprovalTask.StudyId).FirstOrDefault();
                            studyresult.Stage = Utilities.Messages.STUDYCLOSEOUTINITIATED;
                            studyresult.State = Utilities.Messages.CLOSEOUTACTIVITIESINPROGRESS;
                            studyresult.TaskStatus = Utilities.Messages.INITIATESTUDYCLOSEOUTACTIONINITIATED;
                            studyresult.PITaskStatus = Utilities.Messages.STUDYCLOSEOUTINITIATED;
                            studyresult.ANJU_ChangedBy = objGMRCApprovalTask.ANJU_ChangedBy;
                            studyresult.ANJU_ChangeDate = DateTime.UtcNow;
                            retVal = dbContextNavigate.SaveChanges(studyresult, new NewStudy_H(), objGMRCApprovalTask.ANJU_ChangedBy, eAuditChangeType.Update);

                        if (retVal > 0)
                            {
                                var lstTlTasks = dbContextNavigate.SysCodeValues.Where(x => (x.ColumnName.ToUpper().Trim() == Utilities.Messages.TLACTIVATIONTASKS) && (x.IsActive == true) && (x.IsDeleted == false))
                                                               .Select(x => new Data.SysCodeValues
                                                               {
                                                                   CodeId = x.CodeId,
                                                                   Code = x.Code.Trim(),
                                                                   Description = x.Description.Trim()
                                                               }).ToList();
                                foreach (string taskName in lstTlTasks.Select(Code => Code.Code).ToList())
                                {
                                    DataAccess.GMRCApprovalTask objGMRCApprovalTaskDetails = new DataAccess.GMRCApprovalTask()
                                    {
                                        StudyId = objGMRCApprovalTask.StudyId,
                                        TaskName = taskName,
                                        IsTaskCompleted = false,
                                        IsGearTaskCompleted = true,
                                        AssignedTo = objGMRCApprovalTask.AssignedTo,
                                        IsActive = true,
                                        IsDeleted = false,
                                        ANJU_AddedBy = objGMRCApprovalTask.ANJU_ChangedBy,
                                        ANJU_AddDate = DateTime.UtcNow
                                    };                                    
                                    retVal = dbContextNavigate.SaveChanges(objGMRCApprovalTaskDetails, new GMRCApprovalTask_H(), objGMRCApprovalTask.ANJU_ChangedBy, eAuditChangeType.Insert);
                            }
                            if (retVal > 0)
                            {
                                var lstPITasks = dbContextNavigate.SysCodeValues.Where(x => (x.ColumnName.ToUpper().Trim() == Utilities.Messages.PIACTIVATIONTASKS) && (x.IsActive == true) && (x.IsDeleted == false))
                                                          .Select(x => new Data.SysCodeValues
                                                          {
                                                              CodeId = x.CodeId,
                                                              Code = x.Code.Trim(),
                                                              Description = x.Description.Trim()
                                                          }).ToList();
                                foreach (string PItaskName in lstPITasks.Select(Code => Code.Code).ToList())
                                {
                                    DataAccess.GMRCApprovalTask objGMRCApprovalPITaskDetails = new DataAccess.GMRCApprovalTask()
                                    {
                                        StudyId = objGMRCApprovalTask.StudyId,
                                        TaskName = PItaskName,
                                        IsTaskCompleted = false,
                                        IsGearTaskCompleted = true,
                                        AssignedTo = objGMRCApprovalTask.ANJU_AddedBy,
                                        IsActive = true,
                                        IsDeleted = false,
                                        ANJU_AddedBy = objGMRCApprovalTask.ANJU_ChangedBy,
                                        ANJU_AddDate = DateTime.UtcNow
                                    };                                    
                                    retVal = dbContextNavigate.SaveChanges(objGMRCApprovalPITaskDetails, new GMRCApprovalTask_H(), objGMRCApprovalTask.ANJU_ChangedBy, eAuditChangeType.Insert);
                                }
                                if (retVal > 0)
                                    return true;
                                else
                                    return false;
                            }
                            else
                                return false;
                            }
                            else
                                return false;

                        }
                        else
                            return false;                  
                }                
            }
            return false;
        }


        /// <summary>
        /// Get syscode values By Column Name
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns>list of syscodes</returns>
        public List<Data.GMRCApprovalTask> GetGearTasks(int studyId)
        {
            var lstTasks = dbContextNavigate.GMRCApprovalTask.Where(x => (x.IsGearTaskCompleted == true) && (x.IsActive == true && x.IsDeleted == false && x.StudyId == studyId) )
                                                               .Select(x => new Data.GMRCApprovalTask
                                                               {
                                                                   StudyId = x.StudyId,
                                                                   TaskName = x.TaskName,
                                                                   AssignedTo = x.AssignedTo

                                                               }).ToList();
            return lstTasks;
        }

        #endregion
    }
}