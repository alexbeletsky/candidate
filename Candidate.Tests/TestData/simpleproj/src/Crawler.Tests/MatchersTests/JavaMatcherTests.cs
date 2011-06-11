using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Crawler.Core.Matchers;

namespace Crawler.Tests.MatchersTests
{
    [TestFixture]
    public class JavaMatcherTests
    {
        [Test]
        public void Smoke()
        {
            var matcher = new JavaMatcher();

            Assert.That(matcher, Is.Not.Null);
        }

        [Test]
        public void MatchJava()        
        {
            //arrange
            var matcher = new JavaMatcher();
            var input = "required skills java";

            //act
            var result = matcher.Match(input);
            
            //post
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void MatchJava2()
        {
            //arrange
            var matcher = new JavaMatcher();
            var input = "java is required";

            //act
            var result = matcher.Match(input);

            //post
            Assert.That(result, Is.True);
        }

        [Test]
        public void DoesNotMatchJavascript()
        {
            //arrange
            var matcher = new JavaMatcher();
            var input = @"<script type=""text\javascript""><script/>";

            //act
            var result = matcher.Match(input);

            //post
            Assert.That(result, Is.False);
        }


    }
}
