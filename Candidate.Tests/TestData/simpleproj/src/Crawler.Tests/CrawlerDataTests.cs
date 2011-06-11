using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Crawler.Core;
using Crawler.Core.Domain;
using System.Transactions;
using Crawler.Core.Model;

namespace Crawler.Tests
{
    /// <summary>
    /// CrawlerDataTests
    /// 
    /// Simple test cases, to check EF4 Code-first features
    /// </summary>
    [TestFixture]
    public class CrawlerDataTests
    {
        private static ICrawlerRepository _context = new CrawlerRepository();

        [TestFixtureSetUp]
        public static void Setup()
        {
            _context.Database.CreateIfNotExists();
        }

        [TestFixtureTearDown]
        public static void TearDown()
        {
            _context.Database.DeleteIfExists();
        }

        [Test]
        public void AddNewRecord()
        {
            //arrange
            var record = new TddDemandRecord
            {
                Company = "xxx",
                Demand = false,
                Site = "http://localhost",
                Technology = "C#"
            };

            //act
            _context.Add(record);
            _context.SaveChanges();

            //assert
            var found = _context.GetByCompanyName("xxx").First();
            Assert.That(found, Is.Not.Null);
        }
    }
}
