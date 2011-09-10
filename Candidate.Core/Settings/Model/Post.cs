using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Candidate.Core.Settings.Model {
    public class Post {
        [DisplayName("Post batch")]
        public string PostBatch { get; set; }
    }
}
