using System.IO;
using Candidate.Core.Configurations.Exceptions;
using Candidate.Core.Configurations.Tasks;
using Candidate.Core.Configurations.Types;
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
            var sourcesDirectory = Path.Combine(_directoryProvider.Sources, configuration.Id);
 
            return new XCopyBounceConfiguration
                       {
                           CheckoutSources = new CheckoutSourcesTask(configuration.Github.Url, configuration.Github.Branch, sourcesDirectory).ToTask(),
                           StopSiteBeforeDeployment = new StopSiteTask(configuration.Iis.SiteName).ToTask(),
                           CopyToDestination = new CopyToDestinationTask(sourcesDirectory, deploymentFolder).ToTask(),
                           DeployWebsite = new DeployWebsiteTask(deploymentFolder, configuration.Iis.SiteName, configuration.Iis.Port, configuration.Iis.Bindings).ToTask(),
                           StartSiteAfterDeployment = new StartSiteTask(configuration.Iis.SiteName).ToTask()
                       };
        }
    }
}