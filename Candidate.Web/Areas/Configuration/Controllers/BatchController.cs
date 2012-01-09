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
    public class BatchController : ConfigureControllerBase
    {
        public BatchController(ISettingsManager settingsManager) : base(settingsManager)
        {
        }

        [HttpGet, ActionName("github")]
        public ActionResult ConfigureGithibSection(string id)
        {
            return View<BatchConfiguration>(id, "Github", c => c.Github);
        }

        [HttpPost, ActionName("github")]
        public ActionResult ConfigureGithibSection(string id, Github config)
        {
            return Post<BatchConfiguration>(id, c => c.Github = config);
        }

        [HttpGet, ActionName("iis")]
        public ActionResult ConfigureIisSection(string id)
        {
            return View<BatchConfiguration>(id, "Iis", c => c.Iis);
        }

        [HttpPost, ActionName("iis")]
        public ActionResult ConfigureIisSection(string id, Iis config)
        {
            return Post<BatchConfiguration>(id, c => c.Iis = config);
        }

        [HttpGet, ActionName("batch")]
        public ActionResult ConfigurePostSection(string id)
        {
            return View<BatchConfiguration>(id, "Batch", c => c.Batch);
        }

        [HttpPost, ActionName("batch")]
        public ActionResult ConfigurePostSection(string id, Batch config)
        {
            return Post<BatchConfiguration>(id, c => c.Batch = config);
        }
    }
}
