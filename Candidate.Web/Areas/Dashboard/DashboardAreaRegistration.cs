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
                "Dashboard_hook",
                "dashboard/hook/{id}/token/{token}",
                new { controller = "Setup", action = "Hook" }
            );

            context.MapRoute(
                "Dashboard_log",
                "dashboard/log/{action}/{id}/{logId}",
                new { controller = "Log" }
            );

            context.MapRoute(
                "Dashboard_overview",
                "dashboard/overview/{action}/{id}",
                new { controller = "Overview" }
            );

            context.MapRoute(
                "Dashboard_default",
                "dashboard/{controller}/{action}/{id}",
                new { action = "Index", controller = "Dashboard", id = UrlParameter.Optional }
            );
        }
    }
}
