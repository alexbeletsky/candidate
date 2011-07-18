using System.Collections.Generic;
using System.Web.Mvc;
using Candidate.Areas.Dashboard.Controllers;
using Candidate.Areas.Dashboard.Models;
using Candidate.Core.Settings;
using Moq;
using NUnit.Framework;
using SharpTestsEx;
namespace Candidate.Tests.Controllers
{
    [TestFixture]
    public class DashboardControllerTests
    {
        [Test]
        public void Index_Get_ReturnsView()
        {
            // arrange 
            var settingsManager = new Mock<ISettingsManager>();
            var controller = new DashboardController(settingsManager.Object);

            // act
            var result = controller.Index() as ViewResult;

            // assert
            result.Should().Not.Be.Null();
        }

        [Test]
        public void List_Get_ReturnsTheListOfJobs()
        {
            // arrange 
            var settingsManager = new Mock<ISettingsManager>();
            var controller = new DashboardController(settingsManager.Object);

            settingsManager.Setup(s => s.ReadSettings<JobsSettingsModel>()).Returns(new JobsSettingsModel { Jobs = new List<JobModel>() });

            // act
            var result = controller.List() as ViewResult;

            // assert
            var model = result.Model as IList<JobModel>;
            model.Should().Not.Be.Null();
        }

        [Test]
        public void Add_Get_ReturnsView()
        {
            // arrange 
            var settingsManager = new Mock<ISettingsManager>();
            var controller = new DashboardController(settingsManager.Object);

            // act
            var result = controller.Add() as ViewResult;

            // assert
            result.Should().Not.Be.Null();
        }

        [Test]
        public void Add_Post_NewJobConfigurationAdded()
        {
            // arrange 
            var settingsManager = new Mock<ISettingsManager>();
            var controller = new DashboardController(settingsManager.Object);
            var config = new NewJobModel { Name = "testApp" };

            object savedSettings = null;
            settingsManager.Setup(s => s.ReadSettings<JobsSettingsModel>()).Returns(new JobsSettingsModel());
            settingsManager.Setup(s => s.SaveSettings(It.IsAny<object>())).Callback<object>((o) => savedSettings = o);

            // act
            var result = controller.Add(config);

            // assert
            var jobSettings = savedSettings as JobsSettingsModel;
            jobSettings.Jobs.Count.Should().Be(1);
        }

        [Test]
        public void Add_Post_RedirectedToDashboardIndex()
        {
            // arrange 
            var settingsManager = new Mock<ISettingsManager>();
            var controller = new DashboardController(settingsManager.Object);
            var config = new NewJobModel { Name = "testApp" };

            object savedSettings = null;
            settingsManager.Setup(s => s.ReadSettings<JobsSettingsModel>()).Returns(new JobsSettingsModel());
            settingsManager.Setup(s => s.SaveSettings(It.IsAny<object>())).Callback<object>((o) => savedSettings = o);

            // act
            var result = controller.Add(config) as RedirectToRouteResult;

            // assert
            result.RouteValues["controller"].Should().Be("Dashboard");
            result.RouteValues["action"].Should().Be("Index");
        }
    }
}
