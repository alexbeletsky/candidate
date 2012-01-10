using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Candidate.Areas.Dashboard.Models;
using Candidate.Core.Utils;

namespace Candidate.Areas.Overview.Controllers
{
    public class OverviewController : SecuredController
    {
        [HttpGet]
        public ActionResult Show(string id)
        {
            var directoryHelper = DirectoryHelper.For(id);

            if (Directory.Exists(directoryHelper.LogsDirectory))
            {
                var logFiles = new DirectoryInfo(directoryHelper.LogsDirectory).GetFiles("*.log").OrderByDescending(f => f.CreationTime).Select(f => f.Name);
                var overview = new Dashboard.Models.Overview { Id = id, LastBuildStatus = "Success", LastDeployTime = DateTime.Now, LastDeployDuration = new TimeSpan(0, 2, 30), Logs = logFiles };

                return View(overview);
            }

            return View("NoInfo");
        }
    }
}
