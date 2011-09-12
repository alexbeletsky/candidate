using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Candidate.Infrustructure.Authentication {
    public interface IAuthentication {
        bool ValidateUser(string login, string password);
        void AuthenticateUser(string login);
    }
}