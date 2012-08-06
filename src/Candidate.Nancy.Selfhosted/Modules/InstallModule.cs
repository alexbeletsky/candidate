using Nancy;

namespace Candidate.Nancy.Selfhosted.Modules
{
    public class InstallModule : NancyModule
    {
        public InstallModule() : base("/install")
        {
            Get["/"] = p => "Install";
        }
    }
}
