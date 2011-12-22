using System.Collections.Generic;
using Bounce.Framework;
using Candidate.Core.Settings.Model;
using Candidate.Core.Settings.Model.Configurations;

namespace Candidate.Core.Setup
{
    public interface ITargetsObjectBuilder
    {
        IEnumerable<Target> BuildTargetsFromConfig(VisualStudioConfiguration config);
    }
}
