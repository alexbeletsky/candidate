using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Candidate.Areas.Dashboard.Models {
    public class NewJobModel {
        [Required]
        [DisplayName("Site name")]
        public string Name { get; set; }
    }
}