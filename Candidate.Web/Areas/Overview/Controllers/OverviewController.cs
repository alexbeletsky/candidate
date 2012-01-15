using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Candidate.Areas.Dashboard.Models;
using Candidate.Core.Services;
using Candidate.Core.Utils;

namespace Candidate.Areas.Overview.Controllers
{
    public class OverviewController : SecuredController
    {
        private readonly IUserManagement _userManagement;

        public OverviewController(IUserManagement userManagement)
        {
            _userManagement = userManagement;
        }

        [HttpGet]
        public ActionResult Show(string id)
        {
            var user = _userManagement.Current();
            var overview = new Dashboard.Models.Overview
                               {
                                   Id = id,
                                   LastBuildStatus = "Success",
                                   LastDeployTime = DateTime.Now,
                                   LastDeployDuration = new TimeSpan(0, 2, 30),
                                   GithubHook = string.Format(@"http://{0}{1}", Request.Url.Host, Url.Action("index", new {area = "Hook", controller="Hook", id, token = user.PasswordHash }))
                               };

            var directoryHelper = DirectoryHelper.For(id);

            if (Directory.Exists(directoryHelper.LogsDirectory))
            {
                overview.Logs = new DirectoryInfo(directoryHelper.LogsDirectory).GetFiles("*.log").OrderByDescending(f => f.CreationTime).Select(f => f.Name);
            }

            return View(overview);
        }
    }
}
