using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Ivanov.Build.Server.Core.System
{
    public class ProcessRunner : IProcessRunner
    {
        public void Run(string pathToExecutable)
        {
            var processInfo = new ProcessStartInfo
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                FileName = pathToExecutable
            };

            using (var process = Process.Start(processInfo))
            {
                process.WaitForExit();
            }
        }
    }
}
