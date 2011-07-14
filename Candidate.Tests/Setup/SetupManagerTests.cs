using System;
using System.Collections.Generic;
using Candidate.Core.Settings;
using Candidate.Core.Settings.Model;
using Candidate.Core.Setup;
using Moq;
using NUnit.Framework;

namespace Candidate.Tests.Setup {
    [TestFixture]
    public class SetupManagerTests {

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateSetup_SettingsManagerIsNull_Exception() {
            // arrange
            var settingsMock = new Mock<ISettingsManager>();
            var setupManager = new SetupManager();

            // act / assert
            setupManager.CreateSetup(null, "existing-job");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateSetup_JobNameIsNull_Exception() {
            // arrange
            var settingsMock = new Mock<ISettingsManager>();
            var setupManager = new SetupManager();

            // act / assert
            setupManager.CreateSetup(settingsMock.Object, null);
        }

        [Test]
        [ExpectedException]
        public void CreateSetup_SettingsForJobForNonExisting_Exception() {
            var settingsMock = new Mock<ISettingsManager>();
            var setupManager = new SetupManager();

            var settings = new JobsConfigurationSettingsModel() { Configurations = new List<JobConfigurationModel>() { new JobConfigurationModel { JobName = "existing-job" } } };
            settingsMock.Setup(s => s.ReadSettings<JobsConfigurationSettingsModel>()).Returns(settings);

            // act 
            var setup = setupManager.CreateSetup(settingsMock.Object, "does-not-exist-job");
        }


        [Test]
        public void CreateSetup_SettingsForJobExists_SetupCreated() {
            var settingsMock = new Mock<ISettingsManager>();
            var setupManager = new SetupManager();

            var settings = new JobsConfigurationSettingsModel() { Configurations = new List<JobConfigurationModel>() { new JobConfigurationModel { JobName = "existing-job" } } };
            settingsMock.Setup(s => s.ReadSettings<JobsConfigurationSettingsModel>()).Returns(settings);

            // act 
            var setup = setupManager.CreateSetup(settingsMock.Object, "existing-job");

            // assert
            Assert.That(setup, Is.Not.Null);
        }
    }
}
