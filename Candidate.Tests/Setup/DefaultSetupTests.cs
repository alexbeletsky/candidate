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

namespace Candidate.Tests.Setup {
    [TestFixture]
    public class DefaultSetupTests {
        [Test]
        public void DefaultSetup_Construction() {
            // arrange
            var targetsObjectBuilderMock = new Mock<ITargetsObjectBuilder>();
            var targetsBuilderMock = new Mock<ITargetsBuilder>();
            var bounceMock = new Mock<ITargetBuilderBounce>();
            var config = new JobConfigurationModel();

            // act / assert
            var setup = new DefaultSetup(targetsObjectBuilderMock.Object, targetsBuilderMock.Object, bounceMock.Object, config);
        }

        [Test]
        public void Execute_TargetsBuildFromConfig() {
            // arrange
            var targetsObjectBuilderMock = new Mock<ITargetsObjectBuilder>();
            var targetsBuilderMock = new Mock<ITargetsBuilder>();
            var bounceMock = new Mock<ITargetBuilderBounce>();
            var loggerMock = new Mock<ILogger>();
            var config = new JobConfigurationModel();
            
            var setup = new DefaultSetup(targetsObjectBuilderMock.Object, targetsBuilderMock.Object, bounceMock.Object, config);

            // act 
            setup.Execute(loggerMock.Object);

            // assert
            targetsObjectBuilderMock.Verify(_ => _.BuildTargetsFromConfig(config));
        }

        [Test]
        public void Execute_BuildTargetsRun() {
            // arrange
            var targetsObjectBuilderMock = new Mock<ITargetsObjectBuilder>();
            var targetsBuilderMock = new Mock<ITargetsBuilder>();
            var bounceMock = new Mock<ITargetBuilderBounce>();
            var loggerMock = new Mock<ILogger>();
            var config = new JobConfigurationModel();

            var targetsList = new List<Target>();
            targetsObjectBuilderMock.Setup(_ => _.BuildTargetsFromConfig(config)).Returns(targetsList);

            var setup = new DefaultSetup(targetsObjectBuilderMock.Object, targetsBuilderMock.Object, bounceMock.Object, config);

            // act 
            setup.Execute(loggerMock.Object);

            // assert
            targetsBuilderMock.Verify(_ => _.BuildTargets(bounceMock.Object, targetsList, It.IsAny<IBounceCommand>()));
        }
    }
}
