using System.Web.Mvc;
using Candidate.Core.Settings;
using Candidate.Core.Setup;
using Candidate.Core.System;

namespace Candidate.Areas.Dashboard.Controllers {

    public class SetupController : Controller {
        private ISettingsManager _settingsManager;
        private ISetupManager _setupManager;

        public SetupController(ISettingsManager settingsManager, ISetupManager setupManager) {
            _settingsManager = settingsManager;
            _setupManager = setupManager;
        }

        [HttpGet]
        public ActionResult Setup(string jobName) {
            ViewBag.JobName = jobName;
            return View();
        }

        [HttpPost]
        public ActionResult StartSetup(string jobName) {
            var logId = "logId";

            //using (var logger = new Logger(logId)) {
            //    var setup = _setupManager.CreateSetup(_settingsManager, jobName);
            //    setup.Execute(logger);
            //}

            return Json(new { success = true, logId = logId });
        }

        //[HttpGet]
        //public JsonResult StartSetup(string jobName) {
        //    var currentDirectory = LocalAppDataFolder.Folder;
        //    var currentSettings = _settingsManager.ReadSettings<JobsConfigurationSettingsModel>().Configurations.Where(c => c.JobName == jobName).SingleOrDefault();

        //    var workingDirectory = currentDirectory + "\\Jobs\\" + jobName + "\\src\\";

        //    var repoCloned = false;
        //    if (Directory.Exists(workingDirectory)) {
        //        repoCloned = true;
        //    }

        //    return Json(new { success = true, setupInitInfo = new { isRepoCloned = repoCloned } }, JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //public JsonResult CloneRepository(string jobName) {
        //    var currentDirectory = LocalAppDataFolder.Folder;
        //    var currentSettings = _settingsManager.ReadSettings<JobsConfigurationSettingsModel>().Configurations.Where(c => c.JobName == jobName).SingleOrDefault();

        //    if (currentSettings == null) {
        //        throw new Exception(string.Format(@"Job ""{0}"" has not been configured", jobName));
        //    }

        //    var workingDirectory = currentDirectory + "\\Jobs\\" + jobName + "\\";
        //    var logId = workingDirectory + "logs\\clone-repo.log";

        //    using (var logger = new Logger(logId)) {
        //        var runner = new ProcessRunner(logger, workingDirectory);
        //        var githubUrl = currentSettings.Github.Url;
        //        var gitCloneCommand = new CloneCommand(githubUrl, "src");
        //        runner.RunCommandSync(gitCloneCommand);
        //    }

        //    return Json(new { success = true, logId = logId });
        //}

        //[HttpPost]
        //public JsonResult PullRepository(string jobName) {
        //    var currentDirectory = LocalAppDataFolder.Folder;
        //    var currentSettings = _settingsManager.ReadSettings<JobsConfigurationSettingsModel>().Configurations.Where(c => c.JobName == jobName).SingleOrDefault();

        //    if (currentSettings == null) {
        //        throw new Exception(string.Format(@"Job ""{0}"" has not been configured", jobName));
        //    }

        //    var workingDirectory = currentDirectory + "\\Jobs\\" + jobName + "\\src\\";
        //    var logId = workingDirectory + "..\\logs\\pull-build.log";

        //    using (var logger = new Logger(logId)) {
        //        var runner = new ProcessRunner(logger, workingDirectory);
        //        var githubUrl = currentSettings.Github.Url;
        //        var gitCloneCommand = new PullCommand("origin");
        //        runner.RunCommandSync(gitCloneCommand);
        //    }

        //    return Json(new { success = true, logId = logId });
        //}

        //[HttpPost]
        //public JsonResult RunBuild(string jobName) {
        //    var currentDirectory = LocalAppDataFolder.Folder;
        //    var currentSettings = _settingsManager.ReadSettings<JobsConfigurationSettingsModel>().Configurations.Where(c => c.JobName == jobName).SingleOrDefault();

        //    if (currentSettings == null) {
        //        throw new Exception(string.Format(@"Job ""{0}"" has not been configured", jobName));
        //    }

        //    var workingDirectory = currentDirectory + "\\Jobs\\" + jobName + "\\src\\";
        //    var logId = workingDirectory + "..\\logs\\run-build.log";

        //    using (var logger = new Logger(logId)) {
        //        var runner = new ProcessRunner(logger, workingDirectory);
        //        var batchCommand = new BatchCommand("build.bat", workingDirectory);
        //        runner.RunCommandSync(batchCommand);
        //    }

