using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Candidate.Core.Settings.Model;
using Bounce.Framework;

namespace Candidate.Core.Setup {
    public class DefaultBounceTargetsBuilder : IBounceTargetsBuilder {
        public IEnumerable<Target> BuildTargetsFromConfig(JobConfigurationModel config) {
            var targetsRetriever = new TargetsRetriever();
            var configObject = GetConfigObject(config);

            return targetsRetriever.GetTargetsFromObject((object)config).ToTargets();
        }

        private dynamic GetConfigObject(JobConfigurationModel config) {
            dynamic configObject = new { };

            throw new NotImplementedException();
        }
    }
}
