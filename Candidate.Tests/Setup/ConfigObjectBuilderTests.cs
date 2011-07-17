using System;
using System.IO;
using Candidate.Core.Settings.Model;
using Candidate.Core.Setup;
using Candidate.Core.Utils;
using ICSharpCode.SharpZipLib.Zip;
using NUnit.Framework;

namespace Candidate.Tests.Setup {
    [TestFixture]
    public class ConfigObjectBuilderTests {
        private static string CurrentDirectory = Directory.GetCurrentDirectory();
        private IDirectoryProvider DirectoryProvider = new DirectoryProvider("ConfigObjectBuilderTests", CurrentDirectory);

        [SetUp]
        public void Setup() {
            UnzipTestSolution();
        }

        [TearDown]
        public void Teardown() {
            DeleteTestFolder();
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateConfigObject_ForNull_Exception() {
            // arrange
            var configObjectBuilder = new ConfigObjectBuilder(DirectoryProvider);

            // act
            var configObject = configObjectBuilder.CreateConfigObject(null);
        }

        [Test]
        public void CreateConfigObject_ForGit_CreateObjectWithGit() {
            // arrange
            var configObjectBuilder = new ConfigObjectBuilder(DirectoryProvider);
            var config = new JobConfigurationModel { Github = new GithubModel { Url = "git://myhost/repo.git", Branch = "master" } };
            
            // act
            var configObject = configObjectBuilder.CreateConfigObject(config);

            // assert
            Assert.That(configObject.Git, Is.Not.Null);
            Assert.That(configObject.Git.Repository.Value, Is.EqualTo("git://myhost/repo.git"));
        }

        [Test]
        public void CreateConfigObject_ForGit_DirectoryIsInited() {
            // arrange
            var configObjectBuilder = new ConfigObjectBuilder(DirectoryProvider);
            var config = new JobConfigurationModel { Github = new GithubModel { Url = "git://myhost/repo.git", Branch = "master" } };

            // act
            var configObject = configObjectBuilder.CreateConfigObject(config);

            // assert
            Assert.That(configObject.Git.Directory.Value, Is.Not.Null);
            Assert.That(configObject.Git.Directory.Value, Is.EqualTo(DirectoryProvider.Source));
        }

        [Test]
        public void CreateConfigObject_ForSolutionIfGitIsDefined_CreateObjectWithSolution() {
            // arrange
            var configObjectBuilder = new ConfigObjectBuilder(DirectoryProvider);
            var config = new JobConfigurationModel { Github = new GithubModel { Url = "git://myhost/repo.git", Branch = "master" }, Solution = new SolutionModel { Name = "TestSolution\\Test.sln" } };

            // act
            var configObject = configObjectBuilder.CreateConfigObject(config);

            // assert
            Assert.That(configObject.Solution, Is.Not.Null);
            Assert.That(configObject.Solution.SolutionPath.Value, Is.EqualTo(DirectoryProvider.Source + "TestSolution\\Test.sln"));
        }

        [Test]
        public void CreateConfigObject_ForSolutionIfGitIsNoDefined_CreateObjectWithSolution() {
            // arrange
            var configObjectBuilder = new ConfigObjectBuilder(DirectoryProvider);
            var config = new JobConfigurationModel { Solution = new SolutionModel { Name = "TestSolution\\Test.sln" } };

            // act
            var configObject = configObjectBuilder.CreateConfigObject(config);

            // assert
            Assert.That(configObject.Solution, Is.Not.Null);
            Assert.That(configObject.Solution.SolutionPath.Value, Is.EqualTo(DirectoryProvider.Source + "TestSolution\\Test.sln"));
        }  

        [Test]
        [ExpectedException]
        public void CreateConfigObject_ForIisDefinedIfNoSolution_Exception() {
            // arrange
            var configObjectBuilder = new ConfigObjectBuilder(DirectoryProvider);
            var config = new JobConfigurationModel { Iis = new IisModel { SiteName = "TestSite" } };

            // act
            var configObject = configObjectBuilder.CreateConfigObject(config);
        }

        [Test]
        [ExpectedException]
        public void CreateConfig_ForIisIfNoWebprojectName_Exception() {
            // arrange
            var configObjectBuilder = new ConfigObjectBuilder(DirectoryProvider);
            var config = new JobConfigurationModel { Solution = new SolutionModel { Name = "TestSolution\\Test.sln" }, Iis = new IisModel { SiteName = "TestSite" } };

            // act
            var configObject = configObjectBuilder.CreateConfigObject(config);
        }

        [Test]
        public void CreateConfigObject_ForIisIfDefined_CreateIisWebSiteObject() {
            // arrange
            var configObjectBuilder = new ConfigObjectBuilder(DirectoryProvider);
            var config = new JobConfigurationModel { Solution = new SolutionModel { Name = "TestSolution\\Test.sln", WebProject = "Test" }, Iis = new IisModel { SiteName = "TestSite" } };

            // act
            var configObject = configObjectBuilder.CreateConfigObject(config);

            // assert
            Assert.That(configObject.WebSite, Is.Not.Null);
            Assert.That(configObject.WebSite.Name.Value, Is.EqualTo("TestSite"));
        }

        [Test]
        public void CreateConfigObject_ForIisIfDefinedWithWebProject_CreateIisWebSiteObject() {
            // arrange
            var configObjectBuilder = new ConfigObjectBuilder(DirectoryProvider);
            var config = new JobConfigurationModel { Solution = new SolutionModel { Name = "TestSolution\\Test.sln", WebProject = "Test" }, Iis = new IisModel { SiteName = "TestSite" } };

            // act
            var configObject = configObjectBuilder.CreateConfigObject(config);

            // assert
            Assert.That(configObject.WebSite, Is.Not.Null);
            Assert.That(configObject.WebSite.Name.Value, Is.EqualTo("TestSite"));
            Assert.That(configObject.WebSite.Directory.Value, Is.EqualTo(DirectoryProvider.Source + "TestSolution\\Test"));
        }

        [Test]
        public void CreateConfigObject_ForIisIfDefined_DefaultPortIs8081() {
            // arrange
            var configObjectBuilder = new ConfigObjectBuilder(DirectoryProvider);
            var config = new JobConfigurationModel { Solution = new SolutionModel { Name = "TestSolution\\Test.sln", WebProject = "Test" }, Iis = new IisModel { SiteName = "TestSite" } };

            // act
            var configObject = configObjectBuilder.CreateConfigObject(config);

            // assert
            Assert.That(configObject.WebSite, Is.Not.Null);
            Assert.That(configObject.WebSite.Port.Value, Is.EqualTo(8081));
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
