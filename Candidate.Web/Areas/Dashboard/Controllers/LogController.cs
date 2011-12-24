using System.IO;
using System.Web.Mvc;
using Candidate.Core.Utils;

namespace Candidate.Areas.Dashboard.Controllers
{

    [Authorize]
    public class LogController : Controller
    {
        private readonly IDirectoryProvider _directoryProvider;

        public LogController(IDirectoryProvider directoryProvider)
        {
            _directoryProvider = directoryProvider;
        }

        [HttpGet]
        public ActionResult Show(string jobName, string logId)
        {
            _directoryProvider.SiteName = jobName;

            var pathToLog = _directoryProvider.Logs + "\\" + logId;
            using (var reader = new StreamReader(pathToLog))
            {
                return new ContentResult { ContentType = "text/plain", Content = reader.ReadToEnd() };
            }
        }
    }
}
