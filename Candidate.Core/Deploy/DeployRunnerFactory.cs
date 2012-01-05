using System;
using System.Linq;
using System.Text;
using Candidate.Core.Configurations;
using Candidate.Core.Configurations.Bounce.Builders;
using Candidate.Core.Configurations.Types;

namespace Candidate.Core.Deploy
{
    public class DeployRunnerFactory
    {
        public IDeployRunner ForConfiguration(BatchConfiguration config)
        {
            var bounceConfig = new BatchBounceConfigurationBuilder(config).CreateConfig();
            return new DeployRunner(bounceConfig.ToBounceTargets());
        }

        public IDeployRunner ForConfiguration(XCopyConfiguration config)
        {
            var bounceConfig = new XCopyBounceConfigurationBuilder(config).CreateConfig();
            return new DeployRunner(bounceConfig.ToBounceTargets());
        }

        internal IDeployRunner ForConfiguration(VisualStudioConfiguration config)
        {
            var bounceConfig = new VisualStudioBounceConfigurationBuilder(config).CreateConfig();
            return new DeployRunner(bounceConfig.ToBounceTargets());        
        }
    }
}
