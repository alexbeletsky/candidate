using System.IO;
using Bounce.Framework;

namespace Candidate.Core.Configurations.Tasks
{
    internal class CheckoutSourcesTask
    {
        private readonly string _url;
        private readonly string _branch;
        private readonly string _sources;

        public CheckoutSourcesTask(string url, string branch, string sources)
        {
            _url = url;
            _branch = branch;
            _sources = sources;
        }

        public GitCheckout ToTask()
        {
            return new GitCheckout { Repository = _url, Branch = _branch, Directory = _sources };
        }
    }
}