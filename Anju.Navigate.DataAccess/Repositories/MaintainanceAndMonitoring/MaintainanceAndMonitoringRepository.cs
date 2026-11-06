using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Anju.Navigate.Utilities;

namespace Anju.Navigate.DataAccess
{
    public class MaintainanceAndMonitoringRepository
    {
        #region Properties
        private readonly Navigate30Context dbContextNavigate;
        #endregion

        #region Constructor       
        public MaintainanceAndMonitoringRepository(Navigate30Context dbContext)
        {
            dbContextNavigate = new Navigate30Context();

        }
        #endregion

        #region Variables
        #endregion

        #region Methods
        /// <summary>
        /// Update Final Reconciliation
        /// </summary>
        /// <param name="objGMRCApprovalTask"></param>      
        public bool UpdateFinalReconciliation(Data.GMRCApprovalTask objGMRCApprovalTask)
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
                retVal = dbContextNavigate.SaveChanges(result, new GMRCApprovalTask_H(), objGMRCApprovalTask.ANJU_ChangedBy, eAuditChangeType.Delete);
                if (retVal > 0)
                {
                    StudyTaskRepository objStudyTaskRepository = new StudyTaskRepository(dbContextNavigate);
                    bool taskcompletion = objStudyTaskRepository.UpdateMilestonecompletiondateDetails(objGMRCApprovalTask.StudyId, "SAE Final Reconciliation Report Confirmation", DateTime.UtcNow, objGMRCApprovalTask.ANJU_ChangedBy);
                    if (taskcompletion)
                    {
                        DataAccess.GMRCApprovalTask objGMRCApprovalCloseoutTask = new DataAccess.GMRCApprovalTask();
                        objGMRCApprovalCloseoutTask.StudyId = objGMRCApprovalTask.StudyId;
                        objGMRCApprovalCloseoutTask.TaskName = Utilities.Messages.INITIATESTUDYCLOSEOUT;
                        objGMRCApprovalCloseoutTask.IsActive = true;
                        objGMRCApprovalCloseoutTask.IsDeleted = false;
                        objGMRCApprovalCloseoutTask.ANJU_AddedBy = objGMRCApprovalTask.ANJU_ChangedBy;
                        objGMRCApprovalCloseoutTask.ANJU_AddDate = DateTime.UtcNow;
                        objGMRCApprovalCloseoutTask.AssignedTo = objGMRCApprovalTask.ANJU_ChangedBy;
                        objGMRCApprovalCloseoutTask.IsTaskCompleted = false;
                        objGMRCApprovalCloseoutTask.IsGearTaskCompleted = true;
                        retVal = dbContextNavigate.SaveChanges(objGMRCApprovalCloseoutTask, new GMRCApprovalTask_H(), objGMRCApprovalTask.ANJU_ChangedBy, eAuditChangeType.Insert);
                    }                    
                    if (retVal > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                    return false;
            }
            return false;
        }
        #endregion
    }
}
