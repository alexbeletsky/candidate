using System.Web.Mvc;

namespace Candidate.Areas.Hook
{
    public class HookAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Hook";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Hook_hooh",
                "hook/{id}/",
                new { action = "Index", controller = "Hook" }
            );

            context.MapRoute(
                "Hook_default",
                "hook/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
