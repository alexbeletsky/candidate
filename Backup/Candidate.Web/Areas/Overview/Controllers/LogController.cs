using System;
using System.IO;
using System.Web.Mvc;
using Candidate.Core.Utils;

namespace Candidate.Areas.Overview.Controllers
{
    public class LogController : SecuredController
    {
        [HttpGet]
        public ActionResult Show(string id, string logId)
        {
            var pathToLog = Path.Combine(DirectoryHelper.For(id).LogsDirectory, logId);

            using (var reader = new StreamReader(pathToLog))
            {
                return new ContentResult { ContentType = "text/plain", Content = reader.ReadToEnd() };
            }
        }
    }
}
