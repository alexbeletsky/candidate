namespace Candidate.Core.Settings.Model.Configurations
{
    public class BatchConfiguration : Configuration
    {
        public Github Github { get; set; }
        public Iis Iis { get; set; }
        public Post Post { get; set; }
    }
}