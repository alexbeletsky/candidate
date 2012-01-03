namespace Candidate.Core.Model.Configurations
{
    public interface IDeployable
    {
        DeployResults Deploy();
    }

    public class DeployResults
    {
        public string Url { get; set; }
    }

    public abstract class Configuration : IDeployable
    {
        public string Id { get; set; }
        public string ReadableName { get; set; }

        public abstract string Type { get; }
        public abstract DeployResults Deploy();
    }
}