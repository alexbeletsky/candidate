using Candidate.Core.Model.Configurations;

namespace Candidate.Core.Deploy
{
    public interface IDeployRunner
    {
        DeployResults Run();
    }
}