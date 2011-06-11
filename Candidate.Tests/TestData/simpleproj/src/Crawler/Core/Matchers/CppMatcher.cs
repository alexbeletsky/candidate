using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crawler.Core.Matchers
{
    public class CppMatcher : IMatcher
    {
        private static IList<string> _patterns = new List<string>()
            {
                "c\\+\\+",
                "cpp",
                "stl",
                "cppunit"
            };

        public bool Match(string input)
        {
            return MatchUtil.Match(input, _patterns);
        }
    }
}
