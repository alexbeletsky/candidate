using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SharpTestsEx;
using Candidate.Areas.Dashboard.Controllers;
using Moq;
using Candidate.Core.Settings;
using System.Web.Mvc;
using Candidate.Areas.Dashboard.Models;
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
    }
}
