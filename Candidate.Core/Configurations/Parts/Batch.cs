using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Candidate.Core.Extensions;

namespace Candidate.Core.Configurations.Parts
{
    public class Batch : IConfigurable
    {
        [Required]
        [DisplayName("Batch build")]
        public string BuildScript { get; set; }

        [Required]
        [DisplayName("Build folder")]
        public string BuildDirectory { get; set; }

        public bool IsConfigured()
        {
            return this.TryValidateObject();
        }
    }
}