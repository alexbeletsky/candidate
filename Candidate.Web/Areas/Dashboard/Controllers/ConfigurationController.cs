using System.Linq;
using System.Web.Mvc;
using Candidate.Areas.Dashboard.Models;
using Candidate.Core.Settings;
using System;

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

            //var currentSettings = _settingsManager.ReadSettings<JobsConfigurationSettingsModel>();
            //var jobConfiguration = currentSettings.Configurations.Where(c => c.JobName == jobName).SingleOrDefault();

            //return View(jobConfiguration);

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

        //[HttpPost]
        //public ActionResult Configure(JobConfigurationModel config)
        //{
        //    using (var settingsManager = new TrackableSettingsManager(_settingsManager))
        //    {
        //        var currentSettings = settingsManager.ReadSettings<JobsConfigurationSettingsModel>();
        //        var jobConfiguration = currentSettings.Configurations.Where(c => c.JobName == config.JobName).SingleOrDefault();

        //        if (jobConfiguration == null)
        //        {
        //            currentSettings.Configurations.Add(new JobConfigurationModel { JobName = config.JobName, Github = config.Github } );
        //        }
        //        else
        //        {
        //            jobConfiguration.Github = config.Github;
        //        }

        //        return Json(new { success = true, settings = config });
        //    }
        //}
    }
}
