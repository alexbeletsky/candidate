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
                "Dashboard_Setup",
                "Dashboard/Setup/{action}/{jobName}",
                new { controller = "Setup" }
            );

            context.MapRoute(
                "Dashboard_Log",
                "Dashboard/Log/{action}/{jobName}",
                new { controller = "Log" }
            );

            context.MapRoute(
                "Dashboard_Batch",
                "Dashboard/Batch/{action}/{jobName}",
                new { controller = "Batch",  }
            );

            context.MapRoute(
                "Dashboard_Configuration",
                "Dashboard/SiteConfiguration/{action}/{jobName}",
                new { controller = "SiteConfiguration", }
            );

            context.MapRoute(
                "Dashboard_default",
                "Dashboard/{action}/{jobName}",
                new { action = "Index", controller = "Dashboard", jobName = UrlParameter.Optional }
            );
        }
    }
}
