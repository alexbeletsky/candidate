using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Candidate.Infrustructure.Error
{
    // http://www.dotnetcurry.com/ShowArticle.aspx?ID=496

    public class HandleJsonError : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception != null)
            {
                SetResponseStatusCode(filterContext);
                filterContext.Result = new JsonResult()
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        success = false,
                        message = filterContext.Exception.Message,
                    }
                };
                filterContext.ExceptionHandled = true;
            }
        }

        private static void SetResponseStatusCode(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception is NotImplementedException)
            {
                filterContext.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.NotImplemented;
            }
            else
            {
                filterContext.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
            }
        }
    }
}