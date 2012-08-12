using System;
using Nancy;

namespace Candidate.Nancy.Selfhosted.App.Modules
{
    public class AccountModule : NancyModule
    {
        private readonly IUserManagement _userManagement;

        public AccountModule(IUserManagement userManagement) : base("/account")
        {
            _userManagement = userManagement;

            Get["/login"] = p => View["Login"];
        }
    }

    public interface IUserManagement
    {
        User CurrentUser { get; }
        void CreateUser(string login, string password);
    }

    public class UserManagement : IUserManagement
    {
        public User CurrentUser
        {
            get { throw new NotImplementedException(); }
        }

        public void CreateUser(string login, string password)
        {
            throw new NotImplementedException();
        }
    }

    public class User
    {
        public string Login { get; set; }
        public string PasswordHash { get; set; }
    }
}
