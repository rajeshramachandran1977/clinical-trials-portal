using Anju.Navigate.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anju.Navigate.BusinessAccess
{
    public class ProtocolPhaseBA
    {
        #region Properties
        private readonly UnitOfWork unitOfWork;
        #endregion

        #region Constructor
        public ProtocolPhaseBA()
        {
            unitOfWork = new UnitOfWork();
        }
        #endregion

        #region Methods 

        /// <summary>
        /// Update GMRCApproval Task details 
        /// </summary>
        /// <returns>true/false</returns>
        public bool UpdateGMRCApprovalTaskDetails(Data.GMRCApprovalTask objGMRCApprovalTask)
        {
            return unitOfWork.ProtocolPhase.UpdateGMRCApprovalTaskDetails(objGMRCApprovalTask);
        }
        /// <summary>
        /// Update GMRCApproval GearTask details 
        /// </summary>
        /// <returns>true/false</returns>
        public bool UpdateGMRCApprovalGearTaskDetails(Data.GMRCApprovalTask objGMRCApprovalTask)
        {
            return unitOfWork.ProtocolPhase.UpdateGMRCApprovalGearTaskDetails(objGMRCApprovalTask);
        }

        /// <summary>
        /// Update GMRCApproval task and Document details
        /// </summary>
        /// <param name="objGMRCApprovalTask"></param>      
        /// <param name="objDocument"></param>      
        /// <returns>true/false</returns>
        public bool UpdateGMRCApprovalTaskAndDocumentDetails(Data.GMRCApprovalTask objGMRCApprovalTask, Data.Documents objDocument)
        {
            return unitOfWork.ProtocolPhase.UpdateGMRCApprovalTaskAndDocumentDetails(objGMRCApprovalTask, objDocument);
        }

        public List<Data.SysCodeValues> GetReviewDecision()
        {
            return unitOfWork.ProtocolPhase.GetReviewDecision();
        }

        #endregion

    }
}
