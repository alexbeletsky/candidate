using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace Ivanov.Build.Server.Areas.Dashboard.Controllers
{
    public class LogController : Controller
    {
        [HttpGet]
        public ActionResult ReadLog(string jobName, string logId, int offset)
        {
            var bufferSize = 512;
            var buffer = new char[bufferSize];
            var count = 0;

            using (var reader = new StreamReader(logId))
            {
                reader.BaseStream.Seek(offset, SeekOrigin.Begin);
                count = reader.Read(buffer, 0, buffer.Length);
            }

            return Json(new { success = true, eof = count == 0, count = count, line = new string(buffer, 0, count) }, JsonRequestBehavior.AllowGet);
        }
    }
}
