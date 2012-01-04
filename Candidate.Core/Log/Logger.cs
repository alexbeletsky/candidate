using System;
using System.IO;
using Candidate.Core.Utils;

namespace Candidate.Core.Log
{
    public class Logger : ILogger
    {
        private StreamWriter _writter;

        public Logger(IDirectoryProvider directoryProvider)
        {
            LogFileName = GetUniqueLogFilename();
            LogsDirectory = directoryProvider.Logs;
            LogFileFullPath = LogsDirectory + "\\" + LogFileName;

            CreateLogsDirectory();
            CreateLogsWriter();
        }

        private void CreateLogsWriter()
        {
            _writter = new StreamWriter(new FileStream(LogFileFullPath, FileMode.OpenOrCreate));
        }

        private void CreateLogsDirectory()
        {
            if (!Directory.Exists(LogsDirectory))
            {
                Directory.CreateDirectory(LogsDirectory);
            }
        }

        public void Dispose()
        {
            _writter.Close();
        }

        public TextWriter LogWriter
        {
            get
            {
                return _writter;
            }
        }

        public string LogFileName
        {
            get;
            private set;
        }

        public string LogFileFullPath
        {
            get;
            private set;
        }

        private string GetUniqueLogFilename()
        {
            return DateTime.Now.ToString("MMddyyyy_HHmmss") + ".log";
        }

        public string LogsDirectory { get; set; }
    }
}
