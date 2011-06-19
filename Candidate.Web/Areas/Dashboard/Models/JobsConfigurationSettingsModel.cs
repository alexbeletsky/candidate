using System.Collections.Generic;

namespace Candidate.Areas.Dashboard.Models
{
    public class JobsConfigurationSettingsModel
    {
        public JobsConfigurationSettingsModel()
        {
            Configurations = new List<JobConfigurationModel>();
        }

        public IList<JobConfigurationModel> Configurations { get; set; }
    }
}
