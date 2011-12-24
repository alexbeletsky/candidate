using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Candidate.Core.Model;
using Candidate.Core.Settings;
using Candidate.Infrustructure.Filters;
using Config = Candidate.Core.Model.Configurations;

namespace Candidate.Areas.Configuration.Controllers
{
    public class VisualStudioController : ConfigurationControllerBase
    {
        public VisualStudioController(ISettingsManager settingsManager) : base(settingsManager)
        {
        }

        [HttpGet, AddViewNameAndHash, ActionName("github")]
        public ActionResult ConfigureGithubSection(string id)
        {
            return View<Config.VisualStudioConfiguration>(id, "Github", c => c.Github);
        }

        [HttpPost, AddViewNameAndHash, ActionName("github")]
        public ActionResult ConfigureGithubSection(string id, Github config)
        {
            return Post<Config.VisualStudioConfiguration>(id, c => c.Github = config);
        }

        [HttpGet, ActionName("solution")]
        public ActionResult ConfigureSolutionSection(string id)
        {
            return View<Config.VisualStudioConfiguration>(id, "Solution", c => c.Solution);
        }

        [HttpPost, ActionName("solution")]
        public ActionResult ConfigureSolutionSection(string id, Solution config)
        {
            return Post<Config.VisualStudioConfiguration>(id, c => c.Solution = config);
        }

        [HttpGet, ActionName("iis")]
        public ActionResult ConfigureIisSection(string id)
        {
            return View<Config.VisualStudioConfiguration>(id, "Iis", c => c.Iis);
        }

        [HttpPost, ActionName("iis")]
        public ActionResult ConfigureIisSection(string id, Iis config)
        {
            return Post<Config.VisualStudioConfiguration>(id, c => c.Iis = config);
        }
    }
}
