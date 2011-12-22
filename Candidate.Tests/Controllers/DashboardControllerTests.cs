//using System.Collections.Generic;
//using System.Web.Mvc;
//using Candidate.Areas.Dashboard.Controllers;
//using Candidate.Areas.Dashboard.Models;
//using Candidate.Core.Settings;
//using Candidate.Core.Settings.Model;
//using Candidate.Infrustructure.Authentication;
//using Moq;
//using NUnit.Framework;
//using SharpTestsEx;
//namespace Candidate.Tests.Controllers
//{
//    [TestFixture]
//    public class DashboardControllerTests
//    {
//        [Test]
//        public void Index_Get_ReturnsView()
//        {
//            // arrange 
//            var settingsManager = new Mock<ISettingsManager>();
//            var controller = new DashboardController(settingsManager.Object);

//            settingsManager.Setup(_ => _.ReadSettings<UserSettings>()).Returns(new UserSettings { User = new User() });

//            // act
//            var result = controller.Index() as ViewResult;

//            // assert
//            result.Should().Not.Be.Null();
//        }

//        [Test]
//        public void List_Get_ReturnsTheListOfJobs()
//        {
//            // arrange 
//            var settingsManager = new Mock<ISettingsManager>();
//            var controller = new DashboardController(settingsManager.Object);

//            settingsManager.Setup(s => s.ReadSettings<ConfigurationsList>()).Returns(new ConfigurationsList { Configurations = new List<VisualStudioConfiguration>() });

//            // act
//            var result = controller.List() as ViewResult;

//            // assert
//            var model = result.Model as IList<VisualStudioConfiguration>;
//            model.Should().Not.Be.Null();
//        }

//        [Test]
//        public void Add_Get_ReturnsView()
//        {
//            // arrange 
//            var settingsManager = new Mock<ISettingsManager>();
//            var controller = new DashboardController(settingsManager.Object);

//            // act
//            var result = controller.Add() as ViewResult;

//            // assert
//            result.Should().Not.Be.Null();
//        }

//        [Test]
//        public void Add_Post_NewJobConfigurationAdded()
//        {
//            // arrange 
//            var settingsManager = new Mock<ISettingsManager>();
//            var controller = new DashboardController(settingsManager.Object);
//            var config = new NewJobModel { Name = "testApp" };

//            object savedSettings = null;
//            settingsManager.Setup(s => s.ReadSettings<ConfigurationsList>()).Returns(new ConfigurationsList());
//            settingsManager.Setup(s => s.SaveSettings(It.IsAny<object>())).Callback<object>((o) => savedSettings = o);

//            // act
//            var result = controller.Add(config);

//            // assert
//            var jobSettings = savedSettings as ConfigurationsList;
//            jobSettings.Configurations.Count.Should().Be(1);
//        }

//        [Test]
//        public void Add_Post_RedirectedToDashboardIndex()
//        {
//            // arrange 
//            var settingsManager = new Mock<ISettingsManager>();
//            var controller = new DashboardController(settingsManager.Object);
//            var config = new NewJobModel { Name = "testApp" };

//            object savedSettings = null;
//            settingsManager.Setup(s => s.ReadSettings<ConfigurationsList>()).Returns(new ConfigurationsList());
//            settingsManager.Setup(s => s.SaveSettings(It.IsAny<object>())).Callback<object>((o) => savedSettings = o);

//            // act
//            var result = controller.Add(config) as RedirectToRouteResult;

//            // assert
//            result.RouteValues["controller"].Should().Be("Dashboard");
//            result.RouteValues["action"].Should().Be("Index");
//        }
//    }
//}
