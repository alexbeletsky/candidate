using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Candidate.Core.Settings;
using Candidate.Infrustructure.Error;
using Config = Candidate.Core.Model.Configurations;

namespace Candidate.Areas.Deployment.Controllers
{
    [Authorize]
    [HandleJsonError]
    public class DeployController : Controller
    {
        private readonly ISettingsManager _settingsManager;

        public DeployController(ISettingsManager settingsManager)
        {
            _settingsManager = settingsManager;
        }

        [HttpGet, ActionName("batch")]
        public ActionResult DeployBatch(string id)
        {
            var configuration = _settingsManager.ReadConfiguration<Config.BatchConfiguration>(id);
            return View("Deploy", configuration);
        }

        [HttpPost, ActionName("batch")]
        public ActionResult DeployBatch(Config.BatchConfiguration configuration)
        {
            if (ModelState.IsValid)
            {
                return View("Action", configuration);
            }

            return View();
        }


        //[HttpGet, ActionName("deploy")]
        //public ActionResult Deploy(string id)
        //{
        //    var configuration = _settingsManager.ReadConfiguration<Config.Configuration>(id);
        //    return View(configuration);
        //}

        //[HttpPost, ActionName("deploy")]
        //public ActionResult PostDeploy(string id)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // TODO: ABE return NotConfigured if NotConfigured..
        //        var configuration = _settingsManager.ReadConfiguration<Config.Configuration>(id);

        //        return View("Action", configuration);
        //    }

        //    return View();
        //}

        //[HttpPost, ActionName("start")]
        //public ActionResult StartDeploy(string id)
        //{
        //    return Json(new { success = true, result = new { Url = "http://localhost" } });
        //}
    }
}
