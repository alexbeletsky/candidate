using Candidate.Core.Log;

namespace Candidate.Tests.Integration {
    public class DummyLogger : ILogger {
        public void Log(string line) {
            Writer.WriteLine(line);
        }

        public global::System.IO.TextWriter Writer {
            get {
                return global::System.Console.Out;
            }
        }

        public string Id {
            get {
                return "loggerId";
            }
        }

        public void Dispose() {
        }
    }
}
