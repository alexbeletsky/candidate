using System.Collections.Generic;
using Bounce.Framework;
using Candidate.Core.Log;
using Candidate.Core.Model.Configurations;

namespace Candidate.Core.Deploy
{
    public class DeployRunner : IDeployRunner
    {
        private readonly IEnumerable<Target> _bounceTargets;
        private readonly TargetsBuilder _bounceTargetsBuilder;

        public DeployRunner(IEnumerable<Target> bounceTargets)
        {
            _bounceTargets = bounceTargets;
            _bounceTargetsBuilder = new TargetsBuilder();
        }

        public DeployResults Run(ILoggerFactory loggerFactory)
        {
            using (var logger = loggerFactory.CreateLogger())
            {
                var bounce = new BounceFactory().GetBounce(CreateLogOptions(logger, LogLevel.Debug));
                _bounceTargetsBuilder.BuildTargets(bounce, _bounceTargets, BounceCommandFactory.GetCommandByName("build"));

                return new DeployResults { Url = "http://localhost" };
            }
        }

        public LogOptions CreateLogOptions(ILogger logger, LogLevel level)
        {
            return new LogOptions { LogLevel = level, CommandOutput = true, DescribeTasks = true, StdErr = logger.LogWriter, StdOut = logger.LogWriter };
        }

        public IEnumerable<Target> Targets
        {
            get { return _bounceTargets; }
        }
    }
}