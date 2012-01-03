using System.IO;
using Candidate.Core.Configurations.Exceptions;
using Candidate.Core.Configurations.Tasks;
using Candidate.Core.Model.Configurations;
using Candidate.Core.Utils;

namespace Candidate.Core.Configurations.Bounce.Builders
{
    internal class XCopyBounceConfigurationBuilder
    {
        private readonly IDirectoryProvider _directoryProvider;

        public XCopyBounceConfigurationBuilder(IDirectoryProvider directoryProvider)
        {
            _directoryProvider = directoryProvider;
        }

        public XCopyBounceConfiguration CreateConfig(XCopyConfiguration configuration)
        {
            var deploymentFolder = Path.Combine(configuration.Iis.DeployFolder, configuration.Id);

            return new XCopyBounceConfiguration
                       {
                           CheckoutSources = new CheckoutSourcesTask(configuration.Github.Url, configuration.Github.Branch, _directoryProvider.Sources).ToTask(),
                           StopSiteBeforeDeployment = new StopSiteTask(configuration.Iis.SiteName).ToTask(),
                           CopyToDestination = new CopyToDestinationTask(_directoryProvider.Sources, deploymentFolder).ToTask(),
                           DeployWebsite = new DeployWebsiteTask(deploymentFolder, configuration.Iis.SiteName, configuration.Iis.Port, configuration.Iis.Bindings).ToTask(),
                           StartSiteAfterDeployment = new StartSiteTask(configuration.Iis.SiteName).ToTask()
                       };
        }
    }
}