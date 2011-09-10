namespace Candidate.Areas.Dashboard.Controllers {
    using System.Linq;
    using System.Web.Mvc;
    using Candidate.Areas.Dashboard.Models;
    using Candidate.Core.Settings;
    using Candidate.Core.Settings.Model;
    using Candidate.Infrustructure.Filters;

    // TODO: avoid code duplication in POST methods
    public class ConfigurationController : Controller {
        private ISettingsManager _settingsManager;

        public ConfigurationController(ISettingsManager settingsManager) {
            _settingsManager = settingsManager;
        }

        [HttpGet]
        [AddViewNameAndHash]
        public ActionResult Index(string jobName) {
            
            return View();
        }

        [HttpGet]
        [AddViewNameAndHash]
        public ActionResult Github(string jobName) {
            var currentConfiguration = _settingsManager.ReadSettings<SitesConfigurationList>();
            var siteConfiguration = currentConfiguration.Configurations.Where(c => c.JobName == jobName).SingleOrDefault();

            return View(siteConfiguration.Github);
        }

        [HttpPost]
        public ActionResult Github(string jobName, GitHub config) {
            using (var settingsManager = new TrackableSettingsManager(_settingsManager)) {
                var currentConfiguration = settingsManager.ReadSettings<SitesConfigurationList>();
                var siteConfiguration = currentConfiguration.Configurations.Where(c => c.JobName == jobName).SingleOrDefault();

                if (siteConfiguration == null) {
                    currentConfiguration.Configurations.Add(new SiteConfiguration { JobName = jobName, Github = config });
                }
                else {
                    siteConfiguration.Github = config;
                }

                return Json(new { success = true, settings = config });
            }
        }

        [HttpGet]
        [AddViewNameAndHash]
        public ActionResult Iis(string jobName) {
            var currentConfiguration = _settingsManager.ReadSettings<SitesConfigurationList>();
            var siteConfiguration = currentConfiguration.Configurations.Where(c => c.JobName == jobName).SingleOrDefault();

            return View(siteConfiguration.Iis);
        }

        [HttpPost]
        public ActionResult Iis(string jobName, Iis config) {
            using (var settingsManager = new TrackableSettingsManager(_settingsManager)) {
                var currentConfiguration = settingsManager.ReadSettings<SitesConfigurationList>();
                var siteConfiguration = currentConfiguration.Configurations.Where(c => c.JobName == jobName).SingleOrDefault();

                if (siteConfiguration == null) {
                    currentConfiguration.Configurations.Add(new SiteConfiguration { JobName = jobName, Iis = config });
                }
                else {
                    siteConfiguration.Iis = config;
                }

                return Json(new { success = true, settings = config });
            }
        }

        [HttpGet]
        [AddViewNameAndHash]
        public ActionResult Solution(string jobName) {
            var currentConfiguration = _settingsManager.ReadSettings<SitesConfigurationList>();
            var siteConfiguration = currentConfiguration.Configurations.Where(c => c.JobName == jobName).SingleOrDefault();

            return View(siteConfiguration.Solution);
        }

        [HttpPost]
        public ActionResult Solution(string jobName, Solution config) {
            using (var settingsManager = new TrackableSettingsManager(_settingsManager)) {
                var currentConfiguration = settingsManager.ReadSettings<SitesConfigurationList>();
                var siteConfiguration = currentConfiguration.Configurations.Where(c => c.JobName == jobName).SingleOrDefault();

                if (siteConfiguration == null) {
                    currentConfiguration.Configurations.Add(new SiteConfiguration { JobName = jobName, Solution = config });
                }
                else {
                    siteConfiguration.Solution = config;
                }

                return Json(new { success = true, settings = config });
            }
        }

        [HttpGet]
        [AddViewNameAndHash]
        public ActionResult Delete(string jobName) {
            return View(new DeleteJobModel { JobName = jobName });
        }

        [HttpPost]
        public ActionResult Delete(DeleteJobModel deleteJob) {
            using (var settingsManager = new TrackableSettingsManager(_settingsManager)) {
                var currentConfiguration = settingsManager.ReadSettings<SitesConfigurationList>();
                var jobToDelete = currentConfiguration.Configurations.Where(j => j.JobName == deleteJob.JobName).SingleOrDefault();
                var currentJobs = currentConfiguration.Configurations.Remove(jobToDelete);

                return RedirectToAction("Index", "Dashboard");
            }
        }

        [HttpGet]
        [AddViewNameAndHash]
        public ActionResult Post(string jobName) {
            var currentConfiguration = _settingsManager.ReadSettings<SitesConfigurationList>();
            var siteConfiguration = currentConfiguration.Configurations.Where(c => c.JobName == jobName).SingleOrDefault();

            return View(siteConfiguration.Post);
        }

        [HttpPost]
        public ActionResult Post(string jobName, Post config) {
            using (var settingsManager = new TrackableSettingsManager(_settingsManager)) {
                var currentConfiguration = settingsManager.ReadSettings<SitesConfigurationList>();
                var siteConfiguration = currentConfiguration.Configurations.Where(c => c.JobName == jobName).SingleOrDefault();

                if (siteConfiguration == null) {
                    currentConfiguration.Configurations.Add(new SiteConfiguration { JobName = jobName, Post = config });
                }
                else {
                    siteConfiguration.Post = config;
                }

                return Json(new { success = true, settings = config });
            }
        }
    }
}
