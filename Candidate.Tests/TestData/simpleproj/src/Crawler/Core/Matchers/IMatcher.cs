using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crawler.Core.Matchers
{
    public interface IMatcher
    {
        bool Match(string input);
    }
}
