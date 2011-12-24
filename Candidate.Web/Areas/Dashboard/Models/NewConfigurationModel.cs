using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Candidate.Core.Model.Configurations;

namespace Candidate.Areas.Dashboard.Models
{
    public class NewConfigurationModel
    {
        public NewConfigurationModel()
        {
            Types = new Dictionary<ConfigurationType, string>
            {
                { ConfigurationType.Batch, "Batch" },
                { ConfigurationType.XCopy, "XCopy" },
                { ConfigurationType.VisualStudio, "Visual Studio" }
            };
        }

        [Required]
        [DisplayName("Site name")]
        public string Name { get; set; }

        public IDictionary<ConfigurationType, string> Types { get; set; }
        public ConfigurationType SelectedType { get; set; }
    }
}