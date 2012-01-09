using Candidate.Core.Deploy;

namespace Candidate.Core.Configurations.Types
{
    public abstract class Configuration : IDeployable, IConfigurable
    {
        public string Id { get; set; }
        public string ReadableName { get; set; }

        public abstract string Type { get; }
        public abstract bool IsConfigured();
        public abstract IDeployRunner CreateDeployRunner();
    }
}