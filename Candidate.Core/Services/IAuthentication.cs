
namespace Candidate.Core.Services
{
    public interface IAuthentication
    {
        bool ValidateUser(string login, string password);
        void AuthenticateUser(string login);
    }
}