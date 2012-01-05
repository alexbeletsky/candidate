using System.Web.Mvc;
using Candidate.Core.Settings;
using Config = Candidate.Core.Model.Configurations;
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
            var configuration = _settingsManager.ReadConfiguration<Config.Configuration>(id);
            return View(configuration.Type, configuration);
        }
    }
}
