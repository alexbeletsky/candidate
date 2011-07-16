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
            DeleteTestSolution();
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
            var logger = new DummyLogger();

            // act
            var defaultSetup = new DefaultSetup(targetsObjectBuilder, targetsBuilder, bounce, config);
            defaultSetup.Execute(logger);

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

            var bounce = new BounceFactory().GetBounce(new FileTaskLogFactory(), new LogOptions());
            var logger = new DummyLogger();

            // act
            var defaultSetup = new DefaultSetup(targetsObjectBuilder, targetsBuilder, bounce, config);
            defaultSetup.Execute(logger);

        }

        private void UnzipTestSolution() {
            DeleteTestSolution();
            new FastZip().ExtractZip("TestSolution.zip", DirectoryProvider.Source, null);
        }

        private void DeleteTestSolution() {
            if (Directory.Exists(DirectoryProvider.Source)) {
                Directory.Delete(DirectoryProvider.Source, true);
            }
        }

    }
}
