using Bounce.Framework;

namespace Candidate.Core.Configurations.Bounce
{
    public class VisualStudioBounceConfiguration
    {
        public GitCheckout CheckoutSources { get; set; }
        public VisualStudioSolution BuildSolution { get; set; }
        public NUnitTests RunTests { get; set; }
        public Iis7StoppedSite StopSiteBeforeDeployment { get; set; }
        public Copy CopyToDestination { get; set; }
        public Iis7WebSite DeployWebsite { get; set; }
        public Iis7StartedSite StartSiteAfterDeployment { get; set; }
    }
}