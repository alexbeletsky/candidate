using System.Web.Mvc;

namespace Candidate.Areas.Dashboard
{
    public class DashboardAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Dashboard";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Dashboard_default",
                "dashboard/{controller}/{action}/{id}",
                new { action = "Index", controller = "Dashboard", id = UrlParameter.Optional }
            );
        }
    }
}
