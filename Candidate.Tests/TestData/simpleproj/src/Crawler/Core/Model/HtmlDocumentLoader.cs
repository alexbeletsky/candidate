using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;

namespace Crawler.Core.Model
{
    public class HtmlDocumentLoader : IHtmlDocumentLoader
    {
        private WebRequest CreateRequest(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = 5000; 
            request.UserAgent = @"Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.1.5) Gecko/20091102 Firefox/3.5.5";
            return request;
        }

        public HtmlAgilityPack.HtmlDocument LoadDocument(string url)
        {
            var document = new HtmlAgilityPack.HtmlDocument();

            try
            {
                using (var responseStream = CreateRequest(url).GetResponse().GetResponseStream())
                {
                    document.Load(responseStream, Encoding.UTF8);
                }
            }
            catch(Exception ) 
            {
                //just do a second try
                Thread.Sleep(1000);
                using (var responseStream = CreateRequest(url).GetResponse().GetResponseStream())
                {
                    document.Load(responseStream, Encoding.UTF8);
                }
            }

            return document;
        }
    }
}
