using System.Linq;
using System.Web.Mvc;
using Candidate.Areas.Dashboard.Controllers;
using Candidate.Areas.Dashboard.Models;
using Candidate.Core.Configurations;
using Candidate.Core.Model;
using Candidate.Core.Model.Configurations;
using Candidate.Core.Settings;
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
            Controller = new ConfigurationController(SettingsManager.Object, new ConfigurationsFactory());
            SavedObject = null;

            SettingsManager.Setup(s => s.SaveSettings(It.IsAny<object>())).Callback<object>(o => SavedObject = o);
            SettingsManager.Setup(s => s.ReadSettings<ConfigurationsList>()).Returns(new ConfigurationsList());
        }

        [Test]
        public void should_add_action_return_view()
        {
            // act
            var result = Controller.Add() as ViewResult;

            // assert
            result.Should().Not.Be.Null();
        }

        [Test]
        public void should_add_action_return_empty_model()
        {
            // act
            var result = Controller.Add() as ViewResult;

            // assert
            var model = result.Model;
            Assert.That(model, Is.Not.Null);
        }

        [Test]
        public void should_add_post_method_create_new_configuration()
        {
            // arrange 
            var config = new NewConfigurationModel { Name = "testApp" };

            // act
            Controller.Add(config);

            // assert
            var newConfiguration = SavedObject as ConfigurationsList;
            newConfiguration.Configurations.Count.Should().Be(1);
        }

        [Test]
        public void should_add_create_configuration_based_on_type_case_for_batch()
        {
            // arrange 
            var config = new NewConfigurationModel { Name = "testApp", SelectedType = ConfigurationType.Batch };

            // act
            Controller.Add(config);

            // assert
            var savedConfiguration = ((ConfigurationsList)SavedObject).Configurations.First();
            Assert.That(savedConfiguration, Is.TypeOf<BatchConfiguration>());
        }

        [Test]
        public void should_add_create_configuration_based_on_type_case_for_xcopy()
        {
            // arrange 
            var config = new NewConfigurationModel { Name = "testApp", SelectedType = ConfigurationType.XCopy };

            // act
            Controller.Add(config);

            // assert
            var savedConfiguration = ((ConfigurationsList)SavedObject).Configurations.First();
            Assert.That(savedConfiguration, Is.TypeOf<XCopyConfiguration>());
        }

        [Test]
        public void should_add_create_configuration_based_on_type_case_for_visual_studio()
        {
            // arrange 
            var config = new NewConfigurationModel { Name = "testApp", SelectedType = ConfigurationType.VisualStudio };

            // act
            Controller.Add(config);

            // assert
            var savedConfiguration = ((ConfigurationsList)SavedObject).Configurations.First();
            Assert.That(savedConfiguration, Is.TypeOf<VisualStudioConfiguration>());
        }

        [Test]
        public void should_add_post_redirect_to_dashboard()
        {
            // arrange 
            var config = new NewConfigurationModel { Name = "testApp" };

            // act
            var result = Controller.Add(config) as RedirectToRouteResult;

            // assert
            result.RouteValues["controller"].Should().Be("Dashboard");
            result.RouteValues["action"].Should().Be("Index");
        }

//        [Test]
//        public void Index_Get_Returns_View()
//        {
//            // arrange

//            // act
//            var result = Controller.Index("testJob") as ViewResult;

//            // assert
//            result.Should().Not.Be.Null();
//        }

//        [Test]
//        public void Github_Get_Returns_Model()
//        {
//            // arrange
//            SettingsManager.Setup(s => s.ReadSettings<ConfigurationsList>()).Returns(
//                new ConfigurationsList
//                {
//                    Configurations = new List<VisualStudioConfiguration> { 
//                    new VisualStudioConfiguration { Id = "testJob", Github = new Github() } }
//                });

//            // act
//            var result = Controller.Github("testJob") as ViewResult;

//            // assert
//            Assert.That(result.Model, Is.Not.Null);
//        }

