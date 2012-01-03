using Candidate.Core.Deploy;

namespace Candidate.Core.Model.Configurations
{
    public class XCopyConfiguration : Configuration
    {
        public XCopyConfiguration()
        {
            Github = new Github();
            Iis = new Iis();
        }

        public Github Github { get; set; }
        public Iis Iis { get; set; }

        public override string Type
        {
            get { return "xcopy"; }
        }

        public override IDeployRunner CreateDeployRunner()
        {
            throw new System.NotImplementedException();
        }
    }
}