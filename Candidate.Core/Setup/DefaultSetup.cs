using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Candidate.Core.Settings.Model;
using Bounce.Framework;

namespace Candidate.Core.Setup {
    public class DefaultSetup : ISetup {
        private ITargetsObjectBuilder _targetsObjectBuilder;
        private ITargetsBuilder _targetsBuilder;
        private ITargetBuilderBounce _bounce;
        private JobConfigurationModel _config;

        public DefaultSetup(ITargetsObjectBuilder targetsObjectBuilder, ITargetsBuilder targetsBuilder, ITargetBuilderBounce bounce, JobConfigurationModel config) {
            _targetsObjectBuilder = targetsObjectBuilder;
            _targetsBuilder = targetsBuilder;
            _bounce = bounce;
            _config = config;
        }

        public void Execute() {
            var targets = _targetsObjectBuilder.BuildTargetsFromConfig(_config);
            
            // TODO: inject command
            var command = BounceCommandFactory.GetCommandByName("build");

            _targetsBuilder.BuildTargets(_bounce, targets, command);
        }
    }
}
