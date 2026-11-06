using Anju.Navigate.BusinessAccess;
using Anju.Navigate.Data;
using Anju.Navigate.Utilities;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Anju.Navigate.Utilities.Logger;

namespace Anju.Navigate.UI.Controllers.Search
{
    public class SearchController : Controller
    {
        #region Variable Declarations
        private readonly IAppLogger<SearchController> _logger = null;
        SearchBA searchBA = new SearchBA();

        #endregion

        #region Constructor
        public SearchController(IAppLogger<SearchController> logger)
        {
            this._logger = logger;

        }

        #endregion

        #region Views

        public PartialViewResult SearchResult()
        {
            var model = searchBA.GetAttributeName();
            return PartialView(model);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get Attribute for Dropdown
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Json</returns>
        public JsonResult GetAttribute()
        {
            try
            {
                var result = searchBA.GetAttributeName();
                return Json(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new SysCodeValues() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }

        /// <summary>
        /// Get Search Result
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Json</returns>
        public JsonResult GetSearchResult([DataSourceRequest] DataSourceRequest request, List<Data.AttributeSearch> lsAttributeSearch,string matchCriteria)
        {
            try
            {
                var result = searchBA.SearchResult(lsAttributeSearch,matchCriteria);
                return Json(result.ToDataSourceResult(request));
                

            }
            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new SysCodeValues() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }

        /// <summary>
        /// Get Quick Search Result
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Json</returns>
        public JsonResult GetQuickSearchResult([DataSourceRequest] DataSourceRequest request, string matchCriteria)
        {
            try
            {
                var result = searchBA.QuickSearchResult(matchCriteria);
                return Json(result.ToDataSourceResult(request));
            }

            catch (Exception ex)
            {
                _logger.LogError(ResponseType.Exception.ToId(), ex.ToFullString(), null);
                return Json(new SysCodeValues() { Status = Utilities.Messages.FailedStatus, ErrorMessage = Utilities.Messages.FetchError });
            }
        }




        #endregion
    }
}