using System;
using System.Collections.Generic;

namespace Candidate.Core.Settings
{
    public class AutoSaveSettingsManager : IDisposable, ISettingsManager
    {
        private readonly ISettingsManager _settingsManager;
        private readonly List<object> _autoSavedObjects = new List<object>();

        public AutoSaveSettingsManager(ISettingsManager settingsManager)
        {
            _settingsManager = settingsManager;
        }

        public void Dispose()
        {
            _autoSavedObjects.ForEach(o => _settingsManager.SaveSettings(o));
        }

        public T ReadSettings<T>() where T : new()
        {
            var readSettings = _settingsManager.ReadSettings<T>();
            _autoSavedObjects.Add(readSettings);

            return readSettings;
        }

        public void SaveSettings(object settings)
        {
            // nothing to do here, will be saved in dispose
        }
    }
}
