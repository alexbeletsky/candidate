using System;
using System.Linq;
using System.Web.Mvc;
using Candidate.Core.Log;
using Candidate.Core.Settings;
using Candidate.Core.Settings.Model;
using Candidate.Core.Setup;
using Candidate.Core.Utils;
using Candidate.Infrustructure.Error;

namespace Candidate.Areas.Dashboard.Controllers {

    public class SetupController : Controller {
        private ISettingsManager _settingsManager;
        private ISetupFactory _setupFactory;
        private ILoggerFactory _loggerFactory;
        private IDirectoryProvider _directoryProvider;

        public SetupController(ISettingsManager settingsManager, ISetupFactory setupFactory, ILoggerFactory loggerFactory, IDirectoryProvider directoryProvider) {
            _settingsManager = settingsManager;
            _setupFactory = setupFactory;
            _loggerFactory = loggerFactory;
            _directoryProvider = directoryProvider;
        }

        [HttpGet]
        public ActionResult Setup(string jobName) {
            ViewBag.JobName = jobName;
            return View();
        }

        [HttpPost]
        [HandleJsonError]
        public ActionResult StartSetup(string jobName) {

            var currentSettings = _settingsManager.ReadSettings<JobsConfigurationSettingsModel>().Configurations.Where(c => c.JobName == jobName).SingleOrDefault();
            if (currentSettings == null) {
                throw new Exception(string.Format("Can't create setup for non-existing job: {0}", jobName));
            }

            _directoryProvider.JobName = jobName;

            using (var logger = _loggerFactory.CreateLogger(_directoryProvider.Logs)) {
                var setup = _setupFactory.CreateSetup();
                setup.RunForConfig(logger, currentSettings);

                return Json(new { success = true, logId = logger.Id });
            }
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
