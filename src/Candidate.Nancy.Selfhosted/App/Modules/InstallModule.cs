using Nancy;

namespace Candidate.Nancy.Selfhosted.App.Modules
{
    public class InstallModule : NancyModule
    {
        public InstallModule() : base("/install")
        {
            Get["/"] = p => "Install";
        }
    }
}
