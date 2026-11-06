using Anju.Navigate.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anju.Navigate.BusinessAccess
{
    public class StudyCloseoutBA
    {
        #region Properties
        private readonly UnitOfWork UnitOfWork;
        #endregion

        #region Constructor
        public StudyCloseoutBA()
        {
            UnitOfWork = new UnitOfWork();
        }
        #endregion

        #region Methods

        ///<summary>
        /// Update Initiate Study Closeout
        ///</summary>
        ///<param name="objGMRCApprovalTask"></param>
        public bool UpdateInitiateCloseout(Data.GMRCApprovalTask objGMRCApprovalTask)
        {
            return UnitOfWork.StudyCloseout.UpdateInitiateCloseout(objGMRCApprovalTask);
        }

        /// <summary>
        /// Get Gear Tasks by studyId
        /// </summary>
        /// <param name="request"></param>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public List<Data.GMRCApprovalTask> GetGearTasks(int studyId)
        {
            return UnitOfWork.StudyCloseout.GetGearTasks(studyId);
        }

        #endregion
    }
}
