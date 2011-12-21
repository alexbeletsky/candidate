using Bounce.Framework;

namespace Candidate.Core.Log
{
    public interface ILogOptionsFactory
    {
        LogOptions CreateLogOptions(ILogger logger, LogLevel level);
    }
}
