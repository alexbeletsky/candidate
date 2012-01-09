using System.Web.Mvc;

namespace Candidate.Areas.FirstLaunch
{
    public class FirstLaunchAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "FirstLaunch";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "firstlaunch_firstlaunch",
                "firstlaunch/{action}",
                new { action = "Index", controller = "FirstLaunch" }
            );

            context.MapRoute(
                "FirstLaunch_default",
                "FirstLaunch/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
