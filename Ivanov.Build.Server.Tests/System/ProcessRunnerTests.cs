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
            using (var logger = new Logger("output.log"))
            {
                var processRunner = new ProcessRunner(logger, @".\..\..\TestData\simplebat");

                // act
                processRunner.Run(@".\..\..\TestData\simplebat\run.bat");
            }
        }

        [Test]
        public void Smoke2()
        {
            // arrange
            using (var logger = new Logger("output.log"))
            {
                var processRunner = new ProcessRunner(logger, @"D:\Development\Projects\ivanov.build.server\Ivanov.Build.Server.Tests\TestData\simpleproj\");

                // act
                processRunner.Run(@"build.bat");
            }
        }
    }
}
