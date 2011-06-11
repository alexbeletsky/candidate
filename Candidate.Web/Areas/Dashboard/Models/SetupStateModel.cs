using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Candidate.Areas.Dashboard.Models
{
    public class SetupStateModel
    {
        public string JobName { get; set; }
        public bool IsRepoCloned { get; set; }
    }
}