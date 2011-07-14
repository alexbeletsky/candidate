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
        public void CreateConfigObject_ForNull_CreateEmptyObject() {
            // arrange
            var configObjectBuilder = new ConfigObjectBuilder();

            // act
            var configObject = configObjectBuilder.CreateConfigObject(null);

            // assert
            Assert.That(configObject, Is.Not.Null);
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
        }
    }
}
