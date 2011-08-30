using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Candidate.Core.Settings.Model;
using Candidate.Core.Utils;
using SharpTestsEx;

namespace Candidate.Tests.Utils {
    [TestFixture]
    public class SiteConfigurationExtentionsTests {
        [Test]
        public void GetSiteUrl_SiteWithOutPort() {
            // arrange
            var iis = new Iis { SiteName = "xxx.com" };
 
            // act
            var result = iis.GetSiteUrl();

            // assert
            result.Should().Be("http://xxx.com");
        }

        [Test]
        public void GetSiteUrl_SiteWithPort() {
            // arrange
            var iis = new Iis { SiteName = "xxx.com", Port = 8080 };

            // act
            var result = iis.GetSiteUrl();

            // assert
            result.Should().Be("http://xxx.com:8080");
        }
    }
}
