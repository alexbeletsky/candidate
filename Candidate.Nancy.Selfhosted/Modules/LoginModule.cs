using Nancy;

namespace Candidate.Nancy.Selfhosted.Modules
{
    public class LoginModule : NancyModule
    {
        public LoginModule()
        {
            Get["/"] = x => { return View["Login"]; };
        }
    }

    public class SuperModule : NancyModule
    {
        public SuperModule()
        {
            Get["/super"] = _ => { return View["super"]; };
        }
    }
}
