using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Candidate.Areas.Dashboard.Models;

namespace Candidate.Areas.Dashboard.Controllers
{
    public class OverviewController : SecuredController
    {
        [HttpGet]
        public ActionResult Show(string jobName)
        {
            throw new NotImplementedException();

            //ViewBag.JobName = jobName;
            //_directoryProvider.SiteName = jobName;

            //if (Directory.Exists(_directoryProvider.Logs))
            //{
            //    var logFiles = new DirectoryInfo(_directoryProvider.Logs).GetFiles("*.log").OrderByDescending(f => f.CreationTime).Select(f => f.Name);
            //    var overview = new OverviewModel { LastBuildStatus = "Success", LastDeployTime = DateTime.Now, LastDeployDuration = new TimeSpan(0, 2, 30), Logs = logFiles };

            //    return View(overview);
            //}

            //return View("NoInfo");
        }
    }
}
