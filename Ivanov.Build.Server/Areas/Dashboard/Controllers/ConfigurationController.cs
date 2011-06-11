using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ncqrs.Commanding.ServiceModel;
using Ivanov.Build.Server.Areas.Dashboard.Models;
using Ivanov.Build.Server.Core.Settings;

namespace Ivanov.Build.Server.Areas.Dashboard.Controllers
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
            var currentSettings = _settingsManager.ReadSettings<JobsConfigurationSettingsModel>();
            var jobConfiguration = currentSettings.Configurations.Where(c => c.JobName == jobName).SingleOrDefault();

            return View(jobConfiguration);
        }

        [HttpPost]
        public ActionResult Configure(JobConfigurationModel config)
        {
            var currentSettings = _settingsManager.ReadSettings<JobsConfigurationSettingsModel>();
            var jobConfiguration = currentSettings.Configurations.Where(c => c.JobName == config.JobName).SingleOrDefault();

            if (jobConfiguration == null)
            {
                currentSettings.Configurations.Add(new JobConfigurationModel { JobName = config.JobName, Batch = new BatchModel { BatchName = config.Batch.BatchName } });
            }
            else
            {
                jobConfiguration.JobName = config.JobName;
                jobConfiguration.Batch = new BatchModel { BatchName = config.Batch.BatchName };
            }

            _settingsManager.SaveSettings(currentSettings);

            return RedirectToAction("Index", new { area = "Dashboard", controller = "Dashboard" });
        }
    }
}
