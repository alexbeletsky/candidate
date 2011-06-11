using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ivanov.Build.Server.Areas.Dashboard.Models
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
