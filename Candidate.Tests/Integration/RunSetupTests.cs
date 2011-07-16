using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Candidate.Core.Settings.Model;
using Candidate.Core.Setup;
using Bounce.Framework;
using Candidate.Core.System;
using Candidate.Core.Utils;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using Candidate.Core.Log;

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
            var config = new JobConfigurationModel() {
                Solution = new SolutionModel {
                    Name = "TestSolution\\Test.sln"
                },
            };

            var targetsRetriever = new TargetsRetriever();

            var configObjectBuilder = new ConfigObjectBuilder(DirectoryProvider);
            var targetsObjectBuilder = new DefaultTargetsObjectBuilder(targetsRetriever, configObjectBuilder);

            var targetsBuilder = new TargetsBuilder();

            var bounceFactory = new BounceFactory();

            // act
            var defaultSetup = new DefaultSetup(targetsObjectBuilder, targetsBuilder, bounceFactory);
            defaultSetup.RunForConfig(new DummyLogger(), config);

            // assert
            Assert.That(Directory.Exists(DirectoryProvider.Source + "TestSolution\\Test\\bin"));
        }

        [Test]
        public void OutputShouldGoToLogger() {
            // arrange
            var config = new JobConfigurationModel() {
                Solution = new SolutionModel {
                    Name = "TestSolution\\Test.sln"
                },
            };

            var targetsRetriever = new TargetsRetriever();

            var configObjectBuilder = new ConfigObjectBuilder(DirectoryProvider);
            var targetsObjectBuilder = new DefaultTargetsObjectBuilder(targetsRetriever, configObjectBuilder);

            var targetsBuilder = new TargetsBuilder();
            var bounceFactory = new BounceFactory();

            // act
            var loggerFactory = new LoggerFactory();
            var loggerId = "";
            using (var logger = loggerFactory.CreateLogger(DirectoryProvider.Logs)) {
                loggerId = logger.Id;

                var defaultSetup = new DefaultSetup(targetsObjectBuilder, targetsBuilder, bounceFactory);
                defaultSetup.RunForConfig(logger, config);
            }

            // assert
            Assert.That(File.Exists(loggerId), Is.True);
            Assert.That(File.ReadAllText(loggerId), Is.Not.Empty);
        }

        private void UnzipTestSolution() {
            DeleteTestFolder();
            new FastZip().ExtractZip("TestSolution.zip", DirectoryProvider.Source, null);
        }

        private void DeleteTestFolder() {
            if (Directory.Exists(DirectoryProvider.Job)) {
                Directory.Delete(DirectoryProvider.Job, true);
            }
        }

    }
}
