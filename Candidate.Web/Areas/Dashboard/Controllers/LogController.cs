using System.IO;
using System.Web.Mvc;
using Candidate.Core.Utils;

namespace Candidate.Areas.Dashboard.Controllers {
    
    public class LogController : Controller {
        private IDirectoryProvider _directoryProvider;

        public LogController(IDirectoryProvider directoryProvider) {
            _directoryProvider = directoryProvider;
        }

        //[HttpGet]
        //public ActionResult ReadLog(string jobName, string logId, int offset) {
        //    var bufferSize = 512;
        //    var buffer = new char[bufferSize];
        //    var count = 0;

        //    using (var reader = new StreamReader(logId)) {
        //        reader.BaseStream.Seek(offset, SeekOrigin.Begin);
        //        count = reader.Read(buffer, 0, buffer.Length);
        //    }

        //    return Json(new { success = true, eof = count == 0, count = count, line = new string(buffer, 0, count) }, JsonRequestBehavior.AllowGet);
        //}

        [HttpGet]
        public ActionResult ShowLog(string jobName, string logId) {

            var pathToLog = _directoryProvider.Logs + "\\" + logId;
            using (var reader = new StreamReader(pathToLog)) {
                return new ContentResult { ContentType = "text/plain", Content = reader.ReadToEnd() }; 
            }

        }
    }
}
