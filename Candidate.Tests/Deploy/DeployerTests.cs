using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Candidate.Core.Configurations;
using Candidate.Core.Configurations.Parts;
using Candidate.Core.Configurations.Types;
using Candidate.Core.Deploy;
using Candidate.Core.Settings;
using Moq;
using NUnit.Framework;

namespace Candidate.Tests.Deploy
{
    public class DeployerTests
    {
        [SetUp]
        public void Setup()
        {
            SettingsManager = new Mock<ISettingsManager>();
            Deployer = new Deployer(SettingsManager.Object);
            DeployRunner = new Mock<IDeployRunner>();

            ConfigurationsList = new ConfigurationsList();
            SettingsManager.Setup(s => s.ReadSettings<ConfigurationsList>()).Returns(ConfigurationsList);
        }

        protected Mock<IDeployRunner> DeployRunner { get; set; }
        protected ConfigurationsList ConfigurationsList { get; set; }
        protected Deployer Deployer { get; set; }
        protected Mock<ISettingsManager> SettingsManager { get; set; }

        [Test]
        public void should_start_new_deploy_for_configuration()
        {
            // arrange
            var configuration = new Mock<BatchConfiguration>();
            configuration.Object.Id = "1";
            configuration.Setup(_ => _.CreateDeployRunner()).Returns(DeployRunner.Object);

            ConfigurationsList.Configurations.Add(configuration.Object);
    
            // act
            Deployer.Deploy("1");

            // assert
            DeployRunner.Verify(_ => _.Run("1"), Times.Once());
        }

        [Test]
        public void should_start_deploy_for_branch_if_hook_branch_equals_to_configuration_branch()
        {
            // arrange
            var configuration = new Mock<BatchConfiguration>();
            configuration.Object.Id = "1";
            configuration.Object.Github = new Github {Branch = "master"};

            configuration.Setup(_ => _.Type).Returns("Batch");
            configuration.Setup(_ => _.CreateDeployRunner()).Returns(DeployRunner.Object);

            ConfigurationsList.Configurations.Add(configuration.Object);

            // act
            Deployer.Deploy("1", "master");

            // assert
            DeployRunner.Verify(_ => _.Run("1"), Times.Once());
        }

        [Test]
        public void should_not_deploy_if_branches_are_different()
        {
            // arrange
            var configuration = new Mock<BatchConfiguration>();
            configuration.Object.Id = "1";
            configuration.Object.Github = new Github { Branch = "develop" };

            configuration.Setup(_ => _.Type).Returns("Batch");
            configuration.Setup(_ => _.CreateDeployRunner()).Returns(DeployRunner.Object);

            ConfigurationsList.Configurations.Add(configuration.Object);

            // act
            Deployer.Deploy("1", "master");

            // assert
            DeployRunner.Verify(_ => _.Run("1"), Times.Never());
        }
    }
}
