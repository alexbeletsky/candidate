using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Candidate.Core.Setup;
using Candidate.Core.Settings.Model;
using Moq;
using Bounce.Framework;
using Candidate.Core.System;
using Candidate.Core.Log;

namespace Candidate.Tests.Setup {
    [TestFixture]
    public class DefaultSetupTests {
        [Test]
        public void Execute_TargetsBuildFromConfig() {
            // arrange
            var targetsObjectBuilderMock = new Mock<ITargetsObjectBuilder>();
            var targetsBuilderMock = new Mock<ITargetsBuilder>();
            var bounceFactoryMock = new Mock<IBounceFactory>();
            var config = new JobConfigurationModel();            
            var setup = new DefaultSetup(targetsObjectBuilderMock.Object, targetsBuilderMock.Object, bounceFactoryMock.Object);

            // act 
            setup.RunForConfig(new Mock<ILogger>().Object, config);

            // assert
            targetsObjectBuilderMock.Verify(_ => _.BuildTargetsFromConfig(config));
        }

        [Test]
        public void Exectute_BounceObjectCreated() {
            // arrange
            var targetsObjectBuilderMock = new Mock<ITargetsObjectBuilder>();
            var targetsBuilderMock = new Mock<ITargetsBuilder>();
            var bounceFactoryMock = new Mock<IBounceFactory>();
            var config = new JobConfigurationModel();
            var setup = new DefaultSetup(targetsObjectBuilderMock.Object, targetsBuilderMock.Object, bounceFactoryMock.Object);

            var targetsList = new List<Target>();
            targetsObjectBuilderMock.Setup(_ => _.BuildTargetsFromConfig(config)).Returns(targetsList);

            // act 
            setup.RunForConfig(new Mock<ILogger>().Object, config);

            // assert
            bounceFactoryMock.Verify(_ => _.GetBounce(It.IsAny <LogOptions>()));
        }

        [Test]
        public void Execute_BuildTargetsRun() {
            // arrange
            var targetsObjectBuilderMock = new Mock<ITargetsObjectBuilder>();
            var targetsBuilderMock = new Mock<ITargetsBuilder>();
            var bounceFactoryMock = new Mock<IBounceFactory>();
            var config = new JobConfigurationModel();
            var setup = new DefaultSetup(targetsObjectBuilderMock.Object, targetsBuilderMock.Object, bounceFactoryMock.Object);

            var targetsList = new List<Target>();
            targetsObjectBuilderMock.Setup(_ => _.BuildTargetsFromConfig(config)).Returns(targetsList);

            // act 
            setup.RunForConfig(new Mock<ILogger>().Object, config);

            // assert
            targetsBuilderMock.Verify(_ => _.BuildTargets(It.IsAny<ITargetBuilderBounce>(), targetsList, It.IsAny<IBounceCommand>()));
        }
    }
}
