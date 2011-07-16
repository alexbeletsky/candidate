using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Candidate.Core.Setup;
using Candidate.Core.Settings.Model;

namespace Candidate.Tests.Setup {
    [TestFixture]
    public class ConfigObjectBuilderTests {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateConfigObject_ForNull_Exception() {
            // arrange
            var configObjectBuilder = new ConfigObjectBuilder();

            // act
            var configObject = configObjectBuilder.CreateConfigObject(null);
        }

        [Test]
        public void CreateConfigObject_ForGit_CreateObjectWithGit() {
            // arrange
            var configObjectBuilder = new ConfigObjectBuilder();
            var config = new JobConfigurationModel { Github = new GithubModel { Url = "git://myhost/repo.git", Branch = "master" } };
            
            // act
            var configObject = configObjectBuilder.CreateConfigObject(config);

            // assert
            Assert.That(configObject.Git, Is.Not.Null);
            Assert.That(configObject.Git.Repository.Value, Is.EqualTo("git://myhost/repo.git"));
        }

        [Test]
        public void CreateConfigObject_ForSolution_CreateObjectWithSolution() {
            // arrange
            var configObjectBuilder = new ConfigObjectBuilder();
            var config = new JobConfigurationModel { Github = new GithubModel { Url = "git://myhost/repo.git", Branch = "master" }, Solution = new SolutionModel { Name = "Test.sln" } };

            // act
            var configObject = configObjectBuilder.CreateConfigObject(config);

            // assert
            Assert.That(configObject.Solution, Is.Not.Null);
            Assert.That(configObject.Solution.SolutionPath.Value, Is.EqualTo("Test.sln"));
        }
    }
}
