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
        [ExpectedException]
        public void JobName_IfNotSet_Exception() {
            // arrange
            var provider = new DirectoryProvider();  

            // act
            var job = provider.SiteName;
        }

        [Test]
        [ExpectedException]
        public void JobDirectory_CoundNotBeGet_WithoutSettingJobName() {
            // arrange
            var provider = new DirectoryProvider();

            // act
            var job = provider.Site;
        }

        [Test]
        [ExpectedException]
        public void SourceDirectory_CoundNotBeGet_WithoutSettingJobName() {
            // arrange
            var provider = new DirectoryProvider();

            // act
            var job = provider.Sources;
        }

        [Test]
        [ExpectedException]
        public void LogsDirectory_CoundNotBeGet_WithoutSettingJobName() {
            // arrange
            var provider = new DirectoryProvider();

            // act
            var job = provider.Logs;
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
