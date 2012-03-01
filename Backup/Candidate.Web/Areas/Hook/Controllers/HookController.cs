using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Candidate.Areas.Dashboard.Models;
using Candidate.Core.Deploy;
using Candidate.Core.Extensions;
using Candidate.Core.Services;
using Candidate.Infrustructure.Filters;
using Newtonsoft.Json;

namespace Candidate.Areas.Hook.Controllers
{
    [AuthorizeByToken]
    public class HookController : Controller
    {
        private readonly IDeployer _deployer;

        public HookController(IDeployer deployer)
        {
            _deployer = deployer;
        }

        [HttpPost]
        public ActionResult Index(string id, string token, string payload)
        {
            var githubPayload = JsonConvert.DeserializeObject<GithubHookPayload>(payload);
            var results = _deployer.Deploy(id, githubPayload.Branch);

            return Json(new { success = true, result = new { url = results.Url } });                        
        }
    }
}
