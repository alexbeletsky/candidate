using Candidate.Core.Log;

namespace Candidate.Tests.Integration {
    public class DummyLogger : ILogger {
        public void Log(string line) {
            LogWriter.WriteLine(line);
        }

        public global::System.IO.TextWriter LogWriter {
            get {
                return global::System.Console.Out;
            }
        }

        public string LogFilename {
            get { throw new global::System.NotImplementedException(); }
        }

        public string LogFullPath {
            get { throw new global::System.NotImplementedException(); }
        }

        public void Dispose() {
            throw new global::System.NotImplementedException();
        }
    }
}
