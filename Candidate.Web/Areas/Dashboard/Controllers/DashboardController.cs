using Candidate.Core.Settings.Model.Configurations;

namespace Candidate.Areas.Dashboard.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Candidate.Areas.Dashboard.Models;
    using Candidate.Core.Settings;
    using Candidate.Core.Settings.Model;
    using Candidate.Infrustructure.Authentication;

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

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(NewJobModel newJob)
        {
            if (ModelState.IsValid)
            {
                using (var settingsManager = new AutoSaveSettingsManager(_settingsManager))
                {
                    var currentSettings = settingsManager.ReadSettings<ConfigurationsList>();
                    var currentJobs = currentSettings.Configurations;

                    currentJobs.Add(new VisualStudioConfiguration { Id = SubstitutePunctuationWithDashes(newJob.Name), ReadableName = newJob.Name });

                    return RedirectToAction("Index", new { controller = "Dashboard" });
                }
            }

            return View(newJob);
        }

        private string SubstitutePunctuationWithDashes(string title)
        {
            var titleWithoutPunctuation = new string(title.Where(c => !char.IsPunctuation(c)).ToArray());
            return titleWithoutPunctuation.ToLower().Trim().Replace(" ", "-");
        }

    }
}
