using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Candidate.Core.Settings.Model {
    public class GitHub {
        /// <summary>
        /// Accepts the specified node visitor and passes control to it
        /// </summary>
        /// <param name="nodeVisitor">The node visitor.</param>
        public void Accept(SiteConfigurationNodeVisitor nodeVisitor)
        {
            nodeVisitor.Visit(this);
        }
        
        [Required]
        [DisplayName("Repository URL")]
        public string Url { get; set; }

        [Required]
        [DisplayName("Branch")]
        public string Branch { get; set; }

        [DisplayName("Hook")]
        public string Hook { get; set; }
    }
}
