using Candidate.Core.Deploy;

namespace Candidate.Core.Model.Configurations
{
    public abstract class Configuration : IDeployable
    {
        public string Id { get; set; }
        public string ReadableName { get; set; }

        public abstract string Type { get; }
        public abstract IDeployRunner CreateDeployRunner();
    }
}