//        [Test]
//        public void Github_Post_Creates_New_Settings_Section()
//        {
//            // arrange
//            SettingsManager.Setup(s => s.ReadSettings<ConfigurationsList>()).Returns(
//                new ConfigurationsList
//                {
//                    Configurations = new List<VisualStudioConfiguration>()
//                });

//            // act
//            var result = Controller.Github("testJob", new Github { Branch = "branch", Url = "url" });

//            // assert
//            var savedConfiguration = SavedObject as ConfigurationsList;
//            var config = savedConfiguration.Configurations.Where(c => c.Id == "testJob").Single();
//            Assert.That(config.Id, Is.EqualTo("testJob"));
//            Assert.That(config.Github.Branch, Is.EqualTo("branch"));
//            Assert.That(config.Github.Url, Is.EqualTo("url"));
//        }

//        [Test]
//        public void Github_Post_Updates_Settings_Section()
//        {
//            // arrange
//            SettingsManager.Setup(s => s.ReadSettings<ConfigurationsList>()).Returns(
//                new ConfigurationsList
//                {
//                    Configurations = new List<VisualStudioConfiguration>()
//                    {
//                        new VisualStudioConfiguration { Id = "testJob", Github = new Github { Branch = "branch", Url = "url" } }
//                    }
//                });

//            // act
//            var result = Controller.Github("testJob", new Github { Branch = "branch2", Url = "url2" });

//            // assert
//            var savedConfiguration = SavedObject as ConfigurationsList;
//            var config = savedConfiguration.Configurations.Where(c => c.Id == "testJob").Single();
//            Assert.That(config.Id, Is.EqualTo("testJob"));
//            Assert.That(config.Github.Branch, Is.EqualTo("branch2"));
//            Assert.That(config.Github.Url, Is.EqualTo("url2"));
//        }

//        [Test]
//        public void Iis_Get_Returns_Model()
//        {
//            // arrange
//            SettingsManager.Setup(s => s.ReadSettings<ConfigurationsList>()).Returns(
//                new ConfigurationsList
//                {
//                    Configurations = new List<VisualStudioConfiguration> { 
//                    new VisualStudioConfiguration { Id = "testJob", Iis = new Iis() } }
//                });

//            // act
//            var result = Controller.Iis("testJob") as ViewResult;

//            // assert
//            Assert.That(result.Model, Is.Not.Null);
//        }

//        [Test]
//        public void Iis_Post_Creates_New_Settings_Section()
//        {
//            // arrange
//            SettingsManager.Setup(s => s.ReadSettings<ConfigurationsList>()).Returns(
//                new ConfigurationsList
//                {
//                    Configurations = new List<VisualStudioConfiguration>()
//                });

//            // act
//            var result = Controller.Iis("testJob", new Iis { SiteName = "site" });

//            // assert
//            var savedConfiguration = SavedObject as ConfigurationsList;
//            var config = savedConfiguration.Configurations.Where(c => c.Id == "testJob").Single();
//            Assert.That(config.Id, Is.EqualTo("testJob"));
//            Assert.That(config.Iis.SiteName, Is.EqualTo("site"));
//        }

//        [Test]
//        public void Iis_Post_Updates_Settings_Section()
//        {
//            // arrange
//            SettingsManager.Setup(s => s.ReadSettings<ConfigurationsList>()).Returns(
//                new ConfigurationsList
//                {
//                    Configurations = new List<VisualStudioConfiguration>()
//                    {
//                        new VisualStudioConfiguration { Id = "testJob", Iis = new Iis { SiteName = "site" } }
//                    }
//                });

//            // act
//            var result = Controller.Iis("testJob", new Iis { SiteName = "site2" });

//            // assert
//            var savedConfiguration = SavedObject as ConfigurationsList;
//            var config = savedConfiguration.Configurations.Where(c => c.Id == "testJob").Single();
//            Assert.That(config.Id, Is.EqualTo("testJob"));
//            Assert.That(config.Iis.SiteName, Is.EqualTo("site2"));
//        }

//        [Test]
//        public void Delete_Get_Returns_Model()
//        {
//            // arrange
//            // act
//            var result = Controller.Delete("testJob") as ViewResult;

