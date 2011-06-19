using System.ComponentModel;

namespace Candidate.Areas.Dashboard.Models
{
    public class GithubModel
    {
        [DisplayName("Repository URL")]
        public string Url { get; set; }

        [DisplayName("Branch")]
        public string Branch { get; set; }
    }
}
