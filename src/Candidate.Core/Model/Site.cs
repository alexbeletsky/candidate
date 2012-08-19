using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Candidate.Core.Model
{
    public class Site
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime Created { get; set; }
    }

}
