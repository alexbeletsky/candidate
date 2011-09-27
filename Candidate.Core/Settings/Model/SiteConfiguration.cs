
namespace Candidate.Core.Settings.Model {
    public class SiteConfiguration {        
        public string JobName { get; set; }
        
        public GitHub Github { get; set; }
        public Solution Solution { get; set; }
        public Iis Iis { get; set; }
        public Post Post { get; set; }

        public bool IsConfigured() {
            return !string.IsNullOrEmpty(JobName) && Github != null && Solution != null && Iis != null;
        }

        /// <summary>
        /// Accepts the specified node visitor.
        /// </summary>
        /// <param name="nodeVisitor">The node visitor.</param>
        public void Accept(SiteConfigurationNodeVisitor nodeVisitor)
        {
            nodeVisitor.Visit(this);

            if (Github != null) {
                Github.Accept(nodeVisitor);
            }

            if (Solution != null) {
                Solution.Accept(nodeVisitor);
            }

            if (Iis != null) {
                Iis.Accept(nodeVisitor);
            }

            if (Post != null) {
                Post.Accept(nodeVisitor);
            }
        }
    }
}
