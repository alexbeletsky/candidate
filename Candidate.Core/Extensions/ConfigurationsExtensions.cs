using System.Collections.Generic;
using Bounce.Framework;

namespace Candidate.Core.Extensions
{
    internal static class ConfigurationsExtensions
    {
        public static IEnumerable<Target> ToBounceTargets(this object config)
        {
            return new TargetsRetriever().GetTargetsFromObject(config).ToTargets();
        }
    }
}