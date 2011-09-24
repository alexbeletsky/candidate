using System;
using System.Linq;
using System.Web.Mvc;
using Candidate.Areas.Dashboard.Models;
using Candidate.Core.Log;
using Candidate.Core.Settings;
using Candidate.Core.Settings.Model;
using Candidate.Core.Setup;
using Candidate.Core.Utils;
using Candidate.Infrustructure.Error;
using Candidate.Infrustructure.Filters;
using Newtonsoft.Json;

namespace Candidate.Areas.Dashboard.Controllers {

    [Authorize]
    [HandleJsonError]
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

            var currentConfiguration = _settingsManager.ReadSettings<SitesConfigurationList>();
            var siteConfiguration = currentConfiguration.Configurations.Where(c => c.JobName == jobName).SingleOrDefault();

            if (!siteConfiguration.IsConfigured()) {
                return View("NotConfigured");
            }

            return View();
        }

        [HttpPost]
        public ActionResult StartSetup(string jobName) {
            var currentSettings = _settingsManager.ReadSettings<SitesConfigurationList>().Configurations.Where(c => c.JobName == jobName).SingleOrDefault();
            if (currentSettings == null) {
                throw new Exception(string.Format("Can't create setup for non-existing job: {0}", jobName));
            }

            return RunDeployAndLog(jobName, currentSettings);
        }

        [HttpPost]
        [ValidateToken]
        public ActionResult Hook(string jobName, string token, string payload) {

            var currentSettings = _settingsManager.ReadSettings<SitesConfigurationList>().Configurations.Where(c => c.JobName == jobName).SingleOrDefault();
            if (currentSettings == null) {
                throw new Exception(string.Format("Can't create setup for non-existing job: {0}", jobName));
            }

            // TODO: move this serialization to service
            var payloadDeserialized = JsonConvert.DeserializeObject<GithubHookPayload>(payload);
            var githubConfiguration = currentSettings.Github;

            if (!IsHookForBranch(payloadDeserialized.Branch, githubConfiguration)) {
                return null;
            }

            return RunDeployAndLog(jobName, currentSettings);
        }

        private static bool IsHookForBranch(string payload, GitHub githubConfiguration) {
            return payload.Equals(githubConfiguration.Branch);
        }

        private ActionResult RunDeployAndLog(string jobName, SiteConfiguration currentSettings) {
            _directoryProvider.SiteName = jobName;

            using (var logger = _loggerFactory.CreateLogger()) {
                var setup = _setupFactory.CreateSetup();
                var result = setup.RunForConfig(logger, currentSettings);

                return Json(new { success = true, result = result });
            }
        }

    }
}