        //    return Json(new { success = true, logId = logId });
        //}

        //[HttpPost]
        //public JsonResult RunTest(string jobName) {
        //    var currentDirectory = LocalAppDataFolder.Folder;
        //    var currentSettings = _settingsManager.ReadSettings<JobsConfigurationSettingsModel>().Configurations.Where(c => c.JobName == jobName).SingleOrDefault();

        //    if (currentSettings == null) {
        //        throw new Exception(string.Format(@"Job ""{0}"" has not been configured", jobName));
        //    }

        //    var workingDirectory = currentDirectory + "\\Jobs\\" + jobName + "\\src\\";
        //    var logId = workingDirectory + "..\\logs\\test-build.log";

        //    using (var logger = new Logger(logId)) {
        //        var runner = new ProcessRunner(logger, workingDirectory);
        //        var batchCommand = new BatchCommand("test.bat", workingDirectory);
        //        runner.RunCommandSync(batchCommand);
        //    }

        //    return Json(new { success = true, logId = logId });
        //}

        //[HttpPost]
        //public JsonResult RunDeploy(string jobName) {
        //    var currentDirectory = LocalAppDataFolder.Folder;
        //    var currentSettings = _settingsManager.ReadSettings<JobsConfigurationSettingsModel>().Configurations.Where(c => c.JobName == jobName).SingleOrDefault();

        //    if (currentSettings == null) {
        //        throw new Exception(string.Format(@"Job ""{0}"" has not been configured", jobName));
        //    }

        //    var workingDirectory = currentDirectory + "\\Jobs\\" + jobName + "\\src\\";
        //    var logId = workingDirectory + "..\\logs\\test-build.log";

        //    using (var logger = new Logger(logId)) {
        //        var runner = new ProcessRunner(logger, workingDirectory);
        //        var batchCommand = new BatchCommand("deploy.bat", workingDirectory);
        //        runner.RunCommandSync(batchCommand);
        //    }

        //    return Json(new { success = true, logId = logId });
        //}

        //[HttpPost]
        //public JsonResult StartWebSite(string jobName) {
        //    var currentDirectory = LocalAppDataFolder.Folder;
        //    var currentSettings = _settingsManager.ReadSettings<JobsConfigurationSettingsModel>().Configurations.Where(c => c.JobName == jobName).SingleOrDefault();

        //    if (currentSettings == null) {
        //        throw new Exception(string.Format(@"Job ""{0}"" has not been configured", jobName));
        //    }

        //    var workingDirectory = currentDirectory + "\\Jobs\\" + jobName + "\\src\\";
        //    var logId = workingDirectory + "..\\logs\\start-site-build.log";

        //    try {
        //        using (var logger = new Logger(logId)) {
        //            var runner = new ProcessRunner(logger, workingDirectory);
        //            var startSite = new StartSite(jobName);
        //            runner.RunCommandSync(startSite);
        //        }

        //    }
        //    catch (System.Exception ex) {

        //    }

        //    return Json(new { success = true, logId = logId });

        //}

        //[HttpPost]
        //public JsonResult StopWebSite(string jobName) {
        //    var currentDirectory = LocalAppDataFolder.Folder;
        //    var currentSettings = _settingsManager.ReadSettings<JobsConfigurationSettingsModel>().Configurations.Where(c => c.JobName == jobName).SingleOrDefault();

        //    if (currentSettings == null) {
        //        throw new Exception(string.Format(@"Job ""{0}"" has not been configured", jobName));
        //    }

        //    var workingDirectory = currentDirectory + "\\Jobs\\" + jobName + "\\src\\";
        //    var logId = workingDirectory + "..\\logs\\start-site-build.log";

        //    try {
        //        using (var logger = new Logger(logId)) {
        //            var runner = new ProcessRunner(logger, workingDirectory);
        //            var startSite = new StopSite(jobName);
        //            runner.RunCommandSync(startSite);
        //        }
        //    }
        //    catch {

        //    }

        //    return Json(new { success = true, logId = logId });
        //}

        //[HttpPost]
        //public JsonResult Hook(string jobName) {
        //    StopWebSite(jobName);
        //    PullRepository(jobName);
        //    RunBuild(jobName);
        //    RunTest(jobName);
        //    RunDeploy(jobName);
        //    StartWebSite(jobName);

        //    return Json(new { success = true, logId = "" });
        //}

    }
}
