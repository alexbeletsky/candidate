using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Candidate.Areas.Dashboard.Models
{
    public class BatchModel
    {
        public string BuildBatchName { get; set; }
        public string TestBatchName { get; set; }
        public string DeployBatchName { get; set; }
    }
}