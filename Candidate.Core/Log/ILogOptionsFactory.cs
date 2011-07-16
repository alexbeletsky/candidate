using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bounce.Framework;

namespace Candidate.Core.Log {
    public interface ILogOptionsFactory {
        LogOptions CreateLogOptions(ILogger logger, LogLevel level);
    }
}
