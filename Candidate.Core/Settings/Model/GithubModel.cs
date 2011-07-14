using System.ComponentModel;

namespace Candidate.Core.Settings.Model {
    public class GithubModel {
        [DisplayName("Repository URL")]
        public string Url { get; set; }

        [DisplayName("Branch")]
        public string Branch { get; set; }
    }
}
