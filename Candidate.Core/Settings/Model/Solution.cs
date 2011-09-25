using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Candidate.Core.Settings.Model {
    public class Solution {
        public Solution() {
            Targets = new Dictionary<int, string> {
                { 0, "Build" },
                { 1, "Rebuild"}
            };

            Configurations = new Dictionary<int, string> {
                { 0, "Debug" },
                { 1, "Release" }
            };

            NUnitRuntimeVersions = new Dictionary<int, string> {
                { 0, "4.0" }
            };
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
        [DisplayName("Solution name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Web project")]
        public string WebProject { get; set; }

        [Required]
        [DisplayName("Target")]
        public IDictionary<int, string> Targets { get; set; }

        public int SelectedTarget { get; set; }

        [Required]
        [DisplayName("Configuration")]
        public IDictionary<int, string> Configurations { get; set; }

        public int SelectedConfiguration { get; set; }

        [Required]
        [DisplayName("NUnit version")]
        public IDictionary<int, string> NUnitRuntimeVersions { get; set; }

        public int SelectedNUnitRuntimeVersion { get; set; }
        
        [DisplayName("Run tests?")]
        public bool IsRunTests { get; set; }
 }
}
