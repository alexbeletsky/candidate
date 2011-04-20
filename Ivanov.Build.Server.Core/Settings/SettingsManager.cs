using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace Ivanov.Build.Server.Core.Settings
{
    public class SettingsManager : ISettingsManager
    {
        private JsonSerializer _serializer = new JsonSerializer();
        private static readonly string SettingsFolder = "Settings";

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
            try
            {
                using (var reader = new JsonTextReader(new StreamReader(GetSettingsFilename<T>())))
                {
                    return _serializer.Deserialize<T>(reader);
                }
            }
            catch (FileNotFoundException)
            {
                return new T();
            }
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
    }
}
