
namespace Candidate.Core.Settings
{
    public interface ISettingsManager
    {
        T ReadSettings<T>() where T : new();
        void SaveSettings(object settings);
    }
}
