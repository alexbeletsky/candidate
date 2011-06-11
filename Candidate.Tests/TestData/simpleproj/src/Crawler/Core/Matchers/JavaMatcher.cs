using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crawler.Core.Matchers
{
    public class JavaMatcher : IMatcher
    {
        private static IList<string> _patterns = new List<string>()
            {
                "java",
                "j2ee",
                "jwt",
                "jsp"
            };

        public bool Match(string input)
        {
            return MatchUtil.Match(input, _patterns);
        }
    }
}
