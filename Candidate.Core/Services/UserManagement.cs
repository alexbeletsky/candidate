using Candidate.Core.Account;
using Candidate.Core.Settings;

namespace Candidate.Core.Services
{
    public class UserManagement : IUserManagement
    {
        private readonly ISettingsManager _settingsManager;
        private readonly IHashService _hashService;

        public UserManagement(ISettingsManager settingsManager, IHashService hashService)
        {
            _settingsManager = settingsManager;
            _hashService = hashService;
        }

        public User Current()
        {
            var userSettings = _settingsManager.ReadSettings<UserSettings>();
            return userSettings.CurrentUser;
        }

        public void Create(string login, string password)
        {
            using (var settings = new AutoSaveSettingsManager(_settingsManager))
            {
                var userSettings = settings.ReadSettings<UserSettings>();
                var user = new User
                               {
                                   Login = login,
                                   PasswordHash = _hashService.CreateMD5Hash(password)
                               };

                userSettings.CurrentUser = user;
            }
        }
    }
}