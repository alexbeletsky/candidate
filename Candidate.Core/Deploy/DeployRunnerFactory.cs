using System;
using System.Linq;
using System.Text;
using Candidate.Core.Configurations;
using Candidate.Core.Configurations.Bounce;
using Candidate.Core.Configurations.Bounce.Builders;
using Candidate.Core.Model.Configurations;
using Candidate.Core.Utils;

namespace Candidate.Core.Deploy
{
    public class DeployRunnerFactory
    {
        private readonly IDirectoryProvider _directoryProvider;
        private readonly BounceConfigurationFactory _bounceConfigFactory;

        public DeployRunnerFactory(IDirectoryProvider directoryProvider)
        {
            _directoryProvider = directoryProvider;
            _bounceConfigFactory = new BounceConfigurationFactory(_directoryProvider);
        }

        public IDeployRunner ForConfiguration(BatchConfiguration config)
        {
            return new DeployRunner(_bounceConfigFactory.CreateFor(config).ToBounceTargets());            
        }

        public IDeployRunner ForConfiguration(XCopyConfiguration config)
        {
            return new DeployRunner(_bounceConfigFactory.CreateFor(config).ToBounceTargets());
        }
    }
}
