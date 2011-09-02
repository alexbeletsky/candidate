using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Candidate.Areas.Dashboard.Models {
    public class OverviewModel {
        public string LastBuildStatus { get; set; }
        public DateTime LastDeployTime { get; set; }
        public TimeSpan LastDeployDuration { get; set; }

        public IEnumerable<string> Logs { get; set; }
    }
}