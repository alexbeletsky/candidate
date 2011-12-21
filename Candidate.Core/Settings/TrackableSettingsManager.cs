using System;
using System.Collections.Generic;

namespace Candidate.Core.Settings
{
    // TODO: find a better name for that class
    public class TrackableSettingsManager : IDisposable, ISettingsManager
    {
        private ISettingsManager _settingsManager;
        private List<object> _trackableObjects = new List<object>();

        public TrackableSettingsManager(ISettingsManager settingsManager)
        {
            _settingsManager = settingsManager;
        }

        public void Dispose()
        {
            _trackableObjects.ForEach((o) => { _settingsManager.SaveSettings(o); });
        }

        public T ReadSettings<T>() where T : new()
        {
            var readSettings = _settingsManager.ReadSettings<T>();
            _trackableObjects.Add(readSettings);

            return readSettings;
        }

        public void SaveSettings(object settings)
        {
            // nothing to do here, will be saved in dispose
        }
    }
}
