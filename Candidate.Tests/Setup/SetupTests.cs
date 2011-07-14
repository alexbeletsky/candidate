using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Candidate.Core.Setup;
using Candidate.Core.Settings.Model;

namespace Candidate.Tests.Setup {
    [TestFixture]
    public class SetupTests {
        [Test]
        public void DefaultSetup() {
            // arrange
            var config = new JobConfigurationModel();
            var setup = new DefaultSetup(config);
        }
    }
}
