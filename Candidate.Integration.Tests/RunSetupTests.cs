using System.IO;
using Bounce.Framework;
using Candidate.Core.Log;
using Candidate.Core.Settings.Model;
using Candidate.Core.Setup;
using Candidate.Core.Utils;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.Web.Administration;
using NUnit.Framework;

namespace Candidate.Tests.Integration {
    [TestFixture]
    public class RunSetupTests {

        private static string CurrentDirectory = Directory.GetCurrentDirectory();
        private static DirectoryProvider DirectoryProvider = new DirectoryProvider("RunSetupTestsJob", CurrentDirectory);

        [SetUp]
        public void Setup() {
            UnzipTestSolution();
        }

        [TearDown]
        public void Teardown() {
            DeleteTestFolder();
        }

        [Test]
        public void SetupWithOutGitHub_ShouldBuild() {
            // arrange
            var config = new SiteConfiguration() {
                Solution = new Solution {
                    Name = "TestSolution\\Test.sln",
                    IsRunTests = false
                },
            };

            var targetsRetriever = new TargetsRetriever();

            var configObjectBuilder = new ConfigObjectBuilder(DirectoryProvider);
            var targetsObjectBuilder = new DefaultTargetsObjectBuilder(targetsRetriever, configObjectBuilder);

            var targetsBuilder = new TargetsBuilder();

            var bounceFactory = new BounceFactory();

            // act
            var defaultSetup = new DefaultSetup(targetsObjectBuilder, targetsBuilder, bounceFactory);
            defaultSetup.RunForConfig(new NullLogger(), config);

            // assert
            Assert.That(Directory.Exists(DirectoryProvider.Build));
        }

        [Test]
        public void OutputShouldGoToLogger() {
            // arrange
            var config = new SiteConfiguration() {
                Solution = new Solution {
                    Name = "TestSolution\\Test.sln",
                    IsRunTests = false
                },
            };

            var targetsRetriever = new TargetsRetriever();

            var configObjectBuilder = new ConfigObjectBuilder(DirectoryProvider);
            var targetsObjectBuilder = new DefaultTargetsObjectBuilder(targetsRetriever, configObjectBuilder);

            var targetsBuilder = new TargetsBuilder();
            var bounceFactory = new BounceFactory();

            // act
            var loggerFactory = new LoggerFactory(DirectoryProvider);
            var loggerPath = "";
            using (var logger = loggerFactory.CreateLogger()) {
                loggerPath = logger.LogFullPath;

                var defaultSetup = new DefaultSetup(targetsObjectBuilder, targetsBuilder, bounceFactory);
                defaultSetup.RunForConfig(logger, config);
            }

            // assert
            Assert.That(File.Exists(loggerPath), Is.True);
            Assert.That(File.ReadAllText(loggerPath), Is.Not.Empty);
        }

        [Test]
        public void ShouldBeAbleToDeployIisSite() {
            // arrange
            var config = new SiteConfiguration() {
                Solution = new Solution {
                    Name = "TestSolution\\Test.sln",
                    WebProject = "Test",
                    IsRunTests = false
                },
                Iis = new Iis {
                    SiteName = "TestSite"
                }
            };

            var targetsRetriever = new TargetsRetriever();

            var configObjectBuilder = new ConfigObjectBuilder(DirectoryProvider);
            var targetsObjectBuilder = new DefaultTargetsObjectBuilder(targetsRetriever, configObjectBuilder);

            var targetsBuilder = new TargetsBuilder();
            var bounceFactory = new BounceFactory();

            // act
            var defaultSetup = new DefaultSetup(targetsObjectBuilder, targetsBuilder, bounceFactory);
            defaultSetup.RunForConfig(new NullLogger(), config);

            // assert
            var iisServer = new ServerManager();
            Assert.That(iisServer.Sites["TestSite"], Is.Not.Null);
        }

        private void UnzipTestSolution() {
            DeleteTestFolder();
            new FastZip().ExtractZip("TestData\\TestSolution.zip", DirectoryProvider.Source, null);
        }

        private void DeleteTestFolder() {
            if (Directory.Exists(DirectoryProvider.Job)) {
                Directory.Delete(DirectoryProvider.Job, true);
            }
        }

    }
}
