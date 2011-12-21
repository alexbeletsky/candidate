using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Candidate.Areas.Dashboard.Controllers;
using Candidate.Areas.Dashboard.Models;
using Candidate.Core.Settings;
using Candidate.Core.Settings.Model;
using Moq;
using NUnit.Framework;
using SharpTestsEx;

namespace Candidate.Tests.Controllers
{
    [TestFixture]
    public class ConfigurationControllerTests
    {
        [SetUp]
        public void Setup()
        {
            SettingsManager = new Mock<ISettingsManager>();
            Controller = new ConfigurationController(SettingsManager.Object);
            SavedObject = null;
            SettingsManager.Setup(s => s.SaveSettings(It.IsAny<object>())).Callback<object>((o) => SavedObject = o);
        }

        [Test]
        public void Index_Get_Returns_View()
        {
            // arrange

            // act
            var result = Controller.Index("testJob") as ViewResult;

            // assert
            result.Should().Not.Be.Null();
        }

        [Test]
        public void Github_Get_Returns_Model()
        {
            // arrange
            SettingsManager.Setup(s => s.ReadSettings<SitesConfigurationList>()).Returns(
                new SitesConfigurationList
                {
                    Configurations = new List<SiteConfiguration> { 
                    new SiteConfiguration { JobName = "testJob", Github = new GitHub() } }
                });

            // act
            var result = Controller.Github("testJob") as ViewResult;

            // assert
            Assert.That(result.Model, Is.Not.Null);
        }

        [Test]
        public void Github_Post_Creates_New_Settings_Section()
        {
            // arrange
            SettingsManager.Setup(s => s.ReadSettings<SitesConfigurationList>()).Returns(
                new SitesConfigurationList
                {
                    Configurations = new List<SiteConfiguration>()
                });

            // act
            var result = Controller.Github("testJob", new GitHub { Branch = "branch", Url = "url" });

            // assert
            var savedConfiguration = SavedObject as SitesConfigurationList;
            var config = savedConfiguration.Configurations.Where(c => c.JobName == "testJob").Single();
            Assert.That(config.JobName, Is.EqualTo("testJob"));
            Assert.That(config.Github.Branch, Is.EqualTo("branch"));
            Assert.That(config.Github.Url, Is.EqualTo("url"));
        }

        [Test]
        public void Github_Post_Updates_Settings_Section()
        {
            // arrange
            SettingsManager.Setup(s => s.ReadSettings<SitesConfigurationList>()).Returns(
                new SitesConfigurationList
                {
                    Configurations = new List<SiteConfiguration>()
                    {
                        new SiteConfiguration { JobName = "testJob", Github = new GitHub { Branch = "branch", Url = "url" } }
                    }
                });

            // act
            var result = Controller.Github("testJob", new GitHub { Branch = "branch2", Url = "url2" });

            // assert
            var savedConfiguration = SavedObject as SitesConfigurationList;
            var config = savedConfiguration.Configurations.Where(c => c.JobName == "testJob").Single();
            Assert.That(config.JobName, Is.EqualTo("testJob"));
            Assert.That(config.Github.Branch, Is.EqualTo("branch2"));
            Assert.That(config.Github.Url, Is.EqualTo("url2"));
        }

        [Test]
        public void Iis_Get_Returns_Model()
        {
            // arrange
            SettingsManager.Setup(s => s.ReadSettings<SitesConfigurationList>()).Returns(
                new SitesConfigurationList
                {
                    Configurations = new List<SiteConfiguration> { 
                    new SiteConfiguration { JobName = "testJob", Iis = new Iis() } }
                });

            // act
            var result = Controller.Iis("testJob") as ViewResult;

            // assert
            Assert.That(result.Model, Is.Not.Null);
        }

        [Test]
        public void Iis_Post_Creates_New_Settings_Section()
        {
            // arrange
            SettingsManager.Setup(s => s.ReadSettings<SitesConfigurationList>()).Returns(
                new SitesConfigurationList
                {
                    Configurations = new List<SiteConfiguration>()
                });

            // act
            var result = Controller.Iis("testJob", new Iis { SiteName = "site" });

            // assert
            var savedConfiguration = SavedObject as SitesConfigurationList;
            var config = savedConfiguration.Configurations.Where(c => c.JobName == "testJob").Single();
            Assert.That(config.JobName, Is.EqualTo("testJob"));
            Assert.That(config.Iis.SiteName, Is.EqualTo("site"));
        }

