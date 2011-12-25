using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Candidate.Areas.Dashboard.Models
{
    public class NewConfigurationModel
    {
        public NewConfigurationModel()
        {
            Types = new Dictionary<string, string>
            {
                { "batch", "Batch" },
                { "xcopy", "XCopy" },
                { "visualstudio", "Visual Studio" }
            };
        }

        [Required]
        [DisplayName("Site name")]
        public string Name { get; set; }

        public IDictionary<string, string> Types { get; set; }
        public string SelectedType { get; set; }
    }
}