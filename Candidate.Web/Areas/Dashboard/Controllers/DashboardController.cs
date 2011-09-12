namespace Candidate.Areas.Dashboard.Controllers {
    using System.Web.Mvc;
    using Candidate.Areas.Dashboard.Models;
    using Candidate.Core.Settings;
    using Candidate.Core.Settings.Model;

    [Authorize]
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
            var currentSettings = _settingsManager.ReadSettings<SitesConfigurationList>();

            return View(currentSettings.Configurations);
        }

        [HttpGet]
        public ActionResult Add() {
            return View();
        }

        [HttpPost]
        public ActionResult Add(NewJobModel newJob) {
            using (var settingsManager = new TrackableSettingsManager(_settingsManager)) {
                var currentSettings = settingsManager.ReadSettings<SitesConfigurationList>();
                var currentJobs = currentSettings.Configurations;

                currentJobs.Add(new SiteConfiguration { JobName = newJob.Name });

                return RedirectToAction("Index", new { area = "Dashboard", controller = "Dashboard" });
            }
        }
    }
}
