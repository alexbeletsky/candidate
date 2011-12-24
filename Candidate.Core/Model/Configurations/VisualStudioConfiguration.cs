
namespace Candidate.Core.Model.Configurations
{
    public class VisualStudioConfiguration : Configuration
    {
        public Pre Pre { get; set; }
        public Github Github { get; set; }
        public Solution Solution { get; set; }
        public Iis Iis { get; set; }
        public Post Post { get; set; }

        public bool IsConfigured()
        {
            return !string.IsNullOrEmpty(Id) && Github != null && Solution != null && Iis != null;
        }
    }
}
