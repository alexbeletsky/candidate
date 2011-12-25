using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bounce.Framework;

namespace Candidate.Core.Configurations.Tasks
{
    internal class StartSiteTask
    {
        private readonly string _siteName;

        public StartSiteTask(string siteName)
        {
            _siteName = siteName;
        }

        public Iis7StartedSite ToTask()
        {
            return new Iis7StartedSite
            {
                Name = _siteName,
                Wait = TimeSpan.FromMilliseconds(1000)
            };
        }
    }
}
