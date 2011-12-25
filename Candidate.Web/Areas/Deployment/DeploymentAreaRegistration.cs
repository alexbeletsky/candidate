using System.Web.Mvc;

namespace Candidate.Areas.Deployment
{
    public class DeploymentAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Deployment";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            
            context.MapRoute(
                "Deployment_default",
                "deployment/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
