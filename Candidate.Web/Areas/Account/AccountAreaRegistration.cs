using System.Web.Mvc;

namespace Candidate.Areas.Account
{
    public class AccountAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Account";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "account_default",
                "account/{controller}/{action}/{id}",
                new { action = "Index", controller="Account", id = UrlParameter.Optional }
            );
        }
    }
}
