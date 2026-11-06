using Anju.Navigate.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Anju.Navigate.DataAccess
{
    public class CenterRepository
    {
        #region Properties
        private readonly Navigate30Context dbContextNavigate;
        private readonly UnitOfWork unitOfWork;
        #endregion

        #region Constructor

        public CenterRepository(Navigate30Context dbContext)
        {
            this.dbContextNavigate = new Navigate30Context();

        }
        #endregion

        #region Methods     

        /// <summary>
        /// Get Centers
        /// </summary>
        /// <param name="StudyID"></param>
        /// <returns>lstCenters</returns>
        public List<Data.Center> GetCenter(int StudyID)
        {
            var lstCenters = dbContextNavigate.Center.Where(x => x.StudyId == StudyID && x.IsActive)
                                                         .Select(x => new Data.Center
                                                         {
                                                             CenterId = x.CenterId,
                                                             StudyId = x.StudyId,
                                                            Institution = x.Institution

                                                         }).ToList();
            return lstCenters;


        }

        /// <summary>
        /// Create Update Center
        /// </summary>
        /// <param name="center"></param>
        /// <param name="mode"></param>
        /// <param name="StudyID"></param>
        /// <param name="userName"></param>
        public bool CreateUpdateCenter(Data.Center center,int StudyID, string userName)
        {
            int retVal = default(int);
            if (center != null)
            {                
                var result = dbContextNavigate.Center.Where(x => x.StudyId == StudyID && x.IsActive).SingleOrDefault();
                if (result != null)
                {
                    result.CenterId = center.CenterId;
                    result.Institution = center.Institution.Trim();
                    result.ANJU_ChangedBy = userName;
                    result.ANJU_ChangeDate = DateTime.UtcNow;                   
                    retVal = dbContextNavigate.SaveChanges(result, new Center_H(), userName, eAuditChangeType.Update);
                }
                else
                {
                    DataAccess.Center objcenter = new DataAccess.Center()
                    {
                        StudyId = StudyID,
                        Institution = center.Institution,
                        IsActive = true,
                        IsDeleted = false,
                        ANJU_AddedBy = userName,
                        ANJU_AddDate = DateTime.UtcNow
                    };                   
                    retVal = dbContextNavigate.SaveChanges(objcenter, new Center_H(), userName, eAuditChangeType.Insert);
                }                
                if (retVal > 0)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Delete Center
        /// </summary>
        /// <param name="center"></param>
        /// <param name="userName"></param>
        /// <returns>true/false</returns>
        public bool DeleteCenter(Data.Center center, string userName)
        {
            int retVal = default(int);
            if (center != null)
            {
                var result = dbContextNavigate.Center.Where(x => x.CenterId == center.CenterId).SingleOrDefault();
                if (result != null)
                {
                    result.IsActive = false;
                    result.IsDeleted = true;
                    result.ANJU_ChangedBy = userName;
                    result.ANJU_ChangeDate = DateTime.UtcNow;
                };               
                retVal = dbContextNavigate.SaveChanges(result, new Center_H(), userName, eAuditChangeType.Delete);
                if (retVal > 0)
                    return true;
            }
            return false;
        }
        #endregion
    }
}
