using Bounce.Framework;

namespace Candidate.Core.Configurations.Bounce
{
    public class XCopyBounceConfiguration
    {
        public GitCheckout CheckoutSources { get; set; }
        public Iis7StoppedSite StopSiteBeforeDeployment { get; set; }
        public Copy CopyToDestination { get; set; }
        public Iis7WebSite DeployWebsite { get; set; }
        public Iis7StartedSite StartSiteAfterDeployment { get; set; }
    }
}