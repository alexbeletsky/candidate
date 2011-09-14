using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Candidate.Core.Settings.Model {
    public class Post {
        [Required]
        [DisplayName("Post batch")]
        public string PostBatch { get; set; }
    }
}
