using Nancy;
using Raven.Client;

namespace Candidate.Nancy.Selfhosted.App.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule(IDocumentSession session) : base("/")
        {
            //this.RequiresAuthentication();

            Get["/"] = o => View["Master"];
        }
    }
}
