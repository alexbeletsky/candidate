using System;
using System.Collections.Generic;

namespace Candidate.Areas.Dashboard.Models
{
    public class OverviewModel
    {
        public string Id { get; set; }
        public string LastBuildStatus { get; set; }
        public DateTime LastDeployTime { get; set; }
        public TimeSpan LastDeployDuration { get; set; }

        public IEnumerable<string> Logs { get; set; }
    }
}