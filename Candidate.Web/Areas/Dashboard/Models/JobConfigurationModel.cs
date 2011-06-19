
namespace Candidate.Areas.Dashboard.Models
{
    public class JobConfigurationModel
    {
        public string JobName { get; set; }
        public GithubModel Github { get; set; }
        public IisModel Iis { get; set; }
    }
}
