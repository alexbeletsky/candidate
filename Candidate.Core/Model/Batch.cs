using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Candidate.Core.Model
{
    public class Batch
    {
        [Required]
        [DisplayName("Batch build")]
        public string BuildScript { get; set; }

        [DisplayName("Build folder")]
        public string BuildFolder { get; set; }
    }
}