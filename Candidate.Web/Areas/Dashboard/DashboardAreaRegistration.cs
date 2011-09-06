using System.Web.Mvc;

namespace Candidate.Areas.Dashboard {
    public class DashboardAreaRegistration : AreaRegistration {
        public override string AreaName {
            get {
                return "Dashboard";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) {

            context.MapRoute(
                "Dashboard_hook",
                "Dashboard/hook/{jobName}/token/{token}",
                new { controller = "Setup", action = "Hook" }
            );

            context.MapRoute(
                "Dashboard_log",
                "Dashboard/Log/{action}/{jobName}/{logId}",
                new { controller = "Log" }
            );

            context.MapRoute(
                "Dashboard_overview",
                "Dashboard/Overview/{action}/{*jobName}",
                new { controller = "Overview" }
            );

            context.MapRoute(
                "Dashboard_default",
                "Dashboard/{controller}/{action}/{*jobName}",
                new { action = "Index", controller = "Dashboard", jobName = UrlParameter.Optional }
            );
        }
    }
}
