using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bounce.Framework;

namespace Candidate.Core.Configurations.Tasks
{
    internal class StopSiteTask
    {
        private readonly string _siteName;

        public StopSiteTask(string siteName)
        {
            _siteName = siteName;
        }

        public Iis7StoppedSite ToTask()
        {
            return new Iis7StoppedSite
            {
                Name = _siteName,
                Wait = TimeSpan.FromMilliseconds(1000)
            };
        }
    }
}
