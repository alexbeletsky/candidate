using System.IO;
using Bounce.Framework;

namespace Candidate.Core.Configurations.Tasks
{
    internal class CopyToDestinationTask
    {
        private readonly string _sourcesFolder;
        private readonly string _deployFolder;
        private readonly string _configurationId;

        public CopyToDestinationTask(string sourcesFolder, string deployFolder, string configurationId)
        {
            _sourcesFolder = sourcesFolder;
            _deployFolder = deployFolder;
            _configurationId = configurationId;
        }

        public Copy ToTask()
        {
            return new Copy 
                       { 
                           FromPath = _sourcesFolder,
                           ToPath = Path.Combine(_deployFolder, _configurationId),
                           Excludes = new [] { ".git" },
                           DeleteToDirectory = true
                       };
        }
    }
}