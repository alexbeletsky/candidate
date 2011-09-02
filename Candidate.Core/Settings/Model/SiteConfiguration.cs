
namespace Candidate.Core.Settings.Model {
    public class SiteConfiguration {
        public SiteConfiguration() {
            Github = new GitHub();
            Solution = new Solution();
            Iis = new Iis();
        }
        
        public string JobName { get; set; }
        
        public GitHub Github { get; set; }
        public Solution Solution { get; set; }
        public Iis Iis { get; set; }
    }
}
