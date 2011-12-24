namespace Candidate.Core.Model.Configurations
{
    public class XCopyConfiguration : Configuration
    {
        public XCopyConfiguration()
        {
            Github = new Github();
            Iis = new Iis();
            XCopy = new Post();
        }

        public Github Github { get; set; }
        public Iis Iis { get; set; }
        public Post XCopy { get; set; }

        public override string ViewName
        {
            get { return "ConfigureXCopy"; }
        }
    }
}