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

        public XCopyBounceConfiguration CreateConfig(Configuration configuration)
        {
            var xCopyConfiguration = configuration as XCopyConfiguration;

            if (xCopyConfiguration == null)
            {
                throw new ConfigurationTypeNotSupported();
            }

            var deploymentFolder = Path.Combine(xCopyConfiguration.Iis.DeployFolder, configuration.Id);

            return new XCopyBounceConfiguration
                       {
                           CheckoutSources = new CheckoutSourcesTask(xCopyConfiguration.Github.Url, xCopyConfiguration.Github.Branch, _directoryProvider.Sources).ToTask(),
                           StopSiteBeforeDeployment = new StopSiteTask(xCopyConfiguration.Iis.SiteName).ToTask(),
                           CopyToDestination = new CopyToDestinationTask(_directoryProvider.Sources, deploymentFolder).ToTask(),
                           DeployWebsite = new DeployWebsiteTask(deploymentFolder, xCopyConfiguration.Iis.SiteName, xCopyConfiguration.Iis.Port, xCopyConfiguration.Iis.Bindings).ToTask(),
                           StartSiteAfterDeployment = new StartSiteTask(xCopyConfiguration.Iis.SiteName).ToTask()
                       };
        }
    }
}