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

            return new XCopyBounceConfiguration
                       {
                           CheckoutSources = new CheckoutSourcesTask(xCopyConfiguration.Github.Url, xCopyConfiguration.Github.Branch, _directoryProvider.Sources).ToTask(),
                           CopyToDestination = new CopyToDestinationTask(_directoryProvider.Sources, xCopyConfiguration.Iis.DeployFolder, configuration.Id).ToTask(),
                           DeployWebsite = new DeployWebsiteTask(xCopyConfiguration.Iis, _directoryProvider).ToTask()
                       };
        }
    }
}