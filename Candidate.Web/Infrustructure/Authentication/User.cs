
namespace Candidate.Infrustructure.Authentication
{
    public class User
    {
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public bool TemporaryPassword { get; set; }
    }
}