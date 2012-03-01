using System;
using System.Web.Mvc;

namespace Candidate.Infrustructure.Error
{
    // http://www.dotnetcurry.com/ShowArticle.aspx?ID=496

    public class HandleJsonError : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception != null && filterContext.HttpContext.Request.IsAjaxRequest())
            {
                SetResponseStatusCode(filterContext);
                filterContext.Result = new JsonResult()
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        success = false,
                        message = GetExceptionMessage(filterContext.Exception),
                    }
                };
                filterContext.ExceptionHandled = true;
            }
        }

        private string GetExceptionMessage(Exception exception)
        {
            var aggregateException = exception as AggregateException;

            if (aggregateException != null)
            {
                return aggregateException.InnerException.Message;
            }

            return exception.Message;
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