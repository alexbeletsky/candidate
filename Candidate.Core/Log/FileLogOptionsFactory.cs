using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bounce.Framework;

namespace Candidate.Core.Log {
    public class FileLogOptionsFactory : ILogOptionsFactory{

        public LogOptions CreateLogOptions(ILogger logger, LogLevel level) {
            return new LogOptions { LogLevel = level, CommandOutput = true, DescribeTasks = true, StdErr = logger.Writer, StdOut = logger.Writer };
        }
    }
}
