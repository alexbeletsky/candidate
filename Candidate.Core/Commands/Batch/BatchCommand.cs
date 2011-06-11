using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candidate.Core.Commands.Batch
{
    public class BatchCommand : ICommand
    {
        private string _batchName;
        private string _workingDirectory;

        public BatchCommand(string batchName, string workingDirectory)
        {
            _batchName = batchName;
            _workingDirectory = workingDirectory;
        }

        public string Arguments
        {
            get 
            {
                return null;
            }
        }

        public string Executable
        {
            get 
            {
                return _workingDirectory + _batchName; 
            }
        }
    }
}
