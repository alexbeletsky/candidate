using System.IO;
using Bounce.Framework;
using Candidate.Core.Configurations.Tasks;
using Candidate.Core.Configurations.Types;

namespace Candidate.Core.Configurations.Bounce.Builders
{
    public class BatchBounceConfigurationBuilder : ConfigurationBuilderBase
    {
        private readonly BatchConfiguration _configuration;

        public BatchBounceConfigurationBuilder(BatchConfiguration configuration) 
            : base(configuration.Id, configuration.Iis.DeployDirectory, configuration.Batch.BuildDirectory)
        {
            _configuration = configuration;
        }

        public BatchBounceConfiguration CreateConfig()
        {
            return new BatchBounceConfiguration 
            {
                CheckoutSources = new CheckoutSourcesTask(_configuration.Github.Url, _configuration.Github.Branch, SourcesDirectory).ToTask(),
                StopSiteBeforeDeployment = new StopSiteTask(_configuration.Iis.SiteName).ToTask(),
                RunBatchBuild = new ShellTask(_configuration.Batch.BuildScript, SourcesDirectory).ToTask(),
                CopyToDestination = new CopyToDestinationTask(BuildDirectory, DeploymentDirectory).ToTask(),
                DeployWebsite = new DeployWebsiteTask(DeploymentDirectory, _configuration.Iis.SiteName, _configuration.Iis.Port, _configuration.Iis.Bindings).ToTask(),
                StartSiteAfterDeployment = new StartSiteTask(_configuration.Iis.SiteName).ToTask()
            };
        }
    }
}