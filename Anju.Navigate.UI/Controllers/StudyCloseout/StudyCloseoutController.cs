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
    public class StudyCloseoutController : Controller
    {
        #region Variable Declarations
        private readonly IAppLogger<StudyCloseoutController> _logger = null;
        StudyCloseoutBA objStudyCloseoutBA = new StudyCloseoutBA();
        NewStudyBA objNewStudyBA = new NewStudyBA();
        string msgType = string.Empty;
        string message = string.Empty;
        #endregion

        #region Constructor
        public StudyCloseoutController(IAppLogger<StudyCloseoutController> logger)
        {
            this._logger = logger;

        }
        #endregion

        #region Views
        public IActionResult StudyCloseout()
        {
            var objNewStudy = JsonConvert.DeserializeObject<Data.NewStudy>(TempData["OpenData"]?.ToString());
            TempData.Keep("OpenData");
            var documents = new List<Data.Documents>();
            var model = new ListOfDocuments();
            if (objNewStudy != null)
            {
                HttpContext.Session.SetString("StudyId", objNewStudy.StudyId.ToString());
                if (objNewStudy.StudyId > 0)
                {
                    if (objNewStudy.TaskName == Utilities.Messages.FINALSTUDYTASK || objNewStudy.TaskName == Utilities.Messages.RESUBMITFINALSTUDYREPORT)
                    {
                        documents = objNewStudyBA.GetDocumentsByStudyID(objNewStudy.StudyId, Utilities.Messages.FINALSTUDYREPORT);
                        foreach (var item in documents)
                        {
                            model.Documents.Add(
                            new Documents { DocumentName = item.DocumentName, DocumentNameWithOutExtension = item.DocumentNameWithOutExtension,DocumentExtension = item.DocumentExtension, DocumentSize = item.DocumentSize });

                        }
                    }
                }
                ViewBag.StudyId = objNewStudy.StudyId;
                ViewBag.AssignedUsername = objNewStudy.ANJU_AddedBy;
                ViewBag.LogedinUserName = HttpContext.Session.GetString("Username");
                ViewBag.GMRCTaskName = objNewStudy.GMRCTaskName;
                ViewBag.StudyNumber = objNewStudy.StudyNumber;
                ViewBag.TitleofTrial = objNewStudy.TitleofTrial;
                ViewBag.Institution = objNewStudy.Institution;                
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
            return View(model);
        }

        public IActionResult CloseStudy()
        {
            return View();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Update Initiate Study Closeout
        /// </summary>
        /// <param name="objGMRCApprovalTask"></param>      
        /// <returns></returns>
        public JsonResult UpdateInitiateCloseout(Data.GMRCApprovalTask objGMRCApprovalTask)
        {
            try
            {
                bool result = objStudyCloseoutBA.UpdateInitiateCloseout(objGMRCApprovalTask);
                if (result == true)
                    msgType = Utilities.Messages.SuccessStatus;
                else
                {
                    msgType = Utilities.Messages.ProblemInCreation;
                }
                return Json(new
                {
                    data = message,
                    msgType
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new GMRCApprovalTask() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInCreation });
            }
        }

        /// <summary>
        /// Get Gear Tasks by studyId
        /// </summary>
        /// <param name="request"></param>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public JsonResult GetGearTasks([DataSourceRequest] DataSourceRequest request, int studyId)
        {
            try
            {
                var result = objStudyCloseoutBA.GetGearTasks(studyId);
                return Json(result.ToDataSourceResult(request).Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new GMRCApprovalTask() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }


        /// <summary>
        /// Upload Final Study Document
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public async Task<ActionResult> SaveAsyncFinalStudyDocument(IEnumerable<IFormFile> fileFinalStudyData)
        {
            try
            {
                bool result = true;
                if (fileFinalStudyData != null)
                {
                    foreach (var file in fileFinalStudyData)
                    {
                        var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                        var studyId = HttpContext.Session.GetString("StudyId");
                        var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
                        var folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, Utilities.Messages.FINALSTUDYREPORT);
                        var filePath = Path.Combine(folderPath, fileName);
                        bool isCreated = CreateDirectory(folderPath);
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
                                    SubModuleName = Utilities.Messages.FINALSTUDYREPORT,
                                    StudyId = Convert.ToInt32(studyId),
                                    Path = filePath,
                                    DocumentType = EnumExtension.DisplayName(Utilities.DocumentTypeEnum.DocumentMilestone),
                                    DocumentStatus = EnumExtension.DisplayName(Utilities.DocumentStatusEnum.PendingReview),
                                    DocumentSubType = null,
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
        /// Remove the Final Study Document
        /// </summary>
        /// <param name="fileNames"></param>
        /// <returns></returns>
        public ActionResult RemoveFinalStudyDocument(string[] fileNames)
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
                        var folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, Utilities.Messages.FINALSTUDYREPORT);
                        var filePath = Path.Combine(folderPath, fileName);

                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                        result = objNewStudyBA.DeleteUploadedFile(studyId, username, Utilities.Messages.FINALSTUDYREPORT, fileName);
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
        /// Upload Study closure Document
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public async Task<ActionResult> SavecloseStudyDocuments(IEnumerable<IFormFile> uploadCloseStudyFiles, string[] additional)
        {
            try
            {
                bool result = true;
                if (uploadCloseStudyFiles != null)
                {
                    foreach (var file in uploadCloseStudyFiles)
                    {
                        var folderPath = "";
                        string SubModuleName = string.Empty;
                        var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                        var studyId = HttpContext.Session.GetString("StudyId");
                        var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
                        folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, Utilities.Messages.CLOSESTUDYDOCUMENT);
                        SubModuleName = Utilities.Messages.CLOSESTUDYDOCUMENT;
                   
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
        /// Remove Study closure Document
        /// </summary>
        /// <param name="fileNames"></param>
        /// <returns></returns>
        public ActionResult RemovecloseStudyDocuments(string[] fileNames, string[] additional)
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
                            SubModuleName = Utilities.Messages.CLOSESTUDYDOCUMENT;

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

        #endregion
    }
}