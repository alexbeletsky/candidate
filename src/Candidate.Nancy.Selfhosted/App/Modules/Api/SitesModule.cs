using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nancy;

namespace Candidate.Nancy.Selfhosted.App.Modules.Api
{
    public class SitesModule : NancyModule
    {
        public SitesModule() : base("/api/sites")
        {
            Get["/"] = parameters => Response.AsJson(new[] {new {Name = "Site 1"}});
        }
    }
}
