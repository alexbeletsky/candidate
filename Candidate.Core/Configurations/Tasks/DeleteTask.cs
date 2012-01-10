using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bounce.Framework;

namespace Candidate.Core.Configurations.Tasks
{
    public class DeleteTask
    {
        private readonly string _buildDirectory;

        public DeleteTask(string buildDirectory)
        {
            _buildDirectory = buildDirectory;
        }

        public CleanDirectory ToTask()
        {
            return new CleanDirectory
                       {
                           Path = _buildDirectory
                       };
        }
    }
}
