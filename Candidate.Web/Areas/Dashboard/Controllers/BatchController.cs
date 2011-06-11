using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Candidate.Areas.Dashboard.Models;
using Candidate.Core.Settings;
using Candidate.Core.System;

namespace Candidate.Areas.Dashboard.Controllers
{
    public class BatchController : Controller
    {
        private ISettingsManager _settingsManager;

        public BatchController(ISettingsManager settingsManager)
        {
            _settingsManager = settingsManager;
        }

        [HttpPost]
        public ActionResult RunBatch(string jobName)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var currentSettings = _settingsManager.ReadSettings<JobsConfigurationSettingsModel>().Configurations.Where(c => c.JobName == jobName).SingleOrDefault();

            if (currentSettings == null)
            {
                throw new Exception(string.Format(@"Job ""{0}"" has not been configured", jobName));
            }

            var workingDirectory = currentDirectory + "\\Candidate\\Jobs\\" + jobName + "\\";
            var logId = workingDirectory + "Logs\\output.log";
            using (var logger = new Logger(logId))
            {
                var runner = new ProcessRunner(logger, workingDirectory);
                var batch = currentSettings.Batch.BatchName;
                runner.Run(batch);
            }

            return Json(new { success = true, log = logId });
        }
    }
}
