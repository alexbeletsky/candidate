using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Ivanov.Build.Server.Core.System;

namespace Ivanov.Build.Server.Tests.System
{
    [TestFixture]
    public class ProcessRunnerTests
    {
        [Test]
        public void Smoke()
        {
            // arrange
            var processRunner = new ProcessRunner();

            // act
            processRunner.Run(@".\..\..\TestData\run.bat");
        }
    }
}
