using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Crawler.Core;
using Crawler.Core.Model;

namespace Crawler.Tests
{
    [TestFixture]
    public class HtmlDocumentLoaderTests
    {
        [Test]
        public void Smoke()
        {
            //arrange
            var loader = new HtmlDocumentLoader();

            //act/assert
            Assert.That(loader, Is.Not.Null);
        }

        [Test]
        public void LoadDocument()
        {
            //arrange
            var loader = new HtmlDocumentLoader();

            //act
            var document = loader.LoadDocument(@"http://cnn.com");

            //post
            Assert.That(document, Is.Not.Null);
        }

    }
}
