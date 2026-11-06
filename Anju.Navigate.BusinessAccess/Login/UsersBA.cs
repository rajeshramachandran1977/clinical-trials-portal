using Anju.Navigate.DataAccess;
using Anju.Navigate.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace Anju.Navigate.BusinessAccess
{
    public class UsersBA
    {
        #region Properties
        private readonly UnitOfWork unitOfWork;

        #endregion

        #region Variable Declarations
        string message = string.Empty;
        #endregion

        #region Constructor
        public UsersBA()
        {
            unitOfWork = new UnitOfWork();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Validate Login Credentials
        /// </summary>
        /// <param name="objLoginRequest"></param>
        /// <returns>Data.Users()</returns>
        public Data.Users ValidateLoginCredential(Data.Users objLoginRequest, out bool IsPasswordExpired, out string errorMessage)
        {
            IsPasswordExpired = false;
            errorMessage = "";
            if (objLoginRequest != null)
            {
                return unitOfWork.Login.ValidateLoginCredential(objLoginRequest, out IsPasswordExpired,out errorMessage);
            }
            else
                return new Data.Users();
        }

        /// <summary>
        /// Validate Proxy user
        /// </summary>
        /// <param name="loginUser"></param
        /// <param name="proxyUser"></param>
        /// <returns>Data.Users()</returns>
        public Data.Users ValidateProxyUser(string loginUser,string proxyUser)
        {
            return unitOfWork.Login.ValidateProxyUser(loginUser, proxyUser);
        }

        /// <summary>
        /// Get Login Attempts Permitted
        /// </summary>
        /// <returns>string</returns>
        public string GetLoginAttemptsPermitted()
        {
            return unitOfWork.Login.GetLoginAttemptsPermitted();
        }

        /// <summary>
        /// Get Count of Failed Attempts
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>Count of Failed Attempts</returns>
        public int GetCountofFailedAttempts(string userName)
        {
            return unitOfWork.Login.GetCountofFailedAttempts(userName);
        }

        /// <summary>
        /// Login Failed Attempts
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="count"></param>
        /// <returns>NoOfFailedAttempts</returns>
        public int LoginFailedAttempts(string userName, int count)
        {
            return unitOfWork.Login.LogNoOfFailedAttempts(userName, count);
        }

        /// <summary>
        /// Lock User Account
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="message"></param>
        /// <returns>true/false</returns>
        public bool LockAccount(string userName, out string message)
        {
            int retVal = unitOfWork.Login.LockAccount(userName);
            if (retVal > 0)
            {
                message = Utilities.Messages.AccountLocked;
                return true;
            }
            else
            {
                message = string.Empty;
                return false;
            }
        }

        /// <summary>
        /// Get Countries
        /// </summary>
        /// <returns>list of countries</returns>
        public List<Data.Country> GetCountries()
        {
            return unitOfWork.Users.GetCountries();
        }

        /// <summary>
        /// Get States
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns>list of states</returns>
        public List<Data.State> GetStatesByCountryId(int? countryId)
        {
            return unitOfWork.Users.GetStatesByCountryId(countryId);
        }

        /// <summary>
        /// Get Cities
        /// </summary>
        /// <param name="stateId"></param>
        /// <returns>list of cities</returns>
        public List<Data.City> GetCitiesByStateId(int? stateId)
        {
            return unitOfWork.Users.GetCitiesByStateID(stateId);
        }

        /// <summary>
        /// Get Admin Email
        /// </summary>
        /// <returns>unitOfWork.Users.GetAdminEmail</returns>
        public string GetAdminEmail()
        {
            return unitOfWork.Users.GetAdminEmail();
        }

        /// <summary>
        /// Check if the User exists or not,display appropriate messages in either case
        /// </summary>
        /// <param name="forgotCredentials"></param>
        /// <param name="message"></param>
        /// <returns>true/false</returns>
        public bool CheckifUserNameExists(Data.Users forgotCredentials/*, out string message*/)
        {           
            bool isUserNameOrEmailExist = unitOfWork.Users.CheckifUserNameExists(forgotCredentials);
            if (isUserNameOrEmailExist)           
                return true;     
            else               
                return false;            
        }


        /// <summary>
        /// Get Configured Email from Global settings
        /// </summary>
        /// <returns></returns>
        private string GetFromMail()
        {
            return unitOfWork.SendMail.GetFromMail();
        }

        /// <summary>
        /// Get Configured Email and SMTP details from Global settings
        /// </summary>
        /// <returns></returns>
        private List<String> GetSMTPList()
        {
            return unitOfWork.SendMail.GetSMTPList();
        }


        /// <summary>
        /// Send the user an Email containing the link to Change Password
        /// </summary>
        /// <param name="forgotCredentials"></param>
        /// <returns>message</returns>
        public string UserEmail(Data.Users forgotCredentials, out string message, out string msgType)
        {
            string adminEmail = Utilities.Messages.adminEmail;
            msgType = string.Empty;

            if (forgotCredentials != null)
            {
                if (!forgotCredentials.IsAccountLocked.ToString().Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                {
                    int linkSessionaVal = Convert.ToInt32(ConfigValues.LinkSession);
                    string redirecttUrl = string.Concat(Utilities.Utilities.AppBaseUrl, "/Login/ForgotPasswordPage?param=");
                    var users = new Data.Users()
                    {

                        PrimaryEmailId = forgotCredentials.PrimaryEmailId,
                        UserName = forgotCredentials.UserName,
                    };

                    ConfigValues.ExpiryDate = DateTime.Now.AddDays(int.Parse(unitOfWork.Login.PasswordResetExpiryDays()));
                    string encryptText = EncrypPassword.EncryptusingRFC(JsonConvert.SerializeObject(users.UserName));
                    redirecttUrl = string.Concat(redirecttUrl, encryptText);

                    string mailBody = "<p>Dear User,</p><p>We have received a password change request from your account. <p>Click <a href='" + redirecttUrl + "'>Here</a> to reset your password.</p> <p><p>This link will expire on " + Utilities.ConfigValues.ExpiryDate + ", so be sure to use it within the stipulated time frame.</p></p>";

                    mailBody = mailBody.Replace("@URL", redirecttUrl);

                    var emailConfig = new EmailConfig()
                    {
                        From = adminEmail,
                        To = users.PrimaryEmailId,
                        Subject = ConfigValues.PasswordRecoverySubject,
                        Body = mailBody
                    };
                    
                    List<string> frommail = GetSMTPList();
                    if (frommail[0] == null || frommail[0] == "")
                    {
                        msgType = Messages.ErrorStatus;
                        message = Messages.FROMEMAILNOTCONFIGUREDINGLOBALSETTINGS;                       
                    }
                    else
                    {
                        msgType = Messages.SuccessStatus;
                        message = Utilities.Utilities.SendMail(emailConfig, frommail) ? Utilities.Messages.GeneratePassword : Utilities.Messages.EmailFailedToSend;                        
                    }
                }
                else
                {
                    msgType = Messages.ErrorStatus;
                    message = Messages.AccountLocked;                    
                }
            }
            else
            {
                msgType = Messages.ErrorStatus;
                message = Messages.EmailNotExists;                
            }

            return message;
        }
        /// <summary>
        /// Check if url is valid
        /// </summary>
        /// <param name="url"></param>
        /// <returns>true/false</returns>
        public bool CheckValidUrl(string url)
        {

            string decryptTxt = EncrypPassword.DecryptusingRFC(url);
            var result = JsonConvert.DeserializeObject(decryptTxt);

            if (Utilities.ConfigValues.ExpiryDate >= DateTime.Now)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Change Password
        /// </summary>
        /// <param name="url"></param>
        /// <param name="newPassword"></param>
        /// <param name="message"></param>
        /// <returns>isSuccess</returns>
        public bool ChangePassword(string url, string userDetails, string newPassword, string oldPassword, out string message)
        {
            bool isSuccess = false;
            string email = string.Empty;
            string userName = string.Empty;
            int retVal;


            if (!string.IsNullOrWhiteSpace(url))
            {
                string decryptTxt = Utilities.EncrypPassword.DecryptusingRFC(url);
                var result = JsonConvert.DeserializeObject(decryptTxt);
                //email = result.PrimaryEmailId;
                userName = result.ToString();
            }
            if (!string.IsNullOrEmpty(oldPassword))
            {
                userName = userDetails?? userName;
                bool IsValidOldPassword = unitOfWork.Users.IsValidOldPassWord(userName, oldPassword);
                if (IsValidOldPassword)
                {
                    bool isPwdPrevused = unitOfWork.Users.isPrevPwdused(userName, EncrypPassword.Encrypt(newPassword));
                    if (isPwdPrevused)
                    {
                        isSuccess = false;
                        message = Utilities.Messages.PreviousPasswordsUsed;
                    }
                    else
                    {
                        retVal = unitOfWork.Users.ChangePassword(userName, email, EncrypPassword.Encrypt(newPassword), oldPassword);
                        if (retVal > 0)
                            isSuccess = true;
                        message = isSuccess ? Utilities.Messages.PasswordChangedSuccessfully : Utilities.Messages.ChangePasswordFailed;
                    }
                }
                else
                {
                    message = Utilities.Messages.InValidOldPassWord;
                    isSuccess = false;
                }
            }
            else
            {
                // Check if the Password has been previously used or not
                bool isPwdPrevused = unitOfWork.Users.isPrevPwdused(userName, EncrypPassword.Encrypt(newPassword));
                if (isPwdPrevused)
                {
                    isSuccess = false;
                    message = Utilities.Messages.PreviousPasswordsUsed;
                }
                else
                {
                    retVal = unitOfWork.Users.ChangePassword(userName, email, EncrypPassword.Encrypt(newPassword));
                    if (retVal > 0)
                        isSuccess = true;
                    message = isSuccess ? Utilities.Messages.PasswordChangedSuccessfully : Utilities.Messages.ChangePasswordFailed;
                }
            }

            return isSuccess;
        }
        /// <summary>
        /// Save User Details
        /// </summary>
        /// <param name="user"></param>
        /// <param name="credetials"></param>
        /// <param name="message"></param>
        /// <returns>true/false</returns>
        public bool SaveUserDetails(Data.Users user, string[] credetials, out string message)
        {

            if (unitOfWork.Users.IsValidUserName(user.UserName))
            {
                if (unitOfWork.Users.IsvalidEmailid(user.PrimaryEmailId))
                {
                    message = Utilities.Messages.UserSuccessfullyCreated;
                    return unitOfWork.Users.SaveUserDetails(user, credetials);
                }
                else
                {
                    message = Utilities.Messages.PrimaryEmailAlreadyExists;
                    return false;
                }
            }
            else
            {
                message = Utilities.Messages.UsernameAlreadyExists;
                return false;
            }
        }

        /// <summary>
        /// Update User Details
        /// </summary>
        /// <param name="user"></param>
        /// <param name="credetials"></param>
        /// <param name="message"></param>
        /// <returns>true/false</returns>
        
        public bool UpdateUserDetails(Data.Users user, string[] credetials, out string message)
        {
            bool result = true;

            result = unitOfWork.Users.UpdateUserDetails(user, credetials);
            if (result)
                message = Utilities.Messages.UserSuccessfullyUpdated;
            else
                message = Utilities.Messages.ProblemInUpdation;

            return result;


        }
        /// <summary>
        ///  validate username is unique or not
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>true/false</returns>
        public bool IsValidUserName(string userName)
        {
            return unitOfWork.Users.IsValidUserName(userName);
        }

        /// <summary>
        ///  validate Email is unique or not
        /// </summary>
        /// <param name="email"></param>
        /// <returns>true/false</returns>
        public bool IsValidEmail(string email)
        {
            return unitOfWork.Users.IsvalidEmailid(email);
        }

        /// <summary>
        /// Get Users
        /// </summary>
        /// <returns>List of users</returns>
        public List<Data.Users> GetUsers()
        {
            return unitOfWork.Users.GetUsers();
        }

        /// <summary>
        /// Get Users
        /// </summary>
        /// <returns>List of Users</returns>
        public List<Data.Users> GetUserDetailsByUserId(int userId)
        {
            return unitOfWork.Users.GetUserDetailsByUserId(userId);
        }

        /// <summary>
        /// Get User Credentials By UserId
        /// </summary>
        /// <returns>List of  user credentials</returns>
        public List<Data.UserCredentials> GetUserCredentialsByUserId(int userId)
        {
            return unitOfWork.Users.GetUserCredentialsByUserId(userId);
        }

        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="message"></param>
        /// <returns>true/false</returns>
        public bool DeleteUsers(Data.Users users, out string message)
        {
            bool isUserDeleted = unitOfWork.Users.DeleteUsers(users);
            if (isUserDeleted == true)
            {
                message = string.Empty;
                return true;
            }
            else
            {
                message = Utilities.Messages.ProblemInDeletion;
                return false;
            }
        }

        /// <summary>
        /// Get Credentails
        /// </summary>
        /// <returns>list of credentials</returns>
        public List<Data.SysCodeValues> GetCredentails()
        {
            return unitOfWork.SysCodeValues.GetSysCodeValuesByColumnName("Credentials");
        }

       

        /// <summary>
        /// Get User Detail By User Name
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>List of Users</returns>
        public Data.Users GetUserDetailsByUserName(string userName)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                return unitOfWork.Users.GetUserDetailsByUserName(userName);
            }
            else
                return new Data.Users();
        }

        /// <summary>
        /// Get User Detail By MSL User Type
        /// </summary>
        /// <param name="userType"></param>
        /// <returns>List of Users</returns>
        public List<Data.Users> GetUserDetailsByUserType(string userType)
        {
            return unitOfWork.Users.GetUserDetailsByUserType(userType);
        }


        /// <summary>
        /// Get Related Users Associated with a Study
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns>List</returns>
        public List<Data.Users> GetRelatedUsersAssociatedwithaStudy(int studyId)
        {
            return unitOfWork.Users.GetRelatedUsersAssociatedwithaStudy(studyId);
        }

        /// <summary>
        /// Read all Drop down values from Sys Code table,drop downs are differentiated by types
        /// </summary>
        /// <param name="type"></param>
        /// <returns>List</returns>        
        public List<Data.SysCodeValues> GetSysCodeValues(string type)
        {
            return unitOfWork.SysCodeValues.GetSysCodeValuesByColumnName(type);
        }


        /// <summary>
        /// Track Login Attempts
        /// </summary>
        /// <param name="username"></param>
        /// <param name="ipv4address"></param>
        /// <param name="ipv6address"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool TrackLoginAttempts(string username, string ipv4address, string ipv6address, string status)
        {
            return unitOfWork.Login.TrackLoginAttempts(username, ipv4address, ipv6address, status);
        }

        #endregion
    }
}

