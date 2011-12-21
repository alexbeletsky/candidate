using Bounce.Framework;

namespace Candidate.Core.Setup
{
    // NOTE: the order of properties matters here, Bounce is using them as declared
    // this order should reflect actual build process
    public class ConfigObject
    {
        public GitCheckout CheckoutSources { get; set; }
        public ShellCommand PreBuildBatch { get; set; }    
        public VisualStudioSolution BuildSolution { get; set; }
        public NUnitTests RunTests { get; set; }
        public ShellCommand PostBuildBatch { get; set; }     
        public Iis7WebSite DeployWebsite { get; set; }
    }
}
