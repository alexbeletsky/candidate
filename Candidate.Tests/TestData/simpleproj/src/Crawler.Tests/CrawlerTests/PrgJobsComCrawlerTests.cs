using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Crawler.Core.Crawlers;
using Moq;
using Crawler.Core;
using HtmlAgilityPack;
using System.IO;
using Crawler.Core.Domain;

namespace Crawler.Tests.CrawlerTests
{
    [TestFixture]
    public class PrgJobsComCrawlerTests
    {
        private static ILogger _logger = new Mock<ILogger>().Object;

        [Test]
        public void Smoke()
        {
            //arrange
            var crawler = new PrgJobsComCrawler(_logger);

            //act/assert
            Assert.That(crawler, Is.Not.Null);
        }

        [Test]
        public void CrawleOnePage()
        {
            //arrange
            var loader = new Mock<IHtmlDocumentLoader>();
            var context = new Mock<ICrawlerRepository>();
            var crawler = new PrgJobsComCrawler(_logger);

            var document = new HtmlDocument();
            document.Load(new FileStream("TestData/prgjobscom/search.results.htm", FileMode.Open));
            loader.Setup(l => l.LoadDocument("http://www.prgjobs.com/jobout.cfm?ApplicantSearchArea=&SearchText=&Page=1")).Returns(document);
            loader.Setup(l => l.LoadDocument("http://www.prgjobs.com/jobout.cfm?ApplicantSearchArea=&SearchText=&Page=2")).Returns(new HtmlDocument());
            var vacancy = new HtmlDocument();
            vacancy.Load(new FileStream("TestData/prgjobscom/dnet.withtdd.htm", FileMode.Open));
            loader.Setup(l => l.LoadDocument(It.IsRegex(@"http://www.prgjobs.com/Job.cfm/\d+"))).
                Returns(vacancy);

            var storage = new List<TddDemandRecord>();
            context.Setup(c => c.Add(It.IsAny<TddDemandRecord>())).Callback((TddDemandRecord r) => storage.Add(r));

            //act
            crawler.Crawle(loader.Object, context.Object);

            //assert
            context.Verify(c => c.SaveChanges());
            Assert.That(storage.Count, Is.EqualTo(50), "Expected that all 50 jobs processed");
        }
    }
}
