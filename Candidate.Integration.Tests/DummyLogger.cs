using Candidate.Core.Log;
using Moq;

namespace Candidate.Tests.Integration {
    public class DummyLogger : ILogger {

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

    public class NullLogger : ILogger {
        public System.IO.TextWriter LogWriter {
            get { return new Mock<System.IO.TextWriter>(MockBehavior.Loose) { DefaultValue = DefaultValue.Mock }.Object; }
        }

        public string LogFilename {
            get { throw new System.NotImplementedException(); }
        }

        public string LogFullPath {
            get { throw new System.NotImplementedException(); }
        }

        public void Dispose() {
            throw new System.NotImplementedException();
        }
    }

}
