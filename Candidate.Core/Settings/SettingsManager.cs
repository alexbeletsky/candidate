using System.IO;
using Candidate.Core.Utils;
using Newtonsoft.Json;

namespace Candidate.Core.Settings
{
    public class SettingsManager : ISettingsManager
    {
        private readonly JsonSerializer _serializer;
        private readonly string _settingsFolder;

        public SettingsManager()
            : this(DirectoryHelper.For().SettingsDirectory)
        {
        }

        public SettingsManager(string settingsDirectory)
        {
            _serializer = JsonSerializer.Create(new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects });
            _settingsFolder = settingsDirectory;

            EnsureSettingFolderExists();            
        }

        private void EnsureSettingFolderExists()
        {
            if (!Directory.Exists(_settingsFolder))
            {
                Directory.CreateDirectory(_settingsFolder);
            }
        }

        public T ReadSettings<T>() where T : new()
        {
            try
            {
                using (var reader = new JsonTextReader(new StreamReader(GetSettingsFileName<T>())))
                {
                    var settings = _serializer.Deserialize<T>(reader);

                    return settings;
                }
            }
            catch (FileNotFoundException)
            {
                return new T();
            }
        }

        public void SaveSettings(object settings)
        {
            using (var writer = new JsonTextWriter(new StreamWriter(GetSettingsFileName(settings))))
            {
                _serializer.Serialize(writer, settings);
            }
        }

        public string GetSettingsFileName<T>()
        {
            return Path.Combine(_settingsFolder, typeof(T).Name + ".json");
        }

        private string GetSettingsFileName(object settings)
        {
            return Path.Combine(_settingsFolder, settings.GetType().Name + ".json");
        }
    }
}
