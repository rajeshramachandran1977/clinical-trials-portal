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
using System.Net.Http.Headers;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Anju.Navigate.UI.Controllers
{
    public class DashboardController : Controller
    {

        #region Variable Declarations

        private readonly IAppLogger<DashboardController> _logger = null;
        string userName = string.Empty;
        NewStudyBA objNewStudyBA = new NewStudyBA();
        UsersBA users = new UsersBA();
        private string msgType = string.Empty;
        private string message = string.Empty;

        #endregion

        #region Constructor
        public DashboardController(IAppLogger<DashboardController> logger)
        {
            this._logger = logger;

        }
        #endregion

        #region Views
        public IActionResult Dashboard()
        {
            userName = HttpContext.Session.GetString("Username");
            ViewBag.LoginUsername = userName;
            if (string.IsNullOrEmpty(userName))
                return RedirectToAction("Login", "Login");
            ViewBag.UserType = HttpContext.Session.GetString("UserType");
            return View();
        }

        public IActionResult PIDashboard()
        {
            string proxyuser = HttpContext.Session.GetString("AuthenticUser");
            userName = HttpContext.Session.GetString("Username");
            ViewBag.LoginUsername = userName;
            if (string.IsNullOrEmpty(userName))
                return RedirectToAction("Login", "Login");
            if (!string.IsNullOrEmpty(proxyuser))
                ViewBag.Username = proxyuser;
            else
                ViewBag.Username = userName;
            ViewBag.UserType = HttpContext.Session.GetString("UserType");

            if (string.IsNullOrEmpty(proxyuser))
            {
                ViewBag.Proxyuser = "";
                return View();
            }
            if (proxyuser.ToUpper() != userName.ToUpper())
                ViewBag.Proxyuser = ConstDefaultValue.ONBEHALFOF + userName;
            else
                ViewBag.Proxyuser = "";
            return View();
        }
        public IActionResult IISAdminDashboard()
        {
            string proxyuser = HttpContext.Session.GetString("AuthenticUser");
            userName = HttpContext.Session.GetString("Username");
            ViewBag.LoginUsername = userName;
            if (string.IsNullOrEmpty(userName))
                return RedirectToAction("Login", "Login");
            if (!string.IsNullOrEmpty(proxyuser))
                ViewBag.Username = proxyuser;
            else
                ViewBag.Username = userName;
            ViewBag.UserType = HttpContext.Session.GetString("UserType");
            PopulateStudyPhase();
            PopulateMileStoneType();
            if (string.IsNullOrEmpty(proxyuser))
            {
                ViewBag.Proxyuser = "";
                return View();
            }
            if (proxyuser.ToUpper() != userName.ToUpper())
                ViewBag.Proxyuser = ConstDefaultValue.ONBEHALFOF + userName;
            else
                ViewBag.Proxyuser = "";
            return View();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get Study Id For PI
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Json</returns>
        public JsonResult GetStudyIdForPI([DataSourceRequest] DataSourceRequest request, string typeOfGrid)
        {
            try
            {

                userName = HttpContext.Session.GetString("Username");
                var result = objNewStudyBA.GetStudyIdForPI(userName, typeOfGrid);
                return Json(result.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new NewStudy() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }
        /// <summary>
        /// Get Study Details For IISAdmin
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Json</returns>
        public JsonResult GetStudyDetails([DataSourceRequest] DataSourceRequest request, string userType)
        {
            try
            {
                userName = HttpContext.Session.GetString("Username");
                var result = objNewStudyBA.GetStudyDetails(userType, userName);
                return Json(result.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new NewStudy() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }

        /// <summary>
        /// Get task details by username
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Json</returns>
        public JsonResult GetTaskDetails([DataSourceRequest] DataSourceRequest request, string userName, string userType)
        {
            try
            {

                var result = objNewStudyBA.GetTaskDetails(userName, userType);
                return Json(result.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new NewStudy() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }

        /// <summary>
        /// Get task details by username
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Json</returns>
        public JsonResult GetDefaultMilestoneDetails([DataSourceRequest] DataSourceRequest request)
        {
            try
            {

                var result = objNewStudyBA.GetDefaultMilestoneDetails();
                return Json(result.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new NewStudy() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }

        /// <summary>
        /// Save Banner Upload Documents
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>

        public async Task<ActionResult> SaveBannerUploadDocuments(IEnumerable<IFormFile> files)
        {
            try
            {
                bool result = true;
                if (files != null)
                {
                    foreach (var file in files)
                    {
                        var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                        var studyId = HttpContext.Session.GetString("StudyId");
                        var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
                        var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "BannerUpload");
                        var filePath = Path.Combine(folderPath, fileName);
                        bool isCreated = CreateDirectory(folderPath);
                        var username = HttpContext.Session.GetString("Username");

                        if (isCreated)
                        {

                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {

                                await file.CopyToAsync(fileStream);
                                Data.Documents objDocuments = new Data.Documents()
                                {
                                    DocumentName = fileContent.FileName.Trim('"'),
                                    DocumentNameWithOutExtension = Path.GetFileNameWithoutExtension(fileContent.FileName.Trim('"')),
                                    DocumentSize = Convert.ToInt32(new System.IO.FileInfo(filePath).Length),
                                    DocumentExtension = Path.GetExtension(filePath).ToLowerInvariant().ToString(),
                                    SubModuleName = Utilities.Messages.BannerUpload,
                                    StudyId = Convert.ToInt32(studyId),
                                    Path = filePath,
                                    IsActive = true,
                                    IsDeleted = false,
                                    ANJU_AddedBy = userName,
                                    Anju_AddedDate = DateTime.UtcNow

                                };
                                result = objNewStudyBA.DeleteUploadedFile(0, username, Utilities.Messages.BannerUpload, "");
                                if (result)
                                {
                                    result = objNewStudyBA.Fileupload(objDocuments);
                                }
                            }
                        }
                    }
                }
                else
                {
                    msgType = Utilities.Messages.FileNotFound;
                    return Content(msgType);
                }

                if (result)
                {
                    msgType = Utilities.Messages.SuccessStatus;
                    return Content("");
                }
                else
                    return Content(Utilities.Messages.ErrorStatus);
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), Utilities.Messages.ProblemInUpload);
            }
            return Json(new { msgType = msgType });
        }

        /// <summary>
        /// Save Login Background Documents
        /// </summary>
        /// <param name="loginBackgroundUpload"></param>
        /// <returns></returns>
        public async Task<ActionResult> SaveLoginBackgroundDocuments(IEnumerable<IFormFile> loginBackgroundUpload)
        {
            try
            {

                bool result = true;
                if (loginBackgroundUpload != null)
                {
                    foreach (var file in loginBackgroundUpload)
                    {
                        var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                        var studyId = HttpContext.Session.GetString("StudyId");
                        var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
                        var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "BannerUpload", "BackgroundUpload");
                        var filePath = Path.Combine(folderPath, fileName);
                        bool isDeleted = DeleteDirectory(folderPath);
                        bool isCreated = CreateDirectory(folderPath);
                        var username = HttpContext.Session.GetString("Username");

                        if (isCreated)
                        {

                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {

                                await file.CopyToAsync(fileStream);
                                Data.Documents objDocuments = new Data.Documents()
                                {
                                    DocumentName = fileContent.FileName.Trim('"'),
                                    DocumentNameWithOutExtension = Path.GetFileNameWithoutExtension(fileContent.FileName.Trim('"')),
                                    DocumentSize = Convert.ToInt32(new System.IO.FileInfo(filePath).Length),
                                    DocumentExtension = Path.GetExtension(filePath).ToLowerInvariant().ToString(),
                                    SubModuleName = Utilities.Messages.BackgroundUpload,
                                    StudyId = Convert.ToInt32(studyId),
                                    Path = filePath,
                                    IsActive = true,
                                    IsDeleted = false,
                                    ANJU_AddedBy = userName,
                                    Anju_AddedDate = DateTime.UtcNow

                                };
                                result = objNewStudyBA.DeleteUploadedFile(0, username, Utilities.Messages.BackgroundUpload, "");
                                if (result)
                                {
                                    result = objNewStudyBA.Fileupload(objDocuments);
                                }
                            }
                        }
                    }
                }
                else
                {
                    msgType = Utilities.Messages.FileNotFound;
                    return Content(msgType);
                }

                if (result)
                {
                    msgType = Utilities.Messages.SuccessStatus;
                    return Content("");
                }
                else
                    return Content(Utilities.Messages.ErrorStatus);
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), Utilities.Messages.ProblemInUpload);
            }
            return Json(new { msgType = msgType });
        }

        /// <summary>
        /// Get Banner List
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Json</returns>
        public ActionResult GetBannerList([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                var response = objNewStudyBA.GetBannerDetails();
                return Json(response.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new EmailList() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }


        /// <summary>
        /// Get Login Background
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Json</returns>
        public ActionResult GetLoginBackground([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                var response = objNewStudyBA.GetLoginBckgndDetails();
                return Json(response.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new EmailList() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }

        /// <summary>
        /// Create Directory
        /// </summary>
        /// <param name="forlderPath"></param>
        /// <returns>true/false</returns>
        public static bool CreateDirectory(string forlderPath)
        {
            if (!Directory.Exists(forlderPath))
                Directory.CreateDirectory(forlderPath);
            return true;
        }

        /// <summary>
        /// Delete Directory
        /// </summary>
        /// <param name="folderPath"></param>
        /// <returns></returns>
        public static bool DeleteDirectory(string folderPath)
        {
            if (Directory.Exists(folderPath))
                Directory.Delete(folderPath, true);
            return true;
        }

        public void PopulateStudyPhase()
        {
            List<Data.SysCodeValues> response = objNewStudyBA.GetSysCodeValues(@ConstDefaultValue.STUDYPHASE);
            ViewData["StudyPhase"] = response;
        }

        public void PopulateMileStoneType()
        {
            List<Data.SysCodeValues> response = objNewStudyBA.GetSysCodeValues(@ConstDefaultValue.MILESTONETYPE);
            ViewData["MileStoneType"] = response;
        }

        /// <summary>
        /// Create Update Objectives and Endpoints
        /// </summary>
        /// <param name="objectivesandEndpoints"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public JsonResult CreateUpdateDefaultMilestoneDetails(Data.DefaultMileStone defaultMileStone)
        {

            try
            {
                var username = HttpContext.Session.GetString("Username");
                bool result = objNewStudyBA.CreateUpdateDefaultMilestoneDetails(defaultMileStone, userName);
                if (result == true)
                {
                    msgType = Utilities.Messages.SuccessStatus;
                }
                else
                    msgType = Utilities.Messages.ProblemInCreation;

                return Json(new { data = msgType });
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new DefaultMileStone() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInCreation });
            }
        }


        /// <summary>
        /// Delete Default Milestone Details
        /// </summary>
        /// <param name="request"></param>
        /// <param name="defaultMileStone"></param>
        /// <returns>Json</returns>
        public JsonResult DeleteDefaultMilestoneDetails(Data.DefaultMileStone defaultMileStone)
        {
            try
            {
                userName = HttpContext.Session.GetString("Username");
                bool isDeleteDefaultMileStone = objNewStudyBA.DeleteDefaultMilestoneDetails(defaultMileStone, userName);
                if (isDeleteDefaultMileStone == true)
                    msgType = Utilities.Messages.SuccessStatus;
                else
                    msgType = Utilities.Messages.ProblemInDeletion;
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), Utilities.Messages.ProblemInDeletion);
                return Json(new DefaultMileStone() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInDeletion });

            }
            return Json(new { data = message, msgType = msgType });
        }
        #endregion
    }
}