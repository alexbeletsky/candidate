using Candidate.Core.Configurations;
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

            var bounceConfig = bounceConfigFactory.CreateForXCopy(configuration);

            Assert.That(bounceConfig.CheckoutSources, Is.Not.Null);
            Assert.That(bounceConfig.CopyToDestination, Is.Not.Null);
            Assert.That(bounceConfig.DeployWebsite, Is.Not.Null);
        }
    }
}
