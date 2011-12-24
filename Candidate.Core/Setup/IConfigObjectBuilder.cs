using Candidate.Core.Model.Configurations;

namespace Candidate.Core.Setup
{
    public interface IConfigObjectBuilder
    {
        ConfigObject CreateConfigObject(VisualStudioConfiguration config);
    }
}
