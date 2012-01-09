using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Candidate.Areas.Dashboard.Models;
using Candidate.Core.Deploy;
using Candidate.Core.Settings;
using Candidate.Core.Extensions;
using Newtonsoft.Json;

namespace Candidate.Areas.Hook.Controllers
{
    public class HookController : SecuredController
    {
        private readonly ISettingsManager _settingsManager;
        private readonly IDeployer _deployer;

        public HookController(ISettingsManager settingsManager, IDeployer deployer)
        {
            _settingsManager = settingsManager;
            _deployer = deployer;
        }

        [HttpPost]
        public ActionResult Index(string id, string payload)
        {
            var githubPayload = JsonConvert.DeserializeObject<GithubHookPayload>(payload);
            var results = _deployer.Deploy(id, githubPayload.Branch);

            return Json(new { success = true, result = new { url = results.Url } });                        
        }
    }
}
