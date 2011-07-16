using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candidate.Core.Log {
    public class LoggerFactory : ILoggerFactory{
        public ILogger CreateLogger(string pathToLogsFolder) {
            return new Logger(GetPathToLog(pathToLogsFolder));
        }

        private string GetPathToLog(string pathToLogsFolder) {
            return pathToLogsFolder + GetUniqueLogFilename();
        }

        private string GetUniqueLogFilename() {
            return Guid.NewGuid().ToString() + ".log";
        }
    }
}
