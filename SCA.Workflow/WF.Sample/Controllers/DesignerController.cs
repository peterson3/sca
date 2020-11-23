﻿using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OptimaJet.Workflow;
using WF.Sample.Business.Workflow;


namespace WF.Sample.Controllers
{
    public class DesignerController : Controller
    {
        public ActionResult Index(string schemeName)
        {
            return View();
        }

        //[EnableCors("AllowAll")]
        public IActionResult API()
        {
            Stream filestream = null;
            Request.Headers.Add("Access-Control-Allow-Origin", "*");
            Request.Headers.Add("Access-Control-Allow-Credentials", "true");
            Request.Headers.Add("Access-Control-Allow-Methods", "GET,PUT,POST,DELETE,HEAD,OPTIONS");

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

            var res = WorkflowInit.Runtime.DesignerAPI(pars, out bool hasError, filestream, true);

            if (pars["operation"].ToLower() == "downloadscheme" && !hasError)
                return File(Encoding.UTF8.GetBytes(res), "text/xml");
            if (pars["operation"].ToLower() == "downloadschemebpmn" && !hasError)
                return File(Encoding.UTF8.GetBytes(res), "text/xml");

            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            Response.Headers.Add("Access-Control-Allow-Credentials", "true");
            Response.Headers.Add("Access-Control-Allow-Methods", "GET,PUT,POST,DELETE,HEAD,OPTIONS");


            return Content(res);

        }

    }
}
