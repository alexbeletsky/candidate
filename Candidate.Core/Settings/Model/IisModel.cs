using System.ComponentModel;

namespace Candidate.Core.Settings.Model {
    public class IisModel {
        [DisplayName("Site name")]
        public string SiteName { get; set; }
        [DisplayName("Port")]
        public int Port { get; set; }
    }
}