//            // assert
//            var model = result.Model as DeleteJobModel;
//            Assert.That(model.Id, Is.EqualTo("testJob"));
//        }

//        [Test]
//        public void Delete_Post_Removes_Job_From_List()
//        {
//            // arrange
//            SettingsManager.Setup(s => s.ReadSettings<ConfigurationsList>()).Returns(
//                new ConfigurationsList { Configurations = new List<VisualStudioConfiguration> { new VisualStudioConfiguration { Id = "testJob" } } }
//                );


//            // act
//            var result = Controller.Delete(new DeleteJobModel { Id = "testJob" }) as ViewResult;

//            // assert
//            var savedConfiguration = SavedObject as ConfigurationsList;
//            var config = savedConfiguration.Configurations.Where(c => c.Id == "testJob").SingleOrDefault();
//            Assert.That(config, Is.Null);
//            Assert.That(savedConfiguration.Configurations.Count, Is.EqualTo(0));
//        }

//        [Test]
//        public void Post_Get_Returns_Model()
//        {
//            // arrange
//            SettingsManager.Setup(s => s.ReadSettings<ConfigurationsList>()).Returns(
//                new ConfigurationsList
//                {
//                    Configurations = new List<VisualStudioConfiguration> { 
//                                new VisualStudioConfiguration { Id = "testJob", Post = new Post { Batch = "deploy.bat" } } }
//                });

//            // act
//            var result = Controller.Post("testJob") as ViewResult;

//            // assert
//            var model = result.Model as Post;
//            Assert.That(model.Batch, Is.EqualTo("deploy.bat"));
//        }

//        [Test]
//        public void Post_Post_Updates_Model()
//        {
//            // arrange
//            SettingsManager.Setup(s => s.ReadSettings<ConfigurationsList>()).Returns(
//                new ConfigurationsList
//                {
//                    Configurations = new List<VisualStudioConfiguration> { 
//                                new VisualStudioConfiguration { Id = "testJob", Post = new Post { Batch = "deploy.bat" } } }
//                });

//            // act
//            Controller.Post("testJob", new Post { Batch = "newDeploy.bat" });

//            // assert
//            var savedConfiguration = SavedObject as ConfigurationsList;
//            var config = savedConfiguration.Configurations.Where(c => c.Id == "testJob").SingleOrDefault();
//            Assert.That(config.Post.Batch, Is.EqualTo("newDeploy.bat"));
//        }

//        [Test]
//        public void pre_get_should_return_model()
//        {
//            // arrange
//            SettingsManager.Setup(s => s.ReadSettings<ConfigurationsList>()).Returns(
//                new ConfigurationsList
//                {
//                    Configurations = new List<VisualStudioConfiguration> { 
//                                new VisualStudioConfiguration { Id = "testJob", Pre = new Pre { Batch = "pre.bat" } } }
//                });

//            // act
//            var result = Controller.Pre("testJob") as ViewResult;

//            // assert
//            var model = result.Model as Pre;
//            Assert.That(model.Batch, Is.EqualTo("pre.bat"));

//        }

//        [Test]
//        public void pre_post_should_update_settings()
//        {
//            // arrange
//            SettingsManager.Setup(s => s.ReadSettings<ConfigurationsList>()).Returns(
//                new ConfigurationsList
//                {
//                    Configurations = new List<VisualStudioConfiguration> { 
//                                new VisualStudioConfiguration { Id = "testJob", Pre = new Pre { Batch = "deploy.bat" } } }
//                });

//            // act
//            Controller.Pre("testJob", new Pre { Batch = "newDeploy.bat" });

//            // assert
//            var savedConfiguration = SavedObject as ConfigurationsList;
//            var config = savedConfiguration.Configurations.Where(c => c.Id == "testJob").SingleOrDefault();
//            Assert.That(config.Pre.Batch, Is.EqualTo("newDeploy.bat"));
//        }

        private ConfigurationController Controller { get; set; }
        private Mock<ISettingsManager> SettingsManager { get; set; }
        private object SavedObject { get; set; }
    }
}
