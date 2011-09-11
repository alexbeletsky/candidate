using System.ComponentModel;
using System.Collections.Generic;

namespace Candidate.Core.Settings.Model {
    public class Solution {
        public Solution() {
            Targets = new Dictionary<int, string> {
                { 0, "Build" },
                { 1, "Rebuild"}
            };

            Configurations = new Dictionary<int, string> {
                { 0, "Debug" },
                { 1, "Release" }
            };
        }

        [DisplayName("Solution name")]
        public string Name { get; set; }
        
        [DisplayName("Web project")]
        public string WebProject { get; set; }

        [DisplayName("Targets")]
        public IDictionary<int, string> Targets { get; set; }

        public int SelectedTarget { get; set; }

        [DisplayName("Configurations")]
        public IDictionary<int, string> Configurations { get; set; }

        public int SelectedConfiguration { get; set; }
        
        [DisplayName("Run tests?")]
        public bool IsRunTests { get; set; }
    }
}
