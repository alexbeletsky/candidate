using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Ivanov.Build.Server.Core.Settings;
using Ivanov.Build.Server.Areas.Dashboard.Models;
using Ivanov.Build.Server.Core.System;

namespace Ivanov.Build.Server.Areas.Dashboard.Controllers
{
    public class DashboardController : Controller
    {
        private ISettingsManager _settingsManager = new SettingsManager();
        private DashboardSettings _settings;

        public DashboardController()
        {
            _settings = _settingsManager.ReadSettings<DashboardSettings>();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            return View(_settings.Jobs);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Job job)
        {
            _settings.Jobs.Add(job);
            _settingsManager.SaveSettings(_settings);

            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Configure(string jobName)
        {
            var batch = _settings.Batches.Where(b => b.JobName == jobName).SingleOrDefault();

            return View(batch);
        }

        [HttpPost]
        public ActionResult Configure(Batch batch)
        {
            var existingBatch = _settings.Batches.Where(b => b.JobName == batch.JobName).SingleOrDefault();
            if (existingBatch == null)
            {
                _settings.Batches.Add(batch);
            }
            else
            {
                existingBatch.BatchName = batch.BatchName;
            }

            _settingsManager.SaveSettings(_settings);

            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Run(string jobName)
        {
            ViewBag.JobName = jobName;
            return View();
        }

        [HttpPost]
        public ActionResult RunBatch(string jobName)
        {
            //using (var logger = new Logger("output.log"))
            //{
            //    var runner = new ProcessRunner(logger);
            //    var batch = _settings.Batches.Where(b => b.JobName == jobName).Single();

            //    runner.Run("Ivanov.Build.Server\\Jobs\\" + jobName + "\\" + batch.BatchName);
            //}

            return Json(new { success = true });
        }
    }
}
