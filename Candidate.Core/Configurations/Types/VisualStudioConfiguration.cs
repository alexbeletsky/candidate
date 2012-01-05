using Candidate.Core.Configurations.Parts;
using Candidate.Core.Deploy;

namespace Candidate.Core.Configurations.Types
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
            get { return "VisualStudio"; }
        }

        public override IDeployRunner CreateDeployRunner()
        {
            return new DeployRunnerFactory().ForConfiguration(this);
        }
    }
}
