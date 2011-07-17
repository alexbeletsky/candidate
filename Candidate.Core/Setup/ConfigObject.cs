using Bounce.Framework;

namespace Candidate.Core.Setup {
    public class ConfigObject {
        public GitCheckout Git { get; set; }
        public VisualStudioSolution Solution { get; set; }
        public Iis7WebSite WebSite { get; set; }
    }
}
