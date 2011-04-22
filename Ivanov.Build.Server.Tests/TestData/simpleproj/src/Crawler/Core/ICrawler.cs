using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crawler.Core
{
    public interface ICrawler
    {
        void Crawle(IHtmlDocumentLoader loader, ICrawlerRepository context);
    }
}
