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
        private ISettingsManager _settingsManager = new SettingsManager();
        private DashboardSettings _settings;

        public BatchController()
        {
            _settings = _settingsManager.ReadSettings<DashboardSettings>();
        }

        [HttpPost]
        public ActionResult RunBatch(string jobName)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var workingDirectory = currentDirectory + "\\Ivanov.Build.Server\\Jobs\\" + jobName + "\\";
            var logId = workingDirectory + "Logs\\output.log";
            using (var logger = new Logger(logId))
            {
                var runner = new ProcessRunner(logger, workingDirectory);
                var batch = _settings.Batches.Where(b => b.JobName == jobName).Single();
                runner.Run(batch.BatchName);
            }

            return Json(new { success = true, log = logId });
        }

    }
}
