using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crawler.Core.Domain;
using Crawler.Core.Matchers;

namespace Crawler.Core.Crawlers
{
    public class PrgJobsComCrawler : CrawlerImpl, ICrawler
    {
        private string _baseUrl = @"http://www.prgjobs.com/";
        private string _searchBaseUrl = @"http://www.prgjobs.com/jobout.cfm?ApplicantSearchArea=&SearchText=";

        public PrgJobsComCrawler(ILogger logger)
        {
            Logger = logger;
        }
        
        public void Crawle(IHtmlDocumentLoader loader, ICrawlerRepository context)
        {
            Loader = loader;
            Repository = context;

            StartCrawling();
        }

        protected override string GetVacancyBody(HtmlAgilityPack.HtmlDocument htmlDocument)
        {
            var node = htmlDocument.DocumentNode.SelectSingleNode("/html/body/div/center/table/tr[2]/td/div/table/tr[1]/td/p/font");
            return node.InnerText;
        }

        protected override string GetPosition(HtmlAgilityPack.HtmlNode row)
        {
            return row.Descendants("td").ElementAt(1).Descendants("a").Single().InnerText;
        }

        protected override string GetCompany(HtmlAgilityPack.HtmlNode row)
        {
            return row.Descendants("td").ElementAt(2).Descendants("em").Single().InnerText;
        }

        protected override string GetVacancyUrl(HtmlAgilityPack.HtmlNode row)
        {
            return row.Descendants("td").ElementAt(1).Descendants("a").Single().Attributes["href"].Value;
        }

        protected override IEnumerable<HtmlAgilityPack.HtmlNode> GetJobRows(HtmlAgilityPack.HtmlDocument document)
        {
            var table = document.DocumentNode.Descendants("table").ElementAtOrDefault(2);
            if (table == null)
            {
                return new List<HtmlAgilityPack.HtmlNode>();
            }

            var rows = table.Descendants("tr")
                .Where(r => r.ChildNodes.Count > 3);
            return rows;
        }

        protected override string CreateNextUrl(int nextPage)
        {
            return SearchBaseUrl + "&Page=" + nextPage;
        }

        protected override string BaseUrl
        {
            get { return _baseUrl; }
        }

        protected override string SearchBaseUrl
        {
            get { return _searchBaseUrl; }
        }
    }
}
