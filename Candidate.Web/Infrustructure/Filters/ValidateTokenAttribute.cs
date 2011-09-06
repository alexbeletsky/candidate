using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Candidate.Infrustructure.Filters {
    // TODO: unit test filter
    public class ValidateTokenAttribute : ActionFilterAttribute {
        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            base.OnActionExecuting(filterContext);

            var token = filterContext.ActionParameters["token"];

            if (!IsTokenValid(token)) {
                throw new Exception("User is not authorized");
            }
        }

        private bool IsTokenValid(object token) {
            // TODO: place logic for token validation here
            return true;
        }
    }
}