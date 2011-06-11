
namespace Candidate.Core.System
{
    public interface ILogger
    {
        void Log(string line);
    }

    public interface IProcessRunner
    {
        void Run(string pathToExecutable);
    }
}
