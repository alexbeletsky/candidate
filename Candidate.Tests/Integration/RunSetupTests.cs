using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Candidate.Core.Settings.Model;
using Candidate.Core.Setup;
using Bounce.Framework;
using Candidate.Core.System;

namespace Candidate.Tests.Integration {
    [TestFixture]
    public class RunSetupTests {

        [Test]
        public void SetupWithOutGitHub_ShouldBuildAndDeploy() {
            // arrange
            var config = new JobConfigurationModel() {
                Solution = new SolutionModel {
                    Name = "Test.sln"
                },
                Iis = new IisModel {
                    SiteName = "Test"
                }
            };

            var targetsRetriever = new TargetsRetriever();
            var configObjectBuilder = new ConfigObjectBuilder();
            var targetsObjectBuilder = new DefaultTargetsObjectBuilder(targetsRetriever, configObjectBuilder);

            var targetsBuilder = new TargetsBuilder();

            var bounce = BounceFactory.GetBounce();
            var logger = new DummyLogger();

            // act
            var defaultSetup = new DefaultSetup(targetsObjectBuilder, targetsBuilder, bounce, config);
            defaultSetup.Execute(logger);
        }
    }
}
