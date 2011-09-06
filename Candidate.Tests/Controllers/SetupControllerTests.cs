using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Candidate.Areas.Dashboard.Controllers;
using Moq;
using Candidate.Core.Settings;
using Candidate.Core.Setup;
using Candidate.Core.Utils;
using Candidate.Core.Log;
using Candidate.Core.Settings.Model;

namespace Candidate.Tests.Controllers {
    [TestFixture]
    public class SetupControllerTests {

        [SetUp]
        public void Setup() {
            SettingsManagerMock = new Mock<ISettingsManager>();
            SetupFactoryMock = new Mock<ISetupFactory>();
            SetupMock = new Mock<ISetup>();
            LoggerFactoryMock = new Mock<ILoggerFactory>();
            DirectoryProviderMock = new Mock<IDirectoryProvider>();

            ConfigurationList = new SitesConfigurationList() { Configurations = new List<SiteConfiguration> { new SiteConfiguration { JobName = "testJob",  Github = new GitHub { Branch = "master" } } } };
            Controller = new SetupController(SettingsManagerMock.Object, SetupFactoryMock.Object, LoggerFactoryMock.Object, DirectoryProviderMock.Object);
        }

        [Test]
        public void Hook_Run_Setup_If_Hooked_For_Current_Branch() {
            // arrange
            SettingsManagerMock.Setup(_ => _.ReadSettings<SitesConfigurationList>()).Returns(ConfigurationList);
            SetupFactoryMock.Setup(_ => _.CreateSetup()).Returns(SetupMock.Object);
            PayloadJson = @"{ ref: ""head/some/master"" }";

            // act
            Controller.Hook("testJob", "token", PayloadJson);

            // assert
            SetupMock.Verify(_ => _.RunForConfig(It.IsAny<ILogger>(), It.IsAny<SiteConfiguration>()));
        }

        [Test]
        public void Hook_Does_Not_Run_Setup_If_Hooked_For_Different_Branch() {
            // arrange
            SettingsManagerMock.Setup(_ => _.ReadSettings<SitesConfigurationList>()).Returns(ConfigurationList);
            SetupFactoryMock.Setup(_ => _.CreateSetup()).Returns(SetupMock.Object);
            PayloadJson = @"{ ref: ""head/some/develop"" }";

            // act
            Controller.Hook("testJob", "token", PayloadJson);

            // assert
            SetupMock.Verify(_ => _.RunForConfig(It.IsAny<ILogger>(), It.IsAny<SiteConfiguration>()), Times.Never());
        }

        protected SetupController Controller { get; set; }
        protected Mock<ISettingsManager> SettingsManagerMock { get; set; }
        protected Mock<ISetupFactory> SetupFactoryMock { get; set; }
        protected Mock<ISetup> SetupMock { get; set; }
        protected Mock<ILoggerFactory> LoggerFactoryMock { get; set; }
        protected Mock<IDirectoryProvider> DirectoryProviderMock { get; set; }
        protected SitesConfigurationList ConfigurationList { get; set; }
        protected string PayloadJson { get; set; }
    }
}
