using System;
using System.IO;

namespace Candidate.Core.Log {
    public interface ILogger : IDisposable {
        TextWriter LogWriter { get; }
        string LogFilename { get; }
        string LogFullPath { get; }
    }
}
