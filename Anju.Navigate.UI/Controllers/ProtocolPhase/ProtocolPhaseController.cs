using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Anju.Navigate.BusinessAccess;
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
    public class ProtocolPhaseController : Controller
    {
        #region Variable Declarations
        private readonly IAppLogger<ProtocolPhaseController> _logger = null;
        NewStudyBA objNewStudyBA = new NewStudyBA();
        ProtocolPhaseBA objProtocolPhaseBA = new ProtocolPhaseBA();

        string message = string.Empty;
        string msgType = string.Empty;
        #endregion

        #region Constructor
        public ProtocolPhaseController(IAppLogger<ProtocolPhaseController> logger)
        {
            this._logger = logger;
        }
        #endregion

        #region Views
        public IActionResult ProtocolPhase()
        {
            var objNewStudy = JsonConvert.DeserializeObject<Data.NewStudy>(TempData["OpenData"]?.ToString());
            TempData.Keep("OpenData");
            var model = new ListOfDocuments();
            var documents = new List<Data.Documents>();
            if (objNewStudy != null)
            {
                HttpContext.Session.SetString("StudyId", objNewStudy.StudyId.ToString());
                ViewBag.StudyId = objNewStudy.StudyId;
                ViewBag.AssignedUsername = objNewStudy.ANJU_AddedBy;
                ViewBag.LogedinUserName = HttpContext.Session.GetString("Username");
                ViewBag.TaskName = objNewStudy.TaskName;      
                ViewBag.StudyNumber = objNewStudy.StudyNumber;                      
                ViewBag.TitleofTrial = objNewStudy.TitleofTrial;
                ViewBag.Institution = objNewStudy.Institution;
                if (objNewStudy.TaskName == Messages.SUBMITREQUIREDICFDOCUMENT || objNewStudy.TaskName == Messages.ICFRESUBMISSIONREQUIRED)
                {
                    if (objNewStudy.StudyId > 0)
                    {
                        documents = objNewStudyBA.GetDocumentsByStudyID(objNewStudy.StudyId, Utilities.Messages.ICFDocument);
                        foreach (var item in documents)
                        {
                            model.Documents.Add(
                            new Documents { DocumentName = item.DocumentName, DocumentExtension = item.DocumentExtension, DocumentSize = item.DocumentSize });

                        }
                    }
                }
               
            }
            else
                return RedirectToAction("Login", "Login");

            return View(model);
        }
        public IActionResult ManageContractStatus()
        {
            var objNewStudy = JsonConvert.DeserializeObject<Data.NewStudy>(TempData["OpenData"]?.ToString());
            TempData.Keep("OpenData");
            if (objNewStudy != null)
            {
                HttpContext.Session.SetString("StudyId", objNewStudy.StudyId.ToString());
                ViewBag.StudyId = objNewStudy.StudyId;
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
        public IActionResult IdentifyActivationDocuments()
        {
            var objNewStudy = JsonConvert.DeserializeObject<Data.NewStudy>(TempData["OpenData"]?.ToString());
            
            TempData.Keep("OpenData");
            if (objNewStudy != null)
            {
                HttpContext.Session.SetString("StudyId", objNewStudy.StudyId.ToString());
                string studywner = objNewStudyBA.GetStudyOwnerDetails(objNewStudy.StudyId);
                ViewBag.StudyId = objNewStudy.StudyId;
                ViewBag.AssignedUsername = objNewStudy.ANJU_AddedBy;
                ViewBag.LogedinUserName = HttpContext.Session.GetString("Username");
                ViewBag.TaskName = objNewStudy.TaskName;
                ViewBag.StudyOwner = studywner;
                ViewBag.StudyNumber = objNewStudy.StudyNumber;
                ViewBag.TitleofTrial = objNewStudy.TitleofTrial;
                ViewBag.Institution = objNewStudy.Institution;
            }
            else
                return RedirectToAction("Login", "Login");

            return View();
        }
        public IActionResult ReviewICF()
        {
            var objNewStudy = JsonConvert.DeserializeObject<Data.NewStudy>(TempData["OpenData"]?.ToString());
            TempData.Keep("OpenData");
            if (objNewStudy != null)
            {
                HttpContext.Session.SetString("StudyId", objNewStudy.StudyId.ToString());
                ViewBag.StudyId = objNewStudy.StudyId;
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
        public IActionResult ReviewActivationDocument()
        {
            var objNewStudy = JsonConvert.DeserializeObject<Data.NewStudy>(TempData["OpenData"]?.ToString());
            TempData.Keep("OpenData");
            if (objNewStudy != null)
            {
                HttpContext.Session.SetString("StudyId", objNewStudy.StudyId.ToString());
                ViewBag.StudyId = objNewStudy.StudyId;
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
        public IActionResult ReviewProtocol()
        {
            var objNewStudy = JsonConvert.DeserializeObject<Data.NewStudy>(TempData["OpenData"]?.ToString());
            TempData.Keep("OpenData");
            if (objNewStudy != null)
            {
                HttpContext.Session.SetString("StudyId", objNewStudy.StudyId.ToString());
                ViewBag.StudyId = objNewStudy.StudyId;
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
        public IActionResult CreateDeliverActivationLetter()
        {
            var objNewStudy = JsonConvert.DeserializeObject<Data.NewStudy>(TempData["OpenData"]?.ToString());
            TempData.Keep("OpenData");
            if (objNewStudy != null)
            {
                HttpContext.Session.SetString("StudyId", objNewStudy.StudyId.ToString());
                ViewBag.StudyId = objNewStudy.StudyId;
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

        #endregion

        #region Methods

        /// <summary>
        /// Save FMV Documents
        /// </summary>
        /// <param name="FMVUploadFile"></param>
        /// <param name="additional"></param>
        /// <returns></returns>
        public async Task<ActionResult> SaveFMVDocuments(IEnumerable<IFormFile> FMVUploadFile, string[] additional)
        {
            bool result = true;
            try
            {
                if (FMVUploadFile != null)
                {
                    foreach (var file in FMVUploadFile)
                    {
                        var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                        var studyId = HttpContext.Session.GetString("StudyId");
                        var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
                        var folderPath = "";
                        var subModuleName = "";
                        if(additional[7] == Messages.FAIRMARKETDOCUMENT)
                        { 
                         folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, Messages.FMVDOCUMENT);
                         subModuleName = Messages.FMVDOCUMENT;
                        }
                        else
                        {
                            folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, Messages.STUDYCHECKLIST);
                            subModuleName = Messages.STUDYCHECKLIST;
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
        /// Remove the FMV files
        /// </summary>
        /// <param name="fileNames"></param>
        /// <returns></returns>
        public ActionResult RemoveFMVDocuments(string[] FMVUploadFile, string[] additional)
        {
            bool result = true;
            try
            {
                if (FMVUploadFile != null)
                {
                    foreach (var fullName in FMVUploadFile)
                    {
                        var fileName = Path.GetFileName(fullName);
                        int studyId = int.Parse(HttpContext.Session.GetString("StudyId"));
                        var username = HttpContext.Session.GetString("Username");
                        var folderPath = "";
                        var submoduleName = "";
                        if (additional[7] == Messages.FAIRMARKETDOCUMENT)
                        {
                             folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, Messages.FMVDOCUMENT);
                             submoduleName = Messages.FMVDOCUMENT;
                        }
                        else
                        {
                            folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, Messages.STUDYCHECKLIST);
                            submoduleName = Messages.STUDYCHECKLIST;
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
        /// Update GMRCApproval task details
        /// </summary>
        /// <param name="documents"></param>      
        /// <returns></returns>
        public JsonResult UpdateGMRCApprovalTaskDetails(Data.GMRCApprovalTask objGMRCApprovalTask)
        {
            try
            {
                bool result = objProtocolPhaseBA.UpdateGMRCApprovalTaskDetails(objGMRCApprovalTask);
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
                return Json(new GMRCApprovalTask() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInCreation });

            }
        }
        /// <summary>
        /// Update GMRCApproval gear task details
        /// </summary>
        /// <param name="documents"></param>      
        /// <returns></returns>
        public JsonResult UpdateGMRCApprovalGearTaskDetails(Data.GMRCApprovalTask objGMRCApprovalTask)
        {
            try
            {
                bool result = objProtocolPhaseBA.UpdateGMRCApprovalGearTaskDetails(objGMRCApprovalTask);
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
                return Json(new GMRCApprovalTask() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInCreation });

            }
        }


        /// <summary>
        /// Save Contract Documents
        /// </summary>
        /// <param name="contractUploadfile"></param>
        /// <param name="additional"></param>
        /// <returns></returns>
        public async Task<ActionResult> SavecontractDocument(IEnumerable<IFormFile> contractUploadfile, string[] additional)
        {
            bool result = true;
            try
            {
                if (contractUploadfile != null)
                {
                    foreach (var file in contractUploadfile)
                    {
                        var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                        var studyId = HttpContext.Session.GetString("StudyId");
                        var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
                        var folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, Messages.EXECUTEDCONTRACTDOCUMENT);
                        var subModuleName = Messages.EXECUTEDCONTRACTDOCUMENT;

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
        /// Remove the Contract files
        /// </summary>
        /// <param name="contractUploadfile"></param>
        /// <returns></returns>
        public ActionResult RemovecontractDocument(string[] contractUploadfile, string[] additional)
        {
            bool result = true;
            try
            {
                if (contractUploadfile != null)
                {
                    foreach (var fullName in contractUploadfile)
                    {
                        var fileName = Path.GetFileName(fullName);
                        int studyId = int.Parse(HttpContext.Session.GetString("StudyId"));
                        var username = HttpContext.Session.GetString("Username");
                        var folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, Messages.EXECUTEDCONTRACTDOCUMENT);
                        string submoduleName = Messages.EXECUTEDCONTRACTDOCUMENT;
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
        /// Upload ICFDocuments
        /// </summary>
        /// <param name="fileICFDoc"></param>
        /// <returns></returns>
        public async Task<ActionResult> SaveICFDocuments(IEnumerable<IFormFile> fileICFDoc)
        {
            try
            {
                bool result = true;
                if (fileICFDoc != null)
                {
                    foreach (var file in fileICFDoc)
                    {
                        var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                        var studyId = HttpContext.Session.GetString("StudyId");
                        var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
                        var folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, Messages.ICFDocument);

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
                                    SubModuleName = Utilities.Messages.ICFDocument,
                                    StudyId = Convert.ToInt32(studyId),
                                    Path = filePath,
                                    DocumentType = EnumExtension.DisplayName(Utilities.DocumentTypeEnum.Regulatory),
                                    DocumentStatus = EnumExtension.DisplayName(Utilities.DocumentStatusEnum.PendingReview),
                                    DocumentSubType = EnumExtension.DisplayName(Utilities.DocumentSubTypeEnum.ICF),
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
        /// Remove the ICF uploaded files
        /// </summary>
        /// <param name="fileNames"></param>
        /// <returns></returns>
        public ActionResult RemoveICFDocuments(string[] fileNames)
        {
            try
            {
                bool result = true;

                if (fileNames != null)
                {
                    foreach (var fullName in fileNames)
                    {
                        var fileName = Path.GetFileName(fullName);
                        int studyId = int.Parse(HttpContext.Session.GetString("StudyId"));
                        var username = HttpContext.Session.GetString("Username");
                        var folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, Messages.ICFDocument);
                        var filePath = Path.Combine(folderPath, fileName);

                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                        result = objNewStudyBA.DeleteUploadedFile(studyId, username, Utilities.Messages.ICFDocument, fileName);
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
        /// Save RedLine  Document
        /// </summary>
        /// <param name="icfUploadFiles"></param>
        /// <param name="additionals"></param>
        /// <returns></returns>
        public async Task<ActionResult> SaveRedLineDocuments(IEnumerable<IFormFile> icfUploadFiles, string[] additional)
        {
            bool result = true;
            try
            {
                if (icfUploadFiles != null)
                {
                    foreach (var file in icfUploadFiles)
                    {
                        var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                        var studyId = HttpContext.Session.GetString("StudyId");
                        var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
                        var folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, Messages.REDLINEDICFDOCUMENT);
                        var subModuleName = Messages.REDLINEDICFDOCUMENT;

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
        /// Remove the RedLine files
        /// </summary>
        /// <param name="fileNames"></param>
        /// <returns></returns>
        public ActionResult RemoveRedLineDocuments(string[] icfUploadFiles, string[] additional)
        {
            bool result = true;
            try
            {
                if (icfUploadFiles != null)
                {
                    foreach (var fullName in icfUploadFiles)
                    {
                        var fileName = Path.GetFileName(fullName);
                        int studyId = int.Parse(HttpContext.Session.GetString("StudyId"));
                        var username = HttpContext.Session.GetString("Username");
                        var folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, Messages.REDLINEDICFDOCUMENT);
                        string submoduleName = Messages.REDLINEDICFDOCUMENT;
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
        /// ReUpload ICFDocuments
        /// </summary>
        /// <param name="fileReUploadICFDoc"></param>
        /// <returns></returns>
        public async Task<ActionResult> SaveReuploadICFDocuments(IEnumerable<IFormFile> fileReUploadICFDoc)
        {
            try
            {
                bool result = true;
                if (fileReUploadICFDoc != null)
                {
                    foreach (var file in fileReUploadICFDoc)
                    {
                        var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                        var studyId = HttpContext.Session.GetString("StudyId");
                        var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
                        var folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, Utilities.Messages.ICFDocument);

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
                                    SubModuleName = Utilities.Messages.ICFDocument,
                                    StudyId = Convert.ToInt32(studyId),
                                    Path = filePath,
                                    DocumentType = EnumExtension.DisplayName(Utilities.DocumentTypeEnum.Regulatory),
                                    DocumentStatus = EnumExtension.DisplayName(Utilities.DocumentStatusEnum.PendingReview),
                                    DocumentSubType = EnumExtension.DisplayName(Utilities.DocumentSubTypeEnum.ICF),
                                    IsActive = false,
                                    IsDeleted = true,
                                    IsSubmit = true,
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
        /// Remove the ICF Reuploaded files
        /// </summary>
        /// <param name="fileNames"></param>
        /// <returns></returns>
        public ActionResult RemoveReuploadICFDocuments(string[] fileNames)
        {
            try
            {
                bool result = true;

                if (fileNames != null)
                {
                    foreach (var fullName in fileNames)
                    {
                        var fileName = Path.GetFileName(fullName);
                        int studyId = int.Parse(HttpContext.Session.GetString("StudyId"));
                        var username = HttpContext.Session.GetString("Username");
                        var folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, Messages.ICFDocument);
                        var filePath = Path.Combine(folderPath, fileName);

                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                        result = objNewStudyBA.DeleteUploadedFile(studyId, username, Utilities.Messages.ICFDocument, fileName);
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
        /// Update GMRCApproval task and Document details
        /// </summary>
        /// <param name="objGMRCApprovalTask"></param>      
        /// <param name="objDocument"></param>      
        /// <returns></returns>
        public JsonResult UpdateGMRCApprovalTaskAndDocumentDetails(Data.GMRCApprovalTask objGMRCApprovalTask,Data.Documents objDocument)
        {
            try
            {
                bool result = objProtocolPhaseBA.UpdateGMRCApprovalTaskAndDocumentDetails(objGMRCApprovalTask, objDocument);
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
                return Json(new GMRCApprovalTask() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInCreation });

            }
        }

        public JsonResult GetReviewDecision()
        {
            
            try
            {
                var result = objProtocolPhaseBA.GetReviewDecision();
                return Json(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new SysCodeValues() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }

        /// <summary>
        /// Save RedLined Protocol  Documents
        /// </summary>
        /// <param name="Macuploadfile"></param>
        /// <param name="additionals"></param>
        /// <returns></returns>
        public async Task<ActionResult> SaveRedLinedProtocolDocuments(IEnumerable<IFormFile> uploadfiles, string[] additional)
        {
            bool result = true;
            try
            {
                if (uploadfiles != null)
                {
                    foreach (var file in uploadfiles)
                    {
                        var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                        var studyId = HttpContext.Session.GetString("StudyId");
                        var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
                        var folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, Messages.REDLINEDREVIEWPROTOCOLDOCUMENT);
                        var subModuleName = Messages.REDLINEDREVIEWPROTOCOLDOCUMENT;

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
        /// Remove the RedLined Protocol
        /// </summary>
        /// <param name="fileNames"></param>
        /// <returns></returns>
        public ActionResult RemoveRedLinedProtocolDocuments(string[] uploadfiles, string[] additional)
        {
            bool result = true;
            try
            {
                if (uploadfiles != null)
                {
                    foreach (var fullName in uploadfiles)
                    {
                        var fileName = Path.GetFileName(fullName);
                        int studyId = int.Parse(HttpContext.Session.GetString("StudyId"));
                        var username = HttpContext.Session.GetString("Username");
                        var folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, Messages.REDLINEDREVIEWPROTOCOLDOCUMENT);
                        string submoduleName = Messages.REDLINEDREVIEWPROTOCOLDOCUMENT;
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
        /// Save Activation Supported Documents
        /// </summary>
        /// <param name="uploadfiles"></param>
        /// <param name="additional"></param>
        /// <returns></returns>
        public async Task<ActionResult> SaveActivationSupportDocuments(IEnumerable<IFormFile> uploadfiles, string[] additional)
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

                        if (additional[8]?.ToString() == Messages.ACTIVATIONLETTER)
                        {
                            subModuleName = Messages.STUDYACTIVATIONADDITIONALDOCUMENTS;
                            folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, Messages.STUDYACTIVATIONADDITIONALDOCUMENTS);
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
        /// Remove the Activation support uploaded files
        /// </summary>
        /// <param name="fileNames"></param>
        /// <returns></returns>
        public ActionResult RemoveActivationSupportDocuments(string[] fileNames, string[] additional)
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
                        if (additional[8]?.ToString() == Messages.ACTIVATIONLETTER)
                        {
                            submoduleName = Messages.STUDYACTIVATIONADDITIONALDOCUMENTS;
                            folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, Messages.STUDYACTIVATIONADDITIONALDOCUMENTS);
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
        /// Save Activation Document
        /// </summary>
        /// <param name="uploadFilesFinal"></param>
        /// <param name="additional"></param>
        /// <returns></returns>
        public async Task<ActionResult> SaveStudyActivationDocument(IEnumerable<IFormFile> uploadFilesFinal, string[] additional)
        {
            try
            {
                bool result = true;
                if (uploadFilesFinal != null)
                {
                    foreach (var file in uploadFilesFinal)
                    {
                        var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                        var studyId = HttpContext.Session.GetString("StudyId");
                        var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
                        var folderPath = string.Empty;
                        var subModuleName = string.Empty;

                        if (!string.IsNullOrEmpty(additional[8]?.ToString()))
                        {
                            subModuleName = Messages.STUDYACTIVATIONDOCUMENT;
                            folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, Messages.STUDYACTIVATIONDOCUMENT);
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
        /// Remove the Activation uploaded files
        /// </summary>
        /// <param name="fileNames"></param>
        /// <returns></returns>
        public ActionResult RemoveStudyActivationDocument(string[] fileNames, string[] additional)
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
                        if (!string.IsNullOrEmpty(additional[8]?.ToString()))
                        {
                            submoduleName = Messages.STUDYACTIVATIONDOCUMENT;
                            folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, Messages.STUDYACTIVATIONDOCUMENT);
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


        #endregion

    }
}