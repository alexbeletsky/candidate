using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Candidate.Core.Configurations;
using Candidate.Core.Configurations.Parts;
using Candidate.Core.Configurations.Types;
using Candidate.Core.Settings;

namespace Candidate.Areas.Configuration.Controllers
{
    [Authorize]
    public class XCopyController : ConfigureControllerBase
    {
        public XCopyController(ISettingsManager settingsManager) : base(settingsManager)
        {

        }

        [HttpGet, ActionName("github")]
        public ActionResult ConfigureGithibSection(string id)
        {
            return View<XCopyConfiguration>(id, "Github", c => c.Github);
        }

        [HttpPost, ActionName("github")]
        public ActionResult ConfigureGithibSection(string id, Github config)
        {
            return Post<XCopyConfiguration>(id, c => c.Github = config);
        }

        [HttpGet, ActionName("iis")]
        public ActionResult ConfigureIisSection(string id)
        {
            return View<XCopyConfiguration>(id, "Iis", c => c.Iis);
        }

        [HttpPost, ActionName("iis")]
        public ActionResult ConfigureIisSection(string id, Iis config)
        {
            return Post<XCopyConfiguration>(id, c => c.Iis = config);
        }
    }
}
