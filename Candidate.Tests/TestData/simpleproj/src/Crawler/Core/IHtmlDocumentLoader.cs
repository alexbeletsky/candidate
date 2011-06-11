using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace Crawler.Core
{
    public interface IHtmlDocumentLoader
    {
        HtmlDocument LoadDocument(string url);
        //{
        //    return HtmlDocumentUtils.LoadDocument(url);
        //}
    }
}
