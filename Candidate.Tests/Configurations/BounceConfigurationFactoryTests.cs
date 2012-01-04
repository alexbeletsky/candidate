using Candidate.Core.Configurations;
using Candidate.Core.Configurations.Bounce;
using Candidate.Core.Configurations.Bounce.Builders;
using Candidate.Core.Model;
using Candidate.Core.Model.Configurations;
using Candidate.Core.Utils;
using Moq;
using NUnit.Framework;

namespace Candidate.Tests.Configurations
{
    public class BounceConfigurationFactoryTests
    {
        [SetUp]
        public void Setup()
        {
            DirectoryProvider = new Mock<IDirectoryProvider>();
            DirectoryProvider.Setup(_ => _.Sources).Returns("/sources");
            DirectoryProvider.Setup(_ => _.Build).Returns("/build");
        }

        protected Mock<IDirectoryProvider> DirectoryProvider { get; set; }

        [Test]
        public void should_create_bounce_configuration_object_for_xcopy()
        {
            var configuration = new XCopyConfiguration
            {
                Id = "xcopy-build",
                Github = new Github { Branch = "master", Url = "git@git.com" },
                Iis = new Iis { Port = 9090, SiteName = "x", DeployFolder = "c:\\sites" }
            };

            var bounceConfigFactory = new BounceConfigurationFactory(DirectoryProvider.Object);

            var bounceConfig = bounceConfigFactory.CreateFor(configuration);

            Assert.That(bounceConfig.CheckoutSources, Is.Not.Null);
            Assert.That(bounceConfig.StopSiteBeforeDeployment, Is.Not.Null);
            Assert.That(bounceConfig.CopyToDestination, Is.Not.Null);
            Assert.That(bounceConfig.DeployWebsite, Is.Not.Null);
            Assert.That(bounceConfig.StartSiteAfterDeployment, Is.Not.Null);
        }

        [Test]
        public void should_create_bounce_configuration_object_for_batch()
        {
            var batch = new BatchConfiguration
                            {
                                Id = "batch-build",
                                Github = new Github { Branch = "master", Url = "git@git.com" },
                                Iis = new Iis { Port = 9090, SiteName = "x", DeployFolder = "c:\\sites" },
                                Post = new Post { Batch = "build.bat" }
                            };

            var bounceConfigFactory = new BounceConfigurationFactory(DirectoryProvider.Object);

            var bounceConfig = bounceConfigFactory.CreateFor(batch);

            Assert.That(bounceConfig.CheckoutSources, Is.Not.Null);
            Assert.That(bounceConfig.StopSiteBeforeDeployment, Is.Not.Null);
            Assert.That(bounceConfig.CopyToDestination, Is.Not.Null);
            Assert.That(bounceConfig.RunBatchBuild, Is.Not.Null);
            Assert.That(bounceConfig.DeployWebsite, Is.Not.Null);
            Assert.That(bounceConfig.StartSiteAfterDeployment, Is.Not.Null);
        }

        [Test]
        public void should_create_bounce_configuration_object_for_visual_studio()
        {
            var visual = new VisualStudioConfiguration
                             {
                                 Id = "visual-studio",
                                 Github = new Github { Branch = "master", Url = "git@git.com" },
                                 Iis = new Iis { Port = 9090, SiteName = "x", DeployFolder = "c:\\sites" },
                                 Solution = new Solution { Name = "solution.sln", SelectedConfiguration = 0, WebProject = "Web", IsRunTests = true}
                             };

            var bounceConfigFactory = new BounceConfigurationFactory(DirectoryProvider.Object);

            var bounceConfig = bounceConfigFactory.CreateFor(visual);

            Assert.That(bounceConfig.CheckoutSources, Is.Not.Null);
            Assert.That(bounceConfig.StopSiteBeforeDeployment, Is.Not.Null);
            Assert.That(bounceConfig.CopyToDestination, Is.Not.Null);
            Assert.That(bounceConfig.RunTests, Is.Not.Null);
            Assert.That(bounceConfig.DeployWebsite, Is.Not.Null);
            Assert.That(bounceConfig.StartSiteAfterDeployment, Is.Not.Null);
        }
    }
}
