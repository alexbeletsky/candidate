using Bounce.Framework;
using Candidate.Core.Configurations;
using Candidate.Core.Log;
using Candidate.Core.Model.Configurations;
using Candidate.Core.Utils;

namespace Candidate.Core.Deploy
{
    // TODO: ABE remove
    internal class Deployer
    {
        private readonly IDirectoryProvider _directoryProvider;
        private readonly ILoggerFactory _loggerFactory;
        private readonly BounceConfigurationFactory _bounceConfigFactory;
        private readonly BounceFactory _bounceFactory;
        private readonly TargetsBuilder _bounceTargetsRunner;
        private readonly FileLogOptionsFactory _logOptionsFactory;

        public Deployer(IDirectoryProvider directoryProvider, ILoggerFactory loggerFactory)
        {
            _directoryProvider = directoryProvider;
            _loggerFactory = loggerFactory;

            _bounceConfigFactory = new BounceConfigurationFactory(_directoryProvider);
            _bounceFactory = new BounceFactory();
            _logOptionsFactory = new FileLogOptionsFactory();
            _bounceTargetsRunner = new TargetsBuilder();
        }

        public void DeployXCopyConfig(XCopyConfiguration configuration)
        {
            using (var logger = _loggerFactory.CreateLogger())
            {
                var bounceConfig = _bounceConfigFactory.CreateFor(configuration);
                var bounceTargets = bounceConfig.ToBounceTargets();
                var bounce = _bounceFactory.GetBounce(_logOptionsFactory.CreateLogOptions(logger, LogLevel.Debug));

                _bounceTargetsRunner.BuildTargets(bounce, bounceTargets, BounceCommandFactory.GetCommandByName("build"));
            }
        }
    }
}