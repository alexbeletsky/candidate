using System.IO;
using System.Web.Mvc;
using Candidate.Core.Utils;

namespace Candidate.Areas.Dashboard.Controllers {
    
    public class LogController : Controller {
        private IDirectoryProvider _directoryProvider;

        public LogController(IDirectoryProvider directoryProvider) {
            _directoryProvider = directoryProvider;
        }

        [HttpGet]
        public ActionResult ShowLog(string jobName, string logId) {
            _directoryProvider.JobName = jobName;

            var pathToLog = _directoryProvider.Logs + "\\" + logId;
            using (var reader = new StreamReader(pathToLog)) {
                return new ContentResult { ContentType = "text/plain", Content = reader.ReadToEnd() }; 
            }
        }
    }
}
