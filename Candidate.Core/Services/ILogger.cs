using System;
using System.IO;

namespace Candidate.Core.Services
{
    public interface ILogger : IDisposable
    {
        TextWriter LogWriter { get; }
        string LogFileName { get; }
        string LogFileFullPath { get; }
    }
}
