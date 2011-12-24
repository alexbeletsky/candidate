using System.Collections.Generic;
using Bounce.Framework;
using Candidate.Core.Model;
using Candidate.Core.Model.Configurations;
using Candidate.Core.Setup;
using Moq;
using NUnit.Framework;

namespace Candidate.Tests.Setup
{
    [TestFixture]
    public class DefaultTargetsObjectBuilderTests
    {
        [Test]
        public void DefaultBounceTargetsBuilder()
        {
            // arrange
            var targetsRetrieverMock = new Mock<ITargetsRetriever>();
            var configObjectBuilderMock = new Mock<IConfigObjectBuilder>();
            var config = new VisualStudioConfiguration();

            //act
            var targetsBuilder = new DefaultTargetsObjectBuilder(targetsRetrieverMock.Object, configObjectBuilderMock.Object);
        }

        [Test]
        public void BuildTargetsFromConfig_ConfigObjectCreated_TargetsCreated()
        {
            // arrange
            var config = new VisualStudioConfiguration { Github = new Github { Url = "git://myhost/repo.git", Branch = "master" } };
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
