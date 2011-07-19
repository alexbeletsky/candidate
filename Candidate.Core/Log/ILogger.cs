using System;
using System.IO;

namespace Candidate.Core.Log {
    public interface ILogger : IDisposable {
        void Log(string line);

        TextWriter Writer { get; }
        string LogFilename { get; }
        string LogFullPath { get; }
    }
}
