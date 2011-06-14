
namespace Candidate.Core.Settings
{
    //public delegate void SettingsReadHandler(object readObject); 

    public interface ISettingsManager
    {
        T ReadSettings<T>() where T : new();
        void SaveSettings(object settings);

        // Event's
        //event SettingsReadHandler OnSettingsRead;
    }
}
