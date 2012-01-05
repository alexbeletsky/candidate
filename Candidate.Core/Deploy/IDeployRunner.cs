using Candidate.Core.Log;

namespace Candidate.Core.Deploy
{
    public interface IDeployRunner
    {
        DeployResults Run(ILoggerFactory loggerFactory);
    }
}