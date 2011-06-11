using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ivanov.Build.Server.Areas.Dashboard.Models
{
    public class JobConfigurationModel
    {
        public JobConfigurationModel()
        {
            Batch = new BatchModel();
        }

        public string JobName { get; set; }
        public BatchModel Batch { get; set; }
    }
}
