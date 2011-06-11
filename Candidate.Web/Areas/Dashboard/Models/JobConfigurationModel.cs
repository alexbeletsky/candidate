using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candidate.Areas.Dashboard.Models
{
    public class JobConfigurationModel
    {
        //public JobConfigurationModel()
        //{
        //    Batch = new BatchModel();
        //}

        public string JobName { get; set; }
        //public BatchModel Batch { get; set; }
        public GithubModel Github { get; set; }
    }
}
