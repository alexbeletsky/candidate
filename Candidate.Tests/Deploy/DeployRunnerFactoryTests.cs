using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Candidate.Core.Configurations;
using Candidate.Core.Configurations.Parts;
using Candidate.Core.Configurations.Types;
using Candidate.Core.Deploy;
using NUnit.Framework;

namespace Candidate.Tests.Deploy
{
    public class DeployRunnerFactoryTests
    {
        public class DeployForXCopy
        {
            [Test]
            public void should_create_deploy_runner()
            {
                var configuration = new XCopyConfiguration 
                { 
                    Id = "id", 
                    Github = new Github { Url = "git@git.com", Branch = "master" },
                    Iis = new Iis { SiteName = "test", DeployDirectory = @"c:\deploy" },
                };

                var deployer = CreateFactory();

                var deployRunner = deployer.ForConfiguration(configuration);

                Assert.That(deployRunner, Is.Not.Null);
            }
        }

        public class DeployForBatch
        {
            [Test]
            public void should_create_deploy_runner()
            {
                var configuration = new BatchConfiguration
                {
                    Id = "batch-build",
                    Github = new Github { Branch = "master", Url = "git@git.com" },
                    Iis = new Iis { Port = 9090, SiteName = "x", DeployDirectory = "c:\\sites" },
                    Batch = new Batch { BuildScript = "build.bat" }
                };

                var deployer = CreateFactory();

                var deployRunner = deployer.ForConfiguration(configuration);

                Assert.That(deployRunner, Is.Not.Null);
            }
        }

        public class DeployForVisualStudio
        {
            [Test]
            public void should_create_deploy_runner()
            {
                var configuration = new VisualStudioConfiguration
                {
                    Id = "visual-studio",
                    Github = new Github { Branch = "master", Url = "git@git.com" },
                    Iis = new Iis { Port = 9090, SiteName = "x", DeployDirectory = "c:\\sites" },
                    Solution = new Solution { Name = "solution.sln", SelectedConfiguration = 0, WebProject = "Web", IsRunTests = true }
                };

                var deployer = CreateFactory();

                var deployRunner = deployer.ForConfiguration(configuration);

                Assert.That(deployRunner, Is.Not.Null);
            }
        }

        static DeployRunnerFactory CreateFactory()
        {
            return new DeployRunnerFactory();
        }
    }
}
