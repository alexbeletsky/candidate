using System.Linq;
using System.Web.Mvc;
using Candidate.Areas.Configuration.Controllers;
using Candidate.Areas.Dashboard.Models;
using Candidate.Core.Configurations;
using Candidate.Core.Configurations.Types;
using Candidate.Core.Settings;
using Moq;
using NUnit.Framework;
using SharpTestsEx;

namespace Candidate.Tests.Controllers
{
    [TestFixture]
    public class ConfigurationControllerTests
    {
        private ConfigurationsList ConfigurationsList { get; set; }

        [SetUp]
        public void Setup()
        {
            SettingsManager = new Mock<ISettingsManager>();
            Controller = new ConfigurationController(SettingsManager.Object, new ConfigurationsFactory());
            SavedObject = null;

            SettingsManager.Setup(s => s.SaveSettings(It.IsAny<object>())).Callback<object>(o => SavedObject = o);
            ConfigurationsList = new ConfigurationsList();
            SettingsManager.Setup(s => s.ReadSettings<ConfigurationsList>()).Returns(ConfigurationsList);
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
            var config = new NewConfiguration { Name = "testApp", SelectedType = "batch" };

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
            var config = new NewConfiguration { Name = "testApp", SelectedType = "batch" };

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
            var config = new NewConfiguration { Name = "testApp", SelectedType = "xcopy" };

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
            var config = new NewConfiguration { Name = "testApp", SelectedType = "visualstudio" };

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
            var config = new NewConfiguration { Name = "testApp", SelectedType = "xcopy" };

            // act
            var result = Controller.Add(config) as RedirectToRouteResult;

            // assert
            result.RouteValues["area"].Should().Be("dashboard");
            result.RouteValues["controller"].Should().Be("dashboard");
            result.RouteValues["action"].Should().Be("index");
        }

        [Test]
        public void should_delete_return_model()
        {
            // arrange
            ConfigurationsList.Configurations.Add(new VisualStudioConfiguration { Id = "test" });

            // act
            var result = Controller.Delete("test") as ViewResult;

            // assert
            var model = result.Model as Configuration;
            Assert.That(model.Id, Is.EqualTo("test"));
        }

        [Test]
        public void should_delete_post_remove_configuration()
        {
            // arrange
            var configuration = new VisualStudioConfiguration { Id = "test" };
            ConfigurationsList.Configurations.Add(configuration);

            // act
            Controller.DeleteConfiguration("test");

            // assert
            Assert.That(ConfigurationsList.Configurations.SingleOrDefault(_ => _.Id == "test"), Is.Null);
        } 

        private ConfigurationController Controller { get; set; }
        private Mock<ISettingsManager> SettingsManager { get; set; }
        private object SavedObject { get; set; }
    }
}
