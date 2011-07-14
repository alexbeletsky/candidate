namespace Candidate.Areas.Dashboard.Controllers {
    using System.Web.Mvc;
    using Candidate.Areas.Dashboard.Models;
    using Candidate.Core.Settings;

    public class DashboardController : Controller {
        private ISettingsManager _settingsManager;

        public DashboardController(ISettingsManager settingsManager) {
            _settingsManager = settingsManager;
        }

        [HttpGet]
        public ActionResult Index() {
            return View();
        }

        [HttpGet]
        public ActionResult List() {
            var currentSettings = _settingsManager.ReadSettings<JobsSettingsModel>();

            return View(currentSettings.Jobs);
        }

        [HttpGet]
        public ActionResult Add() {
            return View();
        }

        [HttpPost]
        public ActionResult Add(NewJobModel newJob) {
            using (var settingsManager = new TrackableSettingsManager(_settingsManager)) {
                var currentSettings = settingsManager.ReadSettings<JobsSettingsModel>();
                var currentJobs = currentSettings.Jobs;

                currentJobs.Add(new JobModel { Name = newJob.Name, Status = 0 });

                return RedirectToAction("Index", new { area = "Dashboard", controller = "Dashboard" });
            }
        }
    }
}
