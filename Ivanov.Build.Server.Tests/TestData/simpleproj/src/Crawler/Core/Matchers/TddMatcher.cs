using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crawler.Core.Matchers
{
    public class TddMatcher : IMatcher
    {
        private static IList<string> _patterns = new List<string>()
            {
                "tdd",
                "junit",
                "nunit",
                "xunit",
                "unit",
                "test driven",
                "unit test",
                "unit tests",
                "unit testing",
                "cppunit",
                "development by tests",
            };

        
        public bool Match(string input)
        {
            return MatchUtil.Match(input, _patterns);
        }
    }
}
