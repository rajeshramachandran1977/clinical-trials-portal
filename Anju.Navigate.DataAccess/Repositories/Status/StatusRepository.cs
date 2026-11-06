using Anju.Navigate.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Anju.Navigate.DataAccess
{
    public class StatusRepository
    {
        #region Properties
        private readonly Navigate30Context dbContextNavigate;
        private readonly UnitOfWork unitOfWork;
        #endregion

        #region Constructor

        public StatusRepository(Navigate30Context dbContext)
        {
            this.dbContextNavigate = new Navigate30Context();

        }
        #endregion

        #region Methods  

        /// <summary>
        /// Get Status details
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public List<Data.Status> GetStatusdetails(int studyId)
        {
            var lstStatusdetails = dbContextNavigate.Status.Where(x => x.StudyId == studyId && x.IsActive == true)
                                                         .Select(x => new Data.Status
                                                         {
                                                             StatusId = x.StatusId,
                                                             StudyId = x.StudyId,
                                                             Stage = x.Stage,
                                                             State = x.State,
                                                             StudyStatus = x.StudyStatus,
                                                             Date = x.Date,
                                                             Time = x.Time,                                                             
                                                         }).ToList();
            return lstStatusdetails;
        }



        /// <summary>
        /// Create/Update Status
        /// </summary>
        /// <param name="newStudy"></param>
        /// <param name="usertype"></param>
        /// <returns></returns>
        public bool CreateUpdateStatus(Data.NewStudy newStudy, string usertype)
        {
            int retVal = default(int);
            CommonRepository cmnRep = new CommonRepository();
            var objStatusdetails = dbContextNavigate.Status.Where(x => x.StatusId == newStudy.StatusId &&
                                                                           x.StudyId == newStudy.StudyId).SingleOrDefault();
            if (objStatusdetails != null)
            {
                var lstfieldsrestrictedview = cmnRep.IsFieldRestrictedView();
                var lstfieldsforroles = cmnRep.IsFieldRestrictedViewforgivenRole(usertype);
                var lstfields = lstfieldsrestrictedview.Concat(lstfieldsforroles).ToList();

                bool isstagerestricted = false;
                bool isstaterestricted = false;
                bool isstatusrestricted = false;
                bool istimerestricted = false;
                
                foreach (var item in lstfields)
                {
                    switch (item.FieldType)
                    {
                        case ConstDefaultValue.STAGE:
                            objStatusdetails.Stage = newStudy.Stage ?? objStatusdetails.Stage;
                            isstagerestricted = true;
                            break;
                        case ConstDefaultValue.STATE:
                            objStatusdetails.State = newStudy.State ?? objStatusdetails.State;
                            isstaterestricted = true;
                            break;
                        case ConstDefaultValue.STATUS:
                            objStatusdetails.StudyStatus = newStudy.Status ?? objStatusdetails.StudyStatus;
                            isstatusrestricted = true;
                            break;
                        case ConstDefaultValue.TIME:
                            objStatusdetails.Time = newStudy.Time ?? objStatusdetails.Time;
                            istimerestricted = true;
                            break;
                        
                        default:
                            break;
                    }
                }
                if (isstagerestricted == false)
                    objStatusdetails.Stage = newStudy.Stage;
                if (isstaterestricted == false)
                    objStatusdetails.State = newStudy.State;
                if (isstatusrestricted == false)
                    objStatusdetails.StudyStatus = newStudy.Status;
                if (istimerestricted == false)
                    objStatusdetails.Time = newStudy.Time;

                objStatusdetails.ANJU_ChangedBy = newStudy.ANJU_ChangedBy;
                objStatusdetails.ANJU_ChangeDate = DateTime.UtcNow;
                               
                retVal = dbContextNavigate.SaveChanges(objStatusdetails, new Status_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Update);
            }
            else
            {
                DataAccess.Status statusdetails = new DataAccess.Status()
                {                                  
                    StudyId = newStudy.StudyId,
                    Stage = newStudy.Stage,
                    State = newStudy.State,
                    StudyStatus = newStudy.StudyStatus,
                    Date = newStudy.Date,
                    Time = newStudy.Time,

                    IsActive = true,
                    IsDeleted = false,
                    ANJU_AddedBy = newStudy.ANJU_AddedBy,
                    ANJU_AddDate = DateTime.UtcNow,

                };                
                retVal = dbContextNavigate.SaveChanges(statusdetails, new Status_H(), newStudy.ANJU_AddedBy, eAuditChangeType.Insert);
            }
            if (retVal > 0)
                return true;
            else
                return false;
        }



        /// <summary>
        /// Delete Status 
        /// </summary>
        /// <param name="statusdetails"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool DeleteStatusdetails(Data.Status statusdetails, string username)
        {
            int retVal = default(int);
            if (statusdetails != null)
            {
                var result = dbContextNavigate.Status.Where(x => x.StatusId == statusdetails.StatusId
                                                                        && x.StudyId == statusdetails.StudyId).SingleOrDefault();
                if (result != null)
                {
                    result.IsDeleted = true;
                    result.IsActive = false;
                    result.ANJU_ChangedBy = username;
                    result.ANJU_ChangeDate = DateTime.UtcNow;
                };
                retVal = dbContextNavigate.SaveChanges(result, new Status_H(), username, eAuditChangeType.Delete);
                if (retVal > 0)
                    return true;
            }
            return false;
        }
        #endregion

    }
}
