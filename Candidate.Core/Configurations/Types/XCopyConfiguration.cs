using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Candidate.Core.Configurations.Parts;
using Candidate.Core.Deploy;

namespace Candidate.Core.Configurations.Types
{
    public class XCopyConfiguration : Configuration
    {
        public XCopyConfiguration()
        {
            Github = new Github();
            Iis = new Iis();
        }

        [Required]
        public Github Github { get; set; }

        [Required]
        public Iis Iis { get; set; }

        public override string Type
        {
            get { return "XCopy"; }
        }

        public override bool IsConfigured()
        {
            return Github.IsConfigured() && Iis.IsConfigured();
        }

        public override IDeployRunner CreateDeployRunner()
        {
            return new DeployRunnerFactory().ForConfiguration(this);
        }
    }
}