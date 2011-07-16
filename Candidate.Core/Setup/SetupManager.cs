using System;
using System.Linq;
using Candidate.Core.Settings;
using Candidate.Core.Settings.Model;
using Bounce.Framework;

namespace Candidate.Core.Setup {
    public class SetupManager : ISetupManager{
        private ITargetsObjectBuilder _targetsObjectBuilder;
        private ITargetsBuilder _targetsBuilder;
        private ITargetBuilderBounce _bounce;

        public SetupManager(ITargetsObjectBuilder targetsObjectBuilder, ITargetsBuilder targetsBuilder, ITargetBuilderBounce bounce) {
            _targetsObjectBuilder = targetsObjectBuilder;
            _targetsBuilder = targetsBuilder;
            _bounce = bounce;
        }

        public ISetup CreateSetup(ISettingsManager settingsManager, string jobName) {
            if (settingsManager == null) {
                throw new ArgumentNullException("settingsManager");
            }

            if (string.IsNullOrEmpty(jobName)) {
                throw new ArgumentNullException("jobName");
            }

            var currentSettings = settingsManager.ReadSettings<JobsConfigurationSettingsModel>().Configurations.Where(c => c.JobName == jobName).SingleOrDefault();
            if (currentSettings == null) {
                throw new Exception(string.Format("Can't create setup for non-existing job: {0}", jobName));
            }

            return new DefaultSetup(_targetsObjectBuilder, _targetsBuilder, _bounce, currentSettings);
        }
    }
}
