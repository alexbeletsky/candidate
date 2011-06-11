using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crawler.Core.Matchers
{
    public class DotNetMatcher : IMatcher
    {
        private static IList<string> _patterns = new List<string>()
        {
            "c#",
            "vb\\.net",
            "\\.net",
            "dot net",
            "asp\\.net",
            "ado\\.net"
        };

        public bool Match(string input)
        {
            return MatchUtil.Match(input, _patterns);
        }
    }
}
