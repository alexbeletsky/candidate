using System.IO;
using Newtonsoft.Json;
using Candidate.Core.Utils;

namespace Candidate.Core.Settings
{
    public class SettingsManager : ISettingsManager
    {
        private JsonSerializer _serializer = new JsonSerializer();

        public SettingsManager()
        {
            CreateSettingFolder();
        }

        private void CreateSettingFolder()
        {
            if (!Directory.Exists(SettingsFolder))
            {
                Directory.CreateDirectory(SettingsFolder);
            }
        }

        public T ReadSettings<T>() where T : new()
        {
            T settings = new T();

            try
            {
                using (var reader = new JsonTextReader(new StreamReader(GetSettingsFilename<T>())))
                {
                    settings = _serializer.Deserialize<T>(reader);
                }
            }
            finally
            {
                if (OnSettingsRead != null)
                {
                    OnSettingsRead(settings);
                }
            }

            return settings;
        }

        public void SaveSettings(object settings)
        {
            using (var writer = new JsonTextWriter(new StreamWriter(GetSettingsFilename(settings))))
            {
                _serializer.Serialize(writer, settings);
            }
        }

        private static string GetSettingsFilename(object settings)
        {
            return SettingsFolder + "/" + settings.GetType().Name + ".json";
        }

        private static string GetSettingsFilename<T>()
        {
            return SettingsFolder + "/" + typeof(T).Name + ".json";
        }

        private static string SettingsFolder
        {
            get
            {
                return LocalAppDataFolder.Folder + "\\Settings";
            }
        }


        public event SettingsReadHandler OnSettingsRead;
    }
}
