using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Candidate.Core.Configurations;
using Candidate.Core.Configurations.Parts;
using Candidate.Core.Configurations.Types;
using Candidate.Core.Settings;
using Candidate.Infrustructure.Filters;

namespace Candidate.Areas.Configuration.Controllers
{
    [Authorize]
    public class VisualStudioController : ControllerBase
    {
        public VisualStudioController(ISettingsManager settingsManager) : base(settingsManager)
        {
        }

        [HttpGet, AddViewNameAndHash, ActionName("github")]
        public ActionResult ConfigureGithubSection(string id)
        {
            return View<VisualStudioConfiguration>(id, "Github", c => c.Github);
        }

        [HttpPost, AddViewNameAndHash, ActionName("github")]
        public ActionResult ConfigureGithubSection(string id, Github config)
        {
            return Post<VisualStudioConfiguration>(id, c => c.Github = config);
        }

        [HttpGet, ActionName("solution")]
        public ActionResult ConfigureSolutionSection(string id)
        {
            return View<VisualStudioConfiguration>(id, "Solution", c => c.Solution);
        }

        [HttpPost, ActionName("solution")]
        public ActionResult ConfigureSolutionSection(string id, Solution config)
        {
            return Post<VisualStudioConfiguration>(id, c => c.Solution = config);
        }

        [HttpGet, ActionName("iis")]
        public ActionResult ConfigureIisSection(string id)
        {
            return View<VisualStudioConfiguration>(id, "Iis", c => c.Iis);
        }

        [HttpPost, ActionName("iis")]
        public ActionResult ConfigureIisSection(string id, Iis config)
        {
            return Post<VisualStudioConfiguration>(id, c => c.Iis = config);
        }
    }
}
