namespace Candidate.Core.Model.Configurations
{
    public class BatchConfiguration : Configuration
    {
        public BatchConfiguration()
        {
            Github = new Github();
            Iis = new Iis();
            Post = new Post();
        }

        public Github Github { get; set; }
        public Iis Iis { get; set; }
        public Post Post { get; set; }

        public override string Type
        {
            get { return "batch";  }
        }

        public override string ViewName
        {
            get { return "ConfigureBatch"; }
        }
    }
}