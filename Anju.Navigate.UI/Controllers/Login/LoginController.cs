using Anju.Navigate.BusinessAccess;
using Anju.Navigate.Data;
using Anju.Navigate.Utilities;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using Anju.Navigate.Utilities.Logger;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Anju.Navigate.UI.Controllers
{
    public class LoginController : Controller
    {
        #region Variable Declarations

        private readonly IAppLogger<LoginController> _logger = null;

        UsersBA users = new UsersBA();
        GlobalSettingsBA glbSettings = new GlobalSettingsBA();

        string message = string.Empty;
        string msgType = string.Empty;

        #endregion

        #region Constructor
        public LoginController(IAppLogger<LoginController> logger)
        {
            this._logger = logger;

        }

        #endregion

        #region Views
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public IActionResult ForgetPassword()
        {
            return View();
        }

        public IActionResult ForgotPasswordPage()
        {
            return View();
        }

        public PartialViewResult ChangePasswordPartial()
        {
            return PartialView();
        }

        public ActionResult ResetPassword()
        {
           // HttpContext.Session.SetString("Username", Username);
            return View();
        }

        #endregion

        #region Methods


        /// <summary>
        /// Track Login Attempts
        /// </summary>
        /// <param name="username"></param>
        /// <param name="ipv4address"></param>
        /// <param name="ipv6address"></param>
        /// <param name="status"></param>
        private void TrackLoginAttempts(string username, string ipv4address, string ipv6address, string status)
        {
            users.TrackLoginAttempts(username, ipv4address, ipv6address, status);
        }


        /// <summary>
        /// Check if Users credentials exists,if not track the no.of login attempts and lock the users credentials
        /// </summary>
        /// <param name="logincredentials"></param>
        /// <returns>message</returns>
        public ActionResult CheckifCredentialsExists(Users logincredentials)
        {
            string userName = logincredentials.UserName;
            try
            {
                TempData["ModelActive"] = ConstDefaultValue.ACTIVEMODEL;
                int loginFailedAttempts = 0;
                int incCount = 0;
                incCount += 1;
                int loginAttemptsPermitted = 0;
                bool isAccountLocked = false;
                string ipv4address = ConfigValues.ipV4Address;
                string ipv6address = ConfigValues.ipV6Address;

                Users userTable = users.ValidateLoginCredential(logincredentials, out bool isPasswordExpired, out string errorMessage);
                if (!string.IsNullOrEmpty(userTable?.UserName))
                {
                    HttpContext.Session.SetString("Username", userTable?.UserName);
                    HttpContext.Session.SetString("UserId", userTable?.UserId.ToString());
                }
                if (!string.IsNullOrEmpty(userTable?.UserType))
                {
                    HttpContext.Session.SetString("UserType", userTable?.UserType);
                }
                if (isPasswordExpired == false)
                {
                    if (userTable.UserName == null)
                    {
                        int count = users.GetCountofFailedAttempts(userName);
                        loginAttemptsPermitted = int.Parse(users.GetLoginAttemptsPermitted());
                        if (count > 0)
                        {
                            if (count > loginAttemptsPermitted)
                                isAccountLocked = users.LockAccount(userName, out message);
                            else
                            {
                                count = count + incCount;
                                loginFailedAttempts = users.LoginFailedAttempts(userName, count);
                                message = Utilities.Messages.INVALIDUSERNAMEPASSWORD;
                                TrackLoginAttempts(userName, ipv4address, ipv6address, Utilities.Messages.FailedStatus);
                            }
                        }
                        else
                        {
                            count = count + incCount;
                            loginFailedAttempts = users.LoginFailedAttempts(userName, count);
                            message = Utilities.Messages.INVALIDUSERNAMEPASSWORD;
                            TrackLoginAttempts(userName, ipv4address, ipv6address, Utilities.Messages.FailedStatus);
                        }
                    }
                }
                else
                {
                    return Json(new { message = "ResetPassword" });
                }               
                if (!string.IsNullOrEmpty(userTable?.UserType?.ToUpper()))
                {
                    TrackLoginAttempts(userName, ipv4address, ipv6address, Utilities.Messages.SuccessStatus);
                    return Json(new { message = userTable?.UserType });                    
                }
                else if (!string.IsNullOrEmpty(userTable?.EndUserType?.ToUpper()))
                {
                    TrackLoginAttempts(userName, ipv4address, ipv6address, Utilities.Messages.SuccessStatus);
                    return Json(new { message = userTable?.EndUserType });
                }                
                else
                {
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        TrackLoginAttempts(userName, ipv4address, ipv6address, Utilities.Messages.FailedStatus);
                        return Json(new { message = errorMessage });
                    }
                    else if (!string.IsNullOrEmpty(message))
                    {
                        TrackLoginAttempts(userName, ipv4address, ipv6address, Utilities.Messages.FailedStatus);
                        errorMessage = message;
                        return Json(new { message = errorMessage });
                    }
                    else
                    {
                        TrackLoginAttempts(userName, ipv4address, ipv6address, Utilities.Messages.FailedStatus);
                        return Json(new { message = Utilities.Messages.INVALIDUSERNAMEPASSWORD });
                    }
                }
               
            }

            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), logincredentials);
            }
            return Json(new { message = message });
        }

        /// <summary>
        /// Check Proxy User
        /// </summary>
        /// <param name="logincredentials"></param>
        /// <returns>message</returns>
        public ActionResult CheckProxyUser(string username)
        {          
            try
            {

                string loginuser = "";
                if (!string.IsNullOrEmpty(HttpContext.Session.GetString("AuthenticUser")))
                    loginuser = HttpContext.Session.GetString("AuthenticUser");
                else
                    loginuser = HttpContext.Session.GetString("Username");
                Users userTable = users.ValidateProxyUser(loginuser, username);
                if (!string.IsNullOrEmpty(userTable?.UserName))
                {
                    HttpContext.Session.SetString("AuthenticUser", loginuser);
                    HttpContext.Session.SetString("Username", userTable?.UserName);
                }
                if (!string.IsNullOrEmpty(userTable?.UserType?.ToUpper()))
                {
                    HttpContext.Session.SetString("UserType", userTable?.UserType);
                    return Json(new { message = userTable?.UserType });
                }
                else if (!string.IsNullOrEmpty(userTable?.EndUserType?.ToUpper()))
                {
                    return Json(new { message = userTable?.EndUserType });
                }
                else
                {
                    return Json(new { message = Utilities.Messages.INVALIDUSERNAMEPASSWORD });
                }
            }

            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), username);
            }
            return Json(new { message = message });
        }

        /// <summary>
        /// Get Administrators Email
        /// </summary>
        /// <returns>ObjectResult</returns>
        public ActionResult GetAdminEmail()
        {
            string adminEmail = string.Empty;
            try
            {
                adminEmail = users.GetAdminEmail();
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), string.Empty);
            }
            return new ObjectResult(new DataSourceResult { Data = new[] { adminEmail }, Total = 1 });
        }

        /// <summary>
        /// Check if User Name Exists,if exists send an email to the Users id with instructions on how to reset password
        /// </summary>
        /// <param name="isUserExist"></param>
        /// <returns>ObjectResult</returns>
        public JsonResult CheckifUserNameExists(Users isUserExist)
        {
            bool doesUserExist;
            try
            {
                doesUserExist = users.CheckifUserNameExists(isUserExist/*, out message*/);
                if (doesUserExist == true)               
                    message = users.UserEmail(isUserExist, out message, out msgType);            
                else                
                    message = Messages.EmailNotExists;               
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), isUserExist);
            }

            return Json(new { data = message, msgType = msgType });
        }

        /// <summary>
        /// Check if the Url is valid
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public ActionResult CheckValidUrl(string url)
        {
            bool isValid = false;
            try
            {
                isValid = users.CheckValidUrl(url);
                if (isValid)
                    message = "true";
                else
                    message = "false";
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), string.Empty);
            }
            return Json(new { data = message });
        }

        /// <summary>
        /// ChangePassword
        /// </summary>
        /// <param name="urlString"></param>
        /// <param name="password"></param>
        /// <param name="oldPassword"></param>
        /// <returns></returns>
        public JsonResult ChangePassword(string urlString, string password, string oldPassword)
        {
            bool isChanged = false;
            try
            {
                if (!string.IsNullOrWhiteSpace(urlString) || !string.IsNullOrEmpty(oldPassword))
                {
                    var username = HttpContext.Session.GetString("Username");
                    isChanged = users.ChangePassword(urlString, username, password, oldPassword, out message);
                }
                if (isChanged == true)
                    msgType = Utilities.Messages.SuccessStatus;
                else
                    msgType = message;
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), Utilities.Messages.ChangePasswordFailed);
            }
            return Json(new { data = message, msgType = msgType });
        }

        /// <summary>
        /// GetPwdPolicydetails
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public JsonResult GetPwdPolicydetails([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                var result = glbSettings.GetPwdPolicydetails();
                return Json(result.ToDataSourceResult(request).Data);
            }

            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), Utilities.Messages.ChangePasswordFailed);
                return Json(new Users() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ChangePasswordFailed });
            }

        }



        /// <summary>
        /// Opens New Window
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult OpenNewWindow(Data.NewStudy  obj)
        {
           TempData["OpenData"] = JsonConvert.SerializeObject(obj);
            msgType = Utilities.Messages.SuccessStatus;
            return Json(new { data = msgType });
        }


        #endregion
    }
}