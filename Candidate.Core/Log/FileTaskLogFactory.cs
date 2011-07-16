using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bounce.Framework;
using System.IO;

namespace Candidate.Core.Log {
    public class FileTaskLogFactory : ITaskLogFactory {
        public ILog CreateLogForTask(ITask task, TextWriter stdout, TextWriter stderr, LogOptions logOptions) {
            return new FileLog(logOptions, new TaskLogMessageFormatter(task));
        }
    }
}
