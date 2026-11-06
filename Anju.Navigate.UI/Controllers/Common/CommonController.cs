using Anju.Navigate.BusinessAccess;
using Anju.Navigate.Data;
using Anju.Navigate.Utilities;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using Anju.Navigate.Utilities.Logger;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Anju.Navigate.UI.Controllers
{
    public class CommonController : Controller
    {
        #region Variable Declarations

        private readonly IAppLogger<CommonController> _logger = null;        
        CommonBA cmnBA = new CommonBA();
        private string msgType;

        public IConfiguration Configuration { get; set; }

        #endregion

        #region Constructor
        public CommonController(IAppLogger<CommonController> logger)
        {
            this._logger = logger;

        }
        #endregion

        #region Views

        public IActionResult Index()
        {
            return View();
        }
        #endregion

        #region Methods

        /// <summary>
        /// Get Gender
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public JsonResult GetGender([DataSourceRequest] DataSourceRequest request)
        {
            Exception exception = null;
            try
            {
                var result = cmnBA.GetGender();
                return Json(result.ToDataSourceResult(request).Data);
            }
            catch (Exception ex)
            {
                exception = ex;
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new NewStudy() { Status = "Failed", ErrorMessage = ex.StackTrace });
            }
        }

        /// <summary>
        /// Get email address
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public JsonResult GetHelpEmailAddress([DataSourceRequest] DataSourceRequest request)
        {
            Exception exception = null;
            try
            {
                var result = cmnBA.GetHelpEmailAddress();
                return Json(result);
            }
            catch (Exception ex)
            {
                exception = ex;
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new NewStudy() { Status = "Failed", ErrorMessage = ex.StackTrace });
            }
        }

        /// <summary>
        /// Send Mail
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public JsonResult SendEmail([DataSourceRequest] DataSourceRequest request, string mailMessage,List<string> lsparameter,string subParam,string toMail,string ccMail)
        {
            string subject = string.Empty;
            try
            {
                var studyId =Convert.ToInt32(HttpContext.Session.GetString("StudyId"));
                string title = mailMessage;
                string jsonFilePath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "MailConfig.json");

                string json =System.IO.File.ReadAllText(jsonFilePath);
                JObject jsonObject = JObject.Parse(json);
                
                subject = (string)jsonObject[title]["Subject"];
                if (!string.IsNullOrEmpty(subParam))
                    subject = subject.Replace("SubParam", subParam);               

                string mailbody= (string)jsonObject[title]["Body"];
                var result1 = cmnBA.SendMail(mailbody, toMail, subject, lsparameter,studyId,ccMail);

                return Json(new SysCodeValues() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError }); 

            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString() +" Mail message:" + subject, null);
                return Json(new SysCodeValues() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }
        #endregion
    }
}