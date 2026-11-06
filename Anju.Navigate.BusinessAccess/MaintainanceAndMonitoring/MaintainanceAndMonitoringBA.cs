using Anju.Navigate.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anju.Navigate.BusinessAccess
{
    public class MaintainanceAndMonitoringBA
    {
        #region Properties
        private readonly UnitOfWork unitOfWork;
        #endregion

        #region Constructor
        public MaintainanceAndMonitoringBA()
        {
            unitOfWork = new UnitOfWork();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Update GMRCApproval Task Modify Status Details
        /// </summary>
        /// <param name="objGMRCApprovalTask"></param>
        /// <returns>true/false</returns> 
        public bool UpdateModifyStatusDetails(Data.GMRCApprovalTask objGMRCApprovalTask, string userName)
        {
            return unitOfWork.GMRCApprovalTask.UpdateModifyStatusDetails(objGMRCApprovalTask, userName);
        }

        /// <summary>
        /// Update Final Reconciliation
        /// </summary>
        /// <param name="objGMRCApprovalTask"></param>
        public bool UpdateFinalReconciliation(Data.GMRCApprovalTask objGMRCApprovalTask)
        {
            return unitOfWork.MaintainanceAndMonitoring.UpdateFinalReconciliation(objGMRCApprovalTask);
        }
        #endregion
    }
}
