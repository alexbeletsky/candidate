using Candidate.Core.Deploy;

namespace Candidate.Core.Configurations.Types
{
    public abstract class Configuration : IDeployable
    {
        public string Id { get; set; }
        public string ReadableName { get; set; }

        public abstract string Type { get; }

        public abstract IDeployRunner CreateDeployRunner();
    }
}