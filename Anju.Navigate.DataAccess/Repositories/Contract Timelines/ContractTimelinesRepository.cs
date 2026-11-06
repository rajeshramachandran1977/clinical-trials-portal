using Anju.Navigate.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Anju.Navigate.DataAccess
{
    public class ContractTimelinesRepository
    {
        #region Properties
        private readonly Navigate30Context dbContextNavigate;
        #endregion

        #region Constructor
        public ContractTimelinesRepository(Navigate30Context dbContext)
        {
            this.dbContextNavigate = new Navigate30Context();
        }
        #endregion

        #region Methods    
        /// <summary>
        /// Get Contracts Timeline
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public List<Data.Contracttimelines> GetContractsTimeline(int studyId)
        {
            var lstContracttimelines = dbContextNavigate.Contracttimelines.Where(x => x.StudyId == studyId && x.IsActive == true)
                                                         .Select(x => new Data.Contracttimelines
                                                         {
                                                             ContractId = x.ContractId,
                                                             StudyId = x.StudyId,
                                                             Contracttype = x.Contracttype,
                                                             Contracttimelinestatus = x.Contracttimelinestatus,
                                                             Contractversion = x.Contractversion,
                                                             Currentlocation = x.Currentlocation,
                                                             Contactname = x.Contactname,
                                                             Statuschange = x.Statuschange,
                                                             Comments = x.Comments,
                                                         }).ToList();
            return lstContracttimelines;
        }


        /// <summary>
        /// Delete Contracts Timelines
        /// </summary>
        /// <param name="contracttimelines"></param>
        /// <param name="username"></param>
        /// <returns>true/false</returns>
        public bool DeleteContractsTimelinedetails(Data.Contracttimelines contracttimelines, string userName)
        {
            int retVal = default(int);
            if (contracttimelines != null)
            {
                var result = dbContextNavigate.Contracttimelines.Where(x => x.ContractId == contracttimelines.ContractId
                                                                        && x.StudyId == contracttimelines.StudyId).SingleOrDefault();
                if (result != null)
                {
                    result.IsDeleted = true;
                    result.IsActive = false;
                    result.ANJU_ChangedBy = userName;
                    result.ANJU_ChangeDate = DateTime.UtcNow;
                };
                dbContextNavigate.Contracttimelines.Update(result);
                retVal = dbContextNavigate.SaveChanges(result, new Contracttimelines_H(), userName, eAuditChangeType.Delete);
                if (retVal > 0)
                    return true;
            }
            return false;
        }
        #endregion
    }
}
