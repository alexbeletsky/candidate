using System.IO;
using Candidate.Core.Configurations.Tasks;
using Candidate.Core.Model.Configurations;
using Candidate.Core.Utils;

namespace Candidate.Core.Configurations.Bounce.Builders
{
    public class VisualStudioBounceConfigurationBuilder
    {
        private readonly IDirectoryProvider _directoryProvider;

        public VisualStudioBounceConfigurationBuilder(IDirectoryProvider directoryProvider)
        {
            _directoryProvider = directoryProvider;
        }

        public VisualStudioBounceConfiguration CreateConfig(VisualStudioConfiguration configuration)
        {
            var deploymentFolder = Path.Combine(configuration.Iis.DeployFolder, configuration.Id);

            // TODO: ABE requires sourcesDirectory
            var checkout = new CheckoutSourcesTask(configuration.Github.Url, configuration.Github.Branch,
                                        _directoryProvider.Sources).ToTask();

            var build = new BuildSolutionTask(_directoryProvider.Sources, configuration.Solution.Name,
                                        configuration.Solution.Targets[configuration.Solution.SelectedTarget],
                                        configuration.Solution.Configurations[configuration.Solution.SelectedConfiguration],
                                        _directoryProvider.Build).ToTask();

            var runTests = new RunTestsTask(configuration.Solution.IsRunTests, _directoryProvider.Build,
                                        _directoryProvider.NUnitConsole, configuration.Solution.NUnitRuntimeVersions[configuration.Solution.SelectedNUnitRuntimeVersion], build).ToTask();

            return new VisualStudioBounceConfiguration
                       {
                           CheckoutSources = checkout,
                           BuildSolution = build,
                           RunTests = runTests,
                           StopSiteBeforeDeployment = new StopSiteTask(configuration.Iis.SiteName).ToTask(),
                           CopyToDestination = new CopyToDestinationTask(_directoryProvider.Build, deploymentFolder).ToTask(),
                           DeployWebsite = new DeployWebsiteTask(deploymentFolder, configuration.Iis.SiteName, configuration.Iis.Port, configuration.Iis.Bindings).ToTask(),
                           StartSiteAfterDeployment = new StartSiteTask(configuration.Iis.SiteName).ToTask()
                       };
        }
    }
}