using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Candidate.Areas.Configuration.Controllers;
using Candidate.Core.Model;
using Candidate.Core.Model.Configurations;
using Candidate.Core.Settings;
using Moq;
using NUnit.Framework;

namespace Candidate.Tests.Controllers
{
    public class ConfigureControllerTests
    {
        [SetUp]
        public void Setup()
        {
            SettingsManager = new Mock<ISettingsManager>();
            Controller = new ConfigureController(SettingsManager.Object);

            ConfigurationsList = new ConfigurationsList();
            SettingsManager.Setup(s => s.ReadSettings<ConfigurationsList>()).Returns(ConfigurationsList);
        }

        protected ConfigurationsList ConfigurationsList { get; set; }
        protected ConfigureController Controller { get; set; }
        protected Mock<ISettingsManager> SettingsManager { get; set; }

        [Test]
        public void should_refer_to_view_based_on_configuration_type_batch()
        {
            // arrange
            ConfigurationsList.Configurations.Add(new BatchConfiguration { Id = "1" });

            // act
            var result = Controller.Configure("1") as ViewResult;

            // assert
            Assert.That(result.ViewName, Is.EqualTo("Batch"));
        }

        [Test]
        public void should_refer_to_view_based_on_configuration_type_xcopy()
        {
            // arrange
            ConfigurationsList.Configurations.Add(new XCopyConfiguration { Id = "1" });

            // act
            var result = Controller.Configure("1") as ViewResult;

            // assert
            Assert.That(result.ViewName, Is.EqualTo("XCopy"));
        }

        [Test]
        public void should_refer_to_view_based_on_configuration_type_visual_studio()
        {
            // arrange
            ConfigurationsList.Configurations.Add(new VisualStudioConfiguration { Id = "1" });

            // act
            var result = Controller.Configure("1") as ViewResult;

            // assert
            Assert.That(result.ViewName, Is.EqualTo("VisualStudio"));
        }
    }
}
