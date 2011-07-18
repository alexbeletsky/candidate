using System.ComponentModel;

namespace Candidate.Core.Settings.Model {
    public class SolutionModel {
        [DisplayName("Solution name")]
        public string Name { get; set; }
        [DisplayName("Web project")]
        public string WebProject { get; set; }
    }
}
