namespace Candidate.Core.Deploy
{
    public interface IDeployRunner
    {
        DeployResults Run(string id);
    }
}