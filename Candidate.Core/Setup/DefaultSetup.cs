using Bounce.Framework;
using Candidate.Core.Log;
using Candidate.Core.Settings.Model;

namespace Candidate.Core.Setup {
    public class DefaultSetup : ISetup {
        private ITargetsObjectBuilder _targetsObjectBuilder;
        private ITargetsBuilder _targetsBuilder;
        private IBounceFactory _bounceFactory;
        private ILogOptionsFactory _logOptionsFactory;

        public DefaultSetup(ITargetsObjectBuilder targetsObjectBuilder, ITargetsBuilder targetsBuilder, IBounceFactory bounceFactory) {
            _targetsObjectBuilder = targetsObjectBuilder;
            _targetsBuilder = targetsBuilder;
            _bounceFactory = bounceFactory;
            _logOptionsFactory = new FileLogOptionsFactory();
        }

        public void RunForConfig(ILogger logger, JobConfigurationModel config) {
            var targets = _targetsObjectBuilder.BuildTargetsFromConfig(config);
            var logOptions = _logOptionsFactory.CreateLogOptions(logger, LogLevel.Debug);
            var bounce = _bounceFactory.GetBounce(logOptions);
            var command = BounceCommandFactory.GetCommandByName("build");

            _targetsBuilder.BuildTargets(bounce, targets, command);
        }
    }
}
