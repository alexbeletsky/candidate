using System.Collections.Generic;
using Bounce.Framework;
using Candidate.Core.Settings.Model;

namespace Candidate.Core.Setup
{
    public interface ITargetsObjectBuilder
    {
        IEnumerable<Target> BuildTargetsFromConfig(SiteConfiguration config);
    }
}
