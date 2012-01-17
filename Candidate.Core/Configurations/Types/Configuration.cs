using System;
using System.IO;
using Candidate.Core.Deploy;
using Candidate.Core.Utils;

namespace Candidate.Core.Configurations.Types
{
    public abstract class Configuration : IDeployable, IConfigurable, IDeletable
    {
        public string Id { get; set; }
        public string ReadableName { get; set; }

        public abstract string Type { get; }
        public abstract bool IsConfigured();
        public abstract IDeployRunner CreateDeployRunner();
        
        public void Delete()
        {
            Safe.DirectoryDelete(DirectoryHelper.For(Id).SiteDirectory);
        }
    }
}