using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nancy;

namespace Candidate.Nancy.Selfhosted.Modules
{
    public class AccountModule : NancyModule
    {
        public AccountModule() : base("/account")
        {
            Get["/login"] = p => "Login";
        }
    }
}
