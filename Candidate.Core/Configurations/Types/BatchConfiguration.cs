using Candidate.Core.Configurations.Parts;
using Candidate.Core.Deploy;

namespace Candidate.Core.Configurations.Types
{
    public class BatchConfiguration : Configuration
    {
        // TODO: ABE add build results folder..
        public BatchConfiguration()
        {
            Github = new Github();
            Iis = new Iis();
            Batch = new Batch();
        }

        public Github Github { get; set; }
        public Iis Iis { get; set; }
        //public Post Batch { get; set; }
        public Batch Batch { get; set; }

        public override string Type
        {
            get { return "Batch";  }
        }

        public override IDeployRunner CreateDeployRunner(Context context)
        {
            return new DeployRunnerFactory(context.DirectoryProvider).ForConfiguration(this);
        }
    }
}