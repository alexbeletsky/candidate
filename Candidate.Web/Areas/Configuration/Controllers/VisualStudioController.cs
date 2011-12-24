using System;
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
    public class VisualStudioController : Controller
    {
        private readonly ISettingsManager _settingsManager;

        public VisualStudioController(ISettingsManager settingsManager)
        {
            _settingsManager = settingsManager;
        }

        [HttpGet, AddViewNameAndHash, ActionName("github")]
        public ActionResult ConfigureGithubSection(string id)
        {
            return View(id, "Github", c => c.Github);
        }

        [HttpPost, AddViewNameAndHash, ActionName("github")]
        public ActionResult ConfigureGithubSection(string id, Github config)
        {
            return Post(id, c => c.Github = config);
        }

        [HttpGet, ActionName("solution")]
        public ActionResult ConfigureSolutionSection(string id)
        {
            return View(id, "Solution", c => c.Solution);
        }

        [HttpPost, ActionName("solution")]
        public ActionResult ConfigureSolutionSection(string id, Solution config)
        {
            return Post(id, c => c.Solution = config);
        }

        [HttpGet, ActionName("iis")]
        public ActionResult ConfigureIisSection(string id)
        {
            return View(id, "Iis", c => c.Iis);
        }

        [HttpPost, ActionName("iis")]
        public ActionResult ConfigureIisSection(string id, Iis config)
        {
            return Post(id, c => c.Iis = config);
        }

        private ActionResult View(string id, string viewName, Func<Config.VisualStudioConfiguration, object> property)
        {
            var configuration = _settingsManager.ReadConfiguration<Config.VisualStudioConfiguration>(id);
            return View(viewName, property(configuration));
        }

        private ActionResult Post(string id, Action<Config.VisualStudioConfiguration> update)
        {
            if (ModelState.IsValid)
            {
                _settingsManager.UpdateConfiguration(id, update);
            }

            return View();
        }
    }
}
