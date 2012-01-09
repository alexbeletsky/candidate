using System.Web.Mvc;

namespace Candidate.Areas.Overview
{
    public class OverviewAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Overview";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Overview_showlog",
                "overview/log/{id}/{logId}",
                new { action = "Show", controller = "Log" }
            );

            context.MapRoute(
                "Overview_overview",
                "overview/{action}/{id}",
                new { action = "Index", controller = "overview", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Overview_default",
                "Overview/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
