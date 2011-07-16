using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bounce.Framework;
using System.IO;

namespace Candidate.Core.Log {
    public class FileLog : ILog, ICommandLog {
        private LogOptions logOptions;
        private ILogMessageFormatter taskLogMessageFormatter;

        public FileLog(LogOptions logOptions, ILogMessageFormatter taskLogMessageFormatter) {
            this.logOptions = logOptions;
            this.taskLogMessageFormatter = taskLogMessageFormatter;
        }
        public ICommandLog BeginExecutingCommand(string command, string args) {
            return this;
        }

        public void Debug(object message) {
            throw new NotImplementedException();
        }

        public void Debug(string format, params object[] args) {
            throw new NotImplementedException();
        }

        public void Error(Exception exception, object message) {
            throw new NotImplementedException();
        }

        public void Error(object message) {
            throw new NotImplementedException();
        }

        public void Error(Exception exception, string format, params object[] args) {
            throw new NotImplementedException();
        }

        public void Error(string format, params object[] args) {
            throw new NotImplementedException();
        }

        public void Info(object message) {
            throw new NotImplementedException();
        }

        public void Info(string format, params object[] args) {
            throw new NotImplementedException();
        }

        public ITaskLog TaskLog {
            get { throw new NotImplementedException(); }
        }

        public void Warning(Exception exception, object message) {
            throw new NotImplementedException();
        }

        public void Warning(object message) {
            throw new NotImplementedException();
        }

        public void Warning(Exception exception, string format, params object[] args) {
            throw new NotImplementedException();
        }

        public void Warning(string format, params object[] args) {
            throw new NotImplementedException();
        }

        public string CommandArgumentsForLogging {
            get { throw new NotImplementedException(); }
        }

        public void CommandComplete(int exitCode) {
            throw new NotImplementedException();
        }

        public void CommandError(string error) {
            throw new NotImplementedException();
        }

        public void CommandOutput(string output) {
            throw new NotImplementedException();
        }
    }
}
