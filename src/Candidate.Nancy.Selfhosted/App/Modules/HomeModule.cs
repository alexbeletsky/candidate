using Nancy;

namespace Candidate.Nancy.Selfhosted.App.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule() : base("/")
        {
            //this.RequiresAuthentication();

            Get[""] = o => View["Master"];
        }
    }
}
