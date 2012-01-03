using System.Collections.Generic;
using Bounce.Framework;
using Candidate.Core.Model.Configurations;

namespace Candidate.Core.Deploy
{
    public class DeployRunner : IDeployRunner
    {
        private readonly IEnumerable<Target> _bounceTargets;

        public DeployRunner(IEnumerable<Target> bounceTargets)
        {
            _bounceTargets = bounceTargets;
        }

        public DeployResults Run()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Target> Targets
        {
            get { return _bounceTargets; }
        }
    }
}