using System.Collections.Generic;
using System.Web.Mvc;
using Candidate.Areas.Dashboard.Controllers;
using Candidate.Areas.Dashboard.Models;
using Candidate.Core.Configurations;
using Candidate.Core.Configurations.Types;
using Candidate.Core.Settings;
using Candidate.Infrustructure.Authentication;
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

            settingsManager.Setup(_ => _.ReadSettings<UserSettings>()).Returns(new UserSettings { User = new User() });

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

            settingsManager.Setup(s => s.ReadSettings<ConfigurationsList>()).Returns(new ConfigurationsList { Configurations = new List<Configuration>() });

            // act
            var result = controller.List() as ViewResult;

            // assert
            var model = result.Model as IList<Configuration>;
            model.Should().Not.Be.Null();
        }
    }
}
