using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Candidate.Core.Settings;
using Candidate.Core.Services;
using Ninject;

namespace Candidate.Infrustructure.Authentication {
    public class Authentication : IAuthentication {
        private ISettingsManager _settingsManager;
        private IHashService _hashService;

        public Authentication(ISettingsManager settingsManager, IHashService hashService) {
            _settingsManager = settingsManager;
            _hashService = hashService;
        }

        public bool ValidateUser(string login, string password) {
            var currentSettings = _settingsManager.ReadSettings<UserSettings>();
            var user = currentSettings.User;

            if (user != null && user.Login == login && _hashService.ValidateMD5Hash(password, user.PasswordHash)) {
                return true;
            }

            return false;
        }

        public void AuthenticateUser(string logon) {
            FormsAuthentication.SetAuthCookie(logon, false);
        }
    }
}