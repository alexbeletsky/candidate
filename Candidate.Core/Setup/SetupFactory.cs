using System;
using System.Linq;
using Candidate.Core.Settings;
using Candidate.Core.Settings.Model;
using Bounce.Framework;

namespace Candidate.Core.Setup {
    public class SetupFactory : ISetupFactory {
        private ITargetsObjectBuilder _targetsObjectBuilder;
        private ITargetsBuilder _targetsBuilder;
        private IBounceFactory _bounceFactory;

        public SetupFactory(ITargetsObjectBuilder targetsObjectBuilder, ITargetsBuilder targetsBuilder, IBounceFactory bounceFactory) {
            _targetsObjectBuilder = targetsObjectBuilder;
            _targetsBuilder = targetsBuilder;
            _bounceFactory = bounceFactory;
        }

        public ISetup CreateSetup() {
            //if (settingsManager == null) {
            //    throw new ArgumentNullException("settingsManager");
            //}

            //if (string.IsNullOrEmpty(jobName)) {
            //    throw new ArgumentNullException("jobName");
            //}

            //var currentSettings = settingsManager.ReadSettings<JobsConfigurationSettingsModel>().Configurations.Where(c => c.JobName == jobName).SingleOrDefault();
            //if (currentSettings == null) {
            //    throw new Exception(string.Format("Can't create setup for non-existing job: {0}", jobName));
            //}

            return new DefaultSetup(_targetsObjectBuilder, _targetsBuilder, _bounceFactory);
        }
    }
}
