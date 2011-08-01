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

            var currentSettings = _settingsManager.ReadSettings<SitesConfigurationList>().Configurations.Where(c => c.JobName == jobName).SingleOrDefault();
            if (currentSettings == null) {
                throw new Exception(string.Format("Can't create setup for non-existing job: {0}", jobName));
            }

            _directoryProvider.JobName = jobName;

            using (var logger = _loggerFactory.CreateLogger()) {
                var setup = _setupFactory.CreateSetup();
                setup.RunForConfig(logger, currentSettings);

                return Json(new { success = true, logId = logger.LogFullPath });
            }
        }
    }
}
