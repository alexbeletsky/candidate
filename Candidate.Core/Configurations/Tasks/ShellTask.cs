using Bounce.Framework;

namespace Candidate.Core.Configurations.Tasks
{
    public class ShellTask
    {
        private readonly string _batch;
        private readonly string _sourcesDirectory;

        public ShellTask(string batch, string sourcesDirectory)
        {
            _batch = batch;
            _sourcesDirectory = sourcesDirectory;
        }

        public ShellCommand ToTask()
        {
            return new ShellCommand
            {
                Arguments = _batch,
                WorkingDirectory = _sourcesDirectory,
            };
        }
    }
}