
using Candidate.Core.Deploy;

namespace Candidate.Core.Model.Configurations
{
    public class VisualStudioConfiguration : Configuration
    {
        public VisualStudioConfiguration()
        {
            Github = new Github();
            Solution = new Solution();
            Iis = new Iis();
        }

        public Github Github { get; set; }
        public Solution Solution { get; set; }
        public Iis Iis { get; set; }

        public override string Type
        {
            get { return "visualstudio"; }
        }

        public override IDeployRunner CreateDeployRunner()
        {
            throw new System.NotImplementedException();
        }
    }
}
