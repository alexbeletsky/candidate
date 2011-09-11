using System.ComponentModel;

namespace Candidate.Core.Settings.Model {
    public class Iis {

        public Iis() {
            DeployFolder = "c:\\sites";
        }

        [DisplayName("Site name")]
        public string SiteName { get; set; }
        
        [DisplayName("Port")]
        public int Port { get; set; }

        [DisplayName("Deploy folder")]
        public string DeployFolder { get; set; }

    }
}
