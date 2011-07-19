using System.ComponentModel;

namespace Candidate.Core.Settings.Model {
    public class Solution {
        [DisplayName("Solution name")]
        public string Name { get; set; }
        [DisplayName("Web project")]
        public string WebProject { get; set; }
    }
}
