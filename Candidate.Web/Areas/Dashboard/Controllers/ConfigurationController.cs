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
            var currentSettings = _settingsManager.ReadSettings<JobsConfigurationSettingsModel>();
            var jobConfiguration = currentSettings.Configurations.Where(c => c.JobName == jobName).SingleOrDefault();

            return View(jobConfiguration);
        }

        [HttpPost]
        public ActionResult Configure(JobConfigurationModel config)
        {
            ChangeSettings(config);

            return RedirectToAction("Setup", new { area = "Dashboard", controller = "Setup", jobName = config.JobName });
        }

        private void ChangeSettings(JobConfigurationModel config)
        {
            var currentSettings = _settingsManager.ReadSettings<JobsConfigurationSettingsModel>();
            var jobConfiguration = currentSettings.Configurations.Where(c => c.JobName == config.JobName).SingleOrDefault();

            if (jobConfiguration == null)
            {
                CreateNewConfiguration(config, currentSettings);
            }
            else
            {
                UpdateCurrentConfiguration(config, jobConfiguration);
            }

            _settingsManager.SaveSettings(currentSettings);
        }

        private static void CreateNewConfiguration(JobConfigurationModel config, JobsConfigurationSettingsModel currentSettings)
        {
            currentSettings.Configurations.Add(CreateNewConfigurationModel(config));
        }

        private static void UpdateCurrentConfiguration(JobConfigurationModel config, JobConfigurationModel jobConfiguration)
        {
            jobConfiguration.JobName = config.JobName;
            //jobConfiguration.Batch = new BatchModel { BuildBatchName = config.Batch.BuildBatchName };
            jobConfiguration.Github = new GithubModel { Url = config.Github.Url };
        }

        private static JobConfigurationModel CreateNewConfigurationModel(JobConfigurationModel config)
        {
            return new JobConfigurationModel {
                JobName = config.JobName,
                //Batch = new BatchModel { BuildBatchName = config.Batch.BuildBatchName },
                Github = new GithubModel { Url = config.Github.Url }
            };
        }
    }
}
