using System;
using Candidate.Core.Utils;

namespace Candidate.Core.Log {
    public class LoggerFactory : ILoggerFactory{
        private IDirectoryProvider _directoryProvider;

        public LoggerFactory(IDirectoryProvider directoryProvider) {
            _directoryProvider = directoryProvider;
        }
        
        public ILogger CreateLogger() {
            return new Logger(_directoryProvider);
        }

        //private string GetPathToLog() {
        //    return _directoryProvider.Logs + "\\" + GetUniqueLogFilename();
        //}

        //private string GetUniqueLogFilename() {
        //    return Guid.NewGuid().ToString() + ".log";
        //}
    }
}
