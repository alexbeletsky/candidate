namespace Candidate.Core.Deploy
{
    public interface IDeployable
    {
        IDeployRunner CreateDeployRunner();
    }
}