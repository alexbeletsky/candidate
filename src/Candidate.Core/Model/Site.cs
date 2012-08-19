using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candidate.Core.Model
{
    public class Site
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime Created { get; set; }
    }
}
