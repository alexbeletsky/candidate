using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Candidate.Core.Model;
using Candidate.Core.Settings;
using Config = Candidate.Core.Model.Configurations;

namespace Candidate.Areas.Configuration.Controllers
{
    [Authorize]
    public class XCopyController : ControllerBase
    {
        public XCopyController(ISettingsManager settingsManager) : base(settingsManager)
        {

        }

        [HttpGet, ActionName("github")]
        public ActionResult ConfigureGithibSection(string id)
        {
            return View<Config.XCopyConfiguration>(id, "Github", c => c.Github);
        }

        [HttpPost, ActionName("github")]
        public ActionResult ConfigureGithibSection(string id, Github config)
        {
            return Post<Config.XCopyConfiguration>(id, c => c.Github = config);
        }

        [HttpGet, ActionName("iis")]
        public ActionResult ConfigureIisSection(string id)
        {
            return View<Config.XCopyConfiguration>(id, "Iis", c => c.Iis);
        }

        [HttpPost, ActionName("iis")]
        public ActionResult ConfigureIisSection(string id, Iis config)
        {
            return Post<Config.XCopyConfiguration>(id, c => c.Iis = config);
        }
    }
}
