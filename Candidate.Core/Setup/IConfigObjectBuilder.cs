using Candidate.Core.Settings.Model;
using Candidate.Core.Settings.Model.Configurations;

namespace Candidate.Core.Setup
{
    public interface IConfigObjectBuilder
    {
        ConfigObject CreateConfigObject(VisualStudioConfiguration config);
    }
}
