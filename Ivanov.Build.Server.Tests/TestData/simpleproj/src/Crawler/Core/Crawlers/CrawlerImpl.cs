using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Crawler.Core.Domain;
using Crawler.Core.Matchers;

namespace Crawler.Core.Crawlers
{
    public abstract class CrawlerImpl
    {
        protected abstract string BaseUrl { get; }
        protected abstract string SearchBaseUrl { get; }

        protected IHtmlDocumentLoader Loader { get; set; }
        protected ICrawlerRepository Repository { get; set; }
        protected ILogger Logger { get; set; }

        protected CrawlerImpl()
        {

        }

        protected virtual void CleanUp()
        {
            Logger.Log("removing database records from last crawler run...");
            var records = Repository.GetBySiteName(BaseUrl);
            foreach (var record in records)
            {
                Repository.Delete(record);
            }
            Repository.SaveChanges();
            Logger.Log("all records successfully removed");
        }

        protected virtual void StartCrawling()
        {
            Logger.Log(BaseUrl + " crawler started...");

            CleanUp();

            for (var nextPage = 1; ; nextPage++)
            {
                var url = CreateNextUrl(nextPage);
                var document = Loader.LoadDocument(url);

                Logger.Log("processing page: [" + nextPage.ToString() + "] with url: " + url);

                var rows = GetJobRows(document);
                var rowsCount = rows.Count();

                Logger.Log("extracted " + rowsCount + " vacations on page");
                if (rowsCount == 0)
                {
                    Logger.Log("no more vacancies to process, breaking main loop");
                    break;
                }

                Logger.Log("starting to process all vacancies");
                foreach (var row in rows)
                {
                    Logger.Log("starting processing div, extracting vacancy href...");
                    var vacancyUrl = GetVacancyUrl(row);
                    if (vacancyUrl == null)
                    {
                        Logger.Log("FAILED to extract vacancy href, not stopped, proceed with next one");
                        continue;
                    }

                    Logger.Log("started to process vacancy with url: " + vacancyUrl);
                    var vacancyBody = GetVacancyBody(Loader.LoadDocument(vacancyUrl));
                    if (vacancyBody == null)
                    {
                        Logger.Log("FAILED to extract vacancy body, not stopped, proceed with next one");
                        continue;
                    }

                    var position = GetPosition(row);
                    var company = GetCompany(row);
                    var technology = GetTechnology(position, vacancyBody);
                    var demand = GetDemand(vacancyBody);

                    var record = new TddDemandRecord()
                    {
                        Site = BaseUrl,
                        Company = company,
                        Position = position,
                        Technology = technology,
                        Demand = demand,
                        Url = vacancyUrl
                    };

                    Logger.Log("new record has been created and initialized");
                    Repository.Add(record);
                    Repository.SaveChanges();
                    Logger.Log("record has been successfully stored to database.");
                    Logger.Log("finished to process vacancy");

                }
                Logger.Log("finished to process page");
            }
            Logger.Log(BaseUrl + " crawler has successfully finished");
        }

        protected virtual bool GetDemand(string vacancyBody)
        {
            return MatchToTdd(vacancyBody);
        }

        protected virtual string GetTechnology(string position, string body)
        {
            //2 stage processing.. first we try to match key words from postion name
            //if it is to generic, like "Software developer" try to match key words in vacancy body

            var technology = MatchTechnology(position);

            if (technology == "Other")
            {
                technology = MatchTechnology(body);
            }

            return technology;
        }

        private string MatchTechnology(string position)
        {
            var technology = string.Empty;
            if (MatchToJava(position))
            {
                technology = "Java";
            }
            else if (MatchToCpp(position))
            {
                technology = "Cpp";
            }
            else if (MatchToDotNet(position))
            {
                technology = "DotNet";
            }
            else
            {
                technology = "Other";
            }
            return technology;
        }

        protected bool MatchToTdd(string description)
        {
            return new TddMatcher().Match(description);
        }

        protected bool MatchToJava(string desciption)
        {
            return new JavaMatcher().Match(desciption);
        }

        protected bool MatchToCpp(string desciption)
        {
            return new CppMatcher().Match(desciption);
        }

        protected bool MatchToDotNet(string desciption)
        {
            return new DotNetMatcher().Match(desciption);
        }

        protected abstract IEnumerable<HtmlAgilityPack.HtmlNode> GetJobRows(HtmlAgilityPack.HtmlDocument document);
        protected abstract string CreateNextUrl(int nextPage);
        protected abstract string GetVacancyUrl(HtmlAgilityPack.HtmlNode row);
        protected abstract string GetVacancyBody(HtmlAgilityPack.HtmlDocument htmlDocument);
        protected abstract string GetPosition(HtmlAgilityPack.HtmlNode row);
        protected abstract string GetCompany(HtmlAgilityPack.HtmlNode row);
    }
}
