using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Candidate.Core.Settings.Model;

namespace Candidate.Core.Setup {
    public class DefaultSetup : ISetup {
        public DefaultSetup(JobConfigurationModel config) {
            this.Config = config;
        }

        public JobConfigurationModel Config { get; set; }


        public void Execute(System.ILogger logger) {
            throw new NotImplementedException();
        }
    }
}
