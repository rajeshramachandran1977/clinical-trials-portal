using Anju.Navigate.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anju.Navigate.DataAccess
{
    public class GMRCApprovalTaskRepository
    {
        #region Properties
        private readonly Navigate30Context dbContextNavigate;
        private readonly UnitOfWork unitOfWork;

        #endregion

        #region Constructor
        public GMRCApprovalTaskRepository(Navigate30Context dbContext)
        {
            this.dbContextNavigate = new Navigate30Context();
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
            int retVal = default(int);
            if (objGMRCApprovalTask != null)
            {
                using (var db = new Navigate30Context())
                {
                    db.GMRCApprovalTask.Where(x => x.StudyId == objGMRCApprovalTask.StudyId && x.IsActive == true && x.IsDeleted == false).ToList()
                     .ForEach(x => { x.StudyStatus = objGMRCApprovalTask.StudyStatus; x.StatusChangeReason = objGMRCApprovalTask.StatusChangeReason; x.ANJU_ChangedBy = userName; x.ANJU_ChangeDate = DateTime.UtcNow; x.IsDeleted = false; x.IsActive = true; });

                    retVal = db.SaveChanges();
                    if (retVal > 0)
                    {
                        var result = dbContextNavigate.NewStudy.Where(x => x.StudyId == objGMRCApprovalTask.StudyId).SingleOrDefault();
                        if (result != null)
                        {
                            result.State = Utilities.Messages.MODIFYSTATUSCANCELLEDSTATE;
                            result.TaskStatus = Utilities.Messages.MODIFYSTATUSCANCELLEDTASKNAME;
                            result.TaskName = Utilities.Messages.MODIFYSTATUSCANCELLEDSTATUS;
                            result.Stage = Utilities.Messages.MODIFYSTATUSCANCELLEDSTAGE;
                            result.ANJU_ChangedBy = userName;
                            result.ANJU_ChangeDate = DateTime.UtcNow;                           
                            retVal = dbContextNavigate.SaveChanges(result, new NewStudy_H(), userName, eAuditChangeType.Update);
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
        /// Create/Update GMRC Approval Task
        /// </summary>
        /// <param name="newStudy"></param>
        /// <param name="usertype"></param>
        /// <returns></returns>
        public bool CreateUpdateGMRCApprovalTask(Data.NewStudy newStudy, string usertype,string userName)
        {
            int retVal = default(int);
            CommonRepository cmnRep = new CommonRepository();
            var objContracttimelines = dbContextNavigate.Contracttimelines.Where(x => x.ContractId == newStudy.ContractId &&
                                                                           x.StudyId == newStudy.StudyId).SingleOrDefault();
            if (objContracttimelines != null)
            {
                var lstfieldsrestrictedview = cmnRep.IsFieldRestrictedView();
                var lstfieldsforroles = cmnRep.IsFieldRestrictedViewforgivenRole(usertype);
                var lstfields = lstfieldsrestrictedview.Concat(lstfieldsforroles).ToList();

                bool iscontracttyperestricted = false;
                bool iscontractstatusrestricted = false;               
                bool isversionrestricted = false;
                bool iscurrentlocationrestricted = false;
                bool iscontactnamerestricted = false;
                bool isstatuschangedaterestricted = false;
                bool iscommentsrestricted = false;
                
                foreach (var item in lstfields)
                {
                    switch (item.FieldType)
                    {
                        case ConstDefaultValue.CONTRACTTYPE:
                            objContracttimelines.Contracttype = newStudy.ContractType ?? objContracttimelines.Contracttype;
                            iscontracttyperestricted = true;
                            break;
                        case ConstDefaultValue.CONTRACTSTATUS:
                            objContracttimelines.Contracttimelinestatus = newStudy.ContractStatus ?? objContracttimelines.Contracttimelinestatus;
                            iscontractstatusrestricted = true;
                            break;
                        case ConstDefaultValue.VERSION:
                            objContracttimelines.Contractversion = newStudy.Version ?? objContracttimelines.Contractversion;
                            isversionrestricted = true;
                            break;
                        case ConstDefaultValue.CURRENTLOCATION:
                            objContracttimelines.Currentlocation = newStudy.CurrentLocation ?? objContracttimelines.Currentlocation;
                            iscurrentlocationrestricted = true;
                            break;
                        case ConstDefaultValue.CONTACTNAME:
                            objContracttimelines.Contactname = newStudy.ContactName ?? objContracttimelines.Contactname;
                            iscontactnamerestricted = true;
                            break;
                        case ConstDefaultValue.STATUSCHANGEDATE:
                            objContracttimelines.Statuschange = newStudy.Statuschange ?? objContracttimelines.Statuschange;
                            isstatuschangedaterestricted = true;
                            break;
                        case ConstDefaultValue.COMMENTS:
                            objContracttimelines.Comments = newStudy.Comments ?? objContracttimelines.Comments;
                            iscommentsrestricted = true;
                            break;                        
                        default:
                            break;
                    }
                }
                if (iscontracttyperestricted == false)
                    objContracttimelines.Contracttype = newStudy.ContractType;
                if (iscontractstatusrestricted == false)
                    objContracttimelines.Contracttimelinestatus = newStudy.Contracttimelinestatus;
                if (isversionrestricted == false)
                    objContracttimelines.Contractversion = newStudy.Contractversion;
                if (iscurrentlocationrestricted == false)
                    objContracttimelines.Currentlocation = newStudy.CurrentLocation;
                if (iscontactnamerestricted == false)
                    objContracttimelines.Contactname = newStudy.ContactName;
                if (isstatuschangedaterestricted == false)
                    objContracttimelines.Statuschange = newStudy.Statuschange;
                if (iscommentsrestricted == false)
                    objContracttimelines.Comments = newStudy.Comments;
              
                retVal = dbContextNavigate.SaveChanges(objContracttimelines, new Contracttimelines_H(), newStudy.ANJU_ChangedBy, eAuditChangeType.Update);
            }      
            else
            {
                DataAccess.Contracttimelines contracttimelines = new DataAccess.Contracttimelines()
                {
                    StudyId = newStudy.StudyId,
                    Contracttype = newStudy.Contracttype,
                    Contracttimelinestatus = newStudy.Contracttimelinestatus,
                    Contractversion = newStudy.Contractversion,
                    Currentlocation = newStudy.Currentlocation,
                    Contactname = newStudy.Contactname,
                    Statuschange = newStudy.Statuschange,
                    Comments = newStudy.Comments,
                    IsActive = true,
                    IsDeleted = false,
                    ANJU_AddedBy = userName,
                    ANJU_AddDate = DateTime.UtcNow
                };
                dbContextNavigate.SaveChanges(contracttimelines, new Contracttimelines_H(), userName, eAuditChangeType.Insert);
                retVal = contracttimelines.ContractId;
            }
            if (retVal > 0)
                return true;
            else
                return false;
        }



        /// <summary>
        /// Delete Contracts Timeline
        /// </summary>
        /// <param name="gmrcapprovaltask"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool DeleteContractsTimeline(Data.GMRCApprovalTask gmrcapprovaltask, string username)
        {
            int retVal = default(int);
            if (gmrcapprovaltask != null)
            {
                var result = dbContextNavigate.GMRCApprovalTask.Where(x => x.GMRCApprovalTaskId == gmrcapprovaltask.GMRCApprovalTaskId
                                                                        && x.StudyId == gmrcapprovaltask.StudyId).SingleOrDefault();
                if (result != null)
                {
                    result.IsDeleted = true;
                    result.IsActive = false;
                    result.ANJU_ChangedBy = username;
                    result.ANJU_ChangeDate = DateTime.UtcNow;
                };
                retVal = dbContextNavigate.SaveChanges(result, new GMRCApprovalTask_H(), username, eAuditChangeType.Delete);
                if (retVal > 0)
                    return true;
            }
            return false;
        }

        #endregion
    }
}
