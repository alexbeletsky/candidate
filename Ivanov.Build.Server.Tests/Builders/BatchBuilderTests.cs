using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Ivanov.Build.Server.Core.Builders;
using Moq;
using Ivanov.Build.Server.Core.System;

namespace Ivanov.Build.Server.Tests.Builders
{
    [TestFixture]
    public class BatchBuilderTests
    {
        [Test]
        public void Build_WithPathToBatch_ProcessRunnerInvoked()
        {
            // arrange
            var pathToBatch = "./workspace/job/build.bat";
            var processRunnerMock = new Mock<IProcessRunner>();
            var builder = new BatchBuilder(processRunnerMock.Object, pathToBatch);

            // act
            builder.Build();

            // assert
            processRunnerMock.Verify(p => p.Run(pathToBatch));
        }
    }
}
