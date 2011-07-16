using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candidate.Core.Log {
    public interface ILoggerFactory {
        ILogger CreateLogger(string pathToLogsFolder);
    }
}
