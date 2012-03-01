using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Candidate.Core.Services;
using Ninject;

namespace Candidate.Infrustructure.Filters
{
    public class AuthorizeByTokenAttribute : AuthorizeAttribute
    {
        [Inject]
        public IUserManagement UserManagement { get; set; }
 
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var token = filterContext.HttpContext.Request["token"];

            if (UserManagement.Current().PasswordHash != token)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}