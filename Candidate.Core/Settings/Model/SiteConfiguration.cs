
namespace Candidate.Core.Settings.Model {
    public class SiteConfiguration {        
        public string JobName { get; set; }
        
        public GitHub Github { get; set; }
        public Solution Solution { get; set; }
        public Iis Iis { get; set; }
    }
}
