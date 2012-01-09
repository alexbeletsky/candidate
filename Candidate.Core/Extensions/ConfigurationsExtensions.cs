using System.Collections.Generic;
using Bounce.Framework;
using Candidate.Core.Configurations.Parts;
using Candidate.Core.Configurations.Types;

namespace Candidate.Core.Extensions
{
    internal static class ConfigurationsExtensions
    {
        public static IEnumerable<Target> ToBounceTargets(this object config)
        {
            return new TargetsRetriever().GetTargetsFromObject(config).ToTargets();
        }

        // TODO: UGLY, UGLY, UGLY
        public static Github ForGithub(this Configuration configuration)
        {
            switch (configuration.Type)
            {
                case "VisualStudio":
                    return (configuration as VisualStudioConfiguration).Github;

                case "XCopy":
                    return (configuration as XCopyConfiguration).Github;

                case "Batch":
                    return (configuration as BatchConfiguration).Github;
            }

            return null;
        }
    }
}