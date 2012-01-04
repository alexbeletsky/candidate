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
            var deploymentFolder = Path.Combine(configuration.Iis.DeployFolder, configuration.Id);

            // TODO: ABE requires sourcesDirectory

            return new BatchBounceConfiguration 
            {
                CheckoutSources = new CheckoutSourcesTask(configuration.Github.Url, configuration.Github.Branch, _directoryProvider.Sources).ToTask(),
                StopSiteBeforeDeployment = new StopSiteTask(configuration.Iis.SiteName).ToTask(),
                RunBatchBuild = new ShellTask(configuration.Post.Batch, _directoryProvider.Sources).ToTask(),
                CopyToDestination = new CopyToDestinationTask(_directoryProvider.Sources, deploymentFolder).ToTask(),
                DeployWebsite = new DeployWebsiteTask(deploymentFolder, configuration.Iis.SiteName, configuration.Iis.Port, configuration.Iis.Bindings).ToTask(),
                StartSiteAfterDeployment = new StartSiteTask(configuration.Iis.SiteName).ToTask()
            };
        }
    }
}