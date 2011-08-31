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
                "Dashboard_log",
                "Dashboard/{controller}/{action}/{jobName}/{logId}",
                new { controller = "Log" }
            );

            context.MapRoute(
                "Dashboard_default",
                "Dashboard/{controller}/{action}/{jobName}",
                new { action = "Index", controller = "Dashboard", jobName = UrlParameter.Optional }
            );
        }
    }
}
