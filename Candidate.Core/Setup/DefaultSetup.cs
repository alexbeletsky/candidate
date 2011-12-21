using System;
using System.Threading.Tasks;
using Bounce.Framework;
using Candidate.Core.Log;
using Candidate.Core.Settings.Model;
using Candidate.Core.Utils;

namespace Candidate.Core.Setup
{
    public class DefaultSetup : ISetup
    {
        private ITargetsObjectBuilder _targetsObjectBuilder;
        private ITargetsBuilder _targetsBuilder;
        private IBounceFactory _bounceFactory;
        private ILogOptionsFactory _logOptionsFactory;
        private IBounceCommand _command;

        public DefaultSetup(ITargetsObjectBuilder targetsObjectBuilder, ITargetsBuilder targetsBuilder, IBounceFactory bounceFactory)
        {
            _targetsObjectBuilder = targetsObjectBuilder;
            _targetsBuilder = targetsBuilder;
            _bounceFactory = bounceFactory;
            _logOptionsFactory = new FileLogOptionsFactory();
            _command = BounceCommandFactory.GetCommandByName("build");
        }

        public SetupResult RunForConfig(ILogger logger, SiteConfiguration config)
        {
            var targets = _targetsObjectBuilder.BuildTargetsFromConfig(config);
            var logOptions = _logOptionsFactory.CreateLogOptions(logger, LogLevel.Debug);
            var bounce = _bounceFactory.GetBounce(logOptions);

            // TODO: it have to be run asynchronously, with checking thread status and exit by timeout 
            _targetsBuilder.BuildTargets(bounce, targets, _command);

            return new SetupResult { Url = config.Iis.GetSiteUrl(), Log = logger.LogFileName };
        }
    }
}
