using System.Web.Mvc;

namespace Ivanov.Build.Server.Areas.Dashboard
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
                "Dashboard_Configure",
                "Dashboard/Configure/{jobName}",
                new { action = "Configure", Controller = "Dashboard" }
            );

            context.MapRoute(
                "Dashboard_default",
                "Dashboard/{action}",
                new { action = "Index", Controller = "Dashboard" }
            );
        }
    }
}
