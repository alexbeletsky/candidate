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
using Candidate.Core.Commands.AppCmd;

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
            var currentDirectory = Directory.GetCurrentDirectory();
            var currentSettings = _settingsManager.ReadSettings<JobsConfigurationSettingsModel>().Configurations.Where(c => c.JobName == jobName).SingleOrDefault();

            var workingDirectory = currentDirectory + "\\Candidate\\Jobs\\" + jobName + "\\src\\";
            
            var repoCloned = false;
            if (Directory.Exists(workingDirectory))
            {
                repoCloned = true;
            }

            return Json(new { success = true, setupInitInfo = new { isRepoCloned = repoCloned } }, JsonRequestBehavior.AllowGet);
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
        public JsonResult PullRepository(string jobName)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var currentSettings = _settingsManager.ReadSettings<JobsConfigurationSettingsModel>().Configurations.Where(c => c.JobName == jobName).SingleOrDefault();

            if (currentSettings == null)
            {
                throw new Exception(string.Format(@"Job ""{0}"" has not been configured", jobName));
            }

            var workingDirectory = currentDirectory + "\\Candidate\\Jobs\\" + jobName + "\\src\\";
            var logId = workingDirectory + "..\\logs\\pull-build.log";

            using (var logger = new Logger(logId))
            {
                var runner = new ProcessRunner(logger, workingDirectory);
                var githubUrl = currentSettings.Github.Url;
                var gitCloneCommand = new PullCommand("origin");
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

        [HttpPost]
        public JsonResult StartWebSite(string jobName)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var currentSettings = _settingsManager.ReadSettings<JobsConfigurationSettingsModel>().Configurations.Where(c => c.JobName == jobName).SingleOrDefault();

            if (currentSettings == null)
            {
                throw new Exception(string.Format(@"Job ""{0}"" has not been configured", jobName));
            }

            var workingDirectory = currentDirectory + "\\Candidate\\Jobs\\" + jobName + "\\src\\";
            var logId = workingDirectory + "..\\logs\\start-site-build.log";

            try
            {
                using (var logger = new Logger(logId))
                {
                    var runner = new ProcessRunner(logger, workingDirectory);
                    var startSite = new StartSite(jobName);
                    runner.RunCommandSync(startSite);
                }

            }
            catch (System.Exception ex)
            {
            	
            }

            return Json(new { success = true, logId = logId });

        }

        [HttpPost]
        public JsonResult StopWebSite(string jobName)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var currentSettings = _settingsManager.ReadSettings<JobsConfigurationSettingsModel>().Configurations.Where(c => c.JobName == jobName).SingleOrDefault();

            if (currentSettings == null)
            {
                throw new Exception(string.Format(@"Job ""{0}"" has not been configured", jobName));
            }

            var workingDirectory = currentDirectory + "\\Candidate\\Jobs\\" + jobName + "\\src\\";
            var logId = workingDirectory + "..\\logs\\start-site-build.log";

            try
            {
                using (var logger = new Logger(logId))
                {
                    var runner = new ProcessRunner(logger, workingDirectory);
                    var startSite = new StopSite(jobName);
                    runner.RunCommandSync(startSite);
                }
            }
            catch (System.Exception ex)
            {
            	
            }

            return Json(new { success = true, logId = logId });
        }

    }
}
