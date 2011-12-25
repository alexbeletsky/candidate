using Bounce.Framework;

namespace Candidate.Core.Configurations.Tasks
{
    internal class CopyToDestinationTask
    {
        private readonly string _sourcesFolder;
        private readonly string _deployFolder;

        public CopyToDestinationTask(string sourcesFolder, string deployFolder)
        {
            _sourcesFolder = sourcesFolder;
            _deployFolder = deployFolder;
        }

        public Copy ToTask()
        {
            return new Copy 
                       { 
                           FromPath = _sourcesFolder,
                           ToPath = _deployFolder,
                           Excludes = new [] { ".git" },
                           DeleteToDirectory = true
                       };
        }
    }
}