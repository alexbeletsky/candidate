using System;
using System.IO;
using System.Web.Mvc;

namespace Candidate.Areas.Dashboard.Controllers
{
    public class LogController : SecuredController
    {
        [HttpGet]
        public ActionResult Show(string jobName, string logId)
        {
            throw new NotImplementedException();
            //_directoryProvider.SiteName = jobName;

            //var pathToLog = _directoryProvider.Logs + "\\" + logId;
            //using (var reader = new StreamReader(pathToLog))
            //{
            //    return new ContentResult { ContentType = "text/plain", Content = reader.ReadToEnd() };
            //}
        }
    }
}
