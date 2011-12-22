using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Candidate.Core.Settings.Model
{
    public class Github
    {
        [Required]
        [DisplayName("Repository URL")]
        public string Url { get; set; }

        [Required]
        [DisplayName("Branch")]
        public string Branch { get; set; }

        [DisplayName("Hook")]
        public string Hook { get; set; }
    }
}
