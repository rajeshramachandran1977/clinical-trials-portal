using Anju.Navigate.BusinessAccess;
using Anju.Navigate.BusinessAccess.Workflow;
using Anju.Navigate.Data;
using Anju.Navigate.Utilities;
using Anju.Navigate.Utilities.Logger;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Anju.Navigate.UI.Controllers
{
    public class NewStudyController : Controller
    {
        #region Variable Declarations

        private readonly IAppLogger<NewStudyController> _logger = null;
        private readonly IFileProvider fileProvider;

        NewStudyBA objNewStudy = new NewStudyBA();
        NewStudy objSessionNewStudy = new NewStudy();
        UsersBA usersBA = new UsersBA();
        CommonBA cmnBA = new CommonBA();
        
        string message = string.Empty;
        string msgType = string.Empty;
        int studyId;        
        string mode = string.Empty;
        string studyType = string.Empty;
        string pITaskStatus = string.Empty;
        string TaskName = string.Empty;
        string userName;
        string usertype = string.Empty;
        #endregion

        #region Constructor

        public NewStudyController(IAppLogger<NewStudyController> logger, IFileProvider fileProvider)
        {
            this._logger = logger;
            this.fileProvider = fileProvider;

        }


        #endregion

        #region Views

        /// <summary>
        /// Scientific Rationale I
        /// </summary>
        /// <returns>View</returns>
        public IActionResult ScientificRationaleI()
        {
            var objNewStudy = JsonConvert.DeserializeObject<Data.NewStudy>(TempData["OpenData"]?.ToString());
            TempData.Keep("OpenData");

            if (objNewStudy != null)
            {
                studyId = objNewStudy.StudyId;
                mode = objNewStudy.mode;
                studyType = objNewStudy.StudyType;
                pITaskStatus = objNewStudy.PITaskStatus;
                TaskName = objNewStudy.TaskName;

                if (studyId == 0)
                    GetNewStudyID("Create");
                else
                {
                    HttpContext.Session.SetString("StudyId", studyId.ToString());
                    ViewBag.StudyId = studyId;
                }
                if (mode != null)
                {
                    HttpContext.Session.SetString("Mode", mode);
                    ViewBag.mode = mode;
                }
                ViewBag.StudyType = studyType?.Trim();
                ViewBag.pITaskStatus = pITaskStatus?.Trim();
                ViewBag.Username = HttpContext.Session.GetString("Username");
                ViewBag.TaskName = TaskName?.Trim();



                PopulateObjectiveNames();
                PopulateObjectiveTypes();
                PopulateTypeofTrialDrugs();
                PopulateYesNo();
               
            }
            else
                return RedirectToAction("Login", "Login");

            return View();
        }



        /// <summary>
        /// ScientificRationale II
        /// </summary>
        /// <returns>View</returns>
        public IActionResult ScientificRationaleII()
        {
            userName = HttpContext.Session.GetString("Username");
            var objNewStudy = JsonConvert.DeserializeObject<Data.NewStudy>(TempData["OpenData"]?.ToString());
            TempData.Keep("OpenData");
            if (objNewStudy != null)
            {
                studyId = objNewStudy.StudyId;
                mode = objNewStudy.mode;
                studyType = objNewStudy.StudyType;
                pITaskStatus = objNewStudy.PITaskStatus;
                TaskName = objNewStudy.TaskName;

                if (mode != null)
                {
                    HttpContext.Session.SetString("Mode", mode);

                }
                ViewBag.StudyId = studyId;
                ViewBag.mode = mode;
                ViewBag.StudyType = studyType;
                ViewBag.pITaskStatus = pITaskStatus?.Trim();
                ViewBag.Username = HttpContext.Session.GetString("Username");
                ViewBag.TaskName = TaskName?.Trim();
            }
            else
                return RedirectToAction("Login", "Login");

            return View();
        }


        /// <summary>
        /// Personal and Research Sites
        /// </summary>
        /// <returns>View</returns>
        public IActionResult PersonalandResearchSites()
        {
            ViewBag.Username = HttpContext.Session.GetString("Username");
            var objNewStudyDetails = JsonConvert.DeserializeObject<Data.NewStudy>(TempData["OpenData"]?.ToString());
            TempData.Keep("OpenData");
            var documents = new List<Data.Documents>();
            var model = new ListOfDocuments();
            if (objNewStudyDetails != null)
            {
                studyId = objNewStudyDetails.StudyId;
                mode = objNewStudyDetails.mode;
                studyType = objNewStudyDetails.StudyType;
                pITaskStatus = objNewStudyDetails.PITaskStatus;
                TaskName = objNewStudyDetails.TaskName;
                HttpContext.Session.SetString("StudyId", studyId.ToString());
                if (studyId > 0)
                {
                    documents = objNewStudy.GetDocumentsByStudyID(studyId, Utilities.Messages.PersonalandResearchSites);
                    foreach (var item in documents)
                    {
                        model.LatestCV.Add(
                        new Documents { DocumentName = item.DocumentName, DocumentExtension = item.DocumentExtension, DocumentSize = item.DocumentSize });

                    }
                }
                ViewBag.StudyId = studyId;
                ViewBag.mode = mode;
                ViewBag.StudyType = studyType;
                ViewBag.pITaskStatus = pITaskStatus?.Trim();
                ViewBag.TaskName = TaskName?.Trim();
            }
            else
                return RedirectToAction("Login", "Login");

            return View(model);
        }



        /// <summary>
        /// Requested Support
        /// </summary>
        /// <returns>View</returns>
        public IActionResult RequestedSupport()
        {
            ViewBag.Username = HttpContext.Session.GetString("Username");
            var objNewStudyDetails = JsonConvert.DeserializeObject<Data.NewStudy>(TempData["OpenData"]?.ToString());
            TempData.Keep("OpenData");

            var documents = new List<Data.Documents>();
            var model = new ListOfDocuments();

            if (objNewStudyDetails != null)
            {
                ViewBag.StudyId = objNewStudyDetails.StudyId;
                ViewBag.mode = objNewStudyDetails.mode;
                ViewBag.StudyType = objNewStudyDetails.StudyType;
                ViewBag.pITaskStatus = objNewStudyDetails.PITaskStatus?.Trim();
                ViewBag.TaskName = objNewStudyDetails.TaskName?.Trim();

                if (objNewStudyDetails.StudyId > 0)
                {
                    documents = objNewStudy.GetDocumentsByStudyID(objNewStudyDetails.StudyId, Utilities.Messages.RequestedSupport);
                    foreach (var item in documents)
                    {
                        model.TrialBudgetDocuments.Add(
                        new Documents { DocumentName = item.DocumentName, DocumentExtension = item.DocumentExtension, DocumentSize = item.DocumentSize, });

                    }
                    documents = objNewStudy.GetDocumentsByStudyID(objNewStudyDetails.StudyId, Utilities.Messages.RequestedSupportAdditionalDocuments);
                    foreach (var item in documents)
                    {
                        model.AdditionalDocuments.Add(
                        new Documents { DocumentName = item.DocumentName, DocumentExtension = item.DocumentExtension, DocumentSize = item.DocumentSize });

                    }
                    if (objNewStudyDetails.PITaskStatus?.ToUpper() == ConstDefaultValue.SUBMITPROTOCOL?.ToUpper() || objNewStudyDetails.TaskName?.ToUpper() == ConstDefaultValue.RESUBMITPROTOCOL?.ToUpper())
                    {
                        documents = objNewStudy.GetDocumentsByStudyID(objNewStudyDetails.StudyId, Utilities.Messages.RequestedSupportProtocolDocuments);
                        foreach (var item in documents)
                        {
                            model.ProtocolDocuments.Add(
                            new Documents { DocumentName = item.DocumentName, DocumentExtension = item.DocumentExtension, DocumentSize = item.DocumentSize });

                        }
                    }
                }
            }
            else
                return RedirectToAction("Login", "Login");

            return View(model);
        }



        /// <summary>
        /// Confirmation
        /// </summary>
        /// <returns>View</returns>
        public IActionResult Confirmation()
        {
            ViewBag.Username = HttpContext.Session.GetString("Username");
            var objNewStudyDetails = JsonConvert.DeserializeObject<Data.NewStudy>(TempData["OpenData"]?.ToString());
            TempData.Keep("OpenData");
            var documents = new List<Data.Documents>();
            var model = new ListOfDocuments();
            if (objNewStudyDetails != null)
            {
                ViewBag.StudyId = objNewStudyDetails.StudyId;
                ViewBag.mode = objNewStudyDetails.mode;
                ViewBag.studyType = objNewStudyDetails.StudyType;
                ViewBag.pITaskStatus = objNewStudyDetails.PITaskStatus?.Trim();
                ViewBag.TaskName = objNewStudyDetails.TaskName?.Trim();
                if (objNewStudyDetails.StudyId > 0)
                {
                    documents = objNewStudy.GetDocumentsByStudyID(objNewStudyDetails.StudyId, Utilities.Messages.PersonalandResearchSites);
                    foreach (var item in documents)
                    {
                        model.LatestCV.Add(
                        new Documents { DocumentName = item.DocumentName, DocumentExtension = item.DocumentExtension, DocumentSize = item.DocumentSize, SubModuleName = item.SubModuleName });

                    }
                    documents = objNewStudy.GetDocumentsByStudyID(objNewStudyDetails.StudyId, Utilities.Messages.RequestedSupport);
                    foreach (var item in documents)
                    {
                        model.TrialBudgetDocuments.Add(
                        new Documents { DocumentName = item.DocumentName, DocumentExtension = item.DocumentExtension, DocumentSize = item.DocumentSize, SubModuleName = item.SubModuleName });

                    }
                    documents = objNewStudy.GetDocumentsByStudyID(objNewStudyDetails.StudyId, Utilities.Messages.RequestedSupportProtocolDocuments);
                    foreach (var item in documents)
                    {
                        model.ProtocolDocuments.Add(
                        new Documents { DocumentName = item.DocumentName, DocumentExtension = item.DocumentExtension, DocumentSize = item.DocumentSize, SubModuleName = item.SubModuleName, Path = item.Path });

                    }
                    documents = objNewStudy.GetDocumentsByStudyID(objNewStudyDetails.StudyId, Utilities.Messages.RequestedSupportAdditionalDocuments);
                    foreach (var item in documents)
                    {
                        model.AdditionalDocuments.Add(
                        new Documents { DocumentName = item.DocumentName, DocumentExtension = item.DocumentExtension, DocumentSize = item.DocumentSize, SubModuleName = item.SubModuleName });

                    }
                }

            }
            else
                return RedirectToAction("Login", "Login");

            return View(model);
        }



        /// <summary>
        /// Edit Study
        /// </summary>
        /// <returns>View</returns>
        public IActionResult EditStudy()
        {
            ViewBag.Username = HttpContext.Session.GetString("Username");
            ViewBag.UserType = HttpContext.Session.GetString("UserType");
            var objNewStudyDetails = JsonConvert.DeserializeObject<Data.NewStudy>(TempData["OpenData"]?.ToString());
            TempData.Keep("OpenData");
            if (objNewStudyDetails != null)
            {
                ViewBag.StudyType = objNewStudyDetails.StudyType;
                ViewBag.StudyId = objNewStudyDetails.StudyId;
                HttpContext.Session.SetString("StudyId", objNewStudyDetails.StudyId.ToString());
                var studyInformation = objNewStudy.GetStudyInformation(objNewStudyDetails.StudyId);
                ViewBag.State = studyInformation.State;
                ViewBag.Stage = studyInformation.Stage;
                ViewBag.Status = studyInformation.TaskStatus;
                ViewBag.studyName = studyInformation.TitleofTrial;
                ViewBag.StudyOwner = studyInformation.ANJU_AddedBy;
                ViewBag.StudyNumber = objNewStudyDetails.StudyNumber;
            
                PopulateCompanyCompound();
                PopulateDrugorCompoundType();
                PopulateCompanyCategory();
                PopulateNonCompanyCompound();                
            }
            else
                return RedirectToAction("Login", "Login");
            return View();
        }



        /// <summary>
        /// Help Text
        /// </summary>
        /// <returns>View</returns>
        public IActionResult HelpText()
        {
            return View();
        }



        /// <summary>
        /// Documents
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="docid"></param>
        /// <returns>PartialView</returns>
        public IActionResult Documents(string mode,int docid)
        {
            ViewBag.Username = HttpContext.Session.GetString("Username");
            var objNewStudyDetails = JsonConvert.DeserializeObject<Data.NewStudy>(TempData["OpenData"]?.ToString());
            TempData.Keep("OpenData");

            var documents = new List<Data.Documents>();
            var model = new ListOfDocuments();

            if (objNewStudyDetails != null)
            {
                ViewBag.StudyId = objNewStudyDetails.StudyId;
              
                //if (objNewStudyDetails.StudyId > 0)
                //{
                //    if(mode == "Edit")                        
                //        documents = objNewStudy.GetSpecificDocumentsByStudyID(objNewStudyDetails.StudyId, docid);
                //    else
                //        documents = objNewStudy.GetDocumentsByStudyID(objNewStudyDetails.StudyId, null);

                //    foreach (var item in documents)
                //    {
                //        model.TrialBudgetDocuments.Add(
                //        new Documents { DocumentName = item.DocumentName, DocumentExtension = item.DocumentExtension, DocumentSize = item.DocumentSize, });
                //    }                    
                //}
            }

            return PartialView("Documents", model);           
        }


        /// <summary>
        /// Submissions
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="docid"></param>
        /// <returns>PartialView</returns>
        public IActionResult Submissions(string mode, int docid)
        {
            ViewBag.Username = HttpContext.Session.GetString("Username");
            var objNewStudyDetails = JsonConvert.DeserializeObject<Data.NewStudy>(TempData["OpenData"]?.ToString());
            TempData.Keep("OpenData");

            var submissions = new List<Data.Submissions>();
            var model = new ListOfSubmissions();
            //string documentName;

            if (objNewStudyDetails != null)
            {
                ViewBag.StudyId = objNewStudyDetails.StudyId;

                //if (objNewStudyDetails.StudyId > 0)
                //{
                //    if (mode == "Edit")
                //    {
                //        submissions = objNewStudy.GetSpecificSubmissionsByStudyID(objNewStudyDetails.StudyId, docid);
                //    }
                //    //else
                //    //    submissions = objNewStudy.GetSubmissionsByStudyID(objNewStudyDetails.StudyId);

                //    foreach (var item in submissions)
                //    {
                //        documentName = item.Submissiondetails;
                //        if (!string.IsNullOrEmpty(documentName))
                //        {
                //            int fileExtPos = documentName.LastIndexOf(".");
                //            if (fileExtPos >= 0)
                //                documentName = documentName.Substring(0, fileExtPos);
                //            model.Submissions.Add(
                //            new Submissions { Submissiondetails = documentName, DocumentExtension = item.DocumentExtension, DocumentSize = item.DocumentSize });
                //        }
                //    }
                  
                //}
            }

            return PartialView("Submissions", model);
        }


        /// <summary>
        /// Get Tab Titles for Edit Study
        /// </summary>
        /// <param name="request"></param>
        /// <param name="tabtype"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public JsonResult GetTabTitles([DataSourceRequest] DataSourceRequest request, string tabtype,string category)
        {
            try
            {
                var result = objNewStudy.GetTabTitles(tabtype, category);
                return Json(result.ToDataSourceResult(request).Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new SysCodeValues() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }


        /// <summary>
        /// Get Attribute Values
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Json</returns>
        public JsonResult GetAttributeValues([DataSourceRequest] DataSourceRequest request,int attributeid)
        {
            try
            {
                var result = objNewStudy.GetAttributeValues(attributeid);
                return Json(result.ToDataSourceResult(request).Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new SysCodeValues() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }



        /// <summary>
        /// Get Attributes
        /// </summary>
        /// <param name="request"></param>
        /// <param name="name"></param>
        /// <param name="checkId"></param>
        /// <returns>Json</returns>
        public JsonResult GetAttributes([DataSourceRequest] DataSourceRequest request, string name, int checkId)
        {
            try
            {
                var result = objNewStudy.GetAttributes(name, checkId);
                return Json(result.ToDataSourceResult(request).Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new SysCodeValues() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }



        /// <summary>
        /// Destroy Study Session
        /// </summary>
        public void DestroyStudySession()
        {
            HttpContext.Session.Remove("StudyId");
        }

        #endregion

        #region Methods

        /// <summary>
        /// Populate Type of Trial Drugs for Treatement Grid
        /// </summary>
        public void PopulateTypeofTrialDrugs()
        {
            List<Data.SysCodeValues> response = objNewStudy.GetTypeoftrialdrug();
            ViewData["TypeofTrialDrug"] = response;
        }

        /// <summary>
        /// Populate Objective Types for Objective Types in Objective and Endpoints grid
        /// </summary>
        public void PopulateObjectiveTypes()
        {
            List<Data.SysCodeValues> response = objNewStudy.GetObjectiveTypes();
            ViewData["ObjectiveTypes"] = response;
        }


        /// <summary>
        /// Populate Objective Names
        /// </summary>
        public void PopulateObjectiveNames()
        {
            List<Data.SysCodeValues> response = objNewStudy.GetObjectiveName();
            ViewData["ObjectiveNames"] = response;
        }

        public void PopulateCompanyCompound()
        {
            List<Data.SysCodeValues> response = objNewStudy.GetSysCodeValues(@ConstDefaultValue.PRIMARY);
            ViewData["CompanyCompound"] = response;
        }

        public void PopulateDrugorCompoundType()
        {
            List<Data.SysCodeValues> response = objNewStudy.GetSysCodeValues(@ConstDefaultValue.DRUGORCOMPOUNDCATEGORY);
            ViewData["DrugorCompoundType"] = response;
        }

        public void PopulateNonCompanyCompound()
        {
            List<Data.SysCodeValues> response = objNewStudy.GetSysCodeValues(@ConstDefaultValue.NONCOMPANYCOMPOUND);
            ViewData["NonCompanyCompound"] = response;
        }

        public void PopulateCompanyCategory()
        {
            List<Data.SysCodeValues> response = objNewStudy.GetSysCodeValues(@ConstDefaultValue.DRUGORCOMPOUNDSECONDARYTYPE);
            ViewData["CompanyCategory"] = response;
        }

        public void PopulateYesNo()
        {
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem { Text = @ConstDefaultValue.YES, Value = "True" });
            list.Add(new SelectListItem { Text = @ConstDefaultValue.NO, Value = "False" });
            ViewData["YesNo"] = list;
        }

        /// <summary>
        /// Get SysCode Values by type
        /// </summary>
        /// <param name="request"></param>
        /// <param name="type"></param>
        /// <returns>Json</returns>
        public JsonResult GetSysCodeValues([DataSourceRequest] DataSourceRequest request, string type)
        {
            try
            {
                var result = objNewStudy.GetSysCodeValues(type);
                return Json(result.ToDataSourceResult(request).Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new SysCodeValues() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }

        /// <summary>
        /// Get Age
        /// </summary>
        /// <param name="request"></param>
        /// <param name="agerange"></param>
        /// <returns>Json</returns>
        public JsonResult GetAge([DataSourceRequest] DataSourceRequest request, string agerange)
        {
            try
            {
                var result = objNewStudy.GetAge(agerange);
                return Json(result.ToDataSourceResult(request).Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new Age() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }

        /// <summary>
        /// Get Intervention Status
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Json</returns>
        public JsonResult GetInterventionStatus([DataSourceRequest] DataSourceRequest request)
        {

            try
            {
                var result = objNewStudy.GetInterventionStatus();
                return Json(result.ToDataSourceResult(request).Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new SysCodeValues() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }

        /// <summary>
        /// Get Objectives and Endpoints
        /// </summary>
        /// <param name="request"></param>
        /// <param name="Category"></param>
        /// <returns>Json</returns>
        public ActionResult GetObjectivesandEndpoints([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                studyId = int.Parse(HttpContext.Session.GetString("StudyId"));
                var response = objNewStudy.GetObjectivesandEndpoints(studyId);
                return Json(response.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new ObjectivesandEndpoints() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }


        /// <summary>
        /// Get Milestones
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ActionResult GetMilestones([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                studyId = int.Parse(HttpContext.Session.GetString("StudyId"));
                var response = objNewStudy.GetMilestones(studyId);
                return Json(response.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new Milestones() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }


        /// <summary>
        /// Get Patient Accrual
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ActionResult GetPatientAccrual([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                studyId = int.Parse(HttpContext.Session.GetString("StudyId"));
                var response = objNewStudy.GetPatientAccrual(studyId);
                return Json(response.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new Milestones() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }



        /// <summary>
        /// Get Study Descriptors
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Json</returns>
        public JsonResult GetStudyDescriptors([DataSourceRequest] DataSourceRequest request)
        {

            try
            {
                var result = objNewStudy.GetStudyDescriptors();
                return Json(result.ToDataSourceResult(request).Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new SysCodeValues() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }

        /// <summary>
        /// Get Patient Type
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Json</returns>
        public JsonResult GetPatientType([DataSourceRequest] DataSourceRequest request)
        {

            try
            {
                var result = objNewStudy.GetPatientType();
                return Json(result.ToDataSourceResult(request).Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new SysCodeValues() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }

        /// <summary>
        /// Create Update Objectives and Endpoints
        /// </summary>
        /// <param name="objectivesandEndpoints"></param>
        /// <param name="mode"></param>
        /// <returns>Json</returns>
        public JsonResult CreateUpdateObjectivesandEndpoints(Data.ObjectivesandEndpoints objectivesandEndpoints, string mode)
        {

            try
            {
                studyId = int.Parse(HttpContext.Session.GetString("StudyId"));
                userName = HttpContext.Session.GetString("Username");
                bool result = objNewStudy.CreateUpdateObjectivesandEndpoints(objectivesandEndpoints, mode, studyId, userName);
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
                return Json(new ObjectivesandEndpoints() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInCreation });
            }
        }

        /// <summary>
        /// Create Update Edit Study Attributes
        /// </summary>
        /// <param name="editstudyattributeId"></param>       
        /// <returns>Json</returns>
        public JsonResult CreateUpdateEditStudyAttribute(Data.EditStudyAttributes editstudyattributes)
        {
            try
            {
                userName = HttpContext.Session.GetString("Username");
                bool result = objNewStudy.CreateUpdateEditStudyAttribute(editstudyattributes, userName);
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
                return Json(new ObjectivesandEndpoints() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInCreation });
            }
        }

        /// <summary>
        /// Delete Objectives and End points
        /// </summary>
        /// <param name="request"></param>
        /// <param name="userRoles"></param>
        /// <returns>Json</returns>
        public JsonResult DeleteObjectivesandEndpoints([DataSourceRequest] DataSourceRequest request, Data.ObjectivesandEndpoints objectivesandEndpoints)
        {
            try
            {
                userName = HttpContext.Session.GetString("Username");
                bool isDeleteObjectivesandEndpoints = objNewStudy.DeleteObjectivesandEndpoints(objectivesandEndpoints, userName);
                if (isDeleteObjectivesandEndpoints == true)
                    msgType = Utilities.Messages.SuccessStatus;
                else
                    msgType = Utilities.Messages.ProblemInDeletion;
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), Utilities.Messages.ProblemInDeletion);
                return Json(new ObjectivesandEndpoints() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInDeletion });

            }
            return Json(new { data = message, msgType = msgType });
        }


        /// <summary>
        /// Delete Contacts
        /// </summary>
        /// <param name="request"></param>
        /// <param name="principalInvestigator"></param>
        /// <returns>Json</returns>
        public JsonResult DeleteContacts([DataSourceRequest] DataSourceRequest request, Data.PrincipalInvestigator principalInvestigator)
        {
            try
            {
                userName = HttpContext.Session.GetString("Username");
                bool isDeleteprincipalInvestigator = objNewStudy.DeleteContacts(principalInvestigator, userName);
                if (isDeleteprincipalInvestigator == true)
                    msgType = Utilities.Messages.SuccessStatus;
                else
                    msgType = Utilities.Messages.ProblemInDeletion;
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), Utilities.Messages.ProblemInDeletion);
                return Json(new ObjectivesandEndpoints() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInDeletion });

            }
            return Json(new { data = message, msgType = msgType });
        }


        /// <summary>
        /// Delete Milestones
        /// </summary>
        /// <param name="request"></param>
        /// <param name="milestones"></param>
        /// <returns>Json</returns>
        public JsonResult DeleteMilestones([DataSourceRequest] DataSourceRequest request, Data.Milestones milestones)
        {
            try
            {
                userName = HttpContext.Session.GetString("Username");
                bool isDeleteMilestones = objNewStudy.DeleteMilestones(milestones, userName);
                if (isDeleteMilestones == true)
                    msgType = Utilities.Messages.SuccessStatus;
                else
                    msgType = Utilities.Messages.ProblemInDeletion;
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), Utilities.Messages.ProblemInDeletion);
                return Json(new ObjectivesandEndpoints() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInDeletion });

            }
            return Json(new { data = message, msgType = msgType });
        }




        /// <summary>
        /// Delete Study Sites
        /// </summary>
        /// <param name="request"></param>
        /// <param name="studySites"></param>
        /// <returns>Json</returns>
        public JsonResult DeleteStudySites([DataSourceRequest] DataSourceRequest request, Data.StudySites studySites)
        {
            try
            {
                userName = HttpContext.Session.GetString("Username");
                bool isDeletestudysites = objNewStudy.DeleteStudySites(studySites, userName);
                if (isDeletestudysites == true)
                    msgType = Utilities.Messages.SuccessStatus;
                else
                    msgType = Utilities.Messages.ProblemInDeletion;
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), Utilities.Messages.ProblemInDeletion);
                return Json(new ObjectivesandEndpoints() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInDeletion });

            }
            return Json(new { data = message, msgType = msgType });
        }


        /// <summary>
        /// Delete Patient Accrual
        /// </summary>
        /// <param name="request"></param>
        /// <param name="patientaccrual"></param>
        /// <returns>Json</returns>
        public JsonResult DeletePatientAccrual([DataSourceRequest] DataSourceRequest request, Data.PatientAccrual patientaccrual)
        {
            try
            {
                userName = HttpContext.Session.GetString("Username");
                bool isDeletepatientaccrual = objNewStudy.DeletePatientAccrual(patientaccrual, userName);
                if (isDeletepatientaccrual == true)
                    msgType = Utilities.Messages.SuccessStatus;
                else
                    msgType = Utilities.Messages.ProblemInDeletion;
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), Utilities.Messages.ProblemInDeletion);
                return Json(new PatientAccrual() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInDeletion });

            }
            return Json(new { data = message, msgType = msgType });
        }


        /// <summary>
        /// Delete Invoice
        /// </summary>
        /// <param name="request"></param>
        /// <param name="invoicedetails"></param>
        /// <returns>Json</returns>
        public JsonResult DeleteInvoicedetails([DataSourceRequest] DataSourceRequest request, Data.Invoicedetails invoicedetails)
        {
            try
            {
                userName = HttpContext.Session.GetString("Username");
                bool isDeleteinvoicedetails = objNewStudy.DeleteInvoicedetails(invoicedetails, userName);
                if (isDeleteinvoicedetails == true)
                    msgType = Utilities.Messages.SuccessStatus;
                else
                    msgType = Utilities.Messages.ProblemInDeletion;
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), Utilities.Messages.ProblemInDeletion);
                return Json(new Invoicedetails() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInDeletion });

            }
            return Json(new { data = message, msgType = msgType });
        }



        /// <summary>
        /// Delete Status
        /// </summary>
        /// <param name="request"></param>
        /// <param name="statusdetails"></param>
        /// <returns>Json</returns>
        public JsonResult DeleteStatusdetails([DataSourceRequest] DataSourceRequest request, Data.Status statusdetails)
        {
            try
            {
                userName = HttpContext.Session.GetString("Username");
                bool isDeletestatusdetails = objNewStudy.DeleteStatusdetails(statusdetails, userName);
                if (isDeletestatusdetails == true)
                    msgType = Utilities.Messages.SuccessStatus;
                else
                    msgType = Utilities.Messages.ProblemInDeletion;
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), Utilities.Messages.ProblemInDeletion);
                return Json(new Status() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInDeletion });

            }
            return Json(new { data = message, msgType = msgType });
        }


        /// <summary>
        /// Delete Contracts Timeline
        /// </summary>
        /// <param name="request"></param>
        /// <param name="contracttimelines"></param>
        /// <returns>Json</returns>
        public JsonResult DeleteContractsTimeline([DataSourceRequest] DataSourceRequest request, Data.Contracttimelines contracttimelines)
        {
            try
            {
                userName = HttpContext.Session.GetString("Username");
                bool isDeleteContractsTimelinedetails = objNewStudy.DeleteContractsTimeline(contracttimelines, userName);
                if (isDeleteContractsTimelinedetails == true)
                    msgType = Utilities.Messages.SuccessStatus;
                else
                    msgType = Utilities.Messages.ProblemInDeletion;
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), Utilities.Messages.ProblemInDeletion);
                return Json(new Contracttimelines() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInDeletion });

            }
            return Json(new { data = message, msgType = msgType });
        }


        /// <summary>
        /// Delete Reviews and Notes
        /// </summary>
        /// <param name="request"></param>
        /// <param name="reviewsandnotes"></param>
        /// <returns>Json</returns>
        public JsonResult DeleteReviewsandNotes([DataSourceRequest] DataSourceRequest request, Data.ReviewsandNotes reviewsandnotes)
        {
            try
            {
                userName = HttpContext.Session.GetString("Username");
                bool isDeletestatusdetails = objNewStudy.DeleteReviewsandNotes(reviewsandnotes, userName);
                if (isDeletestatusdetails == true)
                    msgType = Utilities.Messages.SuccessStatus;
                else
                    msgType = Utilities.Messages.ProblemInDeletion;
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), Utilities.Messages.ProblemInDeletion);
                return Json(new ReviewsandNotes() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInDeletion });

            }
            return Json(new { data = message, msgType = msgType });
        }



        /// <summary>
        /// Create/Update Cohort Levels
        /// </summary>
        /// <param name="cohortLevels"></param>
        /// <param name="mode"></param>
        /// <returns>Json</returns>
        public JsonResult CreateUpdateCohortLevels(Data.CohortLevels cohortLevels, string mode)
        {
            try
            {
                studyId = int.Parse(HttpContext.Session.GetString("StudyId"));
                userName = HttpContext.Session.GetString("Username");
                bool result = objNewStudy.CreateUpdateCohortLevels(cohortLevels, mode, studyId, userName);
                if (result == true)
                {
                    msgType = Utilities.Messages.SuccessStatus;
                }
                else
                    msgType = Utilities.Messages.ErrorStatus;

                return Json(new { data = message, msgType });
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                if (this.mode == "Create")
                    return base.Json(new CohortLevels() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInCreation });
                else
                    return base.Json(new CohortLevels() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInUpdation });
            }
        }

        /// <summary>
        /// Get Cohort Levels
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Json</returns>
        public ActionResult GetCohortLevels([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                studyId = int.Parse(HttpContext.Session.GetString("StudyId"));
                var response = objNewStudy.GetCohortLevels(studyId);
                return Json(response.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new CohortLevels() { Status = "Failed", ErrorMessage = ex.StackTrace });
            }
        }

        /// <summary>
        /// Delete Cohort Levels
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cohortLevels"></param>
        /// <returns>Json</returns>
        public JsonResult DeleteCohortLevels([DataSourceRequest] DataSourceRequest request, Data.CohortLevels cohortLevels)
        {
            try
            {
                userName = HttpContext.Session.GetString("Username");
                bool isDeletecohortLevels = objNewStudy.DeleteCohortLevels(cohortLevels, userName);
                if (isDeletecohortLevels == true)
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
        /// Delete Indications
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cohortLevels"></param>
        /// <returns>Json</returns>
        public JsonResult DeleteIndications([DataSourceRequest] DataSourceRequest request, Data.StudyIndication indications)
        {
            try
            {
                userName = HttpContext.Session.GetString("Username");
                bool isDeleteindications = objNewStudy.DeleteStudyIndications(indications, userName);
                if (isDeleteindications == true)
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
        /// Delete Study Protocols
        /// </summary>
        /// <param name="request"></param>
        /// <param name="studyprotocol"></param>
        /// <returns>Json</returns>
        public JsonResult DeleteStudyProtocols([DataSourceRequest] DataSourceRequest request, Data.StudyProtocol studyprotocol)
        {
            try
            {
                userName = HttpContext.Session.GetString("Username");
                bool iDeleteTreatmentInformation = objNewStudy.DeleteStudyProtocols(studyprotocol, userName);
                if (iDeleteTreatmentInformation == true)
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
        /// Create Update Treatment Information
        /// </summary>
        /// <param name="treatmentInformation"></param>
        /// <param name="mode"></param>
        /// <returns>Json</returns>
        public JsonResult CreateUpdateTreatmentInformation(Data.TreatmentInformation treatmentInformation, string mode)
        {
            try
            {
                studyId = int.Parse(HttpContext.Session.GetString("StudyId"));
                userName = HttpContext.Session.GetString("Username");
                bool result = objNewStudy.CreateUpdateTreatmentInformation(treatmentInformation, mode, studyId, userName);
                if (result == true)
                {
                    msgType = Utilities.Messages.SuccessStatus;
                }
                else
                    msgType = Utilities.Messages.ErrorStatus;

                return Json(new { data = message, msgType });
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                if (mode == "Create")
                    return Json(new TreatmentInformation() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInCreation });
                else
                    return Json(new TreatmentInformation() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInUpdation });
            }
        }



        /// <summary>
        /// Create/Update Documents in Add Mode
        /// </summary>
        /// <param name="uploadfiles"></param>
        /// <param name="additional"></param>
        /// <returns>Content</returns>
        public async Task<ActionResult> CreateUpdateDocumentsAddMode(IEnumerable<IFormFile> uploadfiles, string[] additional)
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
                        var folderPath = string.Empty;
                        var subModuleName = string.Empty;
                        if (additional[5]?.ToString() == ConstDefaultValue.MANUAL)
                        {
                            subModuleName = ConstDefaultValue.MANUAL;
                            folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, ConstDefaultValue.MANUAL);
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
                                    DocumentName = fileName,
                                    DocumentNameWithOutExtension = Path.GetFileNameWithoutExtension(fileContent.FileName.Trim('"')),
                                    DocumentSize = Convert.ToInt32(new System.IO.FileInfo(filePath).Length),
                                    DocumentExtension = Path.GetExtension(filePath).ToLowerInvariant().ToString(),

                                    StudyId = Convert.ToInt32(studyId),
                                    Path = filePath,

                                    DocumentStatus = additional[1]?.ToString(),
                                    DocumentVersion = additional[2]?.ToString(),
                                    DocumentType = additional[3]?.ToString(),
                                    DocumentSubType = additional[4]?.ToString(),
                                    SubModuleName = subModuleName,
                                    ANJU_AddedBy = HttpContext.Session.GetString("Username"),
                                    Anju_AddedDate = DateTime.UtcNow,
                                    OriginalDate = additional[8] != "month day, year" ? Convert.ToDateTime(additional[8]) : (DateTime?)null,
                                    ExpirationDate = additional[9] != "month day, year" ? Convert.ToDateTime(additional[9]) : (DateTime?)null,

                                    IsActive = true,
                                    IsDeleted = false,


                                };

                                result = objNewStudy.CreateUpdateManualTypeDocuments(objDocuments);
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
        /// Create/Update Documents in Edit Mode
        /// </summary>
        /// <param name="uploadfileseditmode"></param>
        /// <param name="additionalEditmode"></param>
        /// <returns>Content</returns>
        public async Task<ActionResult> CreateUpdateDocumentsEditMode(IEnumerable<IFormFile> uploadfileseditmode, string[] additionalEditmode)
        {
            bool result = true;
            try
            {
                if (uploadfileseditmode != null)
                {
                    foreach (var file in uploadfileseditmode)
                    {
                        var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                        var studyId = HttpContext.Session.GetString("StudyId");
                        var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
                        var folderPath = string.Empty;
                        var subModuleName = string.Empty;
                        if (additionalEditmode[5]?.ToString() == ConstDefaultValue.MANUAL)
                        {
                            subModuleName = ConstDefaultValue.MANUAL;
                            folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, ConstDefaultValue.MANUAL);
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
                                    DocumentId = int.Parse(additionalEditmode[10]),
                                    DocumentName = fileName,
                                    DocumentNameWithOutExtension = Path.GetFileNameWithoutExtension(fileContent.FileName.Trim('"')),
                                    DocumentSize = Convert.ToInt32(new System.IO.FileInfo(filePath).Length),
                                    DocumentExtension = Path.GetExtension(filePath).ToLowerInvariant().ToString(),
                                    StudyId = Convert.ToInt32(studyId),
                                    Path = filePath,
                                    DocumentStatus = additionalEditmode[1]?.ToString(),
                                    DocumentVersion = additionalEditmode[2]?.ToString(),
                                    DocumentType = additionalEditmode[3]?.ToString(),
                                    DocumentSubType = additionalEditmode[4]?.ToString(),
                                    SubModuleName = subModuleName,
                                    ANJU_AddedBy = HttpContext.Session.GetString("Username"),
                                    Anju_AddedDate = DateTime.UtcNow,                                    
                                    OriginalDate = additionalEditmode[8] != null ? Convert.ToDateTime(additionalEditmode[8]) : (DateTime?)null,
                                    ExpirationDate = additionalEditmode[9] != null ? Convert.ToDateTime(additionalEditmode[9]) : (DateTime?)null,
                                    IsActive = true,
                                    IsDeleted = false
                                };

                                result = objNewStudy.CreateUpdateManualTypeDocuments(objDocuments);
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
        /// Create/Update Submissions in Add Mode
        /// </summary>
        /// <param name="uploadsubmissiondetailsaddmode"></param>
        /// <param name="additional"></param>
        /// <returns>msgType</returns>
        public async Task<ActionResult> CreateUpdateSubmissionsAddMode(IEnumerable<IFormFile> uploadsubmissiondetailsaddmode, string[] additional)
        {
            bool result = true;
            try
            {
                if (uploadsubmissiondetailsaddmode != null)
                {
                    foreach (var file in uploadsubmissiondetailsaddmode)
                    {
                        var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                        var studyId = HttpContext.Session.GetString("StudyId");
                        var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
                        var folderPath = string.Empty;
                        folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "Submissions");
                     
                        var filePath = Path.Combine(folderPath, fileName);
                        bool isCreated = CreateDirectory(folderPath);

                        if (isCreated)
                        {
                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                                //Data.Submissions objSubmissions = new Data.Submissions()
                                //{
                                //    Submissiondetails = fileName,                                    
                                //    StudyId = Convert.ToInt32(studyId),                                    
                                //    Submissiontype = additional[0]?.ToString(), 
                                //    Submissionversion = additional[1]?.ToString(),
                                //    Studyeligibilitydate = additional[2] != "month day, year" ? Convert.ToDateTime(additional[2]) : (DateTime?)null,
                                //    Submissiondate = additional[3] != "month day, year" ? Convert.ToDateTime(additional[3]) : (DateTime?)null,
                                //    DocumentExtension = Path.GetExtension(filePath).ToLowerInvariant().ToString(),
                                //    DocumentSize = Convert.ToInt32(new System.IO.FileInfo(filePath).Length),

                                //    ANJU_AddedBy = HttpContext.Session.GetString("Username"),
                                //    ANJU_AddDate = DateTime.UtcNow,
                                   
                                //    IsActive = true,
                                //    IsDeleted = false,
                                //};

                                //result = objNewStudy.CreateUpdateSubmissionsAddMode(objSubmissions);
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



        public async Task<ActionResult> CreateUpdateSubmissionsEditMode(IEnumerable<IFormFile> uploadsubmissiondetailseditmode, string[] additional)
        {
            bool result = true;
            try
            {
                if (uploadsubmissiondetailseditmode != null)
                {
                    foreach (var file in uploadsubmissiondetailseditmode)
                    {
                        var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                        var studyId = HttpContext.Session.GetString("StudyId");
                        var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
                        var folderPath = string.Empty;
                        //var subModuleName = string.Empty;
                        //if (additional[5]?.ToString() == ConstDefaultValue.MANUAL)
                        //{
                        //    subModuleName = ConstDefaultValue.MANUAL;
                        folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "Submissions");
                        ////}

                        var filePath = Path.Combine(folderPath, fileName);
                        bool isCreated = CreateDirectory(folderPath);

                        if (isCreated)
                        {
                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                                Data.Submissions objSubmissions = new Data.Submissions()
                                {
                                    Submissiondetails = fileName,
                                    //DocumentNameWithOutExtension = Path.GetFileNameWithoutExtension(fileContent.FileName.Trim('"')),
                                    DocumentSize = Convert.ToInt32(new System.IO.FileInfo(filePath).Length),
                                    DocumentExtension = Path.GetExtension(filePath).ToLowerInvariant().ToString(),

                                    StudyId = Convert.ToInt32(studyId),
                                    //Path = filePath,
                                    Submissiontype = additional[0]?.ToString(),
                                    Submissionversion = additional[1]?.ToString(),
                                    Studyeligibilitydate = additional[2] != "month day, year" ? Convert.ToDateTime(additional[2]) : (DateTime?)null,
                                    Submissiondate = additional[3] != "month day, year" ? Convert.ToDateTime(additional[3]) : (DateTime?)null,

                                    ANJU_AddedBy = HttpContext.Session.GetString("Username"),
                                    ANJU_AddDate = DateTime.UtcNow,

                                    IsActive = true,
                                    IsDeleted = false,
                                };

                                result = objNewStudy.CreateUpdateSubmissionsAddMode(objSubmissions);
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
        /// Get Treatment Information
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Json</returns>
        public ActionResult GetTreatmentInformation([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                studyId = int.Parse(HttpContext.Session.GetString("StudyId"));
                var response = objNewStudy.GetTreatmentInformation(studyId);
                return Json(response.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new TreatmentInformation() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }

        /// <summary>
        /// Delete Treatment Information
        /// </summary>
        /// <param name="request"></param>
        /// <param name="treatmentInformation"></param>
        /// <returns>Json</returns>
        public JsonResult DeleteTreatmentInformation([DataSourceRequest] DataSourceRequest request, Data.TreatmentInformation treatmentInformation)
        {
            try
            {
                userName = HttpContext.Session.GetString("Username");
                bool iDeleteTreatmentInformation = objNewStudy.DeleteTreatmentInformations(treatmentInformation, userName);
                if (iDeleteTreatmentInformation == true)
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



        ///// <summary>
        ///// Delete Documents
        ///// </summary>
        ///// <param name="fileNames"></param>
        ///// <param name="additional"></param>
        ///// <returns>msgType</returns>
        //public ActionResult DeleteDocuments(string[] fileNames, string[] additional)
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
        //                var folderPath = string.Empty;
        //                string submoduleName = string.Empty;

        //                if (additional[8]?.ToString() == ConstDefaultValue.MANUAL)
        //                {
        //                    submoduleName = ConstDefaultValue.MANUAL;
        //                    folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, ConstDefaultValue.MANUAL);
        //                }

        //                var filePath = Path.Combine(folderPath, fileName);

        //                if (System.IO.File.Exists(filePath))
        //                {
        //                    System.IO.File.Delete(filePath);
        //                    result = objNewStudy.DeleteUploadedFile(studyId, username, submoduleName, fileName);
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
        /// Get New Study ID number and assign to Session
        /// </summary>
        /// <returns>Json</returns>
        public void GetNewStudyID(string mode)
        {
            try
            {
                if (mode == "Create")
                {
                    int StudyId = objNewStudy.GetNewStudyID();
                    HttpContext.Session.SetString("StudyId", StudyId.ToString());
                    ViewBag.StudyId = HttpContext.Session.GetString("StudyId");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);

            }
        }

        /// <summary>
        /// Create/Update Scientific Rationale I
        /// </summary>
        /// <param name="newStudy"></param>
        /// <param name="trialPhase"></param>
        /// <param name="drugorCompounddetails"></param>
        /// <param name="conceptDesignandRationale"></param>
        /// <param name="Gender"></param>
        /// <returns></returns>
        public JsonResult CreateUpdateScientificRationaleI(NewStudy newStudy,
                                                     TrialPhase trialPhase,
                                                     DrugorCompounddetails drugorCompounddetails,
                                                     ConceptDesignandRationale conceptDesignandRationale,
                                                     string[] gender)
        {
            try
            {
                bool result = false;
                string IsdataAlreadyEntered = string.Empty;
                string mode = HttpContext.Session.GetString("Mode");
                studyId = int.Parse(HttpContext.Session.GetString("StudyId"));
                userName = HttpContext.Session.GetString("Username");

                if (mode == "Create")
                {
                    result = objNewStudy.CreateUpdateScientificRationaleI(studyId, newStudy, trialPhase, drugorCompounddetails, conceptDesignandRationale, userName, gender, "Create");
                    if (result == true)
                        HttpContext.Session.SetString("Mode", "Update");
                }
                else
                    result = objNewStudy.CreateUpdateScientificRationaleI(studyId, newStudy, trialPhase, drugorCompounddetails, conceptDesignandRationale, userName, gender, "Update");
                SavetoSessionforNewStudyForScientificRationaleI(newStudy, trialPhase, drugorCompounddetails, conceptDesignandRationale, gender);

                message = Utilities.Messages.SuccessStatus;

            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString());
            }
            return Json(new { Data = message });
        }

        /// <summary>
        /// Save to Session Scientific Rationale I details
        /// </summary>
        /// <param name="newStudy"></param>
        /// <param name="trialPhase"></param>
        /// <param name="drugorCompounddetails"></param>
        /// <param name="conceptDesignandRationale"></param>
        void SavetoSessionforNewStudyForScientificRationaleI(NewStudy newStudy,
                                                     TrialPhase trialPhase,
                                                     DrugorCompounddetails drugorCompounddetails,
                                                     ConceptDesignandRationale conceptDesignandRationale, string[] gender)
        {
            objSessionNewStudy.TitleofTrial = newStudy.TitleofTrial;
            objSessionNewStudy.StudyType = newStudy.StudyType;
            objSessionNewStudy.PhaseI = trialPhase.PhaseI;
            objSessionNewStudy.PhaseII = trialPhase.PhaseII;
            objSessionNewStudy.PhaseIII = trialPhase.PhaseIII;
            objSessionNewStudy.PhaseIV = trialPhase.PhaseIV;
            objSessionNewStudy.Primarydrug = drugorCompounddetails.Primarydrug;
            objSessionNewStudy.Secondarydrug = drugorCompounddetails.Secondarydrug;
            objSessionNewStudy.Tertiarydrug = drugorCompounddetails.Tertiarydrug;
            objSessionNewStudy.SecondaryType = drugorCompounddetails.SecondaryType;
            objSessionNewStudy.TertiaryaryType = drugorCompounddetails.TertiaryaryType;
            objSessionNewStudy.Indication = conceptDesignandRationale.Indication;
            objSessionNewStudy.RationaleforTrial = conceptDesignandRationale.RationaleforTrial;
            objSessionNewStudy.TrialDesign = conceptDesignandRationale.TrialDesign;
            objSessionNewStudy.Binding = conceptDesignandRationale.Binding;
            objSessionNewStudy.Structure = conceptDesignandRationale.Structure;
            objSessionNewStudy.Randomized = conceptDesignandRationale.Randomized;
            objSessionNewStudy.Gender = gender.Length > 0 ? String.Join(",", gender) : null;
            objSessionNewStudy.MinimumAge = conceptDesignandRationale.MinimumAge;
            objSessionNewStudy.MaximumAge = conceptDesignandRationale.MaximumAge;
            objSessionNewStudy.PatientPopulation = conceptDesignandRationale.PatientPopulation;
            objSessionNewStudy.KeyInclusionCriteria = conceptDesignandRationale.KeyInclusionCriteria;
            objSessionNewStudy.KeyExclusionCriteria = conceptDesignandRationale.KeyExclusionCriteria;
            objSessionNewStudy.Treatmentarms = newStudy.Treatmentarms;

            HttpContext.Session.SetComplexData("SavetoSessionforNewStudy", objSessionNewStudy);
        }

        /// <summary>
        /// Create /Update Scientific Rationale II
        /// </summary>
        /// <param name="objNewStudy"></param>
        /// <param name="CorrelativeScienceStudies"></param>
        /// <param name="PlannedTrialMilestoneDatesandEnrollment"></param>
        /// <returns></returns>
        public JsonResult CreateUpdateScientificRationaleII(NewStudy newStudy,
                                                     CorrelativeScienceStudies correlativeScienceStudies,
                                                     PlannedTrialMilestoneDatesandEnrollment plannedTrialMilestoneDatesandEnrollment,
                                                     PharmacovigilanceRequirements pharmacovigilanceRequirements)
        {
            try
            {
                bool result = false;
                string mode = HttpContext.Session.GetString("Mode");
                studyId = int.Parse(HttpContext.Session.GetString("StudyId"));
                userName = HttpContext.Session.GetString("Username");
                result = objNewStudy.CreateUpdateScientificRationaleII(studyId, newStudy, correlativeScienceStudies, plannedTrialMilestoneDatesandEnrollment, pharmacovigilanceRequirements, userName);
                SavetoSessionforNewStudyForScientificRationaleII(newStudy, correlativeScienceStudies, plannedTrialMilestoneDatesandEnrollment, pharmacovigilanceRequirements);

                message = "Success";

            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString());
            }
            return Json(new { Data = message });
        }

        /// <summary>
        /// Save to Session Scientific Rationale II details
        /// </summary>
        /// <param name="newStudy"></param>
        /// <param name="correlativeScienceStudies"></param>
        /// <param name="plannedTrialMilestoneDatesandEnrollment"></param>
        /// <param name="pharmacovigilanceRequirements"></param>
        void SavetoSessionforNewStudyForScientificRationaleII(NewStudy newStudy,
                                                     CorrelativeScienceStudies correlativeScienceStudies,
                                                     PlannedTrialMilestoneDatesandEnrollment plannedTrialMilestoneDatesandEnrollment,
                                                     PharmacovigilanceRequirements pharmacovigilanceRequirements)
        {
            objSessionNewStudy = HttpContext.Session.GetComplexData<NewStudy>("SavetoSessionforNewStudy");

            objSessionNewStudy.SampleSizeJustificationandStatisticalAnalysis = newStudy.SampleSizeJustificationandStatisticalAnalysis;
            objSessionNewStudy.InvestigationalSiteProtocolNumber = newStudy.InvestigationalSiteProtocolNumber;
            objSessionNewStudy.ClinicalPharmacology = newStudy.ClinicalPharmacology;
            objSessionNewStudy.IsincludeCorrelativeScience = correlativeScienceStudies.IsincludeCorrelativeScience;
            objSessionNewStudy.BiomarkerStudiesperformedatStudySite = correlativeScienceStudies.BiomarkerStudiesperformedatStudySite;
            objSessionNewStudy.BiomarkerStudiesperformedatCompanySite = correlativeScienceStudies.BiomarkerStudiesperformedatCompanySite;
            objSessionNewStudy.BiomarkerSamplingDetails = correlativeScienceStudies.BiomarkerSamplingDetails;
            objSessionNewStudy.TrialStart = plannedTrialMilestoneDatesandEnrollment.TrialStart;
            objSessionNewStudy.RecruitmentEnd = plannedTrialMilestoneDatesandEnrollment.RecruitmentEnd;
            objSessionNewStudy.TrialEnd = plannedTrialMilestoneDatesandEnrollment.TrialEnd;
            objSessionNewStudy.CompletionofTrialReport = plannedTrialMilestoneDatesandEnrollment.CompletionofTrialReport;
            objSessionNewStudy.PrimaryPublicationDate = plannedTrialMilestoneDatesandEnrollment.PrimaryPublicationDate;
            objSessionNewStudy.TotalPlannedNumberofPatients = plannedTrialMilestoneDatesandEnrollment.TotalPlannedNumberofPatients;
            objSessionNewStudy.PlannedNumberofCenters = plannedTrialMilestoneDatesandEnrollment.PlannedNumberofCenters;
            objSessionNewStudy.EnrollmentHistoryforOtherRelatedStudies = newStudy.EnrollmentHistoryforOtherRelatedStudies;
            objSessionNewStudy.IsCompetingStudies = newStudy.IsCompetingStudies;
            objSessionNewStudy.CompetingStudies = newStudy.CompetingStudies;
            objSessionNewStudy.IsIndsubmission = newStudy.IsIndsubmission;
            objSessionNewStudy.RationaleforINDExemption = newStudy.RationaleforINDExemption;
            objSessionNewStudy.IsIrbregistrationRequirement = newStudy.IsIrbregistrationRequirement;
            objSessionNewStudy.TrialType = pharmacovigilanceRequirements.TrialType;
            objSessionNewStudy.IsAllnonseriousAes = pharmacovigilanceRequirements.IsAllnonseriousAes;
            objSessionNewStudy.IsAllreportsdescribingtheoccurrenceofotherspecialscenarios = pharmacovigilanceRequirements.IsAllreportsdescribingtheoccurrenceofotherspecialscenarios;
            objSessionNewStudy.Safetydata = pharmacovigilanceRequirements.Safetydata;
            objSessionNewStudy.AdverseEventsExemptfromCollection = pharmacovigilanceRequirements.AdverseEventsExemptfromCollection;
            objSessionNewStudy.KeyReferences = newStudy.KeyReferences;

            HttpContext.Session.SetComplexData("SavetoSessionforNewStudy", objSessionNewStudy);
        }

        /// <summary>
        /// Get Scientific Rationale I Details
        /// </summary>
        /// <param name="request"></param>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public JsonResult GetScientificRationaleIDetails([DataSourceRequest] DataSourceRequest request, string studyId)
        {
            try
            {
                if (int.Parse(studyId) == 0)
                    HttpContext.Session.GetString("StudyId");
                var result = objNewStudy.GetScientificRationaleIDetails(int.Parse(studyId));

                return Json(result.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new NewStudy() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }

        /// <summary>
        /// Get Scientific Rationale II Details
        /// </summary>
        /// <param name="request"></param>
        /// <param name="StudyId"></param>
        /// <returns></returns>
        public JsonResult GetScientificRationaleIIDetails([DataSourceRequest] DataSourceRequest request, string StudyId)
        {
            try
            {
                if (int.Parse(StudyId) == 0)
                    HttpContext.Session.GetString("StudyId");
                var result = objNewStudy.GetScientificRationaleIIDetails(int.Parse(StudyId));

                return Json(result.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new NewStudy() { Status = "Failed", ErrorMessage = ex.StackTrace });
            }
        }

        /// <summary>
        /// Get Personal and Research Site Details
        /// </summary>
        /// <param name="request"></param>
        /// <param name="StudyId"></param>
        /// <returns></returns>
        public JsonResult GetPersonalandResearchSiteDetails([DataSourceRequest] DataSourceRequest request, string StudyId)
        {
            try
            {
                if (StudyId == null)
                    StudyId = HttpContext.Session.GetString("StudyId");
                var result = objNewStudy.GetPersonalandResearchSiteDetails(int.Parse(StudyId));
                return Json(result.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new NewStudy() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }

        /// <summary>
        /// Get Contacts
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public JsonResult GetContacts([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                string studyId = HttpContext.Session.GetString("StudyId");
                var result = objNewStudy.GetContacts(int.Parse(studyId));
                return Json(result.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new NewStudy() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }


        /// <summary>
        /// Get Study Sites
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public JsonResult GetStudySites([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                string studyId = HttpContext.Session.GetString("StudyId");
                var result = objNewStudy.GetStudySites(int.Parse(studyId));
                return Json(result.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new NewStudy() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }



        /// <summary>
        /// Get Personal and Research Site Details
        /// </summary>
        /// <param name="request"></param>
        /// <param name="StudyId"></param>
        /// <returns></returns>
        public JsonResult GetRequestedSupportDetails([DataSourceRequest] DataSourceRequest request, string StudyId)
        {
            try
            {
                var result = objNewStudy.GetRequestedSupportDetails(int.Parse(StudyId));

                HttpContext.Session.SetComplexData("RequestedSupportDetails", result);
                return Json(result.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new NewStudy() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }

        /// <summary>
        /// Get Complete New Study Details
        /// </summary>
        /// <param name="request"></param>
        /// <param name="pageId"></param>
        /// <returns></returns>
        public JsonResult GetCompleteNewStudyDetails([DataSourceRequest] DataSourceRequest request/*, int pageId*/)
        {
            try
            {
                return Json(HttpContext.Session.GetComplexData<NewStudy>("SavetoSessionforNewStudy"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new NewStudy() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }

        /// <summary>
        /// Get User Details By User Name
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public JsonResult GetUserDetailsByUserName(string userName, [DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                var result = usersBA.GetUserDetailsByUserName(userName);
                return Json(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new NewStudy() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }

        }


        /// <summary>
        /// Get Investigator Qualifications Data
        /// </summary>
        /// <param name="request"></param>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public JsonResult GetInvestigatorQualificationsData([DataSourceRequest] DataSourceRequest request, string studyId)
        {
            try
            {
                if (int.Parse(studyId) == 0)
                    HttpContext.Session.GetString("StudyId");
                var result = objNewStudy.GetInvestigatorQualificationsData(int.Parse(studyId));

                return Json(result.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new NewStudy() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }


        /// <summary>
        /// Get Science Main Data
        /// </summary>
        /// <param name="request"></param>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public JsonResult GetScienceMainData([DataSourceRequest] DataSourceRequest request, string studyId)
        {
            try
            {
                if (int.Parse(studyId) == 0)
                    HttpContext.Session.GetString("StudyId");
                var result = objNewStudy.GetScienceMainData(int.Parse(studyId));

                return Json(result.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new NewStudy() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }


        /// <summary>
        /// Get Diseases Data
        /// </summary>
        /// <param name="request"></param>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public JsonResult GetDiseasesData([DataSourceRequest] DataSourceRequest request, string studyId)
        {
            try
            {
                if (int.Parse(studyId) == 0)
                    HttpContext.Session.GetString("StudyId");
                var result = objNewStudy.GetDiseasesData(int.Parse(studyId));

                return Json(result.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new NewStudy() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }


        /// <summary>
        /// Get Correlative Sciences Data
        /// </summary>
        /// <param name="request"></param>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public JsonResult GetCorrelativeSciencesData([DataSourceRequest] DataSourceRequest request, string studyId)
        {
            try
            {
                if (int.Parse(studyId) == 0)
                    HttpContext.Session.GetString("StudyId");
                var result = objNewStudy.GetCorrelativeSciencesData(int.Parse(studyId));

                return Json(result.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new NewStudy() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }


        /// <summary>
        /// Get Pharmacovigilance Data
        /// </summary>
        /// <param name="request"></param>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public JsonResult GetPharmacovigilanceData([DataSourceRequest] DataSourceRequest request, string studyId)
        {
            try
            {
                if (int.Parse(studyId) == 0)
                    HttpContext.Session.GetString("StudyId");
                var result = objNewStudy.GetPharmacovigilanceData(int.Parse(studyId));

                return Json(result.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new NewStudy() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }


        /// <summary>
        /// Get Study Enrollment and Timelines Data
        /// </summary>
        /// <param name="request"></param>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public JsonResult GetStudyEnrollmentandTimelinesData([DataSourceRequest] DataSourceRequest request, string studyId)
        {
            try
            {
                if (int.Parse(studyId) == 0)
                    HttpContext.Session.GetString("StudyId");
                var result = objNewStudy.GetStudyEnrollmentandTimelinesData(int.Parse(studyId));

                return Json(result.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new NewStudy() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }


        /// <summary>
        /// Get Pandemic preparedness trial categorization Data
        /// </summary>
        /// <param name="request"></param>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public JsonResult GetPandemicpreparednesstrialcategorizationData([DataSourceRequest] DataSourceRequest request, string studyId)
        {
            try
            {
                if (int.Parse(studyId) == 0)
                    HttpContext.Session.GetString("StudyId");
                var result = objNewStudy.GetPandemicpreparednesstrialcategorizationData(int.Parse(studyId));

                return Json(result.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new NewStudy() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }


        /// <summary>
        /// Get Regulatory requirements Data
        /// </summary>
        /// <param name="request"></param>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public JsonResult GetRegulatoryrequirementsData([DataSourceRequest] DataSourceRequest request, string studyId)
        {
            try
            {
                if (int.Parse(studyId) == 0)
                    HttpContext.Session.GetString("StudyId");
                var result = objNewStudy.GetRegulatoryrequirementsData(int.Parse(studyId));

                return Json(result.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new NewStudy() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }



        /// <summary>
        /// Get IRB Requirement Data
        /// </summary>
        /// <param name="request"></param>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public JsonResult GetIRBRequirementData([DataSourceRequest] DataSourceRequest request, string studyId)
        {
            try
            {
                if (int.Parse(studyId) == 0)
                    HttpContext.Session.GetString("StudyId");
                var result = objNewStudy.GetIRBRequirementData(int.Parse(studyId));

                return Json(result.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new NewStudy() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }


        /// <summary>
        /// Get key references Data
        /// </summary>
        /// <param name="request"></param>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public JsonResult GetkeyreferencesData([DataSourceRequest] DataSourceRequest request, string studyId)
        {
            try
            {
                if (int.Parse(studyId) == 0)
                    HttpContext.Session.GetString("StudyId");
                var result = objNewStudy.GetkeyreferencesData(int.Parse(studyId));

                return Json(result.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new NewStudy() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }


        /// <summary>
        /// Get original financial request Data
        /// </summary>
        /// <param name="request"></param>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public JsonResult GetoriginalfinancialrequestData([DataSourceRequest] DataSourceRequest request, string studyId)
        {
            try
            {
                if (int.Parse(studyId) == 0)
                    HttpContext.Session.GetString("StudyId");
                var result = objNewStudy.GetoriginalfinancialrequestData(int.Parse(studyId));

                return Json(result.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new NewStudy() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }



        /// <summary>
        /// Get Research Group Description Data
        /// </summary>
        /// <param name="request"></param>
        /// <param name="studyId"></param>
        /// <returns></returns>
        public JsonResult GetResearchGroupDescriptionData([DataSourceRequest] DataSourceRequest request, string studyId)
        {
            try
            {
                if (int.Parse(studyId) == 0)
                    HttpContext.Session.GetString("StudyId");
                var result = objNewStudy.GetResearchGroupDescriptionData(int.Parse(studyId));

                return Json(result.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new NewStudy() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }





        /// <summary>
        /// Get Email List
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Json</returns>
        public ActionResult GetEmailList([DataSourceRequest] DataSourceRequest request, int studyId)
        {
            try
            {
                var response = objNewStudy.GetEmailList(studyId);
                HttpContext.Session.SetString("StudyId", studyId.ToString());
                return Json(response.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new EmailList() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }

        /// <summary>
        /// Create Update Email List
        /// </summary>
        /// <param name="emailList"></param>
        /// <param name="mode"></param>
        /// <returns>Json</returns>
        public JsonResult CreateUpdateEmailList(Data.EmailList emailList, string mode, int studyId)
        {
            try
            {
                userName = HttpContext.Session.GetString("Username");
                Data.EmailList result = objNewStudy.CreateUpdateAndDeleteEmailList(emailList, mode, studyId, userName);
                return Json(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                if (mode == "Create")
                    return Json(new TreatmentInformation() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInCreation });
                else
                    return Json(new TreatmentInformation() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInUpdation });
            }
        }

        /// <summary>
        /// Delete Email List
        /// </summary>
        /// <param name="objEmailList"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public JsonResult DeleteEmailList(Data.EmailList objEmailList, string mode, int studyId)
        {
            try
            {
                userName = HttpContext.Session.GetString("Username");
                Data.EmailList result = objNewStudy.CreateUpdateAndDeleteEmailList(objEmailList, mode, studyId, userName);
                return Json(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new TreatmentInformation() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInDeletion });
            }
        }
        /// <summary>
        /// Get CooperativeGroup Name
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public JsonResult GetCooperativeGroupName([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                var result = objNewStudy.GetCooperativeGroupName();
                return Json(result.ToDataSourceResult(request).Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new SysCodeValues() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }

        /// <summary>
        /// Save and Update PersonalResearch details
        /// </summary>
        /// <param name="newstudy"></param>
        /// <param name="personalandResearchDetails"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public JsonResult CreateUpdatePersonalResearchdetails(Data.NewStudy newstudy, List<Data.PrincipalInvestigator> lspersonalandResearchDetails, string mode)
        {

            try
            {
                userName = HttpContext.Session.GetString("Username");
                bool result = objNewStudy.CreateUpdatePersonalResearchdetails(lspersonalandResearchDetails, newstudy, newstudy.StudyId, mode, userName);
                if (result == true)
                    msgType = Utilities.Messages.SuccessStatus;
                else
                {
                    if (mode == "Create")
                        msgType = Utilities.Messages.ProblemInCreation;
                    else
                        msgType = Utilities.Messages.ProblemInUpdation;
                }
                SavetoSessionforNewStudyForPersonalResearchdetails(newstudy, lspersonalandResearchDetails);
                return Json(new { data = message, msgType });
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);

                if (mode == "Create")
                    return Json(new PrincipalInvestigator() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInCreation });
                else
                    return Json(new PrincipalInvestigator() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInUpdation });
            }
        }

        /// <summary>
        /// Save to Session Personal Research details
        /// </summary>
        /// <param name="newstudy"></param>
        /// <param name="personalandResearchDetails"></param>
        void SavetoSessionforNewStudyForPersonalResearchdetails(Data.NewStudy newstudy, List<Data.PrincipalInvestigator> lspersonalandResearchDetails)
        {
            objSessionNewStudy = HttpContext.Session.GetComplexData<NewStudy>("SavetoSessionforNewStudy");
            objSessionNewStudy.lsPayeeInformation = new List<PayeeInformation>();
            var StudyId = HttpContext.Session.GetString("StudyId");
            var results = objNewStudy.GetPersonalandResearchSiteDetails(int.Parse(StudyId));
            foreach (Data.NewStudy newstudyresult in results)
            {
                if (newstudyresult.CategoryID == 1)
                {
                    objSessionNewStudy.Salutation = newstudyresult.Salutation;
                    objSessionNewStudy.FirstName = newstudyresult.FirstName;
                    objSessionNewStudy.LastName = newstudyresult.LastName;
                    objSessionNewStudy.Suffix = newstudyresult.Suffix;
                    objSessionNewStudy.Title = newstudyresult.Title;
                    objSessionNewStudy.Degree = newstudyresult.Degree;
                    objSessionNewStudy.Npinumber = newstudyresult.Npinumber;
                    objSessionNewStudy.Institution = newstudyresult.Institution;
                    objSessionNewStudy.CountryName = newstudy.CountryName;
                    objSessionNewStudy.Address1 = newstudyresult.Address1;
                    objSessionNewStudy.Address2 = newstudyresult.Address2;
                    objSessionNewStudy.CityName = newstudy.CityName;
                    objSessionNewStudy.StateName = newstudy.StateName;
                    objSessionNewStudy.PostalCode = newstudyresult.PostalCode;
                    objSessionNewStudy.Phone = newstudyresult.Phone;
                    objSessionNewStudy.Fax = newstudyresult.Fax;
                    objSessionNewStudy.PrimaryEmailId = newstudyresult.PrimaryEmailId;
                    objSessionNewStudy.MedicalSpecialty = newstudy.MedicalSpecialty;
                    objSessionNewStudy.BoardCertification = newstudy.BoardCertification;
                    objSessionNewStudy.MedicalLicense = newstudy.MedicalLicense;
                    objSessionNewStudy.TrialParticipation = newstudy.TrialParticipation;
                    objSessionNewStudy.NumberOfOngoingTrials = newstudy.NumberOfOngoingTrials;
                    objSessionNewStudy.IsSiteInspectedByHealthAuthority = newstudy.IsSiteInspectedByHealthAuthority;
                    objSessionNewStudy.IsSiteInspectedByFda = newstudy.IsSiteInspectedByFda;
                    objSessionNewStudy.IsCooperativeGroupStudy = newstudy.IsCooperativeGroupStudy;
                    objSessionNewStudy.CooperativeGroupName = newstudy.CooperativeGroupName;
                    objSessionNewStudy.IsPhysicianNetworkStudy = newstudy.IsPhysicianNetworkStudy;
                    objSessionNewStudy.PhysicianNetworkName = newstudy.PhysicianNetworkName;
                    objSessionNewStudy.IsGovernmentSupportProvided = newstudy.IsGovernmentSupportProvided;
                    objSessionNewStudy.SupportDescription = newstudy.SupportDescription;
                    objSessionNewStudy.IsSupportProvidedByOtherSources = newstudy.IsSupportProvidedByOtherSources;
                    objSessionNewStudy.SupportSources = newstudy.SupportSources;
                }
                else
                {
                    PayeeInformation objPayeeInformation = new PayeeInformation();
                    objPayeeInformation.PayeeInformationID = newstudyresult.CategoryID;
                    objPayeeInformation.Salutation = newstudyresult.Salutation;
                    objPayeeInformation.FirstName = newstudyresult.FirstName;
                    objPayeeInformation.LastName = newstudyresult.LastName;
                    objPayeeInformation.Suffix = newstudyresult.Suffix;
                    objPayeeInformation.Title = newstudyresult.Title;
                    objPayeeInformation.Degree = newstudyresult.Degree;
                    objPayeeInformation.Institution = newstudyresult.Institution;
                    objPayeeInformation.CountryName = newstudyresult.CountryName;
                    objPayeeInformation.Address1 = newstudyresult.Address1;
                    objPayeeInformation.Address2 = newstudyresult.Address2;
                    objPayeeInformation.Address3 = newstudyresult.Address3;
                    objPayeeInformation.CityName = newstudyresult.CityName;
                    objPayeeInformation.StateName = newstudyresult.StateName;
                    objPayeeInformation.PostalCode = newstudyresult.PostalCode;
                    objPayeeInformation.Phone = newstudyresult.Phone;
                    objPayeeInformation.Fax = newstudyresult.Fax;
                    objPayeeInformation.PrimaryEmailId = newstudyresult.PrimaryEmailId;
                    objPayeeInformation.TaxID = newstudyresult.TaxID;
                    objSessionNewStudy.lsPayeeInformation.Add(objPayeeInformation);
                }
            }
            HttpContext.Session.SetComplexData("SavetoSessionforNewStudy", objSessionNewStudy);
        }

        /// <summary>
        /// Get Center
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ActionResult GetCenter([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                studyId = int.Parse(HttpContext.Session.GetString("StudyId"));
                var response = objNewStudy.GetCenter(studyId);
                return Json(response.ToDataSourceResult(request));
            }
            catch (Exception ex)

            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new Center() { Status = Utilities.Messages.FailedStatus, ErrorMessage = ex.StackTrace });
            }
        }

        /// <summary>
        /// Create Update Center
        /// </summary>
        /// <param name="objCenter"></param>
        /// <param name="Mode"></param>
        /// <returns></returns>
        public JsonResult CreateUpdateCenter(Data.Center objCenter, string Mode)
        {
            try
            {
                studyId = int.Parse(HttpContext.Session.GetString("StudyId"));
                userName = HttpContext.Session.GetString("Username");
                bool result = objNewStudy.CreateUpdateCenter(objCenter, Mode, studyId, userName);
                if (result == true)
                    msgType = Utilities.Messages.SuccessStatus;
                else
                    msgType = Utilities.Messages.ErrorStatus;

                return Json(new { data = message, msgType });
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new Center() { Status = Utilities.Messages.FailedStatus, ErrorMessage = ex.StackTrace });
            }
        }

        /// <summary>
        /// Delete Center
        /// </summary>
        /// <param name="request"></param>
        /// <param name="center"></param>
        /// <returns></returns>
        public JsonResult DeleteCenter([DataSourceRequest] DataSourceRequest request, Data.Center center)
        {
            try
            {
                bool iDeletecenter = false;
                userName = HttpContext.Session.GetString("Username");
                iDeletecenter = objNewStudy.DeleteCenter(center, userName);
                if (iDeletecenter == true)
                    msgType = Utilities.Messages.SuccessStatus;
                else
                    msgType = Utilities.Messages.ErrorStatus;
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), Utilities.Messages.ProblemInCreation);
            }
            return Json(new { data = message, msgType = msgType });
        }

        /// <summary>
        /// Upload Internal and External Help Documents
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public async Task<ActionResult> SaveHelpDocuments(IEnumerable<IFormFile> helpFiles, string[] additional)
        {
            try
            {
                bool result = true;
                if (helpFiles != null)
                {
                    foreach (var file in helpFiles)
                    {
                        var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                        var studyId = HttpContext.Session.GetString("StudyId");
                        var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
                        var folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, Utilities.Messages.CommonDocuments);
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
                                    SubModuleName = additional[0].ToString(),
                                    StudyId = Convert.ToInt32(studyId),
                                    Path = filePath,
                                    DocumentType = EnumExtension.DisplayName(Utilities.DocumentTypeEnum.Regulatory),
                                    DocumentStatus = EnumExtension.DisplayName(Utilities.DocumentStatusEnum.HelpDocuments),
                                    DocumentSubType = EnumExtension.DisplayName(Utilities.DocumentSubTypeEnum.HelpDocuments),
                                    IsActive = true,
                                    IsDeleted = false,
                                    ANJU_AddedBy = HttpContext.Session.GetString("Username"),
                                    Anju_AddedDate = DateTime.UtcNow

                                };
                                result = objNewStudy.Fileupload(objDocuments);
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
        /// Remove Internal and External Help Documents
        /// </summary>
        /// <param name="fileNames"></param>
        /// <returns></returns>
        public ActionResult RemoveHelpDocuments(string[] fileNames)
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
                        var folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, Utilities.Messages.CommonDocuments);
                        var filePath = Path.Combine(folderPath, fileName);

                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                        result = objNewStudy.DeleteUploadedFile(studyId, username, Utilities.Messages.CommonDocuments, fileName);
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
        /// Upload Personal and Research Documents
        /// </summary>
        /// <param name="files"></param>
        /// <returns>Content</returns>
        public async Task<ActionResult> SaveAsyncPersonalandResearchDocuments(IEnumerable<IFormFile> files)
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
                        var folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "PersonalandResearchSites");

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
                                    SubModuleName = Utilities.Messages.PersonalandResearchSites,
                                    StudyId = Convert.ToInt32(studyId),
                                    Path = filePath,                                    
                                    DocumentType = EnumExtension.DisplayName(Utilities.DocumentTypeEnum.Regulatory),
                                    DocumentStatus = EnumExtension.DisplayName(Utilities.DocumentStatusEnum.PendingReview),
                                    DocumentSubType = EnumExtension.DisplayName(Utilities.DocumentSubTypeEnum.CV),
                                    IsActive = true,
                                    IsDeleted = false,
                                    ANJU_AddedBy = HttpContext.Session.GetString("Username"),
                                    Anju_AddedDate = DateTime.UtcNow
                                };
                                result = objNewStudy.Fileupload(objDocuments);
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

        /// <summary>
        /// Remove the PersonalandResearch uploaded files
        /// </summary>
        /// <param name="fileNames"></param>
        /// <returns></returns>
        public ActionResult RemovePersonalandResearchDocuments(string[] fileNames)
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
                        var folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "PersonalandResearchSites");
                        var filePath = Path.Combine(folderPath, fileName);

                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                        result = objNewStudy.DeleteUploadedFile(studyId, username, Utilities.Messages.PersonalandResearchSites, fileName);
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
        /// Download the uploaded documents
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async Task<IActionResult> DownloadFiles(string fileName, string subModuleFolderName, int? studyId, string path)
        {
            var folderPath = string.Empty;
            try
            {
                if (subModuleFolderName != Utilities.Messages.CommonDocuments && path == null)
                {
                    if (studyId == null)
                        studyId = int.Parse(HttpContext.Session.GetString("StudyId"));

                    if (subModuleFolderName == Utilities.Messages.RequestedSupportAdditionalDocuments)
                        folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "RequestedSupport", "AdditionalDocuments");

                    else
                        folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, subModuleFolderName);
                }
                else
                {
                    //folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", subModuleFolderName);
                    folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, subModuleFolderName);
                }
                var filePath = string.Empty;
                if (!string.IsNullOrEmpty(path))
                {
                    filePath = path;
                }
                else
                    filePath = Path.Combine(folderPath, fileName);

                var memory = new MemoryStream();
                using (var stream = new FileStream(filePath, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }
                memory.Position = 0;
                msgType = Utilities.Messages.SuccessStatus;
                return File(memory, GetContentType(filePath), Path.GetFileName(filePath));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), Utilities.Messages.ProblemInDownload);
            }
            return Json(new { msgType = msgType });
        }

        /// <summary>
        /// Get ContentType
        /// </summary>
        /// <param name="path"></param>
        /// <returns>string</returns>
        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        /// <summary>
        /// Get Mime Types
        /// </summary>
        /// <returns>Dictionary</returns>
        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }

        /// <summary>
        /// Save and Update Requested support details
        /// </summary>
        /// <param name="newstudy"></param>        
        /// <param name="mode"></param>
        /// <returns></returns>
        public JsonResult CreateUpdateRequestedSupportDetails(Data.NewStudy newstudy, Data.Documents objDocument)
        {

            try
            {
                userName = HttpContext.Session.GetString("Username");
                bool result = objNewStudy.CreateUpdateRequestedSupportDetails(newstudy.StudyId, newstudy, userName, objDocument);
                if (result == true)
                    msgType = Utilities.Messages.SuccessStatus;
                else
                {
                    msgType = Utilities.Messages.ProblemInUpdation;
                }
                SavetoSessionforNewStudyForRequestedSupportDetails(newstudy);
                return Json(new { data = message, msgType });
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new NewStudy() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInUpdation });
            }
        }


        /// <summary>
        /// Save to Session Requested Support Details
        /// </summary>
        /// <param name="newstudy"></param>
        void SavetoSessionforNewStudyForRequestedSupportDetails(Data.NewStudy newstudy)
        {
            objSessionNewStudy = HttpContext.Session.GetComplexData<NewStudy>("SavetoSessionforNewStudy");

            objSessionNewStudy.IsRequestedForDrugSupply = newstudy.IsRequestedForDrugSupply;
            objSessionNewStudy.IsRequestedForFinancialSupport = newstudy.IsRequestedForFinancialSupport;
            objSessionNewStudy.BudgetRequestedForTrial = newstudy.BudgetRequestedForTrial;

            HttpContext.Session.SetComplexData("SavetoSessionforNewStudy", objSessionNewStudy);
        }


        /// <summary>
        /// Upload Requested Support Documents
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public async Task<ActionResult> SaveAsyncRequestedSupportDocuments(IEnumerable<IFormFile> files)
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
                        var folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "RequestedSupport");
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
                                    SubModuleName = Utilities.Messages.RequestedSupport,
                                    StudyId = Convert.ToInt32(studyId),
                                    DocumentType = EnumExtension.DisplayName(Utilities.DocumentTypeEnum.Budget),
                                    DocumentStatus = EnumExtension.DisplayName(Utilities.DocumentStatusEnum.PendingReview),
                                    DocumentSubType = EnumExtension.DisplayName(Utilities.DocumentSubTypeEnum.Draft),
                                    Path = filePath,
                                    IsActive = true,
                                    IsDeleted = false,
                                    ANJU_AddedBy = HttpContext.Session.GetString("Username"),
                                    Anju_AddedDate = DateTime.UtcNow

                                };
                                result = objNewStudy.Fileupload(objDocuments);
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
        /// Upload Requested Patient Accrual Documents
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public async Task<ActionResult> SaveAsyncPatientAccrualDocuments(IEnumerable<IFormFile> files)
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
                        var folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "PatientAccrual");
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
                                    SubModuleName = Utilities.Messages.RequestedSupport,
                                    StudyId = Convert.ToInt32(studyId),
                                    DocumentType = EnumExtension.DisplayName(Utilities.DocumentTypeEnum.Budget),
                                    DocumentStatus = EnumExtension.DisplayName(Utilities.DocumentStatusEnum.PendingReview),
                                    DocumentSubType = EnumExtension.DisplayName(Utilities.DocumentSubTypeEnum.Draft),
                                    Path = filePath,
                                    IsActive = true,
                                    IsDeleted = false,
                                    ANJU_AddedBy = HttpContext.Session.GetString("Username"),
                                    Anju_AddedDate = DateTime.UtcNow

                                };
                                result = objNewStudy.Fileupload(objDocuments);
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
        public ActionResult RemoveRequestedSupportDocuments(string[] fileNames)
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
                        var folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "RequestedSupport");
                        var filePath = Path.Combine(folderPath, fileName);

                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                        result = objNewStudy.DeleteUploadedFile(studyId, username, Utilities.Messages.RequestedSupport, fileName);
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
        /// Remove the Patient Accrual uploaded files
        /// </summary>
        /// <param name="fileNames"></param>
        /// <returns></returns>
        public ActionResult RemovePatientAccrualDocuments(string[] fileNames)
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
                        var folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "PatientAccrual");
                        var filePath = Path.Combine(folderPath, fileName);

                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                        result = objNewStudy.DeleteUploadedFile(studyId, username, Utilities.Messages.RequestedSupport, fileName);
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
        /// Upload Requested Support Additional Documents
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public async Task<ActionResult> SaveAsyncRequestedSupportAdditionalDocuments(IEnumerable<IFormFile> Additionalfiles)
        {
            try
            {
                bool result = true;
                if (Additionalfiles != null)
                {
                    foreach (var file in Additionalfiles)
                    {
                        var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                        var studyId = HttpContext.Session.GetString("StudyId");
                        var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
                        var folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "RequestedSupport", "AdditionalDocuments");
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
                                    SubModuleName = Utilities.Messages.RequestedSupportAdditionalDocuments,
                                    StudyId = Convert.ToInt32(studyId),
                                    Path = filePath,
                                    DocumentType = EnumExtension.DisplayName(Utilities.DocumentTypeEnum.SubmissionSupport),
                                    DocumentStatus = EnumExtension.DisplayName(Utilities.DocumentStatusEnum.PendingReview),
                                    DocumentSubType = EnumExtension.DisplayName(Utilities.DocumentSubTypeEnum.AdditionalDocuments),
                                    IsActive = true,
                                    IsDeleted = false,
                                    ANJU_AddedBy = HttpContext.Session.GetString("Username"),
                                    Anju_AddedDate = DateTime.UtcNow

                                };
                                result = objNewStudy.Fileupload(objDocuments);
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
        /// Remove the Requested Support Additional uploaded files
        /// </summary>
        /// <param name="fileNames"></param>
        /// <returns></returns>
        public ActionResult RemoveRequestedSupportAdditionalDocuments(string[] fileNames)
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
                        var folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "RequestedSupportDocuments", "AdditionalDocuments");
                        var filePath = Path.Combine(folderPath, fileName);

                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                        result = objNewStudy.DeleteUploadedFile(studyId, username, Utilities.Messages.RequestedSupportAdditionalDocuments, fileName);
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
        /// Delete Study
        /// </summary>
        /// <param name="studyId"></param>
        public void DeleteStudy(int studyId)
        {
            try
            {
                var username = HttpContext.Session.GetString("Username");
                objNewStudy.DeleteStudy(studyId, username);
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
            }
        }


        /// <summary>
        /// Delete Documents
        /// </summary>
        /// <param name="request"></param>
        /// <param name="documents"></param>
        /// <returns>Json</returns>
        public JsonResult DeleteDocuments([DataSourceRequest] DataSourceRequest request, Documents documents)
        {
            try
            {
                bool isDocumentDeleted = objNewStudy.DeleteDocuments(documents);
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
        /// Undelete Documents
        /// </summary>
        /// <param name="request"></param>
        /// <param name="docid"></param>
        /// <param name="studyid"></param>
        /// <returns></returns>
        public JsonResult UndeleteDocuments([DataSourceRequest] DataSourceRequest request, int docid, int studyid)
        {
            try
            {
                var username = HttpContext.Session.GetString("Username");
                bool isDocumentDeleted = objNewStudy.UndeleteDocuments(docid,studyid, username);
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
        /// Save Confirmation details
        /// </summary>
        /// <param name="newstudy"></param>        
        /// <returns>JsonResult</returns>
        public JsonResult SaveConfirmationDetails(Data.NewStudy newstudy)
        {
            try
            {
                bool result = objNewStudy.UpdateConfirmationDetails(newstudy);
                if (result == true)
                {
                    msgType = Utilities.Messages.SuccessStatus;
                    NewStudyWorkflow workflow = new NewStudyWorkflow();
                    workflow.CreateWorkFlow(newstudy.StudyId, HttpContext.Session.GetString("AuthenticUser"),
                        HttpContext.Session.GetString("Username"));

                }
                else
                {
                    msgType = Utilities.Messages.ProblemInUpdation;
                }
                return Json(new { data = message, msgType });
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new PrincipalInvestigator() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInUpdation });
            }
        }

        /// <summary>
        /// Get Documents by study ID
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Json</returns>
        public ActionResult GetDocuments([DataSourceRequest] DataSourceRequest request, int studyId)
        {
            try
            {
                var response = objNewStudy.GetDocumentList(studyId);
                return Json(response.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new Documents() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }

        /// <summary>
        /// Get Documents by study ID
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Json</returns>
        public ActionResult GetPIDocuments([DataSourceRequest] DataSourceRequest request, int studyId, string PIuserName)
        {
            try
            {
                var response = objNewStudy.GetPIDocumentList(studyId, PIuserName);
                return Json(response.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new Documents() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }

        /// <summary>
        /// Get Institute By study
        /// </summary>
        /// <param name="studyId"></param>
        /// <param name="request"></param>
        /// <returns>Json</returns>
        public String GetInstituteBystudyId(int studyId, [DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                return objNewStudy.GetPIInstituteByStudyID(studyId);

            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Utilities.Messages.FetchError;
            }
        }

        /// <summary>
        /// Get Msl Changed Institute By study
        /// </summary>
        /// <param name="studyId"></param>
        /// <param name="request"></param>
        /// <returns>Json</returns>
        public String GetChangedInstituteBystudyId(int studyId, [DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                return objNewStudy.GetMSLChangedInstituteBystudyId(studyId);

            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Utilities.Messages.FetchError;
            }
        }

        /// <summary>
        /// Get Indication By study
        /// </summary>
        /// <param name="studyId"></param>
        /// <param name="request"></param>
        /// <returns>Json</returns>
        public String GetIndicationByStudyID(int studyId, [DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                return objNewStudy.GetPIIndicationByStudyID(studyId);

            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Utilities.Messages.FetchError;
            }
        }

        /// <summary>
        /// Get Title of trial By study
        /// </summary>
        /// <param name="studyId"></param>
        /// <param name="request"></param>
        /// <returns>Json</returns>
        public String GetTitleOfTrialByStudyID(int studyId, [DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                return objNewStudy.GetPITitleOfTrialByStudyID(studyId);

            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Utilities.Messages.FetchError;
            }
        }

        /// <summary>
        /// Get username By studyId and usertype
        /// </summary>
        /// <param name="studyId"></param>
        /// <param name="userType"></param>
        /// <param name="request"></param>
        /// <returns>Json</returns>
        public String GetUserNameByUserTypeAndStudyId(int studyId, string userType, [DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                return objNewStudy.GetUserNameByUserTypeAndStudyId(studyId, userType);

            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Utilities.Messages.FetchError;
            }
        }


        /// <summary>
        /// Get Other Attributes Data
        /// </summary>
        /// <param name="request"></param>
        /// <param name="studyId"></param>
        /// <returns>Json</returns>
        public JsonResult GetOtherAttributesData([DataSourceRequest] DataSourceRequest request, string studyId)
        {
            try
            {
                if (int.Parse(studyId) == 0)
                    HttpContext.Session.GetString("StudyId");
                var result = objNewStudy.GetOtherAttributesData(int.Parse(studyId));

                return Json(result.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new NewStudy() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }


        /// <summary>
        /// Get Related Users Associated with a Study
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Json</returns>
        public ActionResult GetRelatedUsersAssociatedwithaStudy([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                studyId = int.Parse(HttpContext.Session.GetString("StudyId"));
                var response = usersBA.GetRelatedUsersAssociatedwithaStudy(studyId);
                return Json(response.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new TreatmentInformation() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }


        /// <summary>
        /// Create/Update Study Compounds
        /// </summary>
        /// <param name="studyCompounds"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public JsonResult CreateUpdateStudyCompounds(Data.StudyCompounds studyCompounds, string mode)
        {
            try
            {
                studyId = int.Parse(HttpContext.Session.GetString("StudyId"));
                userName = HttpContext.Session.GetString("Username");
                bool result = objNewStudy.CreateUpdateStudyCompounds(studyCompounds, mode, studyId, userName);
                if (result == true)
                {
                    msgType = Utilities.Messages.SuccessStatus;
                }
                else
                    msgType = Utilities.Messages.ErrorStatus;

                return Json(new { data = message, msgType });
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                if (this.mode == "Create")
                    return base.Json(new CohortLevels() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInCreation });
                else
                    return base.Json(new CohortLevels() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInUpdation });
            }
        }

        /// <summary>
        /// Get Study Compounds
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ActionResult GetStudyCompounds([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                studyId = int.Parse(HttpContext.Session.GetString("StudyId"));
                var response = objNewStudy.GetStudyCompounds(studyId);
                return Json(response.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new CohortLevels() { Status = Utilities.Messages.FailedStatus, ErrorMessage = ex.StackTrace });
            }
        }

        /// <summary>
        /// Delete Study Compounds
        /// </summary>
        /// <param name="request"></param>
        /// <param name="studyCompounds"></param>
        /// <returns></returns>
        public JsonResult DeleteStudyCompounds([DataSourceRequest] DataSourceRequest request, Data.StudyCompounds studyCompounds)
        {
            try
            {
                userName = HttpContext.Session.GetString("Username");
                bool isDeletecohortLevels = objNewStudy.DeleteStudyCompounds(studyCompounds, userName);
                if (isDeletecohortLevels == true)
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
        /// Update Science Main details
        /// </summary>
        /// <param name="newStudy"></param>
        /// <returns></returns>
        public JsonResult SaveUpdateEditdetails(NewStudy objEditstudy, int type, string mode)
        {
            try
            {
                usertype = HttpContext.Session.GetString("UserType");
                userName = HttpContext.Session.GetString("Username");
                objEditstudy.ANJU_ChangedBy = userName;
                objEditstudy.ANJU_AddedBy = userName;
                bool result = objNewStudy.SaveUpdateEditdetails(objEditstudy, type, usertype, mode, userName);
                if (result == true)
                    msgType = Utilities.Messages.SuccessStatus;
                else
                    msgType = Utilities.Messages.ProblemInUpdation;
                return Json(new { data = message, msgType = msgType });
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString());
            }
            return Json(new { Data = message, msgType = msgType });
        }

        /// <summary>
        /// Get Documents By StudyID
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Json</returns>
        public JsonResult GetDocumentsByStudyID([DataSourceRequest] DataSourceRequest request, int studyId, string subModuleName)
        {
            try
            {

                var result = objNewStudy.GetDocumentsByStudyID(studyId, subModuleName);
                return Json(result.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new Documents() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }



        /// <summary>
        /// Get Submissions By Study ID
        /// </summary>
        /// <param name="request"></param>
        /// <param name="studyId"></param>
        /// <returns>Json</returns>
        public JsonResult GetSubmissionsByStudyID([DataSourceRequest] DataSourceRequest request, int studyId)
        {
            try
            {
                var result = objNewStudy.GetSubmissionsByStudyID(studyId);
                return Json(result.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new Submissions() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }

        /// <summary>
        /// Delete Submissions
        /// </summary>
        /// <param name="request"></param>
        /// <param name="milestones"></param>
        /// <returns>Json</returns>
        public JsonResult DeleteSubmissions([DataSourceRequest] DataSourceRequest request, Data.Submissions submissions)
        {
            try
            {
                userName = HttpContext.Session.GetString("Username");
                bool isDeleteMilestones = objNewStudy.DeleteSubmissions(submissions, userName);
                if (isDeleteMilestones == true)
                    msgType = Utilities.Messages.SuccessStatus;
                else
                    msgType = Utilities.Messages.ProblemInDeletion;
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), Utilities.Messages.ProblemInDeletion);
                return Json(new ObjectivesandEndpoints() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.ProblemInDeletion });

            }
            return Json(new { data = message, msgType = msgType });
        }





        /// <summary>
        /// Upload Requested Protocol Documents
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public async Task<ActionResult> SaveAsyncRequestedSupportProtocolDocuments(IEnumerable<IFormFile> Protocolfile)
        {
            try
            {
                bool result = true;
                if (Protocolfile != null)
                {
                    foreach (var file in Protocolfile)
                    {
                        var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                        var studyId = HttpContext.Session.GetString("StudyId");
                        var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
                        var folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "RequestedSupport", "ProtocolDocuments");
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
                                    SubModuleName = Utilities.Messages.RequestedSupportProtocolDocuments,
                                    StudyId = Convert.ToInt32(studyId),
                                    Path = filePath,
                                    DocumentType = EnumExtension.DisplayName(Utilities.DocumentTypeEnum.Regulatory),
                                    DocumentStatus = EnumExtension.DisplayName(Utilities.DocumentStatusEnum.PendingReview),
                                    DocumentSubType = EnumExtension.DisplayName(Utilities.DocumentSubTypeEnum.Protocol),
                                    IsActive = true,
                                    IsDeleted = false,
                                    ANJU_AddedBy = HttpContext.Session.GetString("Username"),
                                    Anju_AddedDate = DateTime.UtcNow

                                };
                                result = objNewStudy.Fileupload(objDocuments);
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
        /// Remove the Requested Support Protocol files
        /// </summary>
        /// <param name="fileNames"></param>
        /// <returns></returns>
        public ActionResult RemoveRequestedSupportProtocollDocuments(string[] fileNames)
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
                        var folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "RequestedSupportDocuments", "ProtocolDocuments");
                        var filePath = Path.Combine(folderPath, fileName);

                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                        result = objNewStudy.DeleteUploadedFile(studyId, username, Utilities.Messages.RequestedSupportProtocolDocuments, fileName);
                    }
                }
                return Content(Utilities.Messages.SuccessStatus);
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), Utilities.Messages.ProblemInRemoval);
            }
            return Json(new { msgType = msgType });
        }

        /// <summary>
        /// Get Indications
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ActionResult GetIndications([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                studyId = int.Parse(HttpContext.Session.GetString("StudyId"));
                var response = objNewStudy.GetIndications(studyId);
                return Json(response.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new StudyIndication() { Status = "Failed", ErrorMessage = ex.StackTrace });
            }
        }
        /// <summary>
        /// Get Study Task Details
        /// </summary>
        /// <param name="studyId"></param>
        /// <returns>List of Study</returns>ns>
        public JsonResult GetStudyTaskDetails([DataSourceRequest] DataSourceRequest request, int studyId)
        {
            try
            {

                var result = objNewStudy.GetStudyTaskDetails(studyId);
                return Json(result.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new Documents() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }

        /// <summary>
        /// Get Study Protocols
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ActionResult GetStudyProtocols([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                studyId = int.Parse(HttpContext.Session.GetString("StudyId"));
                var response = objNewStudy.GetStudyProtocols(studyId);
                return Json(response.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new StudyIndication() { Status = "Failed", ErrorMessage = ex.StackTrace });
            }
        }


        /// <summary>
        /// Get Invoices details
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ActionResult GetInvoicesdetails([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                studyId = int.Parse(HttpContext.Session.GetString("StudyId"));
                var response = objNewStudy.GetInvoicesdetails(studyId);
                return Json(response.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new Invoicedetails() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }



        /// <summary>
        /// Get Contracts Timeline
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ActionResult GetContractsTimeline([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                studyId = int.Parse(HttpContext.Session.GetString("StudyId"));
                var response = objNewStudy.GetContractsTimeline(studyId);
                return Json(response.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new Contracttimelines() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }



        /// <summary>
        /// Get Status
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ActionResult GetStatus([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                studyId = int.Parse(HttpContext.Session.GetString("StudyId"));
                var response = objNewStudy.GetStatusdetails(studyId);
                return Json(response.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new Status() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }


        /// <summary>
        /// Get Reviews and Notes
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ActionResult GetReviewsandNotes([DataSourceRequest] DataSourceRequest request)
        {
            try
            {
                studyId = int.Parse(HttpContext.Session.GetString("StudyId"));
                var response = objNewStudy.GetReviewsandNotes(studyId);
                return Json(response.ToDataSourceResult(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new ReviewsandNotes() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }


        /// <summary>
        /// ReUpload ProtocolDocuments
        /// </summary>
        /// <param name="fileReUploadProtocolDoc"></param>
        /// <returns></returns>
        public async Task<ActionResult> SaveReuploadProtocolDocuments(IEnumerable<IFormFile> fileReUploadProtocolDoc)
        {
            try
            {
                bool result = true;
                if (fileReUploadProtocolDoc != null)
                {
                    foreach (var file in fileReUploadProtocolDoc)
                    {
                        var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
                        var studyId = HttpContext.Session.GetString("StudyId");
                        var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));
                        var folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "RequestedSupport", "ProtocolDocuments");

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
                                    SubModuleName = Utilities.Messages.RequestedSupportProtocolDocuments,
                                    StudyId = Convert.ToInt32(studyId),
                                    Path = filePath,
                                    DocumentType = EnumExtension.DisplayName(Utilities.DocumentTypeEnum.Regulatory),
                                    DocumentStatus = EnumExtension.DisplayName(Utilities.DocumentStatusEnum.PendingReview),
                                    DocumentSubType = EnumExtension.DisplayName(Utilities.DocumentSubTypeEnum.Protocol),
                                    IsActive = false,
                                    IsDeleted = true,
                                    IsSubmit = true,
                                    ANJU_AddedBy = HttpContext.Session.GetString("Username"),
                                    Anju_AddedDate = DateTime.UtcNow

                                };
                                result = objNewStudy.Fileupload(objDocuments);
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
        /// Remove the protocol Reuploaded files
        /// </summary>
        /// <param name="fileNames"></param>
        /// <returns></returns>
        public ActionResult RemoveReuploadProtocolDocuments(string[] fileNames)
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
                        var folderPath = Path.Combine(Utilities.ConfigValues.DocumentsUploadFolderPath, "DocumentsUpload", "Study" + studyId, "RequestedSupport", "ProtocolDocuments");
                        var filePath = Path.Combine(folderPath, fileName);

                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                        result = objNewStudy.DeleteUploadedFile(studyId, username, Utilities.Messages.ICFDocument, fileName);
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



