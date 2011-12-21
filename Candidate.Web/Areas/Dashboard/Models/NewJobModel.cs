using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Candidate.Areas.Dashboard.Models
{
    public class NewJobModel
    {
        [Required]
        [DisplayName("Site name")]
        public string Name { get; set; }
    }
}