using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Crawler.Core.Matchers;

namespace Crawler.Tests.MatchersTests
{
    [TestFixture]
    public class DotNetMatcherTests
    {
        [Test]
        public void Smoke()
        {
            //arrange
            var matcher = new DotNetMatcher();

            //act/assert
            Assert.That(matcher, Is.Not.Null);
        }

        [Test]
        public void MatchDotNet()
        {
            //arrange
            var matcher = new DotNetMatcher();
            var input = "required skill .net";

            //act
            var result = matcher.Match(input);

            //post
            Assert.That(result, Is.True);
        }

        [Test]
        public void MatchCSharp()
        {
            //arrange
            var matcher = new DotNetMatcher();
            var input = "required skill c#";

            //act
            var result = matcher.Match(input);

            //post
            Assert.That(result, Is.True);
        }

        [Test]
        public void MatchVb()
        {
            //arrange
            var matcher = new DotNetMatcher();
            var input = "required skill vb.net";

            //act
            var result = matcher.Match(input);

            //post
            Assert.That(result, Is.True);
        }

        [Test]
        public void MatchDotNetUppercase()
        {
            //arrange
            var matcher = new DotNetMatcher();
            var input = ".Net developer";

            //act
            var result = matcher.Match(input);

            //post
            Assert.That(result, Is.True);
        }

        [Test]
        public void OneMoreMatch()
        {
            //arrange
            var matcher = new DotNetMatcher();
            var input = "Senior C# / .NET Developer";

            //act
            var result = matcher.Match(input);

            //post
            Assert.That(result, Is.True);
        }

    }
}
