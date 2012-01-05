using System.Collections.Generic;
using Bounce.Framework;
using Candidate.Core.Configurations;
using Candidate.Core.Configurations.Types;

namespace Candidate.Core.Setup
{
    public interface ITargetsObjectBuilder
    {
        IEnumerable<Target> BuildTargetsFromConfig(VisualStudioConfiguration config);
    }
}
