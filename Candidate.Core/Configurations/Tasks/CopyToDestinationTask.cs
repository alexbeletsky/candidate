using System.IO;
using Bounce.Framework;

namespace Candidate.Core.Configurations.Tasks
{
    internal class CopyToDestinationTask
    {
        private readonly string _sources;
        private readonly string _deployFolder;
        private readonly string _id;

        public CopyToDestinationTask(string sources, string deployFolder, string id)
        {
            _sources = sources;
            _deployFolder = deployFolder;
            _id = id;
        }

        public Copy ToTask()
        {
            return new Copy 
                       { 
                           FromPath = _sources,
                           ToPath = Path.Combine(_deployFolder, _id),
                           Excludes = new [] { ".git" }
                       };
        }
    }
}