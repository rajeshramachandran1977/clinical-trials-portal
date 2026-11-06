using System;
using System.Collections.Generic;
using System.Linq;
using Anju.Navigate.Data;
using Anju.Navigate.Utilities;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;

namespace Anju.Navigate.DataAccess
{
    public class UsersRepository
    {
        #region Properties
        private readonly Navigate30Context dbContextNavigate;
        private readonly UnitOfWork unitOfWork;
        #endregion

        #region Constructor

        public UsersRepository(Navigate30Context dbContext)
        {
            this.dbContextNavigate = new Navigate30Context();

        }
        #endregion

        #region Methods     
        /// <summary>
        /// Get Administrators Email
        /// </summary>
        /// <returns></returns>
        public string GetAdminEmail()
        {
            var userInfo = dbContextNavigate.Users.Where(x => (x.RoleId == 1)).Select(x => new Data.Users
            {
                PrimaryEmailId = x.PrimaryEmailId

            }).FirstOrDefault();

            return userInfo.PrimaryEmailId;
        }

        /// <summary>
        /// Check if User Name Exists
        /// </summary>
        /// <param name="forgotCredentials"></param>
        /// <returns>true/false</returns>
        public bool CheckifUserNameExists(Data.Users forgotCredentials)
        {
            var userInfo = dbContextNavigate.Users.Where(x => (x.UserName == forgotCredentials.UserName && x.PrimaryEmailId == forgotCredentials.PrimaryEmailId)).Select(x => new Data.Users
            {
                UserName = x.UserName

            }).FirstOrDefault();

            if (userInfo == null)
                return false;
            else
                return true;
        }
        /// <summary>
        /// To verify same password is used previously or not
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>true/false</returns>
        public bool isPrevPwdused(string username, string password)
        {
            var userInfo = dbContextNavigate.GlobalSettings.Where(x => x.GlobalKey == ConstDefaultValue.SEC_NUMBER_OF_PASSWORDS_TO_REMEMBER).Select(x => new Data.GlobalSettings
            {
                GlobalValue = x.GlobalValue

            }).FirstOrDefault();

            int NoOfPasswordstoremember = int.Parse(userInfo?.GlobalValue);
            if (NoOfPasswordstoremember > 0)
            {
                var pwdCount = dbContextNavigate.PasswordHistory.Where(x => (x.UserName == username)).OrderByDescending(x => x.PasswordId).Take(NoOfPasswordstoremember).Select(x => new Data.PasswordHistory
                {
                    Previouspassword = x.Previouspassword

                });

                var prevPwds = pwdCount.ToList();
                if (prevPwds != null)
                {
                    foreach (var item in prevPwds)
                    {
                        if (EncrypPassword.Encrypt(item.Previouspassword) == password)
                            return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// To check old password is valid or not.
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="oldPassWord"></param>
        /// <returns>true/false</returns>

        public bool IsValidOldPassWord(string userName, string oldPassWord)
        {
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(oldPassWord))
            {
                var userInfo = dbContextNavigate.Users.Where(x => (x.UserName == userName) && (x.Password == EncrypPassword.Encrypt(oldPassWord))).Select(x => new Data.Users
                {
                    UserName = x.UserName

                }).FirstOrDefault();

                return userInfo != null ? true : false;
            }
            else
                return false;
        }

        /// <summary>
        /// Change Password and update the Password History table with the password
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>retVal</returns>
        public int ChangePassword(string userName, string email, string password, string oldpassword = "")
        {
            int retVal = default(int);
            UnitOfWork unitOfWork = new UnitOfWork();

            if (!string.IsNullOrEmpty(userName))
            {
                DataAccess.Users objusers = dbContextNavigate.Users.FirstOrDefault(x => x.UserName == userName);
                var GlobalSettingsInfo = dbContextNavigate.GlobalSettings.Where(x => x.GlobalKey == ConstDefaultValue.SEC_NUMBER_OF_PASSWORDS_TO_REMEMBER).Select(x => new Data.GlobalSettings
                {
                    GlobalValue = x.GlobalValue

                }).FirstOrDefault();

                if (Convert.ToInt32(GlobalSettingsInfo?.GlobalValue) > 0 && objusers != null)
                {
                    DataAccess.PasswordHistory objPwdHist = new DataAccess.PasswordHistory()
                    {
                        UserName = objusers.UserName,
                        Previouspassword = !string.IsNullOrEmpty(oldpassword) ? oldpassword : objusers.Password,
                        Email = objusers.PrimaryEmailId,
                        IsActive = objusers.IsActive,
                        IsDeleted = objusers.IsDeleted,
                        ANJU_AddDate = DateTime.UtcNow,
                        ANJU_AddedBy = userName

                    };
                    dbContextNavigate.PasswordHistory.Add(objPwdHist);
                    retVal = dbContextNavigate.SaveChanges();
                }
                if (retVal > 0)
                {
                    if (objusers != null)
                    {
                        objusers.Password = password;
                        objusers.ANJU_ChangeDate = DateTime.UtcNow;
                        objusers.ANJU_ChangedBy = userName;
                        objusers.PasswordExpiryDate = DateTime.Now.AddDays(int.Parse(unitOfWork.Login.PasswordResetExpiryDays()));
                        objusers.IsActive = true;
                        objusers.IsDeleted = false;
                        objusers.IsAccountLocked = false;
                        retVal = dbContextNavigate.SaveChanges(objusers, new Users_H(), objusers.UserName, eAuditChangeType.Update);

                    }
                }
            }
            return retVal;
        }

        /// <summary>
        /// Get list of countries
        /// </summary>
        /// <returns>list of countries</returns>
        public List<Data.Country> GetCountries()
        {
            var lstCountries = dbContextNavigate.Country.Where(x => x.IsActive == true && x.IsDeleted == false)
                                                         .Select(x => new Data.Country
                                                         {
                                                             CountryId = x.CountryId,
                                                             Code = x.Code
                                                         }).ToList();
            return lstCountries;
        }
        /// <summary>
        /// Get list of states according to countryid
        /// </summary>
        /// <param name="countryID"></param>
        /// <returns>list of states</returns>
        public List<Data.State> GetStatesByCountryId(int? countryID)
        {
            if (countryID != null)
            {
                var lststates = dbContextNavigate.State.Where(x => (x.CountryId == countryID) && (x.IsActive == true) && (x.IsDeleted == false))
                                                        .Select(x => new Data.State
                                                        {
                                                            StateId = x.StateId,
                                                            Code = x.Code
                                                        }).ToList();
                return lststates;
            }
            else
                return new List<Data.State>();
        }
        /// <summary>
        /// Get list of cities as per stateID
        /// </summary>
        /// <param name="stateID"></param>
        /// <returns>list of cities</returns>
        public List<Data.City> GetCitiesByStateID(int? stateID)
        {
            if (stateID != null)
            {
                var lstcities = dbContextNavigate.City.Where(x => (x.StateId == stateID) && (x.IsActive == true) && (x.IsDeleted == false))
                                                       .Select(x => new Data.City
                                                       {
                                                           CityId = x.CityId,
                                                           Name = x.Name
                                                       }).ToList();
                return lstcities;
            }
            else
                return new List<Data.City>();
        }
        /// <summary>
        /// Get list of Users
        /// </summary>
        /// <param name=""></param>
        /// <returns>list of Users</returns>
        public List<Data.Users> GetUsers()
        {
            var lstUsers = dbContextNavigate.Users.Where(x => x.IsActive == true && x.IsDeleted == false).OrderBy(x =>x.FirstName).Select(x => new Data.Users
            {
                UserId = x.UserId,
                UserName = x.UserName,
                UserType = x.UserType,
                UserStatus = x.UserStatus,
                PrimaryEmailId = x.PrimaryEmailId,
                MobileNumber = x.MobileNumber,
                Address1 = x.Address1,
                FullName = x.FirstName + " " + x.LastName,
            }).ToList();
            return lstUsers;
        }

        /// <summary>
        ///  Get the UserDetails By UserId
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>list of Users</returns>
        public List<Data.Users> GetUserDetailsByUserId(int userID)
        {
            var lstUsers = dbContextNavigate.Users.Where(x => x.IsActive == true && x.IsDeleted == false && x.UserId == userID)
                                                         .Select(x => new Data.Users
                                                         {
                                                             UserId = x.UserId,
                                                             Salutation = x.Salutation,
                                                             UserType = x.UserType,
                                                             UserName = x.UserName,
                                                             UserStatus = x.UserStatus,
                                                             PrimaryEmailId = x.PrimaryEmailId,
                                                             MobileNumber = x.MobileNumber,
                                                             Address1 = x.Address1,
                                                             Department = x.Department,
                                                             Suffix = x.Suffix,
                                                             FirstName = x.FirstName,
                                                             LastName = x.LastName,
                                                             Title = x.Title,
                                                             Address2 = x.Address2,
                                                             CountryId = x.CountryId,
                                                             StateId = x.StateId,
                                                             CityId = x.CityId,
                                                             Zip = x.Zip,
                                                             Fax = x.Fax,
                                                             Password = x.Password,
                                                             OrganizationName = x.OrganizationName,




                                                         }).ToList();

            return lstUsers;
        }

        /// <summary>
        ///  Get the UserCredentials By UserId
        /// </summary>
        /// <param name="userID"></param>
        /// <returns>list of Users</returns>
        public List<Data.UserCredentials> GetUserCredentialsByUserId(int userID)
        {
            var lstUserCredentials = dbContextNavigate.UserCredentials.Where(x => x.IsActive == true && x.IsDeleted == false && x.UserId == userID)
                                                         .Select(x => new Data.UserCredentials
                                                         {
                                                             CredentialId = x.CredentialId

                                                         }).ToList();

            return lstUserCredentials;
        }

        /// <summary>
        /// Save User details
        /// </summary>
        /// <param name="user"></param>
        /// <param name="credetials"></param>
        /// <param name="message"></param>
        /// <returns>true/false</returns>
        public bool SaveUserDetails(Data.Users users, string[] userCredentials)
        {
            int retVal = default(int);
            UnitOfWork unitOfWork = new UnitOfWork();
            IEnumerable<UserCredentials> lsCredential = new HashSet<UserCredentials>();
            if (users != null)
            {
                DataAccess.Users objusers = new DataAccess.Users()
                {
                    Salutation = users.Salutation,
                    FirstName = users.FirstName,
                    LastName = users.LastName,
                    Title = users.Title,
                    OrganizationName = users.OrganizationName,
                    Department = users.Department,
                    Address1 = users.Address1,
                    Address2 = users.Address2,
                    CityId = users.CityId,
                    StateId = users.StateId,
                    CountryId = users.CountryId,
                    Zip = users.Zip,
                    MobileNumber = users.MobileNumber,
                    Fax = users.Fax,
                    PrimaryEmailId = users.PrimaryEmailId,
                    UserName = users.UserName,
                    Password = EncrypPassword.Encrypt(users.Password),
                    PasswordExpiryDate = DateTime.Now.AddDays(int.Parse(unitOfWork.Login.PasswordResetExpiryDays())),
                    UserType = users.UserType,
                    Suffix = users.Suffix,
                    UserStatus = users.UserStatus?.Trim(),
                    IsActive = true,
                    FailedAttempts = 0,
                    EndUserType = users.EndUserType,
                    IsDeleted = false,
                    IsAccountLocked = false

                };
                retVal = dbContextNavigate.SaveChanges(objusers, new Users_H(), users.UserName, eAuditChangeType.Insert);

                if (retVal > 0 && userCredentials != null)
                {
                    var userDetails = dbContextNavigate.Users.Where(x => x.UserName == users.UserName && x.IsActive == true && x.IsDeleted == false && x.IsAccountLocked == false).SingleOrDefault();
                    foreach (string CredentialID in userCredentials)
                    {
                        DataAccess.UserCredentials objusercredentials = new UserCredentials()
                        {
                            UserId = userDetails.UserId,
                            CredentialId = Convert.ToInt32(CredentialID),
                            IsActive = true,
                            IsDeleted = false,
                            ANJU_AddedBy = users.UserName,
                            ANJU_AddDate = DateTime.UtcNow,
                        };
                        retVal = dbContextNavigate.SaveChanges(objusercredentials, new UserCredentials_H(), users.UserName, eAuditChangeType.Insert);
                    }

                    if (retVal > 0)
                        return true;
                    else
                        return false;
                }


            }

            return false;
        }

        /// <summary>
        /// Update User details
        /// </summary>
        /// <param name="user"></param>
        /// <param name="credetials"></param>
        /// <param name="message"></param>
        /// <returns>true/false</returns>
        public bool UpdateUserDetails(Data.Users users, string[] userCredentials)
        {
            int retVal = default(int);
            UnitOfWork unitOfWork = new UnitOfWork();
            UserCredentials objusercredentials = null;

            var userdetails = dbContextNavigate.Users.Where(x => x.UserId == users.UserId).SingleOrDefault();
            var userCredential = dbContextNavigate.UserCredentials.Where(x => x.UserId == users.UserId && x.IsActive == true).ToList();
            var userDisabled = dbContextNavigate.ProxyUserDetails.Where(x => x.UserName == users.UserName && x.IsActive == true && x.IsDeleted == false).ToList();

            if (userdetails != null)
            {
                userdetails.Salutation = users.Salutation;
                userdetails.FirstName = users.FirstName;
                userdetails.LastName = users.LastName;
                userdetails.Title = users.Title;
                userdetails.Department = users.Department;
                userdetails.Address1 = users.Address1;
                userdetails.Address2 = users.Address2;
                userdetails.CityId = users.CityId;
                userdetails.StateId = users.StateId;
                userdetails.CountryId = users.CountryId;
                userdetails.Zip = users.Zip;
                userdetails.MobileNumber = users.MobileNumber;
                userdetails.Fax = users.Fax;
                userdetails.PrimaryEmailId = users.PrimaryEmailId;
                userdetails.UserName = users.UserName;                   
                if (!string.IsNullOrEmpty(users?.Password) && userdetails.Password != users.Password)
                    userdetails.Password = EncrypPassword.Encrypt(users?.Password);
                userdetails.UserType = users.UserType;
                userdetails.Suffix = users.Suffix;
                userdetails.UserStatus = users.UserStatus?.Trim();
                userdetails.ANJU_ChangeDate = DateTime.UtcNow;
                userdetails.ANJU_ChangedBy = users.UserName;
                userdetails.IsActive = users.IsActive;
                userdetails.IsDeleted = users.IsDeleted;

                if (userdetails.UserStatus == Utilities.ConstDefaultValue.ACTIVEUSERSTATUS)
                {
                    userdetails.IsAccountLocked = false;
                    userdetails.FailedAttempts = 0;
                }
                retVal = dbContextNavigate.SaveChanges(userdetails, new Users_H(), userdetails.UserName, eAuditChangeType.Update);

                if (retVal > 0)
                {
                    if (users.UserStatus == Utilities.ConstDefaultValue.DISABLEDUSERSTATUS)
                    {
                        if (userDisabled.Count > 0)
                        {
                            foreach (var item in userDisabled)
                            {
                                item.IsActive = false;
                                item.IsDeleted = false;
                                item.ANJU_ChangedBy = users.UserName;
                                item.ANJU_ChangeDate = DateTime.UtcNow; ;
                                retVal = dbContextNavigate.SaveChanges(item, new ProxyUserDetails_H(), users.UserName, eAuditChangeType.Update);
                            }
                        }
                    }
                    else
                    {
                        var userEnable = dbContextNavigate.ProxyUserDetails.Where(x => x.UserName == users.UserName && x.IsActive == false && x.IsDeleted == false).ToList();
                        if (userEnable.Count > 0)
                        {
                            foreach (var item in userEnable)
                            {
                                item.IsActive = true;
                                item.IsDeleted = false;
                                item.ANJU_ChangedBy = users.UserName;
                                item.ANJU_ChangeDate = DateTime.UtcNow; ;
                                retVal = dbContextNavigate.SaveChanges(item, new ProxyUserDetails_H(), users.UserName, eAuditChangeType.Update);
                            }
                        }

                    }
                    if (userCredentials.Length > 0)
                    {
                        foreach (var item in userCredential)
                        {
                            if (!userCredentials.Contains(Convert.ToString(item.CredentialId)))
                            {
                                item.IsActive = false;
                                item.IsDeleted = true;
                                retVal = dbContextNavigate.SaveChanges(item, new UserCredentials_H(), userdetails.UserName, eAuditChangeType.Delete);
                            }
                        }
                        if (retVal > 0)
                        {
                            userCredential = dbContextNavigate.UserCredentials.Where(x => x.UserId == users.UserId && x.IsActive == true).ToList();
                            for (int i = 0; i < userCredentials.Length; i++)
                            {
                                var IsalreadyExistedCredentials = userCredential.Where(x => x.CredentialId == Convert.ToInt32(userCredentials[i])).ToList();

                                if (IsalreadyExistedCredentials == null || IsalreadyExistedCredentials.Count == 0)
                                {
                                    objusercredentials = new UserCredentials()
                                    {
                                        UserId = userdetails.UserId,
                                        CredentialId = Convert.ToInt32(userCredentials[i]),
                                        IsActive = true,
                                        IsDeleted = false,
                                        ANJU_AddedBy = users.UserName,
                                        ANJU_AddDate = DateTime.UtcNow
                                    };
                                    retVal = dbContextNavigate.SaveChanges(objusercredentials, new UserCredentials_H(), userdetails.UserName, eAuditChangeType.Insert);

                                }

                            }
                            return true;
                        }
                        else
                            return false;
                    }
                    else if (userCredential.Count > 0)
                    {
                        foreach (var item in userCredential)
                        {
                            item.IsActive = false;
                            item.IsDeleted = true;
                            retVal = dbContextNavigate.SaveChanges(item, new UserCredentials_H(), userdetails.UserName, eAuditChangeType.Delete);
                        }
                        if (retVal > 0)
                            return true;
                        else
                            return false;

                    }
                    else
                        return true;
                }
                else
                    return false;
            }
            return false;
        }

        /// <summary>
        /// Validate the userName
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>true/false</returns>
        public bool IsValidUserName(string userName)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                var userInfo = dbContextNavigate.Users.Where(x => (x.IsDeleted == false && x.UserName == userName)).Select(x => new Data.Users
                {
                    UserName = x.UserName

                }).FirstOrDefault();

                return userInfo == null ? true : false;
            }
            else
                return false;
        }
        /// <summary>
        /// Validate the Email ID
        /// </summary>
        /// <param name="primaryEmailid"></param>
        /// <returns>true/false</returns>
        public bool IsvalidEmailid(string primaryEmailid)
        {
            if (!string.IsNullOrEmpty(primaryEmailid))
            {
                var userInfo = dbContextNavigate.Users.Where(x => (x.IsDeleted == false && x.PrimaryEmailId == primaryEmailid)).Select(x => new Data.Users
                {
                    UserName = x.PrimaryEmailId

                }).FirstOrDefault();

                return userInfo == null ? true : false;

            }
            else
                return false;
        }
        /// <summary>
        /// Delete Users 
        /// </summary>
        /// <param name="users"></param>
        /// <returns>true/false</returns>
        public bool DeleteUsers(Data.Users users)
        {
            int retVal = default(int);
            if (users != null)
            {

                var result = dbContextNavigate.Users.Where(x => x.UserId == users.UserId).SingleOrDefault();
                var usercredential = dbContextNavigate.UserCredentials.Where(x => x.UserId == users.UserId).ToList();
                var userproxylist = dbContextNavigate.ProxyUserDetails.Where(x => x.UserName == users.UserName).ToList();

                if (result != null)
                {
                    result.UserId = users.UserId;
                    result.IsActive = false;
                    result.IsDeleted = true;
                    result.ANJU_ChangedBy = users.UserName;
                    result.ANJU_ChangeDate = DateTime.UtcNow;
                    retVal = dbContextNavigate.SaveChanges(result, new Users_H(), users.UserName, eAuditChangeType.Delete);
                    if (retVal > 0 && usercredential.Count > 0)
                    {
                        foreach (var item in usercredential)
                        {
                            item.IsActive = false;
                            item.IsDeleted = true;
                            item.ANJU_ChangedBy = users.UserName;
                            item.ANJU_ChangeDate = DateTime.UtcNow; ;
                            retVal = dbContextNavigate.SaveChanges(item, new UserCredentials_H(), users.UserName, eAuditChangeType.Delete);
                        }
                    }
                    if (retVal > 0 && userproxylist.Count > 0)
                    {
                        foreach (var item in userproxylist)
                        {
                            item.IsActive = false;
                            item.IsDeleted = true;
                            item.ANJU_ChangedBy = users.UserName;
                            item.ANJU_ChangeDate = DateTime.UtcNow; ;
                            retVal = dbContextNavigate.SaveChanges(item, new ProxyUserDetails_H(), users.UserName, eAuditChangeType.Delete);
                        }
                    }
                    if (retVal > 0)
                        return true;
                    else
                        return false;

                }
            }
            return false;
        }

        /// <summary>
        ///  Get the UserDetails By UserName
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>list of Users</returns>
        public Data.Users GetUserDetailsByUserName(string userName)
        {
            Data.Users objUsers = new Data.Users();
            var lstUsers = dbContextNavigate.Users.Where(x => x.IsActive == true && x.IsDeleted == false && x.UserName == userName)
                                                        .Select(x => new Data.Users
                                                        {
                                                            UserId = x.UserId,
                                                            Salutation = x.Salutation,
                                                            UserType = x.UserType,
                                                            UserName = x.UserName,
                                                            UserStatus = x.UserStatus,
                                                            PrimaryEmailId = x.PrimaryEmailId,
                                                            MobileNumber = x.MobileNumber,
                                                            Address1 = x.Address1,
                                                            Department = x.Department,
                                                            Suffix = x.Suffix,
                                                            FirstName = x.FirstName,
                                                            LastName = x.LastName,
                                                            Title = x.Title,
                                                            Address2 = x.Address2,
                                                            CountryId = x.CountryId,
                                                            StateId = x.StateId,
                                                            CityId = x.CityId,
                                                            Zip = x.Zip,
                                                            Fax = x.Fax,
                                                            OrganizationName = x.OrganizationName,
                                                        }).ToList();

            objUsers = lstUsers[0];
            var usercredential = dbContextNavigate.UserCredentials.Where(x => x.IsActive == true && x.IsDeleted == false && x.UserId == objUsers.UserId).ToList();
            foreach (var item in usercredential)
            {
                Data.UserCredentials objUsercredential = new Data.UserCredentials()
                {
                    CredentialId = item.CredentialId
                };
                objUsers.UserCredentials.Add(objUsercredential);
            }

            return objUsers;
        }

        /// <summary>
        ///  Get the UserDetails By UserType
        /// </summary>
        /// <param name="userType"></param>
        /// <returns>list of Users</returns>
        public List<Data.Users> GetUserDetailsByUserType(string userType)
        {
            var lstUsers = dbContextNavigate.Users.Where(x => x.IsActive == true && x.IsDeleted == false && x.UserType == userType)
                                                         .Select(x => new Data.Users
                                                         {
                                                             UserId = x.UserId,
                                                             UserName = x.UserName

                                                         }).ToList();

            return lstUsers;
        }


        /// <summary>
        /// Get Related Users Associated with a Study
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns>List</returns>
        public List<Data.Users> GetRelatedUsersAssociatedwithaStudy(int studyId)
        {

            List<Data.Users> lstUsers = new List<Data.Users>();
            if (studyId > 0)
            {
                var result = dbContextNavigate?.NewStudy?.AsEnumerable()
                                    .Join(dbContextNavigate?.Users?.AsEnumerable(),
                                            Ns => new { username = Ns?.ANJU_AddedBy?.ToString() },
                                            u => new { username = u?.UserName?.ToString() },
                                            (Ns, u) => new { Ns, u }).ToList()
                                    .Where(x => x?.Ns?.StudyId == studyId && x?.Ns?.IsActive == true && x?.Ns?.IsDeleted == false)
                                    .Select(x => new Data.Users
                                    {
                                        UserId = x.u.UserId,
                                        FirstName = x?.u?.FirstName,
                                        LastName = x?.u?.LastName,
                                        PrimaryEmailId = x?.u?.PrimaryEmailId,
                                        MobileNumber = x?.u?.MobileNumber,
                                        UserType = x?.u?.UserType,
                                        ANJU_AddDate = x?.u?.ANJU_AddDate

                                    }).Union(dbContextNavigate?.StudyTask?.AsEnumerable()
                                    .Join(dbContextNavigate?.Users?.AsEnumerable(),
                                            st => new { MSLuserId = st?.MsluserId },
                                            u => new {  MSLuserId = u?.UserId },
                                            (st, u) => new { st, u }).ToList()
                                     .Where(x => x?.st?.StudyId == studyId && x?.st?.IsActive == true && x?.st?.IsDeleted == false)
                                       .Select(x => new Data.Users
                                       {
                                           UserId = x.u.UserId,
                                           FirstName = x.u?.FirstName,
                                           LastName = x.u?.LastName,
                                           PrimaryEmailId = x.u?.PrimaryEmailId,
                                           MobileNumber = x.u?.MobileNumber,
                                           UserType = x.u?.UserType,
                                           ANJU_AddDate = x.st?.ANJU_AddDate

                                       })
                                    ).Union(dbContextNavigate?.StudyTask?.AsEnumerable()
                                    .Join(dbContextNavigate?.Users?.AsEnumerable(),
                                            st => new { PLuserId = st?.PluserId },
                                            u => new { PLuserId = u?.UserId },
                                            (st, u) => new { st, u }).ToList()
                                     .Where(x => x?.st?.StudyId == studyId && x?.st?.IsActive == true && x?.st?.IsDeleted == false)
                                       .Select(x => new Data.Users
                                       {
                                           UserId = x.u.UserId,
                                           FirstName = x.u?.FirstName,
                                           LastName = x.u?.LastName,
                                           PrimaryEmailId = x.u?.PrimaryEmailId,
                                           MobileNumber = x.u?.MobileNumber,
                                           UserType = x.u?.UserType,
                                           ANJU_AddDate = x.st?.ANJU_AddDate

                                       })
                                    ).Union(dbContextNavigate?.PLStudyReview?.AsEnumerable()
                                    .Join(dbContextNavigate?.Users?.AsEnumerable(),
                                            PL => new { TLuserId = PL?.TluserId },
                                            u => new { TLuserId = u?.UserId },
                                            (PL, u) => new { PL, u }).ToList()
                                     .Where(x => x?.PL?.StudyId == studyId && x?.PL?.IsActive == true && x?.PL?.IsDeleted == false)
                                       .Select(x => new Data.Users
                                       {
                                           UserId = x.u.UserId,
                                           FirstName = x.u?.FirstName,
                                           LastName = x.u?.LastName,
                                           PrimaryEmailId = x.u?.PrimaryEmailId,
                                           MobileNumber = x.u?.MobileNumber,
                                           UserType = x.u?.UserType,
                                           ANJU_AddDate = x.PL?.ANJU_AddDate

                                       })).Union(dbContextNavigate?.MRCStudyReview?.AsEnumerable()
                                    .Join(dbContextNavigate?.Users.AsEnumerable(),
                                            Mrc => new { username = Mrc?.LocalMrcdecisionMadeBy?.ToString() },
                                            u => new { username = u?.UserName?.ToString() },
                                            (Mrc, u) => new { Mrc, u }).ToList()
                                     .Where(x => x?.Mrc?.StudyId == studyId && x?.Mrc?.IsActive == true && x?.Mrc?.IsDeleted == false && x?.Mrc?.RecordType == Utilities.ConstDefaultValue.LOCALMRC)
                                       .Select(x => new Data.Users
                                       {
                                           UserId = x.u.UserId,
                                           FirstName = x.u?.FirstName,
                                           LastName = x.u?.LastName,
                                           PrimaryEmailId = x.u?.PrimaryEmailId,
                                           MobileNumber = x.u?.MobileNumber,
                                           UserType = x.u?.UserType,
                                           ANJU_AddDate = x.Mrc?.ANJU_AddDate

                                       }))
                                    .ToList();
                return result;
            }

            return lstUsers;
        }


        #endregion
    }
}

