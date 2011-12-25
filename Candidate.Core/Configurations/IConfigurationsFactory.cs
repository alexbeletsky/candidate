using Candidate.Core.Model.Configurations;

namespace Candidate.Core.Configurations
{
    public interface IConfigurationsFactory
    {
        Configuration CreateConfiguration(string type, string id, string readableName);
    }
}
