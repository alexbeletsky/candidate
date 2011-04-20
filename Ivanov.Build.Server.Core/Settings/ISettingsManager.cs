using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ivanov.Build.Server.Core.Settings
{
    public interface ISettingsManager
    {
        T ReadSettings<T>() where T : new();
        void SaveSettings(object settings);
    }
}
