using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ivanov.Build.Server.Core.System
{
    public interface IProcessRunner
    {
        void Run(string pathToExecutable);
    }
}
