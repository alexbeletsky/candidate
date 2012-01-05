using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Candidate.Core.Configurations.Parts
{
    public class Post
    {
        [Required]
        [DisplayName("Post batch")]
        public string Batch { get; set; }
    }
}
