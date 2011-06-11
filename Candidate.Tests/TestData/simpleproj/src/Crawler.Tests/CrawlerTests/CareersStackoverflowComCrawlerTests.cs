using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Crawler.Core;
using Moq;
using Crawler.Core.Crawlers;
using HtmlAgilityPack;
using System.IO;
using Crawler.Core.Domain;

namespace Crawler.Tests.CrawlerTests
{
    [TestFixture]
    public class CareersStackoverflowComCrawlerTests
    {
        private static ILogger _logger = new Mock<ILogger>().Object;

        [Test]
        public void Smoke()
        {
            //arrange
            var crawler = new CareersStackoverfowComCrawler(_logger);

            //act/assert
            Assert.That(crawler, Is.Not.Null);
        }

        [Test]
        public void CrawleOnePage()
        {
            //arrange
            var loader = new Mock<IHtmlDocumentLoader>();
            var context = new Mock<ICrawlerRepository>();
            var crawler = new CareersStackoverfowComCrawler(_logger);

            var document = new HtmlDocument();
            document.Load(new FileStream("TestData/careers/careers.results.htm", FileMode.Open));
            loader.Setup(l => l.LoadDocument("http://careers.stackoverflow.com/Jobs?searchTerm=.net,java,c%2B%2B&searchType=Any&location=&range=20&pg=1")).Returns(document);
            loader.Setup(l => l.LoadDocument("http://careers.stackoverflow.com/Jobs?searchTerm=.net,java,c%2B%2B&searchType=Any&location=&range=20&pg=2")).Returns(new HtmlDocument());
            var vacancy = new HtmlDocument();
            vacancy.Load(new FileStream("TestData/careers/vacancy.htm", FileMode.Open));
            loader.Setup(l => l.LoadDocument(It.IsRegex(@"http://careers.stackoverflow.com/Jobs/(\d+)\?campaign=(\w+)"))).
                Returns(vacancy);

            var storage = new List<TddDemandRecord>();
            context.Setup(c => c.Add(It.IsAny<TddDemandRecord>())).Callback((TddDemandRecord r) => storage.Add(r));

            //act
            crawler.Crawle(loader.Object, context.Object);

            //assert
            context.Verify(c => c.SaveChanges());
            Assert.That(storage.Count, Is.EqualTo(25), "Expected that all 25 jobs processed");

        }
    }
}
