using System.IO;
using Candidate.Core.Utils;
using Newtonsoft.Json;

namespace Candidate.Core.Settings {
    public class SettingsManager : ISettingsManager {
        private JsonSerializer _serializer = new JsonSerializer();
        private string _settingsFolder;

        public SettingsManager(IDirectoryProvider directoryProvider) {
            _settingsFolder = directoryProvider.Settings;
            CreateSettingFolder();
        }

        private void CreateSettingFolder() {
            if (!Directory.Exists(_settingsFolder)) {
                Directory.CreateDirectory(_settingsFolder);
            }
        }

        public T ReadSettings<T>() where T : new() {
            try {
                using (var reader = new JsonTextReader(new StreamReader(GetSettingsFilename<T>()))) {
                    var settings = _serializer.Deserialize<T>(reader);

                    return settings;
                }
            }
            catch (FileNotFoundException) {
                return new T();
            }
        }

        public void SaveSettings(object settings) {
            using (var writer = new JsonTextWriter(new StreamWriter(GetSettingsFilename(settings)))) {
                _serializer.Serialize(writer, settings);
            }
        }

        public string GetSettingsFilename<T>() {
            return _settingsFolder + "\\" + typeof(T).Name + ".json";
        }

        private string GetSettingsFilename(object settings) {
            return _settingsFolder + "\\" + settings.GetType().Name + ".json";
        }
    }
}
