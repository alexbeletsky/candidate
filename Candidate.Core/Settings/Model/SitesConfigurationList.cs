using System.Collections.Generic;

namespace Candidate.Core.Settings.Model {
    public class SitesConfigurationList {
        public SitesConfigurationList() {
            Configurations = new List<SiteConfiguration>();
        }

        public IList<SiteConfiguration> Configurations { get; set; }
    }
}
