using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Anju.Navigate.BusinessAccess;
using Anju.Navigate.BusinessAccess.Workflow;
using Anju.Navigate.Data;
using Anju.Navigate.Utilities;
using Anju.Navigate.Utilities.Logger;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Anju.Navigate.UI.Controllers
{
    public class TaskWorkFlowController : Controller
    {
        #region Variable Declarations

        private readonly IAppLogger<TaskWorkFlowController> _logger = null;
        UsersBA usersBA = new UsersBA();
        string message = string.Empty;
        string msgType = string.Empty;
        StudyTaskBA objStudyTaskBA = new StudyTaskBA();
        NewStudyBA objNewStudyBA = new NewStudyBA();


        #endregion

        #region Constructor

        public TaskWorkFlowController(IAppLogger<TaskWorkFlowController> logger)
        {
            this._logger = logger;
        }

        #endregion

        #region Views

        public IActionResult AssignMSLAndTL()
        {
            var objNewStudy = JsonConvert.DeserializeObject<Data.NewStudy>(TempData["OpenData"]?.ToString());
            TempData.Keep("OpenData");
            if (objNewStudy != null)
            {
                HttpContext.Session.SetString("StudyId", objNewStudy.StudyId.ToString());
                ViewBag.StudyId = objNewStudy.StudyId;
                ViewBag.AssignedUsername = objNewStudy.ANJU_AddedBy;
                ViewBag.LogedinUserName = HttpContext.Session.GetString("Username");
            }
            else
                return RedirectToAction("Login", "Login");

            return View();
        }

        public IActionResult AssignMSLLOIReview()
        {
            var objNewStudy = JsonConvert.DeserializeObject<Data.NewStudy>(TempData["OpenData"]?.ToString());
            TempData.Keep("OpenData");
            if (objNewStudy != null)
            {
                ViewBag.StudyId = objNewStudy.StudyId;
                ViewBag.AssignedUsername = objNewStudy.ANJU_AddedBy;
                ViewBag.LogedinUserName = HttpContext.Session.GetString("Username");
            }
            else
                return RedirectToAction("Login", "Login");

            return View();
        }

        public IActionResult ProgramLeaderReview()
        {
            var objNewStudy = JsonConvert.DeserializeObject<Data.NewStudy>(TempData["OpenData"]?.ToString());
            TempData.Keep("OpenData");
            if (objNewStudy != null)
            {
                ViewBag.StudyId = objNewStudy.StudyId;
                ViewBag.AssignedUsername = objNewStudy.ANJU_AddedBy;
                ViewBag.LogedinUserName = HttpContext.Session.GetString("Username");
                ViewBag.Institution = objNewStudy.Institution;
                ViewBag.TitleofTrial = objNewStudy.TitleofTrial;
            }
            else
                return RedirectToAction("Login", "Login");

            return View();
        }
        public IActionResult ProposalAndReview()
        {
            var objNewStudy = JsonConvert.DeserializeObject<Data.NewStudy>(TempData["OpenData"]?.ToString());
            TempData.Keep("OpenData");
            if (objNewStudy != null)
            {
                ViewBag.StudyId = objNewStudy.StudyId;
                ViewBag.AssignedUsername = objNewStudy.ANJU_AddedBy; ;
                ViewBag.LogedinUserName = HttpContext.Session.GetString("Username");
                ViewBag.TaskName = objNewStudy.TaskName;
                ViewBag.State = objNewStudy.State;
                ViewBag.RecordType = objNewStudy.LocalMRCRecordType ?? objNewStudy.GlobalMRCRecordType;
                ViewBag.Institution = objNewStudy.Institution;
                ViewBag.TitleofTrial = objNewStudy.TitleofTrial;
                ViewBag.StudyNumber = objNewStudy.StudyNumber;
            }
            else
                return RedirectToAction("Login", "Login");

            return View();
        }
        public IActionResult RecordMRCResults()
        {
            var objNewStudy = JsonConvert.DeserializeObject<Data.NewStudy>(TempData["OpenData"]?.ToString());
            TempData.Keep("OpenData");
            if (objNewStudy != null)
            {
                ViewBag.StudyId = objNewStudy.StudyId;
                HttpContext.Session.SetString("StudyId", objNewStudy.StudyId.ToString());
                ViewBag.AssignedUsername = objNewStudy.ANJU_AddedBy;
                ViewBag.LogedinUserName = HttpContext.Session.GetString("Username");
                ViewBag.recordType = objNewStudy.RecordType;
                ViewBag.Institution = objNewStudy.Institution;
                ViewBag.TitleofTrial = objNewStudy.TitleofTrial;
            }
            else
                return RedirectToAction("Login", "Login");

            return View();
        }
        public IActionResult CreateDeliverLetter()
        {
            var objNewStudy = JsonConvert.DeserializeObject<Data.NewStudy>(TempData["OpenData"]?.ToString());
            TempData.Keep("OpenData");
            if (objNewStudy != null)
            {
                ViewBag.StudyId = objNewStudy.StudyId;
                HttpContext.Session.SetString("StudyId", objNewStudy.StudyId.ToString());
                ViewBag.AssignedUsername = objNewStudy.ANJU_AddedBy;
                ViewBag.LogedinUserName = HttpContext.Session.GetString("Username");
                ViewBag.TaskName = objNewStudy.TaskName;
                ViewBag.recordType = objNewStudy.RecordType;
                ViewBag.StudyNumber = objNewStudy.StudyNumber;
                ViewBag.TitleofTrial = objNewStudy.TitleofTrial;
                ViewBag.Institution = objNewStudy.Institution;
            }
            else
                return RedirectToAction("Login", "Login");

            return View();
        }

        public IActionResult ManageContractStatus()
        {
            return View();
        }
        public IActionResult ReviewICF()
        {
            return View();
        }


        #endregion

        #region Methods

        /// <summary>
        /// Get User Details By UserType
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public JsonResult GetUserDetailsByUserType([DataSourceRequest] DataSourceRequest request, string userType)
        {
            try
            {
                var result = usersBA.GetUserDetailsByUserType(userType);
                return Json(result.ToDataSourceResult(request).Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new Users() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }

        }

        /// <summary>
        /// Save Task details
        /// </summary>
        /// <param name="studyTask"></param>      
        /// <returns></returns>
        public JsonResult SaveMSLAndPLTaskDetails(Data.StudyTask studyTask)
        {
            try
            {
                var LogedinUserName = HttpContext.Session.GetString("Username");
                string taskStatus = Utilities.Messages.MSLANDPLASSIGNMENT;
                bool result = objStudyTaskBA.CreateAndUpdateTaskDetails(studyTask, LogedinUserName, taskStatus);
                if (result)
                {
                    msgType = Utilities.Messages.SuccessStatus;
                    var newStudyWorkflow = new NewStudyWorkflow();
                    newStudyWorkflow.AssignMslAndPlToStudy(studyTask.StudyId,
                        HttpContext.Session.GetString("AuthenticUser"),
                        HttpContext.Session.GetString("Username"));
                }
                else
                {
                    msgType = Utilities.Messages.ProblemInCreation;
                }
                return Json(new { data = message, msgType });
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new StudyTask() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInCreation });

            }
        }

        /// <summary>
        /// Get MSL Review Details by StudyId
        /// </summary>
        /// <param name="studyId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public JsonResult GetMSLReviewDetailsByStudyId([DataSourceRequest] DataSourceRequest request, int studyId)
        {
            try
            {
                var result = objStudyTaskBA.GetMSLReviewDetailsByStudyId(studyId);
                return Json(result.ToDataSourceResult(request).Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new StudyReview() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }

        }

        /// <summary>
        /// Save Task details
        /// </summary>
        /// <param name="studyTask"></param>      
        /// <returns></returns>
        public JsonResult SaveMSLReviewDetails(Data.StudyReview studyReview)
        {
            try
            {
                bool result = objStudyTaskBA.CreateUpdateMSLReview(studyReview);
                if (result)
                {
                    msgType = Utilities.Messages.SuccessStatus;
                    var newStudyWorkflow = new NewStudyWorkflow();
                    newStudyWorkflow.ReviewByMsl(studyReview.StudyId, HttpContext.Session.GetString("AuthenticUser"), HttpContext.Session.GetString("Username"));
                }

                else
                {
                    msgType = Utilities.Messages.ProblemInCreation;
                }
                return Json(new { data = message, msgType });
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new StudyReview() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInCreation });

            }
        }
        /// <summary>
        /// Get States By CountryID
        /// </summary>
        /// <param name="request"></param>
        /// <param name="countryId"></param>
        /// <returns></returns>
        public JsonResult GetDocumentSubTypeByDocumentTypeID([DataSourceRequest] DataSourceRequest request, int documentTypeId)
        {
            try
            {
                var result = objStudyTaskBA.GetDocumentSubtypeByTypeID(documentTypeId);
                return Json(result.ToDataSourceResult(request).Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new DocumentSubTypes() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }
        /// <summary>
        /// Update document details
        /// </summary>
        /// <param name="documents"></param>      
        /// <returns></returns>
        public JsonResult UpdateDocumentDetails(Data.Documents documents)
        {
            try
            {
                bool result = objStudyTaskBA.UpdateDocumentDetails(documents);
                if (result == true)
                    msgType = Utilities.Messages.SuccessStatus;
                else
                {
                    msgType = Utilities.Messages.ProblemInCreation;
                }
                return Json(new { data = message, msgType });
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new Documents() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInCreation });

            }
        }

        /// <summary>
        /// Get document details
        /// </summary>
        /// <param name="documents"></param>      
        /// <returns></returns>
        public JsonResult GetDocumentDetails(Data.Documents documents)
        {
            try
            {
                var response = objStudyTaskBA.GetDocumentDetails();
                return Json(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new Documents() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInCreation });

            }
        }

        /// <summary>
        /// Get DrugorCompounddetails Details by StudyId
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns>list of drugorcompound</returns>
        public JsonResult GetDrugorCompounddetailsDetailsByStudyId([DataSourceRequest] DataSourceRequest request, int studyId)
        {
            try
            {
                var result = objStudyTaskBA.GetDrugorCompounddetailsDetailsByStudyId(studyId);
                return Json(result.ToDataSourceResult(request).Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new NewStudy() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }

        /// <summary>
        /// Get PL Review Details by StudyId
        /// </summary>
        /// <param name="studyId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public JsonResult GetPLReviewDetailsByStudyId([DataSourceRequest] DataSourceRequest request, int studyId)
        {
            try
            {
                var result = objStudyTaskBA.GetPLReviewDetailsByStudyId(studyId);
                return Json(result.ToDataSourceResult(request).Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new PLStudyReview() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }

        }

        /// <summary>
        /// Save PL Task details
        /// </summary>
        /// <param name="studyTask"></param>      
        /// <returns></returns>
        public JsonResult SavePLReviewDetails(Data.PLStudyReview pLStudyReview)
        {
            try
            {
                bool result = objStudyTaskBA.CreateUpdatePLReview(pLStudyReview);
                if (result)
                {
                    msgType = Utilities.Messages.SuccessStatus;
                    NewStudyWorkflow newStudyWorkflow = new NewStudyWorkflow();
                    newStudyWorkflow.ReviewByProgramLead(pLStudyReview.StudyId, HttpContext.Session.GetString("AuthenticUser"),
                        HttpContext.Session.GetString("Username"));
                }
                else
                {
                    msgType = Utilities.Messages.ProblemInCreation;
                }
                return Json(new { data = message, msgType });
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new PLStudyReview() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInCreation });

            }
        }

        /// <summary>
        /// Update PI Resubmission
        /// </summary>
        /// <param name="studyTask"></param>      
        /// <returns></returns>
        public JsonResult UpdatePIResubmission(Data.NewStudy newStudy)
        {
            try
            {
                bool result = objStudyTaskBA.UpdatePIResubmission(newStudy);
                if (result)
                {
                    msgType = Utilities.Messages.SuccessStatus;
                    var newStudyWorkflow = new NewStudyWorkflow();
                    newStudyWorkflow.ReviewByMsl(newStudy.StudyId, HttpContext.Session.GetString("AuthenticUser"), HttpContext.Session.GetString("Username"));
                }
                else
                {
                    msgType = Utilities.Messages.ProblemInCreation;
                }
                return Json(new { data = message, msgType });
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new NewStudy() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInCreation });

            }
        }

        /// <summary>
        ///Get MRC Budget Details by StudyId
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns>list of Budget details</returns>
        public JsonResult GetMRCBudgetDetails([DataSourceRequest] DataSourceRequest request, int studyId)
        {
            try
            {
                var result = objStudyTaskBA.GetMRCBudgetDetails(studyId);
                return Json(result.ToDataSourceResult(request).Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new MRCStudyReview() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }

        /// <summary>
        ///Get MRC Details by StudyId
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns>list of MRC details</returns>
        public JsonResult GetMRCDetails([DataSourceRequest] DataSourceRequest request, int studyId, string loginUserName, string taskName)
        {
            try
            {
                var result = objStudyTaskBA.GetMRCDetails(studyId);
                if (result.Count <= 0)
                {
                    Data.Documents documents = new Data.Documents
                    {
                        StudyId = studyId,
                        SubModuleName = Utilities.Messages.LocalMRCSupportDocuments,
                        ANJU_ChangedBy = loginUserName
                    };
                    bool isDocumentDeleted = objNewStudyBA.DeleteDocuments(documents);
                    var folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "LocalMRCSupportDocuments");
                    DeleteDirectory(folderPath);
                }
                else
                {
                    if (string.IsNullOrEmpty(result[0].MRCDecisionRejectedBy) && string.IsNullOrEmpty(result[0].MRCRejectedDeliveryMethod) && taskName == Utilities.Messages.LMRCDECISIONREJECTEDCONFIRMEDTASKNAME)
                    {
                        Data.Documents documents = new Data.Documents
                        {
                            StudyId = studyId,
                            SubModuleName = Utilities.Messages.LMRCRejectedSupportDocuments,
                            ANJU_ChangedBy = loginUserName
                        };
                        bool isDocumentDeleted = objNewStudyBA.DeleteDocuments(documents);
                        var folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "LMRCRejectedSupportDocuments");
                        DeleteDirectory(folderPath);

                    }
                    if (string.IsNullOrEmpty(result[0].MRCDecisionWithdrawalBy) && string.IsNullOrEmpty(result[0].MRCWithdrawalDeliveryMethod) && taskName == Utilities.Messages.LMRCDECISIONWITHDRAWNTASKNAME)
                    {
                        Data.Documents documents = new Data.Documents
                        {
                            StudyId = studyId,
                            SubModuleName = Utilities.Messages.LMRCWithdrawalSupportDocuments,
                            ANJU_ChangedBy = loginUserName
                        };
                        bool isDocumentDeleted = objNewStudyBA.DeleteDocuments(documents);
                        var folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "LMRCWithdrawalSupportDocuments");
                        DeleteDirectory(folderPath);

                    }

                }
                return Json(result.ToDataSourceResult(request).Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new MRCStudyReview() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }

        /// <summary>
        /// Save local MRC details
        /// </summary>
        /// <param name="mrcStudyReview"></param>      
        /// <returns></returns>
        public JsonResult SaveMRCReviewDetails(Data.MRCStudyReview mrcStudyReview)
        {
            try
            {
                bool result = objStudyTaskBA.CreateUpdateMRCReview(mrcStudyReview);
                if (result == true)
                {
                    msgType = Utilities.Messages.SuccessStatus;

                    NewStudyWorkflow newStudyWorkflow = new NewStudyWorkflow();
                    newStudyWorkflow.RecordMrcResults(mrcStudyReview.StudyId, HttpContext.Session.GetString("AuthenticUser"),
                        HttpContext.Session.GetString("Username"));
                }
                else
                {
                    msgType = Utilities.Messages.ProblemInCreation;
                }
                return Json(new { data = message, msgType });
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new MRCStudyReview() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInCreation });

            }
        }
        /// <summary>
        /// Save LocalMRC Documents
        /// </summary>
        /// <param name="uploadfiles"></param>
        /// <param name="additional"></param>
        /// <returns></returns>
        public async Task<ActionResult> SaveLocalMRCDocuments(IEnumerable<IFormFile> uploadfiles, string[] additional)
        {
            try
            {
                bool result = true;
                if (uploadfiles != null)
                {
                    foreach (var file in uploadfiles)
                    {
                        var folderPath = "";
                        string SubModuleName = string.Empty;
                        var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                        var studyId = HttpContext.Session.GetString("StudyId");
                        var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
                        if (additional[7].ToString() == "LocalMRC")
                        {
                            folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "LocalMRCSupportDocuments");
                            SubModuleName = Utilities.Messages.LocalMRCSupportDocuments;
                        }
                        else
                        {
                            folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "GlobalMRCSupportDocuments");
                            SubModuleName = Utilities.Messages.GlobalMRCSupportDocuments;
                        }
                        var filePath = Path.Combine(folderPath, fileName);
                        bool isCreated = CreateDirectory(folderPath);
                        if (isCreated)
                        {
                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {

                                await file.CopyToAsync(fileStream);
                                Data.Documents objDocuments = new Data.Documents()
                                {
                                    DocumentName = additional[0],
                                    DocumentNameWithOutExtension = Path.GetFileNameWithoutExtension(fileContent.FileName.Trim('"')),
                                    DocumentSize = Convert.ToInt32(new System.IO.FileInfo(filePath).Length),
                                    DocumentExtension = Path.GetExtension(filePath).ToLowerInvariant().ToString(),
                                    SubModuleName = SubModuleName,
                                    StudyId = Convert.ToInt32(studyId),
                                    Path = filePath,
                                    DocumentType = additional[2]?.ToString(),
                                    DocumentStatus = additional[1]?.ToString(),
                                    DocumentSubType = additional[3]?.ToString(),
                                    DocumentVersion = additional[4]?.ToString(),
                                    OriginalDate = additional[5] != null ? Convert.ToDateTime(additional[5]) : (DateTime?)null,
                                    ExpirationDate = additional[6] != null ? Convert.ToDateTime(additional[6]) : (DateTime?)null,
                                    IsActive = true,
                                    IsDeleted = false,
                                    ANJU_AddedBy = HttpContext.Session.GetString("Username"),
                                    Anju_AddedDate = DateTime.UtcNow
                                };

                                result = objNewStudyBA.Fileupload(objDocuments);
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
                    return Content(" ");
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
        /// Remove the Requested Support uploaded files
        /// </summary>
        /// <param name="fileNames"></param>
        /// <returns></returns>
        public ActionResult RemoveLocalMRCDocuments(string[] fileNames, string[] additional)
        {
            bool result = true;
            try
            {
                if (fileNames != null)
                {
                    foreach (var fullName in fileNames)
                    {
                        var fileName = Path.GetFileName(fullName);
                        int studyId = int.Parse(HttpContext.Session.GetString("StudyId"));
                        var username = HttpContext.Session.GetString("Username");
                        string SubModuleName = string.Empty;
                        if (!string.IsNullOrEmpty(additional[6].ToString()))
                        {
                            if (additional[7].ToString() == "LocalMRC")
                            {
                                SubModuleName = Utilities.Messages.LocalMRCSupportDocuments;
                            }
                            else
                            {
                                SubModuleName = Utilities.Messages.GlobalMRCSupportDocuments;
                            }
                        }
                        var folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, SubModuleName);
                        var filePath = Path.Combine(folderPath, fileName);

                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                            result = objNewStudyBA.DeleteUploadedFile(studyId, username, SubModuleName, fileName);
                        }
                    }
                }
                msgType = Utilities.Messages.SuccessStatus;
                return Content("");
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), Utilities.Messages.ProblemInRemoval);
            }
            return Json(new { msgType = msgType });

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

        /// <summary>
        /// Save Rejected MRC details
        /// </summary>
        /// <param name="mrcStudyReview"></param>      
        /// <returns></returns>
        public JsonResult SaveRejectedMRCReviewDetails(Data.MRCStudyReview mrcStudyReview)
        {
            try
            {
                bool result = objStudyTaskBA.CreateRejectedMRCStudyReview(mrcStudyReview);
                if (result == true)
                    msgType = Utilities.Messages.SuccessStatus;
                else
                {
                    msgType = Utilities.Messages.ProblemInCreation;
                }
                return Json(new { data = message, msgType });
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new MRCStudyReview() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInCreation });

            }
        }

        /// <summary>
        /// Save Withdrawal MRC details
        /// </summary>
        /// <param name="mrcStudyReview"></param>      
        /// <returns></returns>
        public JsonResult SaveWithdrawalMRCReviewDetails(Data.MRCStudyReview mrcStudyReview)
        {
            try
            {
                bool result = objStudyTaskBA.CreateWithdrawalMRCStudyReview(mrcStudyReview);
                if (result == true)
                    msgType = Utilities.Messages.SuccessStatus;
                else
                {
                    msgType = Utilities.Messages.ProblemInCreation;
                }
                return Json(new { data = message, msgType });
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new MRCStudyReview() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInCreation });

            }
        }
        /// <summary>
        /// Update MRC details
        /// </summary>
        /// <param name="mrcStudyReview"></param>      
        /// <returns></returns>
        public JsonResult UpdateMRCReviewDetails(Data.MRCStudyReview mrcStudyReview, string piUserName)
        {
            try
            {
                bool result = objStudyTaskBA.UpdateMRCStudyReview(mrcStudyReview, piUserName);
                if (result)
                {
                    msgType = Utilities.Messages.SuccessStatus;
                    var newStudyWorkflow = new NewStudyWorkflow();
                    newStudyWorkflow.MarkMileStoneComplete(mrcStudyReview.StudyId, HttpContext.Session.GetString("AuthenticUser"),
                        HttpContext.Session.GetString("Username"));
                }
                else
                {
                    msgType = Utilities.Messages.ProblemInCreation;
                }
                return Json(new { data = message, msgType });
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new MRCStudyReview() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInCreation });

            }
        }

        /// <summary>
        /// Save LocalMRC Rejected Supported Documents
        /// </summary>
        /// <param name="uploadfiles"></param>
        /// <param name="additional"></param>
        /// <returns></returns>
        public async Task<ActionResult> SaveLMRCRejectedOrWithdrawalSupportDocuments(IEnumerable<IFormFile> uploadfiles, string[] additional)
        {
            try
            {
                bool result = true;
                if (uploadfiles != null)
                {
                    foreach (var file in uploadfiles)
                    {
                        var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                        var studyId = HttpContext.Session.GetString("StudyId");
                        var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
                        var folderPath = string.Empty;
                        var subModuleName = string.Empty;

                        if (additional[8]?.ToString() == Messages.LMRCDECISIONREJECTEDCONFIRMEDTASKNAME && additional[9]?.ToString() == Utilities.Messages.LocalMRC)
                        {
                            subModuleName = Messages.LMRCRejectedSupportDocuments;
                            folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "LMRCRejectedSupportDocuments");
                        }
                        else if (additional[8]?.ToString() == Messages.LMRCDECISIONWITHDRAWNTASKNAME && additional[9]?.ToString() == Utilities.Messages.LocalMRC)
                        {
                            subModuleName = Messages.LMRCWithdrawalSupportDocuments;
                            folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "LMRCWithdrawalSupportDocuments");
                        }
                        else if (additional[8]?.ToString() == Messages.LMRCFINALREJECTEDDOCUMENT && additional[9]?.ToString() == Utilities.Messages.LocalMRC)
                        {
                            subModuleName = Messages.LMRCFINALREJECTEDDOCUMENT;
                            folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "LMRCFinalRejectedDocument");

                        }
                        else if (additional[8]?.ToString() == Messages.GMRCDECISIONREJECTEDCONFIRMEDTASKNAME && additional[9]?.ToString() == Utilities.Messages.GlobalMRC)
                        {
                            subModuleName = Messages.GMRCREJECTEDSUPPORTDOCUMENTS;
                            folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "GMRCRejectedSupportDocuments");
                        }
                        else if (additional[8]?.ToString() == Messages.GMRCDECISIONWITHDRAWNTASKNAME && additional[9]?.ToString() == Utilities.Messages.GlobalMRC)
                        {
                            subModuleName = Messages.GMRCWITHDRAWALSUPPORTDOCUMENTS;
                            folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "GMRCWithdrawalSupportDocuments");
                        }
                        else if (additional[8]?.ToString() == Messages.GMRCFINALREJECTEDDOCUMENT && additional[9]?.ToString() == Utilities.Messages.GlobalMRC)
                        {
                            subModuleName = Messages.GMRCFINALREJECTEDDOCUMENT;
                            folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "GMRCFinalRejectedDocument");
                        }
                        else if (additional[8]?.ToString() == Messages.GMRCAPPROVEDTASKNAME && additional[9]?.ToString() == Utilities.Messages.GlobalMRC)
                        {
                            subModuleName = Messages.GMRCADDITIONALAPPROVALDOCUMENTS;
                            folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "GMRCAdditionalApprovalDocuments");

                        }

                        var filePath = Path.Combine(folderPath, fileName);
                        bool isCreated = CreateDirectory(folderPath);

                        if (isCreated)
                        {

                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {

                                await file.CopyToAsync(fileStream);
                                Data.Documents objDocuments = new Data.Documents()
                                {
                                    DocumentName = additional[0],
                                    DocumentNameWithOutExtension = Path.GetFileNameWithoutExtension(fileContent.FileName.Trim('"')),
                                    DocumentSize = Convert.ToInt32(new System.IO.FileInfo(filePath).Length),
                                    DocumentExtension = Path.GetExtension(filePath).ToLowerInvariant().ToString(),
                                    SubModuleName = subModuleName,
                                    StudyId = Convert.ToInt32(studyId),
                                    Path = filePath,
                                    DocumentType = additional[2]?.ToString(),
                                    DocumentStatus = additional[1]?.ToString(),
                                    DocumentSubType = additional[3]?.ToString(),
                                    DocumentVersion = additional[4]?.ToString(),
                                    OriginalDate = additional[5] != null ? Convert.ToDateTime(additional[5]) : (DateTime?)null,
                                    ExpirationDate = additional[6] != null ? Convert.ToDateTime(additional[6]) : (DateTime?)null,
                                    IsActive = true,
                                    IsDeleted = false,
                                    ANJU_AddedBy = additional[7]?.ToString(),
                                    Anju_AddedDate = DateTime.UtcNow
                                };

                                result = objNewStudyBA.Fileupload(objDocuments);
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
        /// Remove the Requested Support uploaded files
        /// </summary>
        /// <param name="fileNames"></param>
        /// <returns></returns>
        public ActionResult RemoveLMRCRejectedOrWithdrawalSupportDocuments(string[] fileNames, string[] additional)
        {
            bool result = true;
            try
            {
                if (fileNames != null)
                {
                    foreach (var fullName in fileNames)
                    {
                        var fileName = Path.GetFileName(fullName);
                        int studyId = int.Parse(HttpContext.Session.GetString("StudyId"));
                        var username = HttpContext.Session.GetString("Username");
                        var folderPath = string.Empty;
                        string submoduleName = string.Empty;
                        if (additional[8]?.ToString() == Messages.LMRCDECISIONREJECTEDCONFIRMEDTASKNAME && additional[9]?.ToString() == Utilities.Messages.LocalMRC)
                        {
                            submoduleName = Utilities.Messages.LMRCRejectedSupportDocuments;
                            folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "LMRCRejectedSupportDocuments");
                        }
                        else if (additional[8]?.ToString() == Messages.LMRCDECISIONWITHDRAWNTASKNAME && additional[9]?.ToString() == Utilities.Messages.LocalMRC)
                        {
                            submoduleName = Utilities.Messages.LMRCWithdrawalSupportDocuments;
                            folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "LMRCWithdrawalSupportDocuments");
                        }
                        else if (additional[8]?.ToString() == Messages.LMRCFINALREJECTEDDOCUMENT && additional[9]?.ToString() == Utilities.Messages.LocalMRC)
                        {
                            submoduleName = Messages.LMRCFINALREJECTEDDOCUMENT;
                            folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "LMRCFinalRejectedDocument");

                        }
                        else if (additional[8]?.ToString() == Messages.GMRCDECISIONREJECTEDCONFIRMEDTASKNAME && additional[9]?.ToString() == Utilities.Messages.GlobalMRC)
                        {
                            submoduleName = Messages.GMRCREJECTEDSUPPORTDOCUMENTS;
                            folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "GMRCRejectedSupportDocuments");
                        }
                        else if (additional[8]?.ToString() == Messages.GMRCDECISIONWITHDRAWNTASKNAME && additional[9]?.ToString() == Utilities.Messages.GlobalMRC)
                        {
                            submoduleName = Messages.GMRCWITHDRAWALSUPPORTDOCUMENTS;
                            folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "GMRCWithdrawalSupportDocuments");
                        }
                        else if (additional[8]?.ToString() == Messages.GMRCFINALREJECTEDDOCUMENT && additional[9]?.ToString() == Utilities.Messages.GlobalMRC)
                        {
                            submoduleName = Messages.GMRCFINALREJECTEDDOCUMENT;
                            folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "GMRCFinalRejectedDocument");
                        }
                        else if (additional[8]?.ToString() == Messages.GMRCAPPROVEDTASKNAME && additional[9]?.ToString() == Utilities.Messages.GlobalMRC)
                        {
                            submoduleName = Messages.GMRCADDITIONALAPPROVALDOCUMENTS;
                            folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "GMRCAdditionalApprovalDocuments");

                        }
                        var filePath = Path.Combine(folderPath, fileName);

                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                            result = objNewStudyBA.DeleteUploadedFile(studyId, username, submoduleName, fileName);
                        }
                    }
                }
                msgType = Utilities.Messages.SuccessStatus;
                return Content("");
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), Utilities.Messages.ProblemInRemoval);
            }
            return Json(new { msgType = msgType });
        }


        /// <summary>
        /// Save LocalMRC Rejected final Documents
        /// </summary>
        /// <param name="finaluploadfile"></param>
        /// <param name="additionals"></param>
        /// <returns></returns>
        public async Task<ActionResult> SaveLMRCFinalRejectedOrWithdrawalDocuments(IEnumerable<IFormFile> finaluploadfile, string[] additional)
        {
            bool result = true;
            try
            {
                if (finaluploadfile != null)
                {
                    foreach (var file in finaluploadfile)
                    {
                        var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                        var studyId = HttpContext.Session.GetString("StudyId");
                        var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
                        var folderPath = string.Empty;
                        var subModuleName = string.Empty;
                        if (additional[8]?.ToString() == Messages.LMRCFINALREJECTEDDOCUMENT)
                        {
                            subModuleName = Messages.LMRCFINALREJECTEDDOCUMENT;
                            folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "LMRCFinalRejectedDocument");
                        }
                        else if (additional[8]?.ToString() == Messages.LMRCFINALWITHDRAWALDDOCUMENT)
                        {
                            subModuleName = Messages.LMRCFINALWITHDRAWALDDOCUMENT;
                            folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "LMRCFinalWithdrawalDocument");

                        }
                        if (additional[8]?.ToString() == Messages.GMRCFINALREJECTEDDOCUMENT)
                        {
                            subModuleName = Messages.GMRCFINALREJECTEDDOCUMENT;
                            folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "GMRCFinalRejectedDocument");
                        }
                        else if (additional[8]?.ToString() == Messages.GMRCFINALWITHDRAWALDDOCUMENT)
                        {
                            subModuleName = Messages.GMRCFINALWITHDRAWALDDOCUMENT;
                            folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "GMRCFinalWithdrawalDocument");

                        }
                        else if (additional[8]?.ToString() == Messages.GMRCAPPROVALFINALDOCUMENT)
                        {
                            subModuleName = Messages.GMRCAPPROVALFINALDOCUMENT;
                            folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "GMRCApprovalFinalDocument");

                        }
                        var filePath = Path.Combine(folderPath, fileName);
                        bool isCreated = CreateDirectory(folderPath);

                        if (isCreated)
                        {
                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                                Data.Documents objDocuments = new Data.Documents()
                                {
                                    DocumentName = additional[0],
                                    DocumentNameWithOutExtension = Path.GetFileNameWithoutExtension(fileContent.FileName.Trim('"')),
                                    DocumentSize = Convert.ToInt32(new System.IO.FileInfo(filePath).Length),
                                    DocumentExtension = Path.GetExtension(filePath).ToLowerInvariant().ToString(),
                                    SubModuleName = subModuleName,
                                    StudyId = Convert.ToInt32(studyId),
                                    Path = filePath,
                                    DocumentType = additional[2]?.ToString(),
                                    DocumentStatus = additional[1]?.ToString(),
                                    DocumentSubType = additional[3]?.ToString(),
                                    DocumentVersion = additional[4]?.ToString(),
                                    OriginalDate = additional[5] != null ? Convert.ToDateTime(additional[5]) : (DateTime?)null,
                                    ExpirationDate = additional[6] != null ? Convert.ToDateTime(additional[6]) : (DateTime?)null,
                                    IsActive = true,
                                    IsDeleted = false,
                                    ANJU_AddedBy = additional[7]?.ToString(),
                                    Anju_AddedDate = DateTime.UtcNow
                                };

                                result = objNewStudyBA.Fileupload(objDocuments);
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
                    return Content(" ");
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
        /// Remove the Requested Support uploaded files
        /// </summary>
        /// <param name="fileNames"></param>
        /// <returns></returns>
        public ActionResult RemoveLMRCFinalRejectedOrWithdrawalDocuments(string[] fileNames, string[] additional)
        {
            bool result = true;
            try
            {
                if (fileNames != null)
                {
                    foreach (var fullName in fileNames)
                    {
                        var fileName = Path.GetFileName(fullName);
                        int studyId = int.Parse(HttpContext.Session.GetString("StudyId"));
                        var username = HttpContext.Session.GetString("Username");
                        var folderPath = string.Empty;
                        string submoduleName = string.Empty;

                        if (additional[8]?.ToString() == Messages.LMRCFINALREJECTEDDOCUMENT)
                        {
                            submoduleName = Messages.LMRCFINALREJECTEDDOCUMENT;
                            folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "LMRCFinalRejectedDocument");

                        }
                        else if (additional[8]?.ToString() == Messages.LMRCFINALWITHDRAWALDDOCUMENT)
                        {
                            submoduleName = Messages.LMRCFINALWITHDRAWALDDOCUMENT;
                            folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "LMRCFinalWithdrawalDocument");

                        }
                        if (additional[8]?.ToString() == Messages.GMRCFINALREJECTEDDOCUMENT)
                        {
                            submoduleName = Messages.GMRCFINALREJECTEDDOCUMENT;
                            folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "GMRCFinalRejectedDocument");
                        }
                        else if (additional[8]?.ToString() == Messages.GMRCFINALWITHDRAWALDDOCUMENT)
                        {
                            submoduleName = Messages.GMRCFINALWITHDRAWALDDOCUMENT;
                            folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "GMRCFinalWithdrawalDocument");

                        }
                        else if (additional[8]?.ToString() == Messages.GMRCAPPROVEDTASKNAME)
                        {
                            submoduleName = Messages.GMRCAPPROVALFINALDOCUMENT;
                            folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "GMRCApprovalFinalDocument");

                        }
                        else if (additional[5]?.ToString() == ConstDefaultValue.MANUAL)
                        {
                            submoduleName = ConstDefaultValue.MANUAL;
                            folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, ConstDefaultValue.MANUAL);

                        }
                        var filePath = Path.Combine(folderPath, fileName);

                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                            result = objNewStudyBA.DeleteUploadedFile(studyId, username, submoduleName, fileName);
                        }
                    }
                }
                msgType = Utilities.Messages.SuccessStatus;
                return Content("");
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), Utilities.Messages.ProblemInRemoval);
            }
            return Json(new { msgType = msgType });

        }

        /// <summary>
        /// Get MAC Details
        /// </summary>
        /// <param name="request"></param>
        /// <param name="StudyId"></param>
        /// <returns></returns>
        public JsonResult GetMACDocuments([DataSourceRequest] DataSourceRequest request, int studyId)
        {
            try
            {
                var result = objNewStudyBA.GetDocumentsByStudyID(studyId, Utilities.Messages.GMRCMACDDOCUMENT);
                return Json(result.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new NewStudy() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }

        /// <summary>
        /// Get Documents By subModule
        /// </summary>
        /// <param name="request"></param>
        /// <param name="StudyId"></param>
        /// <param name="submodule"></param>
        /// <returns></returns>
        public JsonResult GetDocumentsBysubModule([DataSourceRequest] DataSourceRequest request, int studyId,string submodule)
        {
            try
            {
                var result = objNewStudyBA.GetDocumentsByStudyID(studyId, submodule);
                return Json(result.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new NewStudy() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }

        /// <summary>
        /// Save MAC  Documents
        /// </summary>
        /// <param name="Macuploadfile"></param>
        /// <param name="additionals"></param>
        /// <returns></returns>
        public async Task<ActionResult> SaveMACDocuments(IEnumerable<IFormFile> MACSUploadfiles, string[] additional)
        {
            bool result = true;
            try
            {
                if (MACSUploadfiles != null)
                {
                    foreach (var file in MACSUploadfiles)
                    {
                        var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                        var studyId = HttpContext.Session.GetString("StudyId");
                        var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
                        var folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "GMRCMACDDocument");
                        var subModuleName = Messages.GMRCMACDDOCUMENT;

                        var filePath = Path.Combine(folderPath, fileName);
                        bool isCreated = CreateDirectory(folderPath);

                        if (isCreated)
                        {
                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                                Data.Documents objDocuments = new Data.Documents()
                                {
                                    DocumentName = additional[0],
                                    DocumentNameWithOutExtension = Path.GetFileNameWithoutExtension(fileContent.FileName.Trim('"')),
                                    DocumentSize = Convert.ToInt32(new System.IO.FileInfo(filePath).Length),
                                    DocumentExtension = Path.GetExtension(filePath).ToLowerInvariant().ToString(),
                                    SubModuleName = subModuleName,
                                    StudyId = Convert.ToInt32(studyId),
                                    Path = filePath,
                                    DocumentType = additional[2]?.ToString(),
                                    DocumentStatus = additional[1]?.ToString(),
                                    DocumentSubType = additional[3]?.ToString(),
                                    DocumentVersion = additional[4]?.ToString(),
                                    OriginalDate = additional[5] != null ? Convert.ToDateTime(additional[5]) : (DateTime?)null,
                                    ExpirationDate = additional[6] != null ? Convert.ToDateTime(additional[6]) : (DateTime?)null,
                                    IsActive = true,
                                    IsDeleted = false,
                                    ANJU_AddedBy = HttpContext.Session.GetString("Username"),
                                    Anju_AddedDate = DateTime.UtcNow
                                };

                                result = objNewStudyBA.Fileupload(objDocuments);
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
        /// Remove the MAC files
        /// </summary>
        /// <param name="fileNames"></param>
        /// <returns></returns>
        public ActionResult RemoveMACDocuments(string[] MACSUploadfiles, string[] additional)
        {
            bool result = true;
            try
            {
                if (MACSUploadfiles != null)
                {
                    foreach (var fullName in MACSUploadfiles)
                    {
                        var fileName = Path.GetFileName(fullName);
                        int studyId = int.Parse(HttpContext.Session.GetString("StudyId"));
                        var username = HttpContext.Session.GetString("Username");
                        var folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "GMRCMACDDocument");
                        string submoduleName = Messages.GMRCMACDDOCUMENT;
                        var filePath = Path.Combine(folderPath, fileName);

                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                            result = objNewStudyBA.DeleteUploadedFile(studyId, username, submoduleName, fileName);
                        }
                    }
                }
                msgType = Utilities.Messages.SuccessStatus;
                return Content("");
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), Utilities.Messages.ProblemInRemoval);
            }
            return Json(new { msgType = msgType });
        }

        /// <summary>
        /// Delete Documents
        /// </summary>
        /// <param name="request"></param>
        /// <param name="documents"></param>
        /// <returns>Json</returns>
        public JsonResult DeleteDocuments(Documents documents)
        {
            try
            {
                bool isDocumentDeleted = objNewStudyBA.DeleteDocuments(documents);
                if (isDocumentDeleted == true)
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
        /// Verify wheather document name is unique or not
        /// </summary>
        /// <param name="documentsName"></param>
        /// <param name="studyId"></param>
        /// <returns>true/false</returns>
        public bool IsDocumentNameIsUnique(string documentsName,int studyId,string moduleName)
        {
            bool isDocumentNameUnique = true;
            try
            {
                isDocumentNameUnique = objNewStudyBA.IsDocumentNameIsUnique(documentsName, studyId, moduleName);
               
            }
            catch (Exception ex)
            {

                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), Utilities.Messages.FetchError);
            }
            return isDocumentNameUnique;
        }

        /// <summary>
        /// update Conditional Approval Details
        /// </summary>
        /// <param name="mrcStudyReview"></param>      
        /// <returns></returns>
        public JsonResult UpdateGMRCConditionalApprovalDetails(Data.MRCStudyReview mrcStudyReview)
        {
            try
            {
                bool result = objStudyTaskBA.UpdateGMRCConditionalApprovalDetails(mrcStudyReview);
                if (result == true)
                    msgType = Utilities.Messages.SuccessStatus;
                else
                {
                    msgType = Utilities.Messages.ProblemInUpdation;
                }
                return Json(new { data = message, msgType });
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new MRCStudyReview() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInUpdation });

            }
        }

        /// <summary>
        ///Get Drop down Value for add document type
        /// </summary>           
        /// <returns></returns>
        public JsonResult GetDocumentType([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                var result = objNewStudyBA.GetdocumentType();
                return Json(result.ToDataSourceResult(request).Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new SysCodeValues() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }

        /// <summary>
        ///Save Identification Activation documents
        /// </summary>           
        /// <returns></returns>
        public JsonResult SaveIdentificationActivationDocuments(List<Data.Documents> lsDocuments, string studyowner)
        {
            try
            {
                var LogedinUserName = HttpContext.Session.GetString("Username");
                bool result = objNewStudyBA.SaveIdentificationActivationDocuments(lsDocuments, LogedinUserName, studyowner);
                if (result == true)
                    msgType = Utilities.Messages.SuccessStatus;
                else
                {
                    msgType = Utilities.Messages.ProblemInCreation;
                }
                return Json(new { data = message, msgType });
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new StudyReview() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInCreation });

            }
        }

        /// <summary>
        /// Get Activationdocument Details
        /// </summary>
        /// <param name="request"></param>
        /// <param name="StudyId"></param>
        /// <returns></returns>
        public JsonResult GetActivationDocuments([DataSourceRequest] DataSourceRequest request, int studyId)
        {
            try
            {
                var result = objNewStudyBA.GetDocumentsByStudyID(studyId, Utilities.ConstDefaultValue.ACTIVATIONDOCUMENT);
                return Json(result.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new NewStudy() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }

        /// <summary>
        /// Save SubmitActivation Documents
        /// </summary>
        /// <param name="uploadfiles"></param>
        /// <param name="additional"></param>
        /// <returns></returns>
        public async Task<ActionResult> SaveSubmitActivationDocuments(IEnumerable<IFormFile> files)
        {

            bool result = true;
            int count = 0;
            string extenstion = "", path = "";
            try
            {
                if (files != null)
                {
                    foreach (var file in files)
                    {

                        if (count < 1)
                        {
                            var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                            var studyId = HttpContext.Session.GetString("StudyId");
                            var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
                            var folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, Messages.IDENTIFYACTIVATIONDOCUMENTS);
                            var filePath = Path.Combine(folderPath, fileName);
                            extenstion = Path.GetExtension(filePath).ToLowerInvariant().ToString();
                            path = filePath.ToString();
                            bool isCreated = CreateDirectory(folderPath);

                            if (isCreated)
                            {
                                using (var fileStream = new FileStream(filePath, FileMode.Create))
                                {
                                    await file.CopyToAsync(fileStream);
                                }
                            }
                            count++;

                        }
                        else
                        {
                            var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                            Data.Documents objDocuments = new Data.Documents()
                            {
                                DocumentName = fileContent.FileName.ToString().Trim('"'),

                                DocumentSize = Convert.ToInt32(new System.IO.FileInfo(path).Length),
                                DocumentExtension = extenstion,
                                SubModuleName = Messages.IDENTIFYACTIVATIONDOCUMENTS,
                                StudyId = Convert.ToInt32(HttpContext.Session.GetString("StudyId")),
                                Path = path,
                                IsActive = true,
                                IsDeleted = false,
                                ANJU_AddedBy = HttpContext.Session.GetString("Username"),
                                Anju_AddedDate = DateTime.UtcNow
                            };

                            result = objNewStudyBA.SubmitActivationdocument(objDocuments);
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
                    return Content(msgType);
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
        /// Get Review Activation document details
        /// </summary>
        /// <param name="documents"></param>      
        /// <returns></returns>
        public JsonResult GetReviewActivationDocuments([DataSourceRequest] DataSourceRequest request)
        {
            int studyId = Convert.ToInt32(HttpContext.Session.GetString("StudyId"));
            try
            {
                var result = objStudyTaskBA.GetReviewActivationDocuments(studyId);
                return Json(result.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new NewStudy() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }

        /// <summary>
        /// Get Activated Activation document details
        /// </summary>
        /// <param name="documents"></param>      
        /// <returns></returns>
        public JsonResult ActivateActivationDocuments([DataSourceRequest] DataSourceRequest request, string documentname, string status)
        {
            int studyId = Convert.ToInt32(HttpContext.Session.GetString("StudyId"));
            string userName = HttpContext.Session.GetString("Username");
            try
            {
                var isDocumentUpdated = objStudyTaskBA.ActivateActivationDocuments(studyId, documentname, status, userName);
                if (isDocumentUpdated == true)
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
        /// Get Activated Documents by study ID
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Json</returns>
        public ActionResult GetActivatedActivationdocument([DataSourceRequest] DataSourceRequest request)
        {
            int studyId = Convert.ToInt32(HttpContext.Session.GetString("StudyId"));
            try
            {
                var response = objStudyTaskBA.GetActivatedActivationdocument(studyId);
                return Json(response.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new Documents() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }

        /// <summary>
        /// Get Rejected Activation document details
        /// </summary>
        /// <param name="documents"></param>      
        /// <returns></returns>
        public JsonResult AddRejectedActivationDocument([DataSourceRequest] DataSourceRequest request, string studyowner, int studyid, string comment)
        {
            string userName = HttpContext.Session.GetString("Username");
            try
            {
                var isDocumentUpdated = objStudyTaskBA.AddRejectedActivationDocument(studyid, studyowner, userName, comment);
                if (isDocumentUpdated == true)
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
        /// Get Rejected Updated document details
        /// </summary>
        /// <param name="documents"></param>      
        /// <returns></returns>
        public JsonResult AddRejectedUpdatedDocument([DataSourceRequest] DataSourceRequest request, string studyowner, int studyid, string comment)
        {
            string userName = HttpContext.Session.GetString("Username");
            try
            {
                var isDocumentUpdated = objStudyTaskBA.AddRejectedUpdatedDocument(studyid, studyowner, userName, comment);
                if (isDocumentUpdated == true)
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
        /// Get document by name
        /// </summary>
        /// <param name="documents"></param>      
        /// <returns></returns>
        public JsonResult GetDocumentByName([DataSourceRequest] DataSourceRequest request, string documentname, int studyid)
        {
            try
            {
                var result = objStudyTaskBA.GetDocumentbyName(documentname, studyid);
                return Json(result.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new Documents() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }
        #endregion
    }
}