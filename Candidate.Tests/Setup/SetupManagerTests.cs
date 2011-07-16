using System;
using System.Collections.Generic;
using Candidate.Core.Settings;
using Candidate.Core.Settings.Model;
using Candidate.Core.Setup;
using Moq;
using NUnit.Framework;
using Bounce.Framework;

namespace Candidate.Tests.Setup {
    [TestFixture]
    public class SetupManagerTests {

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateSetup_SettingsManagerIsNull_Exception() {
            // arrange
            var targetsObjectBuilderMock = new Mock<ITargetsObjectBuilder>();
            var targetsBuilderMock = new Mock<ITargetsBuilder>();
            var bounceMock = new Mock<ITargetBuilderBounce>();
            var settingsMock = new Mock<ISettingsManager>();
            var setupManager = new SetupManager(targetsObjectBuilderMock.Object, targetsBuilderMock.Object, bounceMock.Object);

            // act / assert
            setupManager.CreateSetup(null, "existing-job");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateSetup_JobNameIsNull_Exception() {
            // arrange
            // arrange
            var targetsObjectBuilderMock = new Mock<ITargetsObjectBuilder>();
            var targetsBuilderMock = new Mock<ITargetsBuilder>();
            var bounceMock = new Mock<ITargetBuilderBounce>();
            var settingsMock = new Mock<ISettingsManager>();
            var setupManager = new SetupManager(targetsObjectBuilderMock.Object, targetsBuilderMock.Object, bounceMock.Object);

            // act / assert
            setupManager.CreateSetup(settingsMock.Object, null);
        }

        [Test]
        [ExpectedException]
        public void CreateSetup_SettingsForJobForNonExisting_Exception() {
            // arrange
            var targetsObjectBuilderMock = new Mock<ITargetsObjectBuilder>();
            var targetsBuilderMock = new Mock<ITargetsBuilder>();
            var bounceMock = new Mock<ITargetBuilderBounce>();
            var settingsMock = new Mock<ISettingsManager>();
            var setupManager = new SetupManager(targetsObjectBuilderMock.Object, targetsBuilderMock.Object, bounceMock.Object);

            var settings = new JobsConfigurationSettingsModel() { Configurations = new List<JobConfigurationModel>() { new JobConfigurationModel { JobName = "existing-job" } } };
            settingsMock.Setup(s => s.ReadSettings<JobsConfigurationSettingsModel>()).Returns(settings);

            // act 
            var setup = setupManager.CreateSetup(settingsMock.Object, "does-not-exist-job");
        }

        [Test]
        public void CreateSetup_SettingsForJobExists_SetupCreated() {
            // arrange
            var targetsObjectBuilderMock = new Mock<ITargetsObjectBuilder>();
            var targetsBuilderMock = new Mock<ITargetsBuilder>();
            var bounceMock = new Mock<ITargetBuilderBounce>();
            var settingsMock = new Mock<ISettingsManager>();
            var setupManager = new SetupManager(targetsObjectBuilderMock.Object, targetsBuilderMock.Object, bounceMock.Object);

            var settings = new JobsConfigurationSettingsModel() { Configurations = new List<JobConfigurationModel>() { new JobConfigurationModel { JobName = "existing-job" } } };
            settingsMock.Setup(s => s.ReadSettings<JobsConfigurationSettingsModel>()).Returns(settings);

            // act 
            var setup = setupManager.CreateSetup(settingsMock.Object, "existing-job");

            // assert
            Assert.That(setup, Is.Not.Null);
        }
    }
}
