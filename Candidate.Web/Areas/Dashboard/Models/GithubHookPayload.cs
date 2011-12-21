using System.Linq;

namespace Candidate.Areas.Dashboard.Models
{
    public class GithubHookPayload
    {
        public string Ref { get; set; }

        public string Branch
        {
            get
            {
                return Ref.Split('/').Last();
            }
        }
    }
}