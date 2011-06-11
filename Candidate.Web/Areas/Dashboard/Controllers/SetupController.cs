using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Candidate.Core.Settings;
using Candidate.Areas.Dashboard.Models;
using System.IO;
using Candidate.Core.System;
using Candidate.Core.Git.Commands;

namespace Candidate.Areas.Dashboard.Controllers
{
    public class SetupController : Controller
    {
        private ISettingsManager _settingsManager;

        public SetupController(ISettingsManager settingsManager)
        {
            _settingsManager = settingsManager;
        }

        [HttpGet]
        public ActionResult Setup(string jobName)
        {
            ViewBag.JobName = jobName;
            return View();
        }

        [HttpGet]
        public JsonResult StartSetup(string jobName)
        {
            var currentSettings = _settingsManager.ReadSettings<SetupStatesModel>();
            var curentState = currentSettings.States.Where(s => s.JobName == jobName).SingleOrDefault();

            if (curentState == null)
            {
                curentState = new SetupStateModel();
                currentSettings.States.Add(curentState);
            }

            return Json(new { success = true, setupInitInfo = new { isRepoCloned = curentState.IsRepoCloned } }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CloneRepository(string jobName)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var currentSettings = _settingsManager.ReadSettings<JobsConfigurationSettingsModel>().Configurations.Where(c => c.JobName == jobName).SingleOrDefault();

            if (currentSettings == null)
            {
                throw new Exception(string.Format(@"Job ""{0}"" has not been configured", jobName));
            }

            var githubUrl = currentSettings.Github.Url;

            var workingDirectory = currentDirectory + "\\Candidate\\Jobs\\" + jobName + "\\";
            var logId = workingDirectory + "Logs\\clone-repo.log";

            using (var logger = new Logger(logId))
            {
                var runner = new ProcessRunner(logger, workingDirectory);
                var gitCloneCommand = new CloneCommand(githubUrl);
                runner.Run(gitCloneCommand.Batch);
            }

            return Json(new { success = true, log = logId });
        }
    }
}