        [Test]
        public void Iis_Post_Updates_Settings_Section()
        {
            // arrange
            SettingsManager.Setup(s => s.ReadSettings<SitesConfigurationList>()).Returns(
                new SitesConfigurationList
                {
                    Configurations = new List<SiteConfiguration>()
                    {
                        new SiteConfiguration { JobName = "testJob", Iis = new Iis { SiteName = "site" } }
                    }
                });

            // act
            var result = Controller.Iis("testJob", new Iis { SiteName = "site2" });

            // assert
            var savedConfiguration = SavedObject as SitesConfigurationList;
            var config = savedConfiguration.Configurations.Where(c => c.JobName == "testJob").Single();
            Assert.That(config.JobName, Is.EqualTo("testJob"));
            Assert.That(config.Iis.SiteName, Is.EqualTo("site2"));
        }

        [Test]
        public void Delete_Get_Returns_Model()
        {
            // arrange
            // act
            var result = Controller.Delete("testJob") as ViewResult;

            // assert
            var model = result.Model as DeleteJobModel;
            Assert.That(model.JobName, Is.EqualTo("testJob"));
        }

        [Test]
        public void Delete_Post_Removes_Job_From_List()
        {
            // arrange
            SettingsManager.Setup(s => s.ReadSettings<SitesConfigurationList>()).Returns(
                new SitesConfigurationList { Configurations = new List<SiteConfiguration> { new SiteConfiguration { JobName = "testJob" } } }
                );


            // act
            var result = Controller.Delete(new DeleteJobModel { JobName = "testJob" }) as ViewResult;

            // assert
            var savedConfiguration = SavedObject as SitesConfigurationList;
            var config = savedConfiguration.Configurations.Where(c => c.JobName == "testJob").SingleOrDefault();
            Assert.That(config, Is.Null);
            Assert.That(savedConfiguration.Configurations.Count, Is.EqualTo(0));
        }

        [Test]
        public void Post_Get_Returns_Model()
        {
            // arrange
            SettingsManager.Setup(s => s.ReadSettings<SitesConfigurationList>()).Returns(
                new SitesConfigurationList
                {
                    Configurations = new List<SiteConfiguration> { 
                                new SiteConfiguration { JobName = "testJob", Post = new Post { Batch = "deploy.bat" } } }
                });

            // act
            var result = Controller.Post("testJob") as ViewResult;

            // assert
            var model = result.Model as Post;
            Assert.That(model.Batch, Is.EqualTo("deploy.bat"));
        }

        [Test]
        public void Post_Post_Updates_Model()
        {
            // arrange
            SettingsManager.Setup(s => s.ReadSettings<SitesConfigurationList>()).Returns(
                new SitesConfigurationList
                {
                    Configurations = new List<SiteConfiguration> { 
                                new SiteConfiguration { JobName = "testJob", Post = new Post { Batch = "deploy.bat" } } }
                });

            // act
            Controller.Post("testJob", new Post { Batch = "newDeploy.bat" });

            // assert
            var savedConfiguration = SavedObject as SitesConfigurationList;
            var config = savedConfiguration.Configurations.Where(c => c.JobName == "testJob").SingleOrDefault();
            Assert.That(config.Post.Batch, Is.EqualTo("newDeploy.bat"));
        }

        [Test]
        public void pre_get_should_return_model()
        {
            // arrange
            SettingsManager.Setup(s => s.ReadSettings<SitesConfigurationList>()).Returns(
                new SitesConfigurationList
                {
                    Configurations = new List<SiteConfiguration> { 
                                new SiteConfiguration { JobName = "testJob", Pre = new Pre { Batch = "pre.bat" } } }
                });

            // act
            var result = Controller.Pre("testJob") as ViewResult;

            // assert
            var model = result.Model as Pre;
            Assert.That(model.Batch, Is.EqualTo("pre.bat"));

        }

        [Test]
        public void pre_post_should_update_settings()
        {
            // arrange
            SettingsManager.Setup(s => s.ReadSettings<SitesConfigurationList>()).Returns(
                new SitesConfigurationList
                {
                    Configurations = new List<SiteConfiguration> { 
                                new SiteConfiguration { JobName = "testJob", Pre = new Pre { Batch = "deploy.bat" } } }
                });

            // act
            Controller.Pre("testJob", new Pre { Batch = "newDeploy.bat" });

            // assert
            var savedConfiguration = SavedObject as SitesConfigurationList;
            var config = savedConfiguration.Configurations.Where(c => c.JobName == "testJob").SingleOrDefault();
            Assert.That(config.Pre.Batch, Is.EqualTo("newDeploy.bat"));
        }

        private ConfigurationController Controller { get; set; }
        private Mock<ISettingsManager> SettingsManager { get; set; }
        private object SavedObject { get; set; }
    }
}
