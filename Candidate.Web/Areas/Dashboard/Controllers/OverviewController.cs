using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Candidate.Areas.Dashboard.Models;
using Candidate.Core.Utils;
using System.IO;

namespace Candidate.Areas.Dashboard.Controllers {

    public class OverviewController : Controller {
        private IDirectoryProvider _directoryProvider;

        public OverviewController(IDirectoryProvider directoryProvider) {
            _directoryProvider = directoryProvider;
        }

        [HttpGet]
        public ActionResult Show(string jobName) {
            ViewBag.JobName = jobName;
            _directoryProvider.JobName = jobName;

            var logFiles = new DirectoryInfo(_directoryProvider.Logs).GetFiles("*.log").OrderByDescending(f => f.CreationTime).Select(f => f.Name);
            var overview = new OverviewModel { LastBuildStatus = "Success", LastDeployTime = DateTime.Now, LastDeployDuration = new TimeSpan(0, 2, 30), Logs = logFiles };

            return View(overview);
        }
    }
}
