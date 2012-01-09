using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candidate.Core.Deploy
{
    public interface IDeployer
    {
        DeployResults Deploy(string id);
        DeployResults Deploy(string id, string branch);
    }
}
