using System.IO;
using Candidate.Core.Utils;
using System;

namespace Candidate.Core.Log {
    // TODO: refactor
    public class Logger : ILogger {
        private StreamWriter _writter;
        private FileStream _log;

        public Logger(IDirectoryProvider directoryProvider) {

            LogFilename = GetUniqueLogFilename();
            LogFullPath = directoryProvider.Logs + "\\" + LogFilename;

            var folder = Path.GetDirectoryName(LogFullPath);

            if (!Directory.Exists(folder)) {
                Directory.CreateDirectory(folder);
            }

            if (File.Exists(LogFullPath)) {
                File.Delete(LogFullPath);
            }

            _log = new FileStream(LogFullPath, FileMode.OpenOrCreate);
            _writter = new StreamWriter(_log);
        }

        public void Dispose() {
            _writter.Close();
        }

        public void Log(string line) {
            _writter.WriteLine(line);
        }

        public TextWriter Writer {
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
            return Guid.NewGuid().ToString() + ".log";
        }
    }
}
