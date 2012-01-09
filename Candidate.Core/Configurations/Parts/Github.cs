using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Candidate.Core.Extensions;

namespace Candidate.Core.Configurations.Parts
{
    public class Github : IConfigurable
    {
        [Required]
        [DisplayName("Repository URL")]
        public string Url { get; set; }

        [Required]
        [DisplayName("Branch")]
        public string Branch { get; set; }

        [DisplayName("Hook")]
        public string Hook { get; set; }

        public bool IsConfigured()
        {
            return this.TryValidateObject();
        }
    }
}
