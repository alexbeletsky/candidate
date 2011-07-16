using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Candidate.Core.Utils;

namespace Candidate.Core.Log {
    // TODO: refactor
    public class Logger : ILogger {
        private StreamWriter _writter;
        private FileStream _log;
        private string _pathToLog;

        public Logger(string pathToLog) {
            _pathToLog = pathToLog;

            var folder = Path.GetDirectoryName(_pathToLog);

            if (!Directory.Exists(folder)) {
                Directory.CreateDirectory(folder);
            }

            if (File.Exists(_pathToLog)) {
                File.Delete(_pathToLog);
            }

            _log = new FileStream(_pathToLog, FileMode.OpenOrCreate);
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

        public string Id {
            get {
                return _pathToLog;
            }
        }
    }
}
