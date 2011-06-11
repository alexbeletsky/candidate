using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crawler.Core.Crawlers
{
    public class CareersStackoverfowComCrawler : CrawlerImpl, ICrawler
    {
        private string _baseUrl = @"http://careers.stackoverflow.com";
        private string _searchBaseUrl = @"http://careers.stackoverflow.com/Jobs?searchTerm=.net,java,c%2B%2B&searchType=Any&location=&range=20";

        public CareersStackoverfowComCrawler(ILogger logger)
        {
            Logger = logger;
        }

        public void Crawle(IHtmlDocumentLoader loader, ICrawlerRepository context)
        {
            Loader = loader;
            Repository = context;

            StartCrawling();
        }

        protected override string BaseUrl
        {
            get { return _baseUrl; }
        }

        protected override string SearchBaseUrl
        {
            get { return _searchBaseUrl; }
        }

        protected override IEnumerable<HtmlAgilityPack.HtmlNode> GetJobRows(HtmlAgilityPack.HtmlDocument document)
        {
            return document.DocumentNode.Descendants("div").Where(
                r => r.Attributes.Contains("class") && r.Attributes["class"].Value.Contains("listitem"));
        }

        protected override string CreateNextUrl(int nextPage)
        {
            return SearchBaseUrl + "&pg=" + nextPage;
        }

        protected override string GetVacancyUrl(HtmlAgilityPack.HtmlNode row)
        {
            var vacancyHref = row.Descendants("a").Where(
                r => r.Attributes.Contains("class") && r.Attributes["class"].Value.Contains("title"))
                .Select(r => r.Attributes["href"].Value).SingleOrDefault();

            return BaseUrl + vacancyHref;
        }

        protected override string GetVacancyBody(HtmlAgilityPack.HtmlDocument htmlDocument)
        {
            var node = htmlDocument.DocumentNode.SelectSingleNode(@"//*[@id=""description""]");
            return node.InnerText;
        }

        protected override string GetPosition(HtmlAgilityPack.HtmlNode row)
        {
            return row.Descendants("a").Where(
                r => r.Attributes.Contains("class") && r.Attributes["class"].Value.Contains("title"))
                .Select(r => r.InnerText).SingleOrDefault();
        }

        protected override string GetCompany(HtmlAgilityPack.HtmlNode row)
        {
            //could not extract company from a row, skip it, since it not used..
            return "Company";
        }
    }
}
