
namespace Candidate.Infrustructure.Authentication
{
    public interface IAuthentication
    {
        bool ValidateUser(string login, string password);
        void AuthenticateUser(string login);
    }
}