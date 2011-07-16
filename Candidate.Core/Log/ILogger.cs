using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Candidate.Core.Log {
    public interface ILogger : IDisposable {
        void Log(string line);

        TextWriter Writer { get; }
        string Id { get; }
    }
}
