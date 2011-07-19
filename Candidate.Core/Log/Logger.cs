using System.IO;
using Candidate.Core.Utils;
using System;

namespace Candidate.Core.Log {
    public class Logger : ILogger {
        private StreamWriter _writter;
        private FileStream _fileStream;

        public Logger(IDirectoryProvider directoryProvider) {

            LogFilename = GetUniqueLogFilename();
            LogsDirectory = directoryProvider.Logs;
            LogFullPath = LogsDirectory + "\\" + LogFilename;

            CreateLogsDirectory();
            CreateLogsWriter();
        }

        private void CreateLogsWriter() {
            _writter = new StreamWriter(new FileStream(LogFullPath, FileMode.OpenOrCreate));
        }

        private void CreateLogsDirectory() {
            if (!Directory.Exists(LogsDirectory)) {
                Directory.CreateDirectory(LogsDirectory);
            }
        }

        public void Dispose() {
            _writter.Close();
        }

        public TextWriter LogWriter {
            get {
                return _writter;
            }
        }

        public string LogFilename {
            get;
            private set;
        }

        public string LogFullPath {
            get;
            private set;
        }

        private string GetUniqueLogFilename() {
            return DateTime.Now.ToString("MMddyyyy_HHmmss") + ".log";
        }

        public string LogsDirectory { get; set; }
    }
}
