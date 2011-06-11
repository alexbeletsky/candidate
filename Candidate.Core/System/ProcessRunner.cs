using System;
using System.Diagnostics;
using System.IO;
using Candidate.Core.Commands;

namespace Candidate.Core.System
{
    public class Logger : ILogger, IDisposable
    {
        private StreamWriter _writter;
        private FileStream _log;

        public Logger(string pathToLog)
        {
            var folder = Path.GetDirectoryName(pathToLog);

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            if (File.Exists(pathToLog))
            {
                File.Delete(pathToLog);
            }

            _log = new FileStream(pathToLog, FileMode.OpenOrCreate);
            _writter = new StreamWriter(_log);
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

        public void RunCommandSync(ICommand command)
        {
            var processInfo = new ProcessStartInfo
            {
                UseShellExecute = false,
                ErrorDialog = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                FileName = command.Executable,
                WorkingDirectory = _workingFolder
            };

            if (command.Arguments != null)
            {
                processInfo.Arguments = command.Arguments;
            }

            RunProcessWithLoggingSync(processInfo);
        }

        private void RunProcessWithLoggingAsync(ProcessStartInfo processInfo)
        {
            using (var process = Process.Start(processInfo))
            {
                process.OutputDataReceived += delegate(object s, DataReceivedEventArgs args)
                {
                    _logger.Log(args.Data);
                };
                process.ErrorDataReceived += delegate(object s, DataReceivedEventArgs args)
                {
                    _logger.Log(args.Data);
                };

                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
            }
        }

        private void RunProcessWithLoggingSync(ProcessStartInfo processInfo)
        {
            using (var process = Process.Start(processInfo))
            {
                var standardStreamReader = process.StandardOutput;
                var errorStreamReader = process.StandardError;

                _logger.Log(standardStreamReader.ReadToEnd());
                _logger.Log(errorStreamReader.ReadToEnd());

                process.WaitForExit();
            }
        }

    }
}
