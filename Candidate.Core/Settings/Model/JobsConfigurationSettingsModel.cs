using System.Collections.Generic;

namespace Candidate.Core.Settings.Model {
    public class JobsConfigurationSettingsModel {
        public JobsConfigurationSettingsModel() {
            Configurations = new List<JobConfigurationModel>();
        }

        public IList<JobConfigurationModel> Configurations { get; set; }
    }
}
