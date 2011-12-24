using System.Web.Mvc;

namespace Candidate.Areas.Configuration
{
    public class ConfigurationAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Configuration";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Configuration_default",
                "configuration/{action}/{id}",
                new { action = "Index", controller = "Configuration", id = UrlParameter.Optional }
            );
        }
    }
}
