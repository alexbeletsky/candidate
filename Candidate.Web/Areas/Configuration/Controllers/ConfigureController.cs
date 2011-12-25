using System.Web.Mvc;
using Candidate.Core.Settings;
using Config = Candidate.Core.Model.Configurations;

namespace Candidate.Areas.Configuration.Controllers
{
    [Authorize]
    public class ConfigureController : Controller
    {
        private readonly ISettingsManager _settingsManager;

        public ConfigureController(ISettingsManager settingsManager)
        {
            _settingsManager = settingsManager;
        }

        [HttpGet, ActionName("batch")]
        public ActionResult ConfigureBatch(string id)
        {
            var configuration = _settingsManager.ReadConfiguration<Config.BatchConfiguration>(id);
            return View(configuration);
        }

        [HttpGet, ActionName("xcopy")]
        public ActionResult ConfigureXCopy(string id)
        {
            var configuration = _settingsManager.ReadConfiguration<Config.XCopyConfiguration>(id);
            return View(configuration);
        }

        [HttpGet, ActionName("visualstudio")]
        public ActionResult ConfigureVisualStudio(string id)
        {
            var configuration = _settingsManager.ReadConfiguration<Config.VisualStudioConfiguration>(id);
            return View(configuration);
        }
    }
}
