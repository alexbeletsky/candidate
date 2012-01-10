using System.IO;
using Candidate.Core.Configurations.Tasks;
using Candidate.Core.Configurations.Types;

namespace Candidate.Core.Configurations.Bounce.Builders
{
    public class VisualStudioBounceConfigurationBuilder : ConfigurationBuilderBase 
    {
        private readonly VisualStudioConfiguration _configuration;

        public VisualStudioBounceConfigurationBuilder(VisualStudioConfiguration configuration) :
            base(configuration.Id, configuration.Iis.DeployDirectory, "build")
        {
            _configuration = configuration;
        }

        public VisualStudioBounceConfiguration CreateConfig()
        {
            var checkout = new CheckoutSourcesTask(_configuration.Github.Url, _configuration.Github.Branch, SourcesDirectory).ToTask();

            var build = new BuildSolutionTask(SourcesDirectory, _configuration.Solution.Name,
                                        _configuration.Solution.Targets[_configuration.Solution.SelectedTarget],
                                        _configuration.Solution.Configurations[_configuration.Solution.SelectedConfiguration],
                                        BuildDirectory).ToTask();

            var runTests = new RunTestsTask(_configuration.Solution.IsRunTests, BuildDirectory,
                                        NUnitConsole, _configuration.Solution.NUnitRuntimeVersions[_configuration.Solution.SelectedNUnitRuntimeVersion], build).ToTask();

            var compliledWebsiteDirectory = Path.Combine(Path.Combine(BuildDirectory, "_PublishedWebsites"),
                                                         _configuration.Solution.WebProject);

            return new VisualStudioBounceConfiguration
                       {
                           CheckoutSources = checkout,
                           DeleteBuildFolder = new DeleteTask(BuildDirectory).ToTask(),
                           BuildSolution = build,
                           RunTests = runTests,
                           StopSiteBeforeDeployment = new StopSiteTask(_configuration.Iis.SiteName).ToTask(),
                           CopyToDestination = new CopyToDestinationTask(compliledWebsiteDirectory, DeploymentDirectory).ToTask(),
                           DeployWebsite = new DeployWebsiteTask(DeploymentDirectory, _configuration.Iis.SiteName, _configuration.Iis.Port, _configuration.Iis.Bindings).ToTask(),
                           StartSiteAfterDeployment = new StartSiteTask(_configuration.Iis.SiteName).ToTask()
                       };
        }
    }
}