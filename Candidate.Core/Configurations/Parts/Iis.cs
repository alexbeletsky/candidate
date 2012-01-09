using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Candidate.Core.Extensions;

namespace Candidate.Core.Configurations.Parts
{
    public class Iis : IConfigurable 
    {
        public Iis()
        {
            Port = 80;
            DeployDirectory = "c:\\sites";
        }

        [Required]
        [DisplayName("Site name")]
        public string SiteName { get; set; }

        [DisplayName("Port")]
        public int Port { get; set; }

        [DisplayName("Bindings")]
        public string Bindings { get; set; }

        [Required]
        [DisplayName("Deploy folder")]
        public string DeployDirectory { get; set; }

        public bool IsConfigured()
        {
            return this.TryValidateObject();
        }
    }
}
