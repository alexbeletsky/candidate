using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Candidate.Core.Settings.Model {
    public class Iis {

        public Iis() {
            Port = 80;
            DeployFolder = "c:\\sites";
        }

        /// <summary>
        /// Accepts the specified node visitor and passes control to it
        /// </summary>
        /// <param name="nodeVisitor">The node visitor.</param>
        public void Accept(SiteConfigurationNodeVisitor nodeVisitor)
        {
            nodeVisitor.Visit(this);
        }

        [Required]
        [DisplayName("Site name")]
        public string SiteName { get; set; }
        
        [DisplayName("Port")]
        public int Port { get; set; }

        [Required]
        [DisplayName("Deploy folder")]
        public string DeployFolder { get; set; }
    }
}
