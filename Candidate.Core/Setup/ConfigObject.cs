using Bounce.Framework;

namespace Candidate.Core.Setup
{
    public class ConfigObject
    {
        public GitCheckout Git { get; set; }
        public VisualStudioSolution Solution { get; set; }
        public NUnitTests Tests { get; set; }
        public Iis7WebSite Website { get; set; }
        public ShellCommand PostBuild { get; set; }
    }
}
