using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crawler.Core.Domain;
using System.Text.RegularExpressions;
using Crawler.Core.Matchers;

namespace Crawler.Core.Crawlers
{
    public class RabotaUaCrawler : CrawlerImpl, ICrawler
    {
        private string _baseUrl = @"http://rabota.ua";
        private string _searchBaseUrl = @"http://rabota.ua/jobsearch/vacancy_list?rubricIds=8,9&keyWords=&parentId=1";

        public RabotaUaCrawler(ILogger logger)
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
            var vacancyDivs = document.DocumentNode.Descendants("div")
                .Where(d =>
                    d.Attributes.Contains("class") &&
                    d.Attributes["class"].Value.Contains("vacancyitem"));
            return vacancyDivs;
        }

        protected override string GetVacancyUrl(HtmlAgilityPack.HtmlNode div)
        {
            var vacancyHref = div.Descendants("a").Where(
                d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("vacancyDescription"))
                .Select(d => d.Attributes["href"].Value).SingleOrDefault();
            return BaseUrl + vacancyHref;
        }

        private static string GetVacancyHref(HtmlAgilityPack.HtmlNode div)
        {
            var vacancyHref = div.Descendants("a").Where(
                d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("vacancyDescription"))
                .Select(d => d.Attributes["href"].Value).SingleOrDefault();
            return vacancyHref;
        }

        protected override string CreateNextUrl(int nextPage)
        {
            return SearchBaseUrl + "&pg=" + nextPage;
        }

        protected override string GetVacancyBody(HtmlAgilityPack.HtmlDocument vacancyPage)
        {
            if (vacancyPage == null)
            {
                //TODO: log event here and skip this page
                return null;
            }

            var description = vacancyPage.DocumentNode.Descendants("div")
                .Where(
                    d => d.Attributes.Contains("id") && d.Attributes["id"].Value.Contains("ctl00_centerZone_vcVwPopup_pnlBody"))
                .Select(d => d.InnerHtml).SingleOrDefault();
            return description;
        }


        protected override string GetPosition(HtmlAgilityPack.HtmlNode div)
        {
            return div.Descendants("a").Where(
               d => d.Attributes.Contains("class") &&
               d.Attributes["class"].Value.Contains("vacancyName") || d.Attributes["class"].Value.Contains("jqKeywordHighlight")
               ).Select(d => d.InnerText).First();
        }

        protected override string GetCompany(HtmlAgilityPack.HtmlNode div)
        {
            return div.Descendants("div").Where(
                d => d.Attributes.Contains("class") &&
                d.Attributes["class"].Value.Contains("companyName")).Select(d => d.FirstChild.InnerText).First();
        }
    }
}
