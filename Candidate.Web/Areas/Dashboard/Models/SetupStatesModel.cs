using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Candidate.Areas.Dashboard.Models
{
    public class SetupStatesModel
    {
        public SetupStatesModel()
        {
            States = new List<SetupStateModel>();
        }

        public IList<SetupStateModel> States { get; set; }
    }
}