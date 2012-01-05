using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Candidate.Core.Configurations.Parts
{
    public class Batch
    {
        [Required]
        [DisplayName("Batch build")]
        public string BuildScript { get; set; }

        [DisplayName("Build folder")]
        public string BuildDirectory { get; set; }
    }
}