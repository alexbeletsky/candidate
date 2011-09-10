using System.Web.Mvc;
using Candidate.Core.Services;
using Ninject;

namespace Candidate.Infrustructure.Filters {
    public class AddViewNameAndHashAttribute : ActionFilterAttribute {
        [Inject]
        public IHashService HashServices { get; set; }
        
        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            var jobName = filterContext.ActionParameters["jobName"] as string;
            filterContext.Controller.ViewBag.JobName = jobName;
            filterContext.Controller.ViewBag.JobNameHash = HashServices.CreateMD5Hash(jobName);
        }
    }
}