using System.Web.Security;
using Candidate.Core.Account;
using Candidate.Core.Services;
using Candidate.Core.Settings;

namespace Candidate.Infrustructure.Authentication
{
    public class Authentication : IAuthentication
    {
        private readonly ISettingsManager _settingsManager;
        private readonly IHashService _hashService;

        public Authentication(ISettingsManager settingsManager, IHashService hashService)
        {
            _settingsManager = settingsManager;
            _hashService = hashService;
        }

        public bool ValidateUser(string login, string password)
        {
            var currentSettings = _settingsManager.ReadSettings<UserSettings>();
            var user = currentSettings.CurrentUser;

            if (user != null && user.Login == login && _hashService.ValidateMD5Hash(password, user.PasswordHash))
            {
                return true;
            }

            return false;
        }

        public void AuthenticateUser(string logon)
        {
            FormsAuthentication.SetAuthCookie(logon, false);
        }
    }
}