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
using Candidate.Areas.Dashboard.Models;

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

        [Test]
        public void Github_Get_ReturnNullIfConfigurationNotSet()
        {
            // arrange
            var settingsManager = new Mock<ISettingsManager>();
            var controller = new ConfigurationController(settingsManager.Object);

            settingsManager.Setup(s => s.ReadSettings<JobsConfigurationSettingsModel>()).Returns(new JobsConfigurationSettingsModel());

            // act
            var result = controller.Github("testJob") as ViewResult;

            // assert
            Assert.That(result.Model, Is.Null);
        }

        [Test]
        public void Github_Get_ReturnsModel()
        {
            // arrange
            var settingsManager = new Mock<ISettingsManager>();
            var controller = new ConfigurationController(settingsManager.Object);

            settingsManager.Setup(s => s.ReadSettings<JobsConfigurationSettingsModel>()).Returns(
                new JobsConfigurationSettingsModel { Configurations = new List<JobConfigurationModel> { 
                    new JobConfigurationModel { JobName = "testJob", Github = new GithubModel() } } });

            // act
            var result = controller.Github("testJob") as ViewResult;

            // assert
            Assert.That(result.Model, Is.Not.Null);
        }

        [Test]
        public void Github_Post_CreatesNewSettingsSection()
        {
            // arrange
            var settingsManager = new Mock<ISettingsManager>();
            var controller = new ConfigurationController(settingsManager.Object);

            object savedObject = null;
            settingsManager.Setup(s => s.ReadSettings<JobsConfigurationSettingsModel>()).Returns(
                new JobsConfigurationSettingsModel
                {
                    Configurations = new List<JobConfigurationModel> ()
                });
            settingsManager.Setup(s => s.SaveSettings(It.IsAny<object>())).Callback<object>((o) => savedObject = o);

            // act
            var result = controller.Github("testJob", new GithubModel { Branch = "branch", Url = "url" });

            // assert
            var savedConfiguration = savedObject as JobsConfigurationSettingsModel;
            var config = savedConfiguration.Configurations.Where(c => c.JobName == "testJob").Single();
            Assert.That(config.JobName, Is.EqualTo("testJob"));
            Assert.That(config.Github.Branch, Is.EqualTo("branch"));
            Assert.That(config.Github.Url, Is.EqualTo("url"));
        }

        [Test]
        public void Github_Post_UpdatesSettingsSection()
        {
            // arrange
            var settingsManager = new Mock<ISettingsManager>();
            var controller = new ConfigurationController(settingsManager.Object);

            object savedObject = null;
            settingsManager.Setup(s => s.ReadSettings<JobsConfigurationSettingsModel>()).Returns(
                new JobsConfigurationSettingsModel
                {
                    Configurations = new List<JobConfigurationModel>()
                    {
                        new JobConfigurationModel { JobName = "testJob", Github = new GithubModel { Branch = "branch", Url = "url" } }
                    }
                });
            settingsManager.Setup(s => s.SaveSettings(It.IsAny<object>())).Callback<object>((o) => savedObject = o);

            // act
            var result = controller.Github("testJob", new GithubModel { Branch = "branch2", Url = "url2" });

            // assert
            var savedConfiguration = savedObject as JobsConfigurationSettingsModel;
            var config = savedConfiguration.Configurations.Where(c => c.JobName == "testJob").Single();
            Assert.That(config.JobName, Is.EqualTo("testJob"));
            Assert.That(config.Github.Branch, Is.EqualTo("branch2"));
            Assert.That(config.Github.Url, Is.EqualTo("url2"));
        }

        [Test]
        public void Iis_Get_ReturnNullIfConfigurationNotSet()
        {
            // arrange
            var settingsManager = new Mock<ISettingsManager>();
            var controller = new ConfigurationController(settingsManager.Object);

            settingsManager.Setup(s => s.ReadSettings<JobsConfigurationSettingsModel>()).Returns(new JobsConfigurationSettingsModel());

            // act
            var result = controller.Iis("testJob") as ViewResult;

            // assert
            Assert.That(result.Model, Is.Null);
        }

        [Test]
        public void Iis_Get_ReturnsModel()
        {
            // arrange
            var settingsManager = new Mock<ISettingsManager>();
            var controller = new ConfigurationController(settingsManager.Object);

            settingsManager.Setup(s => s.ReadSettings<JobsConfigurationSettingsModel>()).Returns(
                new JobsConfigurationSettingsModel
                {
                    Configurations = new List<JobConfigurationModel> { 
                    new JobConfigurationModel { JobName = "testJob", Iis = new IisModel() } }
                });

            // act
            var result = controller.Iis("testJob") as ViewResult;

            // assert
            Assert.That(result.Model, Is.Not.Null);
        }

        [Test]
        public void Iis_Post_CreatesNewSettingsSection()
        {
            // arrange
            var settingsManager = new Mock<ISettingsManager>();
            var controller = new ConfigurationController(settingsManager.Object);

            object savedObject = null;
            settingsManager.Setup(s => s.ReadSettings<JobsConfigurationSettingsModel>()).Returns(
                new JobsConfigurationSettingsModel
                {
                    Configurations = new List<JobConfigurationModel>()
                });
            settingsManager.Setup(s => s.SaveSettings(It.IsAny<object>())).Callback<object>((o) => savedObject = o);

            // act
            var result = controller.Iis("testJob", new IisModel { SiteName = "site" });

            // assert
            var savedConfiguration = savedObject as JobsConfigurationSettingsModel;
            var config = savedConfiguration.Configurations.Where(c => c.JobName == "testJob").Single();
            Assert.That(config.JobName, Is.EqualTo("testJob"));
            Assert.That(config.Iis.SiteName, Is.EqualTo("site"));
        }

        [Test]
        public void Iis_Post_UpdatesSettingsSection()
        {
            // arrange
            var settingsManager = new Mock<ISettingsManager>();
            var controller = new ConfigurationController(settingsManager.Object);

            object savedObject = null;
            settingsManager.Setup(s => s.ReadSettings<JobsConfigurationSettingsModel>()).Returns(
                new JobsConfigurationSettingsModel
                {
                    Configurations = new List<JobConfigurationModel>()
                    {
                        new JobConfigurationModel { JobName = "testJob", Iis = new IisModel { SiteName = "site" } }
                    }
                });
            settingsManager.Setup(s => s.SaveSettings(It.IsAny<object>())).Callback<object>((o) => savedObject = o);

            // act
            var result = controller.Iis("testJob", new IisModel { SiteName = "site2" });

            // assert
            var savedConfiguration = savedObject as JobsConfigurationSettingsModel;
            var config = savedConfiguration.Configurations.Where(c => c.JobName == "testJob").Single();
            Assert.That(config.JobName, Is.EqualTo("testJob"));
            Assert.That(config.Iis.SiteName, Is.EqualTo("site2"));
        }

        [Test]
        public void Delete_Get_ReturnsModel()
        {
            // arrange
            var settingsManager = new Mock<ISettingsManager>();
            var controller = new ConfigurationController(settingsManager.Object);

            // act
            var result = controller.Delete("testJob") as ViewResult;

            // assert
            var model = result.Model as DeleteJobModel;
            Assert.That(model.JobName, Is.EqualTo("testJob"));
        }

        [Test]
        public void Delete_Post_RemovesJobFromList()
        {
            // arrange
            var settingsManager = new Mock<ISettingsManager>();
            var controller = new ConfigurationController(settingsManager.Object);

            object savedObject = null;
            settingsManager.Setup(s => s.ReadSettings<JobsSettingsModel>()).Returns(
                new JobsSettingsModel { Jobs = new List<JobModel> { new JobModel { Name = "testJob" } } }
                );

            settingsManager.Setup(s => s.SaveSettings(It.IsAny<object>())).Callback<object>((o) => savedObject = o);

            // act
            var result = controller.Delete(new DeleteJobModel { JobName = "testJob" }) as ViewResult;

            // assert
            var savedConfiguration = savedObject as JobsSettingsModel;
            var config = savedConfiguration.Jobs.Where(c => c.Name == "testJob").SingleOrDefault();
            Assert.That(config, Is.Null);
        }
    }
}
