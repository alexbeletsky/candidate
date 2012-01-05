using System.IO;
using Candidate.Core.Configurations.Exceptions;
using Candidate.Core.Configurations.Tasks;
using Candidate.Core.Configurations.Types;

namespace Candidate.Core.Configurations.Bounce.Builders
{
    internal class XCopyBounceConfigurationBuilder : ConfigurationBuilderBase
    {
        private readonly XCopyConfiguration _configuration;

        public XCopyBounceConfigurationBuilder(XCopyConfiguration configuration)
            : base(configuration.Id, configuration.Iis.DeployDirectory)
        {
            _configuration = configuration;
        }

        public XCopyBounceConfiguration CreateConfig()
        {
            return new XCopyBounceConfiguration
                       {
                           CheckoutSources = new CheckoutSourcesTask(_configuration.Github.Url, _configuration.Github.Branch, SourcesDirectory).ToTask(),
                           StopSiteBeforeDeployment = new StopSiteTask(_configuration.Iis.SiteName).ToTask(),
                           CopyToDestination = new CopyToDestinationTask(SourcesDirectory, DeploymentDirectory).ToTask(),
                           DeployWebsite = new DeployWebsiteTask(DeploymentDirectory, _configuration.Iis.SiteName, _configuration.Iis.Port, _configuration.Iis.Bindings).ToTask(),
                           StartSiteAfterDeployment = new StartSiteTask(_configuration.Iis.SiteName).ToTask()
                       };
        }
    }
}