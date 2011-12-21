
namespace Candidate.Core.Settings.Model
{
    public class SiteConfiguration
    {
        public string JobName { get; set; }
        public string JobDisplayName { get; set; }

        public Pre Pre { get; set; }
        public GitHub Github { get; set; }
        public Solution Solution { get; set; }
        public Iis Iis { get; set; }
        public Post Post { get; set; }

        public bool IsConfigured()
        {
            return !string.IsNullOrEmpty(JobName) && Github != null && Solution != null && Iis != null;
        }
    }
}
