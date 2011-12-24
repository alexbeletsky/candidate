namespace Candidate.Core.Model.Configurations
{
    public class XCopyConfiguration : Configuration
    {
        public Github Github { get; set; }
        public Iis Iis { get; set; }
        public XCopy XCopy { get; set; }

        public override string ViewName
        {
            get { return "ConfigureXCopy"; }
        }
    }
}