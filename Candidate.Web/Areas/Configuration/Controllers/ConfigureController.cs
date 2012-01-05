using System.Web.Mvc;
using Candidate.Core.Settings;
using Candidate.Core.Extensions;

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

        [HttpGet, ActionName("configure")]
        public ActionResult Configure(string id)
        {
            var configuration = _settingsManager.ReadConfiguration<Core.Configurations.Types.Configuration>(id);
            return View(configuration.Type, configuration);
        }
    }
}
