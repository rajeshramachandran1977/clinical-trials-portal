using Anju.Navigate.BusinessAccess;
using Anju.Navigate.Data;
using Anju.Navigate.Utilities;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Anju.Navigate.Utilities.Logger;

namespace Anju.Navigate.UI.Controllers.Register
{
    public class RegisterController : Controller
    {
        #region Variable Declarations

        private readonly IAppLogger<RegisterController> _logger = null;
        UsersBA users = new UsersBA();
        string message = string.Empty;
        string msgType = string.Empty;

        #endregion

        #region Constructor
        public RegisterController(IAppLogger<RegisterController> logger)
        {
            this._logger = logger;
        }
        #endregion

        #region Views

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult RegistrationSummary(Data.Users objUsers)
        {
            return PartialView(objUsers);
        }

        public PartialViewResult InternalNewUser()
        {
            return PartialView();
        }
        public IActionResult Image()
        {
            return View();
        }

        public PartialViewResult EditInternalNewUser()
        {
            return PartialView();
        }

        public PartialViewResult Edit()
        {
            return PartialView();
        }
      

        #endregion

        #region Methods        

        /// <summary>
        /// Get SysCode Values by type
        /// </summary>
        /// <param name="request"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public JsonResult GetSysCodeValues([DataSourceRequest] DataSourceRequest request, string type)
        {
            try
            {
                var result = users.GetSysCodeValues(type);
                return Json(result.ToDataSourceResult(request).Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new SysCodeValues() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }

        /// <summary>
        /// Get Countries
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>        
        public JsonResult GetCountries([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                var result = users.GetCountries();
                return Json(result.ToDataSourceResult(request).Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new Users() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }

        /// <summary>
        /// Get States By CountryID
        /// </summary>
        /// <param name="request"></param>
        /// <param name="countryId"></param>
        /// <returns></returns>
        public JsonResult GetStatesByCountryID([DataSourceRequest] DataSourceRequest request, int? countryId)
        {
            try
            {
                var result = users.GetStatesByCountryId(countryId);
                return Json(result.ToDataSourceResult(request).Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new Users() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }

        /// <summary>
        /// Get Cities By StateID
        /// </summary>
        /// <param name="request"></param>
        /// <param name="stateId"></param>
        /// <returns></returns>
        public JsonResult GetCitiesByStateID([DataSourceRequest] DataSourceRequest request, int? stateId)
        {
            try
            {
                var result = users.GetCitiesByStateId(stateId);
                return Json(result.ToDataSourceResult(request).Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new Users() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }

        /// <summary>
        /// Get Credentials
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public JsonResult GetCredentials([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                var result = users.GetCredentails();
                return Json(result.ToDataSourceResult(request).Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new Users() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }

        /// <summary>
        /// Validate UserName
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool ValidateUserName(string userName)
        {
            try
            {
                bool result = users.IsValidUserName(userName);
                return result;
            }
            catch (Exception ex)
            {

                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return false;
            }
        }

        /// <summary>
        /// Validate Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool ValidateEmail(string email)
        {
            try
            {
                bool result = users.IsValidEmail(email);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return false;
            }
        }

        /// <summary>
        /// Get User Details 
        /// </summary>
        /// <param name="request"></param>        
        /// <returns>Json</returns>
        public ActionResult GetUserDetails([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                var response = users.GetUsers();
                return Json(response.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new UserRoles() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }


        /// <summary>
        /// Get User Details For Drop Down ctrls
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Json</returns>
        public ActionResult GetUserDetailsForDropDowns([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                var response = users.GetUsers();
                return Json(response.ToDataSourceResult(request).Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new UserRoles() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }



        /// <summary>
        /// Delete User 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="user"></param>
        /// <returns>Json</returns>
        public JsonResult DeleteUsers([DataSourceRequest] DataSourceRequest request, Users user)
        {
            bool isUserDeleted = false;
            try
            {
                isUserDeleted = users.DeleteUsers(user, out message);
                if (isUserDeleted == true)
                    msgType = Utilities.Messages.SuccessStatus;
                else
                    msgType = Utilities.Messages.ProblemInDeletion;
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), Utilities.Messages.ProblemInDeletion);
            }
            return Json(new { data = message, msgType = msgType });
        }

        /// <summary>
        /// Get UserDetails By UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public JsonResult GetUserDetailsByUserId(int userId, [DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                var response = users.GetUserDetailsByUserId(userId);
                return Json(response.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {

                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new UserRoles() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }

        /// <summary>
        /// Get UserCredentials by UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public JsonResult GetUserCredentialsByUserId(int userId, [DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                var response = users.GetUserCredentialsByUserId(userId);
                return Json(response.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new UserRoles() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }

        /// <summary>
        /// Save UserDetails
        /// </summary>
        /// <param name="objUsers"></param>
        /// <param name="credetials"></param>
        /// <returns></returns>
        public JsonResult SaveUserDetails(Data.Users objUsers, string[] credetials)
        {
            try
            {
                bool result = users.SaveUserDetails(objUsers, credetials, out message);
                if (result == true)
                {
                    msgType = Utilities.Messages.SuccessStatus;
                }
                else
                    msgType = Utilities.Messages.ProblemInCreation;

                return Json(new { data = message, msgType = msgType });
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new Users() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInCreation });
            }
        }

        /// <summary>
        /// Update UserDetails
        /// </summary>
        /// <param name="objUsers"></param>
        /// <param name="credetials"></param>
        /// <returns></returns>
        public JsonResult UpdateUserDetails(Data.Users objUsers, string[] credetials)
        {
            try
            {
                bool result = users.UpdateUserDetails(objUsers, credetials, out message);
                if (result == true)
                {
                    HttpContext.Session.SetString("Username", objUsers.UserName);
                    msgType = Utilities.Messages.SuccessStatus;
                }
                else
                    msgType = Utilities.Messages.ProblemInUpdation;

                return Json(new { data = message, msgType = msgType });
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new Users() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInUpdation });
            }

        }        
        #endregion

    }
}