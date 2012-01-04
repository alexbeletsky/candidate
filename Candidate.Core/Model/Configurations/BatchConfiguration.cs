using System;
using Candidate.Core.Configurations;
using Candidate.Core.Deploy;
using Candidate.Core.Utils;

namespace Candidate.Core.Model.Configurations
{
    public class BatchConfiguration : Configuration
    {
        // TODO: ABE add build results folder..
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

        public override IDeployRunner CreateDeployRunner(Context context)
        {
            return new DeployRunnerFactory(context.DirectoryProvider).ForConfiguration(this);
        }
    }
}