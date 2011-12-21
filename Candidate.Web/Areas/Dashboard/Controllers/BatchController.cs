namespace Candidate.Areas.Dashboard.Controllers
{
    using System;
    using System.Web.Mvc;
    using Candidate.Core.Settings;

    [Authorize]
    public class BatchController : Controller
    {
        private ISettingsManager _settingsManager;

        public BatchController(ISettingsManager settingsManager)
        {
            _settingsManager = settingsManager;
        }

        [HttpPost]
        public ActionResult RunBatch(string jobName)
        {
            throw new NotImplementedException();
        }
    }
}
