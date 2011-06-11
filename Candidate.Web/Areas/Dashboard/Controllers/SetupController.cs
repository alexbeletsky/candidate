using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Candidate.Core.Settings;
using Candidate.Areas.Dashboard.Models;
using System.IO;
using Candidate.Core.System;
using Candidate.Core.Commands.Git;
using Candidate.Core.Commands.Batch;

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

            var workingDirectory = currentDirectory + "\\Candidate\\Jobs\\" + jobName + "\\";
            var logId = workingDirectory + "logs\\clone-repo.log";

            using (var logger = new Logger(logId))
            {
                var runner = new ProcessRunner(logger, workingDirectory);
                var githubUrl = currentSettings.Github.Url;
                var gitCloneCommand = new CloneCommand(githubUrl, "src");
                runner.RunCommandSync(gitCloneCommand);
            }

            return Json(new { success = true, logId = logId });
        }

        [HttpPost]
        public JsonResult RunBuild(string jobName)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var currentSettings = _settingsManager.ReadSettings<JobsConfigurationSettingsModel>().Configurations.Where(c => c.JobName == jobName).SingleOrDefault();

            if (currentSettings == null)
            {
                throw new Exception(string.Format(@"Job ""{0}"" has not been configured", jobName));
            }

            var workingDirectory = currentDirectory + "\\Candidate\\Jobs\\" + jobName + "\\src\\";
            var logId = workingDirectory + "..\\logs\\run-build.log";

            using (var logger = new Logger(logId))
            {
                var runner = new ProcessRunner(logger, workingDirectory);
                var batchCommand = new BatchCommand("build.bat", workingDirectory);
                runner.RunCommandSync(batchCommand);
            }

            return Json(new { success = true, logId = logId });            
        }

        [HttpPost]
        public JsonResult RunTest(string jobName)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var currentSettings = _settingsManager.ReadSettings<JobsConfigurationSettingsModel>().Configurations.Where(c => c.JobName == jobName).SingleOrDefault();

            if (currentSettings == null)
            {
                throw new Exception(string.Format(@"Job ""{0}"" has not been configured", jobName));
            }

            var workingDirectory = currentDirectory + "\\Candidate\\Jobs\\" + jobName + "\\src\\";
            var logId = workingDirectory + "..\\logs\\test-build.log";

            using (var logger = new Logger(logId))
            {
                var runner = new ProcessRunner(logger, workingDirectory);
                var batchCommand = new BatchCommand("test.bat", workingDirectory);
                runner.RunCommandSync(batchCommand);
            }

            return Json(new { success = true, logId = logId });
        }

        [HttpPost]
        public JsonResult RunDeploy(string jobName)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var currentSettings = _settingsManager.ReadSettings<JobsConfigurationSettingsModel>().Configurations.Where(c => c.JobName == jobName).SingleOrDefault();

            if (currentSettings == null)
            {
                throw new Exception(string.Format(@"Job ""{0}"" has not been configured", jobName));
            }

            var workingDirectory = currentDirectory + "\\Candidate\\Jobs\\" + jobName + "\\src\\";
            var logId = workingDirectory + "..\\logs\\test-build.log";

            using (var logger = new Logger(logId))
            {
                var runner = new ProcessRunner(logger, workingDirectory);
                var batchCommand = new BatchCommand("deploy.bat", workingDirectory);
                runner.RunCommandSync(batchCommand);
            }

            return Json(new { success = true, logId = logId });
        }

    }
}
