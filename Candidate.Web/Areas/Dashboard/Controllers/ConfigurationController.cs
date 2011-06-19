using System.Linq;
using System.Web.Mvc;
using Candidate.Areas.Dashboard.Models;
using Candidate.Core.Settings;

namespace Candidate.Areas.Dashboard.Controllers
{
    public class ConfigurationController : Controller
    {
        private ISettingsManager _settingsManager;

        public ConfigurationController(ISettingsManager settingsManager)
        {
            _settingsManager = settingsManager;
        }

        public ActionResult Configure(string jobName)
        {
            ViewBag.JobName = jobName;

            return View();
        }

        public ActionResult ConfigureGithub(string jobName)
        {
            var currentSettings = _settingsManager.ReadSettings<JobsConfigurationSettingsModel>();
            var jobConfiguration = currentSettings.Configurations.Where(c => c.JobName == jobName).SingleOrDefault();

            return View(jobConfiguration.Github);
        }

        [HttpPost]
        public ActionResult ConfigureGithub(string jobName, GithubModel config)
        {
            using (var settingsManager = new TrackableSettingsManager(_settingsManager))
            {
                var currentSettings = settingsManager.ReadSettings<JobsConfigurationSettingsModel>();
                var jobConfiguration = currentSettings.Configurations.Where(c => c.JobName == jobName).SingleOrDefault();

                if (jobConfiguration == null)
                {
                    currentSettings.Configurations.Add(new JobConfigurationModel { JobName = jobName, Github = config });
                }
                else
                {
                    jobConfiguration.Github = config;
                }

                return Json(new { success = true, settings = config });
            }
        }


        public ActionResult ConfigureIis(string jobName)
        {
            var currentSettings = _settingsManager.ReadSettings<JobsConfigurationSettingsModel>();
            var jobConfiguration = currentSettings.Configurations.Where(c => c.JobName == jobName).SingleOrDefault();

            return View(jobConfiguration.Iis);
        }

        [HttpPost]
        public ActionResult ConfigureIis(string jobName, IisModel config)
        {
            using (var settingsManager = new TrackableSettingsManager(_settingsManager))
            {
                var currentSettings = settingsManager.ReadSettings<JobsConfigurationSettingsModel>();
                var jobConfiguration = currentSettings.Configurations.Where(c => c.JobName == jobName).SingleOrDefault();

                if (jobConfiguration == null)
                {
                    currentSettings.Configurations.Add(new JobConfigurationModel { JobName = jobName, Iis = config });
                }
                else
                {
                    jobConfiguration.Iis = config;
                }

                return Json(new { success = true, settings = config });
            }
        }
    }
}
