using System;
using Candidate.Core.Configurations.Types;
using Candidate.Core.Extensions;
using Candidate.Core.Settings;

namespace Candidate.Core.Deploy
{
    public class Deployer : IDeployer
    {
        private readonly ISettingsManager _settingsManager;

        public Deployer(ISettingsManager settingsManager)
        {
            _settingsManager = settingsManager;
        }

        public DeployResults Deploy(string id)
        {
            var configuration = _settingsManager.ReadConfiguration<Configuration>(id);

            var runner = configuration.CreateDeployRunner();
            return runner.Run(configuration.Id);
        }

        public DeployResults Deploy(string id, string branch)
        {
            var configuration = _settingsManager.ReadConfiguration<Configuration>(id);
            var githubConfiguration = configuration.ForGithub();

            if (githubConfiguration.Branch.Equals(branch))
            {
                var runner = configuration.CreateDeployRunner();
                return runner.Run(configuration.Id);                
            }

            return null;
        }
    }
}