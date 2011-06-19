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

        [HttpGet]
        public ActionResult Index(string jobName)
        {
            ViewBag.JobName = jobName;

            return View();
        }

        public ActionResult ConfigureGithub(string jobName)
        {
            var currentSettings = _settingsManager.ReadSettings<JobsConfigurationSettingsModel>();
            var jobConfiguration = currentSettings.Configurations.Where(c => c.JobName == jobName).SingleOrDefault();

            return View(jobConfiguration == null ? null : jobConfiguration.Github);
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

            return View(jobConfiguration == null ? null : jobConfiguration.Iis);
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

        [HttpGet]
        public ActionResult DeleteConfiguration(string jobName)
        {
            return View(new DeleteJobModel { JobName = jobName });
        }

        [HttpPost]
        public ActionResult DeleteConfiguration(DeleteJobModel deleteJob)
        {
            using (var settingsManager = new TrackableSettingsManager(_settingsManager))
            {
                var currentSettings = settingsManager.ReadSettings<JobsSettingsModel>();
                var jobToDelete = currentSettings.Jobs.Where(j => j.Name == deleteJob.JobName).SingleOrDefault();
                var currentJobs = currentSettings.Jobs.Remove(jobToDelete);

                return RedirectToAction("Index", "Dashboard");
            }
        }
    }
}
