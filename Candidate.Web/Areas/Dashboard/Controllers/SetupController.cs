using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Candidate.Core.Settings;
using Candidate.Areas.Dashboard.Models;

namespace Candidate.Areas.Dashboard.Controllers
{
    public class SetupController : Controller
    {
        private ISettingsManager _settingsManager;

        public SetupController(ISettingsManager settingsManager)
        {
            _settingsManager = settingsManager;
        }

        [HttpGet]
        public ActionResult Setup(string jobName)
        {
            ViewBag.JobName = jobName;
            return View();
        }

        [HttpGet]
        public JsonResult StartSetup(string jobName)
        {
            var currentSettings = _settingsManager.ReadSettings<SetupStatesModel>();
            var curentState = currentSettings.States.Where(s => s.JobName == jobName).SingleOrDefault();

            if (curentState == null)
            {
                curentState = new SetupStateModel();
                currentSettings.States.Add(curentState);
            }

            return Json(new { success = true, setupInitInfo = new { isRepoCloned = curentState.IsRepoCloned } }, JsonRequestBehavior.AllowGet);
        }
    }
}
