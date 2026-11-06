using Anju.Navigate.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Anju.Navigate.DataAccess
{
    public class LoginRepository 
    {
        #region Properties
        private readonly Navigate30Context dbContextNavigate;       
        #endregion

        #region Constructor       
        public LoginRepository(Navigate30Context dbContext)
        {
            dbContextNavigate = new Navigate30Context();

        }
        #endregion

        #region Methods     

        /// <summary>
        /// Validate Login Credentials
        /// </summary>
        /// <param name="users"></param>
        /// <returns>userInfo</returns>
        public Data.Users ValidateLoginCredential(Data.Users users, out bool isPasswordExpired,out string errorMessage )
        {

            isPasswordExpired = false;
            errorMessage = "";
            var userInfo = dbContextNavigate.Users.Where(x => (x.UserName.ToUpper() == users.UserName.ToUpper()) && x.Password == EncrypPassword.Encrypt(users.Password) && x.IsActive == true && x.IsDeleted == false).Select(x => new Data.Users
            {
                UserId = x.UserId,
                UserName = x.UserName,
                Password = x.Password,
                PasswordExpiryDate = x.PasswordExpiryDate,
                UserType = x.UserType,
                EndUserType = x.EndUserType,
                UserStatus = x.UserStatus,
                IsAccountLocked = x.IsAccountLocked

            }).FirstOrDefault();
            if(userInfo ?.UserStatus?.Trim() == Utilities.ConstDefaultValue.ACTIVEUSERSTATUS && userInfo?.IsAccountLocked == false) {
                if (userInfo?.PasswordExpiryDate != null)
                {
                    if (userInfo.PasswordExpiryDate >= DateTime.UtcNow)
                    {
                        isPasswordExpired = false;
                    }
                    else
                    {
                        isPasswordExpired = true;
                    }
                }

                DataAccess.Users objusers = dbContextNavigate.Users.Where(x => x.UserName == users.UserName).FirstOrDefault();
                if (objusers != null)
                {
                    userInfo.FailedAttempts = 0;
                    dbContextNavigate.Users.Update(objusers);
                    dbContextNavigate.SaveChanges();
                }  
            }
            else if(userInfo?.UserStatus?.Trim() == Utilities.ConstDefaultValue.DISABLEDUSERSTATUS && userInfo?.IsAccountLocked == false)
            {
                errorMessage = Utilities.Messages.USERDISABLEERRORMESSAGE;
            }
            else if(userInfo?.UserStatus?.Trim() == Utilities.ConstDefaultValue.LOCKEDUSERSTATUS)
            {
                errorMessage = Utilities.Messages.AccountLocked;
            }          
         
            return (userInfo?.UserStatus?.Trim() == Utilities.ConstDefaultValue.ACTIVEUSERSTATUS && userInfo?.IsAccountLocked == false) ? userInfo: new Data.Users();          
        }

        /// <summary>
        /// Validate Proxy User Credentials
        /// </summary>
        /// <param name="loginUser"></param>
        /// <param name="proxyUser"></param>
        /// <returns>userInfo</returns>
        public Data.Users ValidateProxyUser(string loginUser, string proxyUser)
        {
            var userInfo = new Data.Users();
            if (proxyUser.ToUpper() == ConstDefaultValue.SWITCHTOLOGINUSER.ToUpper())
            {
                userInfo = dbContextNavigate.Users.Where(x => (x.UserName.ToUpper() == loginUser.ToUpper()) && x.IsAccountLocked == false).Select(x => new Data.Users
                {
                    UserId = x.UserId,
                    UserName = x.UserName,
                    Password = x.Password,
                    PasswordExpiryDate = x.PasswordExpiryDate,
                    UserType = x.UserType,
                    EndUserType = x.EndUserType


                }).FirstOrDefault();
                return userInfo != null ? userInfo : new Data.Users();
            }



            var proxyuserdetails = dbContextNavigate.ProxyUserDetails.Where(x => x.ProxyUserName == loginUser && x.UserName == proxyUser && x.IsActive == true)
                                .Select(x => new ProxyUserDetails
                                {
                                     UserName =x.UserName,
                                     IsActive=x.IsActive

                                }).FirstOrDefault();

            if(proxyuserdetails!=null)
            {
                userInfo = dbContextNavigate.Users.Where(x => (x.UserName.ToUpper() == proxyUser.ToUpper()) &&  x.IsAccountLocked == false).Select(x => new Data.Users
                {
                    UserId = x.UserId,
                    UserName = x.UserName,
                    Password = x.Password,
                    PasswordExpiryDate = x.PasswordExpiryDate,
                    UserType = x.UserType,
                    EndUserType = x.EndUserType


                }).FirstOrDefault();
            }
          
           
            return userInfo != null ? userInfo : new Data.Users();
        }

        /// <summary>
        /// Get Count of Failed Attempts
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>retVal</returns>
        public int GetCountofFailedAttempts(string userName)
        {
            int retVal = default(int);
            var userInfo = dbContextNavigate.Users.Where(x => (x.UserName.ToUpper() == userName.ToUpper())).Select(x => new Data.Users
            {                  
                FailedAttempts = x.FailedAttempts

            }).FirstOrDefault();            
            if (userInfo != null)
               return userInfo.FailedAttempts.Value;
            else
                return retVal;
        }

        /// <summary>
        /// Get Login Attempts Permitted
        /// </summary>
        /// <returns>userInfo.GlobalValue.Value</returns>
        public string GetLoginAttemptsPermitted()
        {
            string GlobalKey = "InvalidLoginAttemptsToDisableUser";
            var userInfo = dbContextNavigate.GlobalSettings.Where(x => (x.GlobalKey.ToUpper() == GlobalKey.ToUpper())).Select(x => new Data.GlobalSettings
            {
                GlobalValue = x.GlobalValue

            }).FirstOrDefault(); 
            return userInfo.GlobalValue;
        }

        /// <summary>
        /// Log No Of Failed Attempts
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="count"></param>
        /// <returns>retVal</returns>
        public int LogNoOfFailedAttempts(string userName, int count)
        {
            DataAccess.Users objusers = dbContextNavigate.Users.FirstOrDefault(x => x.UserName == userName);
            int retVal = default(int);
            if (objusers != null)
            {
                objusers.FailedAttempts = count;
                dbContextNavigate.Users.Update(objusers);
                retVal = dbContextNavigate.SaveChanges();
            }
            return retVal;
        }

        /// <summary>
        /// Lock the users account
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>retVal</returns>
        public int LockAccount(string userName)
        {
            DataAccess.Users objusers = dbContextNavigate.Users.FirstOrDefault(x => x.UserName == userName);
            int retVal = default(int);
            if (objusers != null)
            {
                objusers.IsAccountLocked = true;
                objusers.UserStatus = Utilities.ConstDefaultValue.LOCKEDUSERSTATUS;
                dbContextNavigate.Users.Update(objusers);
                retVal = dbContextNavigate.SaveChanges();
            }
            return retVal;
        }



        /// <summary>
        /// Get expiry days for password
        /// </summary>
        /// <returns></returns>
        public string PasswordResetExpiryDays()
        {
            string GlobalKey = ConstDefaultValue.SEC_PASSWORD_EXPIRATION_DAYS;
            var userInfo = dbContextNavigate.GlobalSettings.Where(x => (x.GlobalKey.ToUpper() == GlobalKey.ToUpper())).Select(x => new Data.GlobalSettings
            {
                GlobalValue = x.GlobalValue

            }).FirstOrDefault();

            return userInfo.GlobalValue;
        }


        /// <summary>
        /// Track Login Attempts
        /// </summary>
        /// <param name="username"></param>
        /// <param name="ipv4address"></param>
        /// <param name="ipv6address"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool TrackLoginAttempts(string username, string ipv4address, string ipv6address,string status)
        {
            int retVal = default(int);
            DataAccess.LoginAttempts loginattempts = new DataAccess.LoginAttempts()
            {
                UserID = username,
                IPv4Address = ipv4address,
                IPv6Address = ipv6address,
                DateTime = DateTime.UtcNow,
                LoginAttemptStatus = status,

            };
            dbContextNavigate.LoginAttempts.Add(loginattempts);
            retVal = dbContextNavigate.SaveChanges();
      
            if (retVal > 0)
                return true;
            else
                return false;            
        }
        #endregion
    }
}
