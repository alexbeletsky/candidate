using System.IO;
using Bounce.Framework;
using Candidate.Core.Configurations.Tasks;
using Candidate.Core.Model.Configurations;
using Candidate.Core.Utils;

namespace Candidate.Core.Configurations.Bounce.Builders
{
    public class BatchBounceConfigurationBuilder
    {
        private readonly IDirectoryProvider _directoryProvider;

        public BatchBounceConfigurationBuilder(IDirectoryProvider directoryProvider)
        {
            _directoryProvider = directoryProvider;
        }

        public BatchBounceConfiguration CreateConfig(BatchConfiguration configuration)
        {
            var deploymentDirectory = Path.Combine(configuration.Iis.DeployFolder, configuration.Id);
            var sourcesDirectory = Path.Combine(_directoryProvider.Sources, configuration.Id);

            var buildDirectory = sourcesDirectory;
            if (!string.IsNullOrEmpty(configuration.Batch.BuildFolder))
            {
                buildDirectory = Path.Combine(sourcesDirectory, configuration.Batch.BuildFolder);
            }

            return new BatchBounceConfiguration 
            {
                CheckoutSources = new CheckoutSourcesTask(configuration.Github.Url, configuration.Github.Branch, sourcesDirectory).ToTask(),
                StopSiteBeforeDeployment = new StopSiteTask(configuration.Iis.SiteName).ToTask(),
                RunBatchBuild = new ShellTask(configuration.Batch.BuildScript, sourcesDirectory).ToTask(),
                CopyToDestination = new CopyToDestinationTask(buildDirectory, deploymentDirectory).ToTask(),
                DeployWebsite = new DeployWebsiteTask(deploymentDirectory, configuration.Iis.SiteName, configuration.Iis.Port, configuration.Iis.Bindings).ToTask(),
                StartSiteAfterDeployment = new StartSiteTask(configuration.Iis.SiteName).ToTask()
            };
        }
    }
}