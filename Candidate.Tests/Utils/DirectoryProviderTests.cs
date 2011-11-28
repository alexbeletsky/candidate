using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Candidate.Core.Utils;

namespace Candidate.Tests.Utils {
    [TestFixture]
    public class DirectoryProviderTests {
        [Test]
        public void DefaultContruction_RootIsSet() {
            // arrange
            var provider = new DirectoryProvider();  
  
            // assert
            Assert.That(provider.Root, Is.Not.Empty);
        }

        [Test]
        public void JobName_GetValue_RetunsValueAfterBeingSet() {
            // arrange
            var provider = new DirectoryProvider();

            // act
            provider.SiteName = "currentJob";

            // assert
            Assert.That(provider.SiteName, Is.EqualTo("currentJob"));
        }
    }
}
