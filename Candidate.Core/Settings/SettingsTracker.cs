using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Candidate.Core.Settings;

namespace Candidate.Core.Settings
{
    public class SettingsTracker : IDisposable
    {
        private ISettingsManager _settingsManager;
        private List<object> _trackableObjects = new List<object>();

        public SettingsTracker(ISettingsManager settingsManager)
        {
            _settingsManager = settingsManager;

            _settingsManager.OnSettingsRead += (o) =>
                {
                    _trackableObjects.Add(o);
                };
        }

        public void Dispose()
        {
            _trackableObjects.ForEach((o) => { _settingsManager.SaveSettings(o); });
        }
    }
}
