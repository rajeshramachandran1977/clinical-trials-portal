using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Anju.Navigate.BusinessAccess;
using Anju.Navigate.Data;
using Anju.Navigate.Utilities;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Anju.Navigate.Utilities.Logger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.FileProviders;
using System.IO;
using System.Net.Http.Headers;



namespace Anju.Navigate.UI.Controllers.MetaData
{
    public class MetaDataController : Controller
    {

        private readonly IAppLogger<MetaDataController> _logger = null;        
         UsersBA users = new UsersBA();
        AdministrationBA objMetadat = new AdministrationBA();
        string message = string.Empty;
        string msgType = string.Empty;
        List<string> userType = new List<string>();

        public PartialViewResult MetaData()
        {          
            return PartialView();
        }
        public JsonResult GetSysCodeValues([DataSourceRequest] DataSourceRequest request, string type)
        {
            try
            {
                var result = users.GetSysCodeValues(type);
                for (int i = 0; i < result.Count; i++) {
                    userType.Add(result[i].Code);
                }
                ViewBag.userValues = userType;
                return Json(ViewBag.userValues);
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new SysCodeValues() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }

        /// <summary>
        /// Get Meta data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetMetaData([DataSourceRequest] DataSourceRequest request, int? id)
        {
            try
            {
                int attributeid = id??0 ;
                var result = objMetadat.GetMetaData(attributeid);
                return Json(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new SysCodeValues() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }


        public JsonResult GetEntityAttributeValues( int? id)
        {
            try
            {
               
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new SysCodeValues() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }
    }
}