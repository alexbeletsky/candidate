using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Candidate.Core.Settings.Model {
    public class SolutionModel {
        [DisplayName("Solution Name")]
        public string Name { get; set; }
    }
}
