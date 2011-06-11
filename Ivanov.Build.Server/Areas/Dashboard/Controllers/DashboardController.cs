using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Ivanov.Build.Server.Core.Settings;
using Ivanov.Build.Server.Areas.Dashboard.Models;
using Ivanov.Build.Server.Core.System;
using System.IO;

namespace Ivanov.Build.Server.Areas.Dashboard.Controllers
{
    public class DashboardController : Controller
    {
        private ISettingsManager _settingsManager;

        public DashboardController(ISettingsManager settingsManager)
        {
            _settingsManager = settingsManager;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var currentSettings = _settingsManager.ReadSettings<JobsSettingsModel>();

            return View(currentSettings.Jobs);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(NewJobModel newJob)
        {
            var currentSettings = _settingsManager.ReadSettings<JobsSettingsModel>();
            var currentJobs = currentSettings.Jobs;

            currentJobs.Add(new JobModel { Name = newJob.Name, Status = 0 });
            _settingsManager.SaveSettings(currentSettings);

            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Delete(string jobName)
        {
            return View(new DeleteJobModel { JobName = jobName });
        }

        [HttpPost]
        public ActionResult Delete(DeleteJobModel deleteJob)
        {
            var currentSettings = _settingsManager.ReadSettings<JobsSettingsModel>();
            var currentJobs = currentSettings.Jobs.Remove(currentSettings.Jobs.Where(j => j.Name == deleteJob.JobName).SingleOrDefault());
            _settingsManager.SaveSettings(currentSettings);

            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Run(string jobName)
        {
            ViewBag.JobName = jobName;
            return View();
        }
    }
}
