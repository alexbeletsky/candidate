using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Candidate.Core.Setup;
using Candidate.Core.Settings.Model;
using Candidate.Core.Utils;
using System.IO;

namespace Candidate.Tests.Setup {
    [TestFixture]
    public class ConfigObjectBuilderTests {
        private IDirectoryProvider _directoryProvider;
        private static string CurrentDirectory = Directory.GetCurrentDirectory();

        [SetUp]
        public void Setup() {
            _directoryProvider = new DirectoryProvider("test", CurrentDirectory);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateConfigObject_ForNull_Exception() {
            // arrange
            var configObjectBuilder = new ConfigObjectBuilder(_directoryProvider);

            // act
            var configObject = configObjectBuilder.CreateConfigObject(null);
        }

        [Test]
        public void CreateConfigObject_ForGit_CreateObjectWithGit() {
            // arrange
            var configObjectBuilder = new ConfigObjectBuilder(_directoryProvider);
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
            var configObjectBuilder = new ConfigObjectBuilder(_directoryProvider);
            var config = new JobConfigurationModel { Github = new GithubModel { Url = "git://myhost/repo.git", Branch = "master" } };

            // act
            var configObject = configObjectBuilder.CreateConfigObject(config);

            // assert
            Assert.That(configObject.Git.Directory.Value, Is.Not.Null);
            Assert.That(configObject.Git.Directory.Value, Is.EqualTo(_directoryProvider.Source));
        }

        [Test]
        public void CreateConfigObject_ForSolutionIfGitIsDefined_CreateObjectWithSolution() {
            // arrange
            var configObjectBuilder = new ConfigObjectBuilder(_directoryProvider);
            var config = new JobConfigurationModel { Github = new GithubModel { Url = "git://myhost/repo.git", Branch = "master" }, Solution = new SolutionModel { Name = "Test.sln" } };

            // act
            var configObject = configObjectBuilder.CreateConfigObject(config);

            // assert
            Assert.That(configObject.Solution, Is.Not.Null);
            Assert.That(configObject.Solution.SolutionPath.Value, Is.EqualTo(_directoryProvider.Source + "Test.sln"));
        }

        [Test]
        public void CreateConfigObject_ForSolutionIfGitIsNoDefined_CreateObjectWithSolution() {
            // arrange
            var configObjectBuilder = new ConfigObjectBuilder(_directoryProvider);
            var config = new JobConfigurationModel { Solution = new SolutionModel { Name = "Test.sln" } };

            // act
            var configObject = configObjectBuilder.CreateConfigObject(config);

            // assert
            Assert.That(configObject.Solution, Is.Not.Null);
            Assert.That(configObject.Solution.SolutionPath.Value, Is.EqualTo(_directoryProvider.Source + "Test.sln"));
        }
    }
}
