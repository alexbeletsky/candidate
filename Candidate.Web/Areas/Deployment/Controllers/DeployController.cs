using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Candidate.Core.Extensions;
using Candidate.Core.Settings;
using Candidate.Infrustructure.Error;

namespace Candidate.Areas.Deployment.Controllers
{
    public class DeployController : SecuredController
    {
        private readonly ISettingsManager _settingsManager;

        public DeployController(ISettingsManager settingsManager)
        {
            _settingsManager = settingsManager;
        }

        [HttpGet, ActionName("deploy")]
        public ActionResult Deploy(string id)
        {
            var configuration = _settingsManager.ReadConfiguration<Core.Configurations.Types.Configuration>(id);
            
            if (!configuration.IsConfigured())
            {
                return View("NotConfigured");
            }

            return View(configuration);
        }

        [HttpPost, ActionName("deploy")]
        public ActionResult PreDeploy(string id)
        {
            var configuration = _settingsManager.ReadConfiguration<Core.Configurations.Types.Configuration>(id);

            return View("Action", configuration);
        }

        [HttpPost, ActionName("start")]
        public ActionResult StartDeploy(string id)
        {
            var configuration = _settingsManager.ReadConfiguration<Core.Configurations.Types.Configuration>(id);
            
            var runner = configuration.CreateDeployRunner();
            var results = runner.Run(configuration.Id);

            return Json(new { success = true, result = new { url = results.Url } });
        }
    }
}
