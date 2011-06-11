using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Crawler.Core;
using Crawler.Core.Model;
using Crawler.Core.Crawlers;

namespace Crawler
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new ConsoleLogger();
            try
            {
                var loader = new HtmlDocumentLoader();
                var repository = new CrawlerRepository();
                //var crawler = new RabotaUaCrawler(logger);
                //var crawler = new PrgJobsComCrawler(logger);
                var crawler = new CareersStackoverfowComCrawler(logger);

                crawler.Crawle(loader, repository);
            }
            catch (Exception e)
            {
                logger.Log("FAILED exception caught in Main() method. Exception message: " + e.Message);
                logger.Log(e.InnerException.Message);
                logger.Log(e.StackTrace);
            }
        }
    }
}
