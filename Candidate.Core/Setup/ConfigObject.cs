using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bounce.Framework;

namespace Candidate.Core.Setup {
    public class ConfigObject {
        public GitCheckout Git { get; set; }
        public VisualStudioSolution Solution { get; set; }
    }
}
