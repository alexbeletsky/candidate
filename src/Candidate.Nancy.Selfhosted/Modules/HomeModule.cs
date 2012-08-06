using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nancy;
using Nancy.Security;
using Raven.Client;

namespace Candidate.Nancy.Selfhosted.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule(IDocumentSession session) : base("/")
        {
            this.RequiresAuthentication();

            Get["/"] = o => "Home";
        }
    }
}
