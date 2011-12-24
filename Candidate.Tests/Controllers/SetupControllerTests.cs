//using System.Collections.Generic;
//using Candidate.Areas.Dashboard.Controllers;
//using Candidate.Core.Log;
//using Candidate.Core.Settings;
//using Candidate.Core.Settings.Model;
//using Candidate.Core.Setup;
//using Candidate.Core.Utils;
//using Moq;
//using NUnit.Framework;

//namespace Candidate.Tests.Controllers
//{
//    [TestFixture]
//    public class SetupControllerTests
//    {

//        [SetUp]
//        public void Setup()
//        {
//            SettingsManagerMock = new Mock<ISettingsManager>();
//            SetupFactoryMock = new Mock<ISetupFactory>();
//            SetupMock = new Mock<ISetup>();
//            LoggerFactoryMock = new Mock<ILoggerFactory>();
//            DirectoryProviderMock = new Mock<IDirectoryProvider>();

//            ConfigurationList = new ConfigurationsList() { Configurations = new List<VisualStudioConfiguration> { new VisualStudioConfiguration { Id = "testJob", Github = new Github { Branch = "master" } } } };
//            Controller = new DeploymentController(SettingsManagerMock.Object, SetupFactoryMock.Object, LoggerFactoryMock.Object, DirectoryProviderMock.Object);
//        }

//        [Test]
//        public void Hook_Run_Setup_If_Hooked_For_Current_Branch()
//        {
//            // arrange
//            SettingsManagerMock.Setup(_ => _.ReadSettings<ConfigurationsList>()).Returns(ConfigurationList);
//            SetupFactoryMock.Setup(_ => _.CreateSetup()).Returns(SetupMock.Object);
//            PayloadJson = @"{ ref: ""head/some/master"" }";

//            // act
//            Controller.Hook("testJob", "token", PayloadJson);

//            // assert
//            SetupMock.Verify(_ => _.RunForConfig(It.IsAny<ILogger>(), It.IsAny<VisualStudioConfiguration>()));
//        }

//        [Test]
//        public void Hook_Does_Not_Run_Setup_If_Hooked_For_Different_Branch()
//        {
//            // arrange
//            SettingsManagerMock.Setup(_ => _.ReadSettings<ConfigurationsList>()).Returns(ConfigurationList);
//            SetupFactoryMock.Setup(_ => _.CreateSetup()).Returns(SetupMock.Object);
//            PayloadJson = @"{ ref: ""head/some/develop"" }";

//            // act
//            Controller.Hook("testJob", "token", PayloadJson);

//            // assert
//            SetupMock.Verify(_ => _.RunForConfig(It.IsAny<ILogger>(), It.IsAny<VisualStudioConfiguration>()), Times.Never());
//        }

//        protected DeploymentController Controller { get; set; }
//        protected Mock<ISettingsManager> SettingsManagerMock { get; set; }
//        protected Mock<ISetupFactory> SetupFactoryMock { get; set; }
//        protected Mock<ISetup> SetupMock { get; set; }
//        protected Mock<ILoggerFactory> LoggerFactoryMock { get; set; }
//        protected Mock<IDirectoryProvider> DirectoryProviderMock { get; set; }
//        protected ConfigurationsList ConfigurationList { get; set; }
//        protected string PayloadJson { get; set; }
//    }
//}
