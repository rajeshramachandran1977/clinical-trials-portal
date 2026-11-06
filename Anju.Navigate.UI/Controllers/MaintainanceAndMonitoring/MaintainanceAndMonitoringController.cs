using Anju.Navigate.BusinessAccess;
using Anju.Navigate.Data;
using Anju.Navigate.Utilities;
using Anju.Navigate.Utilities.Logger;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Anju.Navigate.UI.Controllers
{
    public class MaintainanceAndMonitoringController : Controller
    {
        #region Variable Declarations

        private readonly IAppLogger<MaintainanceAndMonitoringController> _logger = null;
        PatientAccrualBA objPatientAccrualBA = new PatientAccrualBA();
        MaintainanceAndMonitoringBA objMaintainanceAndMonitoringBA = new MaintainanceAndMonitoringBA();
        NewStudyBA objNewStudyBA = new NewStudyBA();
        StudyTaskBA objStudyTaskBA = new StudyTaskBA();

        string msgType = string.Empty;
        string message = string.Empty;
        #endregion

        #region Constructor

        public MaintainanceAndMonitoringController(IAppLogger<MaintainanceAndMonitoringController> logger)
        {
            this._logger = logger;
        }
        #endregion

        #region Views

        public IActionResult UpdateDocumentforPatientAccrualUpdate()
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
                ViewBag.StudyNumber = objNewStudy.StudyNumber;
                ViewBag.TitleofTrial = objNewStudy.TitleofTrial;
                ViewBag.Institution = objNewStudy.Institution;
            }
            else
                return RedirectToAction("Login", "Login");
            return View();

        }

        public IActionResult AmendProtocolOrBudget()
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
            {
                return RedirectToAction("Login", "Login");
            }
            return View();

        }

        public IActionResult MaintainanceAndMonitoring()
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
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }

        //public IActionResult ModifyStatus()
        //{
        //       var objNewStudy = JsonConvert.DeserializeObject<Data.NewStudy>(TempData["OpenData"]?.ToString());
        //    TempData.Keep("OpenData");
        //    if (objNewStudy != null)
        //    {
        //        ViewBag.StudyId = objNewStudy.StudyId;
        //        HttpContext.Session.SetString("StudyId", objNewStudy.StudyId.ToString());
        //        ViewBag.AssignedUsername = objNewStudy.ANJU_AddedBy;
        //        ViewBag.LogedinUserName = HttpContext.Session.GetString("Username");
        //    }
        //    else
        //        return RedirectToAction("Login", "Login");

        //    return View();
        //}
        public IActionResult CreateDeliverStoppedStudy()
        {
            return View();
        }
        public IActionResult ResubmitAmendmentRequest()
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
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }

        public IActionResult ReviewAUpdatedDocument()
        {
            var objNewStudy = JsonConvert.DeserializeObject<Data.NewStudy>(TempData["OpenData"]?.ToString());
            TempData.Keep("OpenData");
            if (objNewStudy != null)
            {
                HttpContext.Session.SetString("StudyId", objNewStudy.StudyId.ToString());
                ViewBag.StudyId = objNewStudy.StudyId;
                ViewBag.StudyNumber = objNewStudy.StudyNumber;
                ViewBag.TitleofTrial = objNewStudy.TitleofTrial;
                ViewBag.AssignedUsername = objNewStudy.ANJU_AddedBy;
                ViewBag.LogedinUserName = HttpContext.Session.GetString("Username");
                ViewBag.TaskName = objNewStudy.TaskName;
            }
            else
                return RedirectToAction("Login", "Login");

            return View();
        }
        public IActionResult PatientAccrual()
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
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }
        public IActionResult ReviewForAmendment()
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
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }
        #endregion

        #region Methods



        /// <summary>
        /// Get Study Id For Patient Enrollment
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Json</returns>
        public JsonResult GetPatientEnrollmentDetails([DataSourceRequest] DataSourceRequest request, int studyId)
        {
            try
            {
                var result = objPatientAccrualBA.GetPatientEnrollmentDetails(studyId);
                return Json(result.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new PatientAccrual() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }

        /// <summary>
        /// Get Study Id For PI
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Json</returns>
        public JsonResult CreatePatientEnrollmentDetails(Data.PatientAccrual patientAccrual)
        {
            try
            {
                bool result = objPatientAccrualBA.CreatePatientEnrollmentDetails(patientAccrual);
                if (result == true)
                {
                    msgType = Utilities.Messages.SuccessStatus;
                }
                else
                    msgType = Utilities.Messages.ProblemInCreation;

                return Json(new { data = message, msgType });
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new PatientAccrual() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInCreation });
            }
        }

        /// <summary>
        /// Get Study Id For PI
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Json</returns>
        public JsonResult UpdatePatientEnrollmentDates(Data.PatientAccrual patientAccrual, int studyId)
        {
            try
            {
                bool result = objPatientAccrualBA.UpdatePatientEnrollmentDates(patientAccrual, studyId);
                if (result == true)
                {
                    msgType = Utilities.Messages.SuccessStatus;
                }
                else
                    msgType = Utilities.Messages.ProblemInCreation;

                return Json(new { data = message, msgType });
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new PatientAccrual() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInCreation });
            }
        }

        /// <summary>
        /// Update Patient enrollment details
        /// </summary>
        /// <param name="patientAccrual"></param>
        /// <returns>Json</returns>
        public JsonResult UpdatePatientEnrollmentDetails(Data.PatientAccrual patientAccrual, int studyId)
        {
            try
            {
                bool result = objPatientAccrualBA.UpdatePatientEnrollmentDetails(patientAccrual, studyId);
                if (result == true)
                {
                    msgType = Utilities.Messages.SuccessStatus;
                }
                else
                    msgType = Utilities.Messages.ProblemInCreation;

                return Json(new { data = message, msgType });
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new PatientAccrual() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInCreation });
            }
        }

        ///// <summary>
        ///// Update Modify Status details
        ///// </summary>
        ///// <param name="maintainanceAndMonitoring"></param>
        ///// <returns>true/false</returns>
        //public JsonResult UpdateModifyStatusDetails(Data.GMRCApprovalTask maintainanceAndMonitoring)
        //{
        //    try
        //    {
        //        var LogedinUserName = HttpContext.Session.GetString("Username");
        //      bool result = objMaintainanceAndMonitoringBA.UpdateModifyStatusDetails(maintainanceAndMonitoring, LogedinUserName);
        //        if (result == true)
        //        {
        //            msgType = Utilities.Messages.SuccessStatus;
        //        }
        //        else
        //            msgType = Utilities.Messages.ProblemInCreation;

        //        return Json(new { data = message, msgType });
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
        //        return Json(new PatientAccrual() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInCreation });
        //    }
        //}

        /// <summary>
        /// Create Directory
        /// </summary>
        /// <param name="folderPath"></param>
        /// <returns>true/false</returns>
        public static bool CreateDirectory(string folderPath)
        {
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            return true;
        }

        ///// <summary>
        ///// Save Modify status
        ///// </summary>
        ///// <param name="uploadfiles"></param>
        ///// <param name="additional"></param>
        ///// <returns></returns>
        //public async Task<ActionResult> SaveModifyStatusDocuments(IEnumerable<IFormFile> uploadfiles, string[] additional)
        //{

        //    try
        //    {
        //        bool result = true;
        //        if (uploadfiles != null)
        //        {
        //            foreach (var file in uploadfiles)
        //            {
        //                var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
        //                var studyId = int.Parse(HttpContext.Session.GetString("StudyId")); 
        //                var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
        //                var folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, Messages.MODIFYSTATUSSUPPORTDOCUMENTS);
        //                var subModuleName = Utilities.Messages.MODIFYSTATUSSUPPORTDOCUMENTS;
        //                var filePath = Path.Combine(folderPath, fileName);
        //                bool isCreated = CreateDirectory(folderPath);

        //                if (isCreated)
        //                {
        //                    using (var fileStream = new FileStream(filePath, FileMode.Create))
        //                    {
        //                        await file.CopyToAsync(fileStream);
        //                        Data.Documents objDocuments = new Data.Documents()
        //                        {
        //                            DocumentName = additional[0],
        //                            DocumentNameWithOutExtension = Path.GetFileNameWithoutExtension(fileContent.FileName.Trim('"')),
        //                            DocumentSize = Convert.ToInt32(new System.IO.FileInfo(filePath).Length),
        //                            DocumentExtension = Path.GetExtension(filePath).ToLowerInvariant().ToString(),
        //                            SubModuleName = subModuleName,
        //                            StudyId = Convert.ToInt32(studyId),
        //                            Path = filePath,
        //                            DocumentType = additional[2]?.ToString(),
        //                            DocumentStatus = additional[1]?.ToString(),
        //                            DocumentSubType = additional[3]?.ToString(),
        //                            DocumentVersion = additional[4]?.ToString(),
        //                            OriginalDate = additional[5] != null ? Convert.ToDateTime(additional[5]) : (DateTime?)null,
        //                            ExpirationDate = additional[6] != null ? Convert.ToDateTime(additional[6]) : (DateTime?)null,
        //                            IsActive = true,
        //                            IsDeleted = false,
        //                            ANJU_AddedBy = HttpContext.Session.GetString("Username"),
        //                            Anju_AddedDate = DateTime.UtcNow
        //                        };

        //                        result = objNewStudyBA.Fileupload(objDocuments);
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            msgType = Utilities.Messages.FileNotFound;
        //            return Content(msgType);
        //        }

        //        if (result)
        //        {
        //            msgType = Utilities.Messages.SuccessStatus;
        //            return Content("");
        //        }
        //        else
        //            return Content(Utilities.Messages.ErrorStatus);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), Utilities.Messages.ProblemInUpload);
        //    }
        //    return Json(new { msgType = msgType });

        /// <summary>
        /// Get Activationdocument Details
        /// </summary>
        /// <param name="request"></param>
        /// <param name="StudyId"></param>
        /// <returns></returns>
        public JsonResult GetUpdatedDocuments([DataSourceRequest] DataSourceRequest request, int studyId)
        {
            try
            {
                var result = objNewStudyBA.GetDocumentsByStudyID(studyId, Utilities.Messages.UPDATEDDOCUMENTS);
                return Json(result.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
            }
            return Json(new { msgType = msgType });
        }

        
      
        /// <summary>
        /// Save Modify status
        /// </summary>
        /// <param name="uploadfiles"></param>
        /// <param name="additional"></param>
        /// <returns></returns>
        public async Task<ActionResult> SaveUpdatedDocuments(IEnumerable<IFormFile> uploadfilesforUpdatedDocuments)
        {

            try
            {
                bool result = true;
                if (uploadfilesforUpdatedDocuments != null)
                {
                    foreach (var file in uploadfilesforUpdatedDocuments)
                    {
                        var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                        var studyId = int.Parse(HttpContext.Session.GetString("StudyId"));
                        var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
                        var folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, Messages.UPDATEDDOCUMENTS);
                        var subModuleName = Utilities.Messages.UPDATEDDOCUMENTS;
                        var filePath = Path.Combine(folderPath, fileName);
                        bool isCreated = CreateDirectory(folderPath);

                        if (isCreated)
                        {
                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                                Data.Documents objDocuments = new Data.Documents()
                                {
                                    DocumentName = fileName,
                                    DocumentNameWithOutExtension = Path.GetFileNameWithoutExtension(fileContent.FileName.Trim('"')),
                                    DocumentSize = Convert.ToInt32(new System.IO.FileInfo(filePath).Length),
                                    DocumentExtension = Path.GetExtension(filePath).ToLowerInvariant().ToString(),
                                    SubModuleName = subModuleName,
                                    StudyId = Convert.ToInt32(studyId),
                                    Path = filePath,
                                    DocumentType = null,
                                    DocumentStatus = null,
                                    DocumentSubType = null,
                                    DocumentVersion = null,
                                    OriginalDate = null,
                                    ExpirationDate = null,
                                    IsActive = true,
                                    IsDeleted = false,
                                    IsActivated = false,
                                    IsSubmit = false,
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
        /// Save SubmitActivation Documents
        /// </summary>
        /// <param name="uploadfiles"></param>
        /// <param name="additional"></param>
        /// <returns></returns>
        public async Task<ActionResult> SaveSubmitUpdateDocuments(IEnumerable<IFormFile> filesforupload)
        {
            bool result = true;

            try
            {
                if (filesforupload != null)
                {
                    foreach (var file in filesforupload)
                    {
                        var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                        var studyId = int.Parse(HttpContext.Session.GetString("StudyId"));
                        var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
                        var folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, Messages.UPDATEDDOCUMENTS);
                        var subModuleName = Utilities.Messages.UPDATEDDOCUMENTS;
                        var filePath = Path.Combine(folderPath, fileName);
                        bool isCreated = CreateDirectory(folderPath);

                        if (isCreated)
                        {
                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                                Data.Documents objDocuments = new Data.Documents()
                                {
                                    DocumentName = fileName,
                                    DocumentNameWithOutExtension = Path.GetFileNameWithoutExtension(fileContent.FileName.Trim('"')),
                                    DocumentSize = Convert.ToInt32(new System.IO.FileInfo(filePath).Length),
                                    DocumentExtension = Path.GetExtension(filePath).ToLowerInvariant().ToString(),
                                    SubModuleName = subModuleName,
                                    StudyId = Convert.ToInt32(studyId),
                                    Path = filePath,
                                    DocumentType = null,
                                    DocumentStatus = null,
                                    DocumentSubType = null,
                                    DocumentVersion = null,
                                    OriginalDate = null,
                                    ExpirationDate = null,
                                    IsActive = true,
                                    IsDeleted = false,
                                    IsActivated = false,
                                    IsSubmit = true,
                                    ANJU_AddedBy = HttpContext.Session.GetString("Username"),
                                    Anju_AddedDate = DateTime.UtcNow
                                };

                                result = objNewStudyBA.SubmitUpdateddocuments(objDocuments);
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
        /// Save Submit Mandatory Amendment Documents
        /// </summary>
        /// <param name="uploadfiles"></param>
        /// <param name="additional"></param>
        /// <returns></returns>
        public async Task<ActionResult> SaveMandatoryAmendmentDocuments(IEnumerable<IFormFile> addMandatoryFile)
        {
            bool result = true;

            try
            {
                if (addMandatoryFile != null)
                {
                    foreach (var file in addMandatoryFile)
                    {
                        var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                        var studyId = int.Parse(HttpContext.Session.GetString("StudyId"));
                        var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
                        var folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, Messages.AMENDMENTMANDATORYDOCUMENTS);
                        var subModuleName = Utilities.Messages.AMENDMENTMANDATORYDOCUMENTS;
                        var filePath = Path.Combine(folderPath, fileName);
                        bool isCreated = CreateDirectory(folderPath);

                        if (isCreated)
                        {
                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                                Data.Documents objDocuments = new Data.Documents()
                                {
                                    DocumentName = fileName,
                                    DocumentNameWithOutExtension = Path.GetFileNameWithoutExtension(fileContent.FileName.Trim('"')),
                                    DocumentSize = Convert.ToInt32(new System.IO.FileInfo(filePath).Length),
                                    DocumentExtension = Path.GetExtension(filePath).ToLowerInvariant().ToString(),
                                    SubModuleName = subModuleName,
                                    StudyId = Convert.ToInt32(studyId),
                                    Path = filePath,
                                    DocumentType = null,
                                    DocumentStatus = Messages.PENDINGREVIEW,
                                    DocumentSubType = null,
                                    DocumentVersion = null,
                                    OriginalDate = null,
                                    ExpirationDate = null,
                                    IsActive = true,
                                    IsDeleted = false,
                                    IsActivated = false,
                                    IsSubmit = true,
                                    ANJU_AddedBy = HttpContext.Session.GetString("Username"),
                                    Anju_AddedDate = DateTime.UtcNow
                                };

                                result = objNewStudyBA.SubmitAmedmentProtocolDocument(objDocuments);
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
        /// Save Submit Mandatory Amendment Documents
        /// </summary>
        /// <param name="uploadfiles"></param>
        /// <param name="additional"></param>
        /// <returns></returns>
        public async Task<ActionResult> SaveAdditionalAmendmentDocuments(IEnumerable<IFormFile> uploadAdditionalfiles)
        {
            bool result = true;

            try
            {
                if (uploadAdditionalfiles != null)
                {
                    foreach (var file in uploadAdditionalfiles)
                    {
                        var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                        var studyId = int.Parse(HttpContext.Session.GetString("StudyId"));
                        var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
                        var folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, Messages.AMENDMENTMANDATORYDOCUMENTS);
                        var subModuleName = Utilities.Messages.AMENDMENTMANDATORYDOCUMENTS;
                        var filePath = Path.Combine(folderPath, fileName);
                        bool isCreated = CreateDirectory(folderPath);

                        if (isCreated)
                        {
                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                                Data.Documents objDocuments = new Data.Documents()
                                {
                                    DocumentName = fileName,
                                    DocumentNameWithOutExtension = Path.GetFileNameWithoutExtension(fileContent.FileName.Trim('"')),
                                    DocumentSize = Convert.ToInt32(new System.IO.FileInfo(filePath).Length),
                                    DocumentExtension = Path.GetExtension(filePath).ToLowerInvariant().ToString(),
                                    SubModuleName = subModuleName,
                                    StudyId = Convert.ToInt32(studyId),
                                    Path = filePath,
                                    DocumentType = Messages.SUBMISSIONSUPPORT,
                                    DocumentStatus = Messages.PENDINGREVIEW,
                                    DocumentSubType = null,
                                    DocumentVersion = null,
                                    OriginalDate = null,
                                    ExpirationDate = null,
                                    IsActive = true,
                                    IsDeleted = false,
                                    IsActivated = false,
                                    IsSubmit = true,
                                    ANJU_AddedBy = HttpContext.Session.GetString("Username"),
                                    Anju_AddedDate = DateTime.UtcNow
                                };

                                result = objNewStudyBA.SubmitAmedmentProtocolDocument(objDocuments);
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
        ///Save Activated task after document upload
        /// </summary>           
        /// <returns></returns>
        public JsonResult SaveActivatedUpdateDocuments(string studyOwner)
        {
            try
            {
                var studyId = int.Parse(HttpContext.Session.GetString("StudyId"));
                bool result = objNewStudyBA.AddTask(studyId,studyOwner);
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
                return Json(new { msgType = msgType });

            }
        }

        /// <summary>
        ///Create review task for Amendment Protocol/budget
        /// </summary>           
        /// <returns></returns>
        public JsonResult CreateAmendmentTask(string studyOwner)
        {
            try
            {
                var studyId = int.Parse(HttpContext.Session.GetString("StudyId"));
                bool result = objNewStudyBA.AddAmendmentTask(studyId,studyOwner);
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
                return Json(new { msgType = msgType });

            }
        }
        /// <summary>
        ///Save Identification Activation documents
        /// </summary>           
        /// <returns></returns>
        public JsonResult SaveUpdateDocuments(List<Data.Documents> lsDocuments, string studyowner)
        {
            try
            {
                var LogedinUserName = HttpContext.Session.GetString("Username");
                bool result = objNewStudyBA.SaveUpdateDocuments(lsDocuments, LogedinUserName, studyowner);
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
                return Json(new { msgType = msgType });

            }
        }

        /// <summary>
        ///Save Identification Activation documents
        /// </summary>           
        /// <returns></returns>
        public JsonResult SaveAmendmentProtocol(int StudyId, string decision,string studyOwner)
        {
            try
            {
                var LogedinUserName = HttpContext.Session.GetString("Username");
                bool result = objNewStudyBA.SaveAmendmentProtocol(StudyId, LogedinUserName,decision,studyOwner);
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
                return Json(new { msgType = msgType });

            }
        }

        /// <summary>
        /// Remove the uploaded documents files
        /// </summary>
        /// <param name="fileNames"></param>
        /// <returns></returns>
        public ActionResult RemoveUpdatedDocuments(string[] fileNames)
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
                        string SubModuleName = Utilities.Messages.REVIEWUPDATEDDOCUMENTS;

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
        /// Get Review Activation document details
        /// </summary>
        /// <param name="documents"></param>      
        /// <returns></returns>
        public JsonResult GetReviewUpdatedDocuments([DataSourceRequest] DataSourceRequest request)
        {
            int studyId = Convert.ToInt32(HttpContext.Session.GetString("StudyId"));
            try
            {
                var result = objStudyTaskBA.GetReviewUpdatedDocuments(studyId);
                return Json(result.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new { msgType = msgType });
            }
        }

        /// <summary>
        /// Get Review Activation document details
        /// </summary>
        /// <param name="documents"></param>      
        /// <returns></returns>
        public JsonResult GetReviewAmendmentDocuments([DataSourceRequest] DataSourceRequest request)
        {
            int studyId = Convert.ToInt32(HttpContext.Session.GetString("StudyId"));
            try
            {
                var result = objStudyTaskBA.GetReviewAmendmentDocuments(studyId);
                return Json(result.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new { msgType = msgType });
            }
        }



        /// <summary>
        /// Get Activated Updated document details
        /// </summary>
        /// <param name="documents"></param>      
        /// <returns></returns>
        public JsonResult ActivateUpdatedDocuments([DataSourceRequest] DataSourceRequest request, string documentname, string status)
        {
            int studyId = Convert.ToInt32(HttpContext.Session.GetString("StudyId"));
            string userName = HttpContext.Session.GetString("Username");
            try
            {
                var isDocumentUpdated = objStudyTaskBA.ActivateUpdatedDocuments(studyId,documentname,status,userName);
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
        public ActionResult GetActivatedUpdatedocument([DataSourceRequest] DataSourceRequest request)
        {
            int studyId = Convert.ToInt32(HttpContext.Session.GetString("StudyId"));
            try
            {
                var response = objStudyTaskBA.GetActivatedUpdatedocument(studyId);
                return Json(response.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new { msgType = msgType });
            }
        }

        ///// <summary>
        ///// Remove the uploaded files
        ///// </summary>
        ///// <param name="fileNames"></param>
        ///// <returns></returns>
        //public ActionResult RemoveModifyStatusDocuments(string[] fileNames, string[] additional)
        //{
        //    bool result = true;
        //    try
        //    {
        //        if (fileNames != null)
        //        {
        //            foreach (var fullName in fileNames)
        //            {
        //                var fileName = Path.GetFileName(fullName);
        //                int studyId = int.Parse(HttpContext.Session.GetString("StudyId"));
        //                var username = HttpContext.Session.GetString("Username");
        //                string SubModuleName = Utilities.Messages.MODIFYSTATUSSUPPORTDOCUMENTS;

        //                var folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, SubModuleName);
        //                var filePath = Path.Combine(folderPath, fileName);

        //                if (System.IO.File.Exists(filePath))
        //                {
        //                    System.IO.File.Delete(filePath);
        //                    result = objNewStudyBA.DeleteUploadedFile(studyId, username, SubModuleName, fileName);
        //                }
        //            }
        //        }
        //        msgType = Utilities.Messages.SuccessStatus;
        //        return Content("");
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), Utilities.Messages.ProblemInRemoval);
        //    }
        //    return Json(new { msgType = msgType });
        //}


        /// <summary>
        /// Update Final Reconciliation
        /// </summary>
        /// <param name="objGMRCApprovalTask"></param>      
        /// <returns></returns>
        public JsonResult UpdateFinalReconciliation(Data.GMRCApprovalTask objGMRCApprovalTask)
        {
            try
            {
                bool result = objMaintainanceAndMonitoringBA.UpdateFinalReconciliation(objGMRCApprovalTask);
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
                return Json(new PatientAccrual() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInCreation });
            }
        }
        /// <summary>
        /// Get Study Id For Patient Enrollment
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Json</returns>
        public JsonResult GetActivationDate([DataSourceRequest] DataSourceRequest request, int studyId)
        {
            try
            {
                var result = objPatientAccrualBA.GetActivationDate(studyId);
                return Json(result.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new PatientAccrual() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }

        #endregion
    }
}