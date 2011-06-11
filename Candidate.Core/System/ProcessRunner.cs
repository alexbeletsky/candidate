using System;
using System.Diagnostics;
using System.IO;

namespace Candidate.Core.System
{
    public class Logger : ILogger, IDisposable
    {
        private StreamWriter _writter;

        public Logger(string pathToLog)
        {
            _writter = new StreamWriter(pathToLog);
        }

        public void Dispose()
        {
            _writter.Close();
        }

        public void Log(string line)
        {
            _writter.WriteLine(line);
        }
    }

    public class ProcessRunner : IProcessRunner
    {
        private ILogger _logger;
        private string _workingFolder;

        public ProcessRunner(ILogger logger, string workingFolder)
        {
            _logger = logger;
            _workingFolder = workingFolder;
        }

        public void Run(string batch)
        {
            var processInfo = new ProcessStartInfo
            {
                UseShellExecute = false,
                ErrorDialog = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                FileName = _workingFolder + batch,
                WorkingDirectory = _workingFolder
            };

            using (var process = Process.Start(processInfo))
            {
                var standardStreamReader = process.StandardOutput;
                var errorStreamReader = process.StandardError;

                while (!standardStreamReader.EndOfStream)
                {
                    var line = standardStreamReader.ReadLine();
                    _logger.Log(line);
                }

                var error = errorStreamReader.ReadToEnd();
                _logger.Log(error);

                process.WaitForExit();

                _logger.Log(string.Format("{0} has been finished. Error code: {1}", batch, process.ExitCode));

            }
        }
    }
}
