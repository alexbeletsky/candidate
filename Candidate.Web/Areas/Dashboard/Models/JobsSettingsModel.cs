using System.Collections.Generic;

namespace Candidate.Areas.Dashboard.Models {
    public class JobsSettingsModel {
        public JobsSettingsModel() {
            Jobs = new List<JobModel>();
        }

        public IList<JobModel> Jobs { get; set; }
    }
}