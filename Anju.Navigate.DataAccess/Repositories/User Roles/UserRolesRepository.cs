using Anju.Navigate.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Anju.Navigate.DataAccess
{
    public class UserRolesRepository
    {
        #region Properties
        private readonly Navigate30Context dbContextNavigate;
        UsersRepository usrrep = new UsersRepository(dbContext);
        private static Navigate30Context dbContext;
        #endregion

        #region Constructor

        public UserRolesRepository(Navigate30Context dbContext)
        {
            this.dbContextNavigate = new Navigate30Context();

        }
        #endregion

        #region Methods     
        /// <summary>
        /// Get the list of User Roles
        /// </summary>
        /// <returns>lstUserRoles</returns>
        public List<Data.UserRoles> GetUserRoles()
        {
            var lstUserRoles = dbContextNavigate.UserRoles.Where(x => x.IsActive == true && x.IsDeleted == false)
                                                         .Select(x => new Data.UserRoles
                                                         {
                                                             UserRoleId = x.UserRoleId,
                                                             Name = x.Name,
                                                             Description = x.Description,
                                                             IsActive = x.IsActive,
                                                             IsDeleted = x.IsDeleted
                                                         }).ToList();
            return lstUserRoles;
        }
        /// <summary>
        /// Create User Roles
        /// </summary>
        /// <param name="userRoles"></param>
        /// <returns>true/false</returns>
        public bool CreateUserRoles(Data.UserRoles userRoles, string userName)
        {
            int retVal = default(int);
            if (userRoles != null)
            {
                DataAccess.UserRoles objuserRoles = new DataAccess.UserRoles()
                {
                    Name = userRoles.Name,
                    Description = userRoles.Description,
                    IsActive = userRoles.IsActive,
                    IsDeleted = false,
                    ANJU_AddedBy = userName,
                    ANJU_AddDate = DateTime.UtcNow
                };
                retVal = dbContextNavigate.SaveChanges(objuserRoles, new UserRoles_H(), userName, eAuditChangeType.Insert);
                if (retVal > 0)
                    return true;
            }
            return false;

        }

        /// <summary>
        /// Update User Roles
        /// </summary>
        /// <param name="userRoles"></param>
        /// <returns>true/false</returns>
        public bool UpdateUserRoles(Data.UserRoles userRoles, string userName)
        {
            int retVal = default(int);
            if (userRoles != null)
            {
                DataAccess.UserRoles objuserRoles = new DataAccess.UserRoles()
                {
                    UserRoleId = userRoles.UserRoleId,
                    Name = userRoles.Name,
                    Description = userRoles.Description,
                    IsActive = userRoles.IsActive,
                    IsDeleted = false,
                    ANJU_ChangedBy = userName,
                    ANJU_ChangeDate = DateTime.UtcNow
                };
                retVal = dbContextNavigate.SaveChanges(objuserRoles, new UserRoles_H(), userName, eAuditChangeType.Update);
                if (retVal > 0)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Delete User Roles
        /// </summary>
        /// <param name="userRoles"></param>
        /// <returns>true/false</returns>
        public bool DeleteUserRoles(Data.UserRoles userRoles, string userName)
        {
            int retVal = default(int);
            if (userRoles != null)
            {
                DataAccess.UserRoles objuserRoles = new DataAccess.UserRoles()
                {
                    UserRoleId = userRoles.UserRoleId,
                    Name = userRoles.Name,
                    Description = userRoles.Description,
                    IsActive = false,
                    IsDeleted = true,
                    ANJU_ChangedBy = userName,
                    ANJU_ChangeDate = DateTime.UtcNow
                };
                retVal = dbContextNavigate.SaveChanges(objuserRoles, new UserRoles_H(), userName, eAuditChangeType.Delete);
                if (retVal > 0)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Create Proxy user
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>true/false</returns>
        public bool CreateProxyUser(string userName, string loginUser)
        {
            int retVal = default(int);
            bool result = false;
            string checkuser = dbContextNavigate.Users.Where(x => x.UserName == userName)
                                .Select(x => x.UserName).FirstOrDefault();
            if (!string.IsNullOrEmpty(checkuser))
            {
                var dbEntry = dbContextNavigate.ProxyUserDetails.Where(x => x.UserName == loginUser && x.ProxyUserName == userName).ToList();

                if (dbEntry.Count > 0)
                {
                    int isactive = dbEntry.Where(x => x.IsActive == true).Count();
                    if (isactive > 0)
                        return true;
                    else
                    {
                        DataAccess.ProxyUserDetails objProxyUserDetails = new ProxyUserDetails()
                        {
                            ProxyUserName = userName,
                            UserName = loginUser,
                            Created = DateTime.UtcNow,
                            IsActive = true,
                            IsDeleted = false,
                            ANJU_AddedBy = loginUser,
                            ANJU_AddDate = DateTime.UtcNow
                        };
                        retVal = dbContextNavigate.SaveChanges(objProxyUserDetails, new ProxyUserDetails_H(), loginUser, eAuditChangeType.Insert);
                        if (retVal > 0)
                            return true;
                        else
                            return false;
                    }
                }
                else
                {

                    DataAccess.ProxyUserDetails objProxyUserDetails = new ProxyUserDetails()
                    {
                        ProxyUserName = userName,
                        UserName = loginUser,
                        Created = DateTime.UtcNow,
                        IsActive = true,
                        IsDeleted = false,
                        ANJU_AddedBy = loginUser,
                        ANJU_AddDate = DateTime.UtcNow
                    };
                    retVal = dbContextNavigate.SaveChanges(objProxyUserDetails, new ProxyUserDetails_H(), loginUser, eAuditChangeType.Insert);
                    if (retVal > 0)
                        return true;
                    else
                        return false;
                }
            }
            else
                result = false;
            return result;
        }

        /// <summary>
        /// Remove Proxy user
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>true/false</returns>
        public void DeleteProxyUser(string proxyUsers, string loginUserName)
        {
            int retVal = 0; string[] proxyuserid = null;
            if (!string.IsNullOrEmpty(proxyUsers))
                proxyuserid = proxyUsers.Split(',');
            var result = dbContextNavigate.ProxyUserDetails.Where(x => x.UserName == loginUserName && x.IsActive == true && x.IsDeleted == false).ToList();
            foreach (var item in result)
            {
                if (proxyuserid != null)
                {
                    if (!proxyuserid.Contains(item.ProxyUserName))
                    {
                        item.IsActive = false;
                        item.IsDeleted = true;
                        retVal = dbContextNavigate.SaveChanges(item, new ProxyUserDetails_H(), loginUserName, eAuditChangeType.Delete);
                    }
                }
                else
                {
                    item.IsActive = false;
                    item.IsDeleted = true;
                    retVal = dbContextNavigate.SaveChanges(item, new ProxyUserDetails_H(), loginUserName, eAuditChangeType.Delete);
                }

            }
        }

        /// <summary>
        /// Get Proxy user
        /// </summary>       
        /// <returns>string</returns>
        public string GetProxyUser(string loginuser)
        {
            string proxyuserdetails = "";
            int count = 0;
            var proxyuser = dbContextNavigate.ProxyUserDetails.Where(x => x.UserName == loginuser && x.IsActive == true)
                           .Select(x => x.ProxyUserName).ToList();
            foreach (var item in proxyuser)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    if (count == 0)
                        proxyuserdetails += item;
                    else
                        proxyuserdetails += "," + item;
                    count++;
                }

            }
            return proxyuserdetails;
        }

        /// <summary>
        /// Get switch user
        /// </summary> 
        /// <param name="userName"></param>
        /// <returns>string</returns>
        public List<Data.ProxyUserDetails> GetSwitchUsers(string userName, string selectedUser)
        {

            Data.ProxyUserDetails objlogin = new Data.ProxyUserDetails()
            {
                ProxyUserName = ConstDefaultValue.SWITCHTOLOGINUSER,
                Id = 0
            };

            // List<Data.ProxyUserDetails> lstusers = new List<Data.ProxyUserDetails>();
            var lstusers = dbContextNavigate.ProxyUserDetails.Where(x => x.ProxyUserName == userName && x.IsActive == true && x.IsDeleted == false)
                         .Select(x => new Data.ProxyUserDetails
                         {
                             ProxyUserName = x.UserName,
                             Id = x.Id

                         }).ToList();
            lstusers.Add(objlogin);
            if (!string.IsNullOrEmpty(selectedUser))
                foreach (var item in lstusers.Where(r => r.ProxyUserName.ToUpper() == selectedUser.ToUpper()))
                {
                    item.Id = -1;
                }

            return lstusers;
        }



        /// <summary>
        /// Create/Update Roles
        /// </summary>
        /// <param name="newStudy"></param>
        /// <param name="usertype"></param>
        /// <param name="userName"></param>
        /// <returns>retVal</returns>
        public bool CreateUpdateRoles(Data.NewStudy newStudy, string usertype, string userName)
        {
            int retVal = default(int);
            if (newStudy != null)
            {
                var result = usrrep.GetUserDetailsByUserId(newStudy.UserId);
                if (result != null)
                {
                    var objPLStudyReview = dbContextNavigate.PLStudyReview.Where(x => x.StudyId == newStudy.StudyId).FirstOrDefault();
                    if (objPLStudyReview != null)
                    {
                        switch (result[0].UserType)
                        {
                            case ConstDefaultValue.TRIALLEADER:
                                objPLStudyReview.TluserId = result[0].UserId;
                                objPLStudyReview.ANJU_ChangedBy = userName;
                                objPLStudyReview.ANJU_ChangeDate = DateTime.UtcNow;
                                retVal = dbContextNavigate.SaveChanges(objPLStudyReview, new PLStudyReview_H(), userName, eAuditChangeType.Update);
                                break;
                            case ConstDefaultValue.PROGRAMLEADER:
                                objPLStudyReview.PLuserId = result[0].UserId;
                                objPLStudyReview.ANJU_ChangedBy = userName;
                                objPLStudyReview.ANJU_ChangeDate = DateTime.UtcNow;
                                retVal = dbContextNavigate.SaveChanges(objPLStudyReview, new PLStudyReview_H(), userName, eAuditChangeType.Update);
                                break;
                            default:
                                break;
                        }
                    }

                    if (result[0].UserType == ConstDefaultValue.MSL)
                    {
                        var objStudyReview = dbContextNavigate.StudyReview.Where(x => x.StudyId == newStudy.StudyId).FirstOrDefault();
                        if (objStudyReview != null)
                        {
                            objStudyReview.MsluserId = result[0].UserId;
                            objStudyReview.ANJU_ChangedBy = userName;
                            objStudyReview.ANJU_ChangeDate = DateTime.UtcNow;
                            retVal = dbContextNavigate.SaveChanges(objStudyReview, new StudyReview_H(), userName, eAuditChangeType.Update);
                        }

                        var objStudytask = dbContextNavigate.StudyTask.Where(x => x.StudyId == newStudy.StudyId).FirstOrDefault();
                        if (objStudytask != null)
                        {
                            objStudytask.MsluserId = result[0].UserId;
                            objStudytask.ANJU_ChangedBy = userName;
                            objStudytask.ANJU_ChangeDate = DateTime.UtcNow;
                            retVal = dbContextNavigate.SaveChanges(objStudytask, new StudyTask_H(), userName, eAuditChangeType.Update);
                        }
                    }

                    if (result[0].UserType == ConstDefaultValue.MD)
                    {
                        var objMRCStudyReview = dbContextNavigate.MRCStudyReview.Where(x => x.StudyId == newStudy.StudyId && x.RecordType == ConstDefaultValue.LOCALMRC).FirstOrDefault();
                        if (objMRCStudyReview != null)
                        {
                            objMRCStudyReview.LocalMrcdecisionMadeBy = result[0].UserName;
                            objMRCStudyReview.ANJU_ChangedBy = userName;
                            objMRCStudyReview.ANJU_ChangeDate = DateTime.UtcNow;
                            retVal = dbContextNavigate.SaveChanges(objMRCStudyReview, new MRCStudyReview_H(), userName, eAuditChangeType.Update);
                        }
                    }
                }                
            }
            if (retVal > 0)
                return true;
            else
                return false;
        }
        #endregion
    }
}