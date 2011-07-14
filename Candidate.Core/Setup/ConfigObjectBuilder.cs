using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Candidate.Core.Settings.Model;
using Bounce.Framework;
using System.Dynamic;

namespace Candidate.Core.Setup {
    public class ConfigObjectBuilder : IConfigObjectBuilder{
        public dynamic CreateConfigObject(JobConfigurationModel config) {
            dynamic configObject = new ExpandoObject();

            if (config != null) {
                if (config.Github != null) {
                    configObject.Git = new GitCheckout {
                        Repository = config.Github.Url
                    };
                }
            }

            return configObject;
        }
    }
}
