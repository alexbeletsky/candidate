using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Candidate.Core.Settings.Model;
using Candidate.Core.Setup;
using Moq;
using Bounce.Framework;

namespace Candidate.Tests.Setup {
    [TestFixture]
    public class DefaultTargetsObjectBuilderTests {
        [Test]
        public void DefaultBounceTargetsBuilder() {
            // arrange
            var targetsRetrieverMock = new Mock<ITargetsRetriever>();
            var configObjectBuilderMock = new Mock<IConfigObjectBuilder>();
            var config = new JobConfigurationModel();

            //act
            var targetsBuilder = new DefaultTargetsObjectBuilder(targetsRetrieverMock.Object, configObjectBuilderMock.Object);
        }

        [Test]
        public void BuildTargetsFromConfig_ConfigObjectCreated_TargetsCreated() {
            // arrange
            var config = new JobConfigurationModel { Github = new GithubModel { Url = "git://myhost/repo.git", Branch = "master" } };
            var targetsRetrieverMock = new Mock<ITargetsRetriever>();
            var configObjectBuilderMock = new Mock<IConfigObjectBuilder>();
            var targetsBuilder = new DefaultTargetsObjectBuilder(targetsRetrieverMock.Object, configObjectBuilderMock.Object);

            targetsRetrieverMock.Setup(_ => _.GetTargetsFromObject(It.IsAny<object>())).Returns(new Dictionary<string, ITask>());

            //act
            var targets = targetsBuilder.BuildTargetsFromConfig(config);

            // assert
            configObjectBuilderMock.Verify(_ => _.CreateConfigObject(config));
            targetsRetrieverMock.Verify(_ => _.GetTargetsFromObject(It.IsAny<object>()));
        }

    }
}
