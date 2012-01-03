using Candidate.Core.Deploy;

namespace Candidate.Core.Model.Configurations
{
    public interface IDeployable
    {
        IDeployRunner CreateDeployRunner();
    }
}