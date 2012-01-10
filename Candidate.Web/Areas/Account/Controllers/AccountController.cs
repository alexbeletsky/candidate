using System.Web.Mvc;
using Candidate.Areas.Account.Models;
using Candidate.Core.Services;
using Candidate.Core.Settings;
using Candidate.Infrustructure.Authentication;

namespace Candidate.Areas.Account.Controllers
{
    public class AccountController : SecuredController
    {
        private readonly ISettingsManager _settingsManager;
        private readonly IHashService _hashService;

        public AccountController(ISettingsManager settingsManager, IHashService hashService)
        {
            _settingsManager = settingsManager;
            _hashService = hashService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var userSettings = _settingsManager.ReadSettings<UserSettings>();

            var user = userSettings.User;
            var model = new NewAccount
            {
                Login = user.Login
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(NewAccount model)
        {
            if (ModelState.IsValid)
            {
                using (var settings = new AutoSaveSettingsManager(_settingsManager))
                {
                    var userSettings = settings.ReadSettings<UserSettings>();
                    var user = userSettings.User;

                    user.Login = model.Login;
                    user.PasswordHash = _hashService.CreateMD5Hash(model.NewPassword);
                    user.TemporaryPassword = false;
                }
            }

            return View(model);
        }

    }
}
