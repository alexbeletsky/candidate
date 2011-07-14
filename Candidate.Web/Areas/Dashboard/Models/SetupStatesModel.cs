using System.Collections.Generic;

namespace Candidate.Areas.Dashboard.Models {
    public class SetupStatesModel {
        public SetupStatesModel() {
            States = new List<SetupStateModel>();
        }

        public IList<SetupStateModel> States { get; set; }
    }
}