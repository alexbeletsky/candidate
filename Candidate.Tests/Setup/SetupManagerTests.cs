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
        public void CreateSetup_SettingsForJobExists_SetupCreated() {
            // arrange
            var targetsObjectBuilderMock = new Mock<ITargetsObjectBuilder>();
            var targetsBuilderMock = new Mock<ITargetsBuilder>();
            var bounceFactoryMock = new Mock<IBounceFactory>();
            var setupManager = new SetupFactory(targetsObjectBuilderMock.Object, targetsBuilderMock.Object, bounceFactoryMock.Object);

            // act 
            var setup = setupManager.CreateSetup();

            // assert
            Assert.That(setup, Is.Not.Null);
        }
    }
}
