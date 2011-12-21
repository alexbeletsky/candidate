
namespace Candidate.Infrustructure.Authentication
{
    public class UserSettings
    {
        public UserSettings()
        {
            User = new User { Login = "admin", PasswordHash = "21232f297a57a5a743894a0e4a801fc3", TemporaryPassword = true };
        }

        public User User { get; set; }
    }
}