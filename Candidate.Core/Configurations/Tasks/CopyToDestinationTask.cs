using Bounce.Framework;

namespace Candidate.Core.Configurations.Tasks
{
    internal class CopyToDestinationTask
    {
        private readonly string _fromDirectory;
        private readonly string _toDirectory;

        public CopyToDestinationTask(string fromDirectory, string toDirectory)
        {
            _fromDirectory = fromDirectory;
            _toDirectory = toDirectory;
        }

        public Copy ToTask()
        {
            return new Copy 
                       { 
                           FromPath = _fromDirectory,
                           ToPath = _toDirectory,
                           Excludes = new [] { @"**\.git\" },
                           DeleteToDirectory = true
                       };
        }
    }
}