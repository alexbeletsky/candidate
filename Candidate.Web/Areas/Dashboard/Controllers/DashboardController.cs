using System.Web.Mvc;
using Candidate.Core.Configurations;
using Candidate.Core.Settings;
using Candidate.Infrustructure.Authentication;

namespace Candidate.Areas.Dashboard.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ISettingsManager _settingsManager;

        public DashboardController(ISettingsManager settingsManager)
        {
            _settingsManager = settingsManager;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var userSettings = _settingsManager.ReadSettings<UserSettings>();
            ViewBag.TemporaryPassword = userSettings.User.TemporaryPassword;

            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var currentSettings = _settingsManager.ReadSettings<ConfigurationsList>();

            return View(currentSettings.Configurations);
        }
    }
}
