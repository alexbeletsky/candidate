using Candidate.Core.Configurations.Parts;
using Candidate.Core.Deploy;

namespace Candidate.Core.Configurations.Types
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
            get { return "XCopy"; }
        }

        public override IDeployRunner CreateDeployRunner(Context context)
        {
            return new DeployRunnerFactory(context.DirectoryProvider).ForConfiguration(this);
        }
    }
}