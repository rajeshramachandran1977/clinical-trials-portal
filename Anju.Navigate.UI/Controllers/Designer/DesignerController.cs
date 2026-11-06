using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using Anju.Navigate.BusinessAccess.Workflow;
using Anju.Navigate.DataAccess;
using Anju.Navigate.UI.Models;
using Microsoft.AspNetCore.Mvc;
using OptimaJet.Workflow;
using WorkflowRuntime = OptimaJet.Workflow.Core.Runtime.WorkflowRuntime;

namespace Anju.Navigate.UI.Controllers.Designer
{
    public class DesignerController : Controller
    {
        private readonly Navigate30Context _context;

        private static Guid? processId = null;


        public DesignerController()
        {
            _context = new Navigate30Context();

        }

        public IActionResult Index()
        {

            var schemes = (from code in _context.WorkflowScheme
                           select new Scheme
                           {
                               Id = code.Code,
                               Code = code.Code
                           }).ToList();
            schemes.Insert(0, new Scheme { Id = "0", Code = "Select Scheme to Load" });
            ViewBag.Schemes = schemes;
            return View();
        }

        public JsonResult Delete(string scheme)
        {
            var schemes = (from workflow in _context.WorkflowScheme
                           where workflow.Code.Equals(scheme)
                           select workflow).FirstOrDefault();

            _context.WorkflowScheme.Remove(schemes ?? throw new InvalidOperationException());
            _context.SaveChanges();

            return Json(true);
        }

        public JsonResult Create(string schemeName)
        {
            processId = Guid.NewGuid();
            WorkflowInit.Runtime.CreateInstance(schemeName, processId.Value);
            return Json(processId);

        }

        #region "Workflow"

        public IActionResult API()
        {
            Stream filestream = null;
            var isPost = Request.Method.Equals("POST", StringComparison.OrdinalIgnoreCase);
            if (isPost && Request.Form.Files != null && Request.Form.Files.Count > 0)
                filestream = Request.Form.Files[0].OpenReadStream();

            var pars = new NameValueCollection();
            foreach (var q in Request.Query)
            {
                pars.Add(q.Key, q.Value.First());
            }


            if (isPost)
            {
                var parsKeys = pars.AllKeys;
                //foreach (var key in Request.Form.AllKeys)
                foreach (var key in Request.Form.Keys)
                {
                    if (!parsKeys.Contains(key))
                    {
                        pars.Add(key, Request.Form[key]);
                    }
                }
            }

            string res = GetRuntime.DesignerAPI(pars, out bool errors, filestream);
            if (!errors)
            {
                if (pars["operation"].ToLower() == "downloadscheme")
                    return File(Encoding.UTF8.GetBytes(res), "text/xml", "scheme.xml");
                if (pars["operation"].ToLower() == "downloadschemebpmn")
                    return File(Encoding.UTF8.GetBytes(res), "text/xml", "scheme.bpmn");

                return Content(res);
            }
            return Content(string.Empty);
        }

        private WorkflowRuntime GetRuntime => Anju.Navigate.BusinessAccess.Workflow.WorkflowInit.Runtime;

        #endregion

    }
}
