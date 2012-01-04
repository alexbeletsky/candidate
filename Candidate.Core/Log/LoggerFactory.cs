using System;
using Candidate.Core.Utils;

namespace Candidate.Core.Log
{
    public class LoggerFactory : ILoggerFactory
    {
        private readonly IDirectoryProvider _directoryProvider;

        public LoggerFactory(IDirectoryProvider directoryProvider)
        {
            _directoryProvider = directoryProvider;
        }

        public ILogger CreateLogger()
        {
            return new Logger(_directoryProvider);
        }
    }
}
