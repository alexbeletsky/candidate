using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Candidate.Core.Settings.Model;
using Candidate.Core.Setup;

namespace Candidate.Tests.Setup {
    [TestFixture]
    public class BounceTargetsBuilderTests {
        [Test]
        public void DefaultBounceTargetsBuilder() {
            // arrange
            var config = new JobConfigurationModel();

            //act
            var targetsBuilder = new DefaultBounceTargetsBuilder();
        }

        [Test]
        public void CreateTargets_GitSettingsSet_GitTargetCreate() {
            // arrange
            var config = new JobConfigurationModel { Github = new GithubModel { Url = "git://myhost/repo.git", Branch = "master" } };
            var targetsBuilder = new DefaultBounceTargetsBuilder();

            // act 
            var targets = targetsBuilder.BuildTargetsFromConfig(config);
            
            // assert
            Assert.That(targets.Count(), Is.EqualTo(1));
        }

    }
}
