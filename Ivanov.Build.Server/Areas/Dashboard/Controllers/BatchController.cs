using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Ivanov.Build.Server.Core.System;
using Ivanov.Build.Server.Core.Settings;
using Ivanov.Build.Server.Areas.Dashboard.Models;

namespace Ivanov.Build.Server.Areas.Dashboard.Controllers
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

            var workingDirectory = currentDirectory + "\\Ivanov.Build.Server\\Jobs\\" + jobName + "\\";
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
