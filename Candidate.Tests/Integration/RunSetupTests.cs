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

            var bounce = new BounceFactory().GetBounce();

            // act
            var defaultSetup = new DefaultSetup(targetsObjectBuilder, targetsBuilder, bounce, config);
            defaultSetup.Execute();

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

            // act
            var loggerFactory = new LoggerFactory();
            using (var logger = loggerFactory.CreateLogger(DirectoryProvider.Logs)) {
                var logOptions = new FileLogOptionsFactory().CreateLogOptions(logger, LogLevel.Debug);
                var bounce = new BounceFactory().GetBounce(logOptions);

                var defaultSetup = new DefaultSetup(targetsObjectBuilder, targetsBuilder, bounce, config);
                defaultSetup.Execute();

                // assert
                Assert.That(File.Exists(logger.Id), Is.True);
            }
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
