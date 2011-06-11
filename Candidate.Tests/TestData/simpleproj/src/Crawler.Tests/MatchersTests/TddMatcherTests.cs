using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Crawler.Core.Matchers;

namespace Crawler.Tests.MatchersTests
{
    [TestFixture]
    public class TddMatcherTests
    {
        [Test]
        public void Smoke()
        {
            var matcher = new TddMatcher();

            Assert.That(matcher, Is.Not.Null);
        }

        [Test]
        public void MatchTdd()
        {
            //arrange
            var matcher = new TddMatcher();
            var input = "required skills \r\n c#, asp.net, tdd";
 
            //act
            var result = matcher.Match(input);

            //assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void MatchJUnit()
        {
            //arrange
            var matcher = new TddMatcher();
            var input = "required skills \r\n junit, asp.net, tdd";

            //act
            var result = matcher.Match(input);

            //assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void MatchUnitTests()
        {
            //arrange
            var matcher = new TddMatcher();
            var input = "required skills \r\n unit tests, asp.net";

            //act
            var result = matcher.Match(input);

            //assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void DoesNotMatchUnity()
        {
            //arrange
            var matcher = new TddMatcher();
            var input = "good opportunity";

            //act
            var result = matcher.Match(input);

            //assert
            Assert.That(result, Is.False);

        }

    }
}
