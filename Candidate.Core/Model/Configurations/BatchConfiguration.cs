namespace Candidate.Core.Model.Configurations
{
    public class BatchConfiguration : Configuration
    {
        public Github Github { get; set; }
        public Iis Iis { get; set; }
        public Post Post { get; set; }

        public override string ViewName
        {
            get { return "ConfigureBatch"; }
        }
    }
}