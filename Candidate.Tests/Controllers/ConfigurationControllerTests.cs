using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Candidate.Core.Settings;
using Moq;
using Candidate.Areas.Dashboard.Controllers;
using System.Web.Mvc;
using SharpTestsEx;

namespace Candidate.Tests.Controllers
{
    [TestFixture]
    public class ConfigurationControllerTests
    {
        [Test]
        public void Index_Get_ReturnsView()
        {
            // arrange
            var settingsManager = new Mock<ISettingsManager>();
            var controller = new ConfigurationController(settingsManager.Object);

            // act
            var result = controller.Index("testJob") as ViewResult;

            // assert
            result.Should().Not.Be.Null();
        }

        [Test]
        public void Index_Get_PutsJobNameIntoViewBag()
        {
            // arrange
            var settingsManager = new Mock<ISettingsManager>();
            var controller = new ConfigurationController(settingsManager.Object);

            // act
            var result = controller.Index("testJob") as ViewResult;

            // assert
            var jobName = result.ViewBag.JobName;
            Assert.That(jobName, Is.EqualTo("testJob"));
        }
    }
}
