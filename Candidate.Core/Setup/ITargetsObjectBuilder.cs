using System.Collections.Generic;
using Bounce.Framework;
using Candidate.Core.Model.Configurations;

namespace Candidate.Core.Setup
{
    public interface ITargetsObjectBuilder
    {
        IEnumerable<Target> BuildTargetsFromConfig(VisualStudioConfiguration config);
    }
}
