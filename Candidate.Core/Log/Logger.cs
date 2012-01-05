using System;
using System.IO;
using Candidate.Core.Utils;

namespace Candidate.Core.Log
{
    public class Logger : ILogger
    {
        private readonly string _id;
        private StreamWriter _writter;

        public Logger(string id)
        {
            _id = id;

            LogFileName = GetUniqueLogFilename();

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
            get { return _writter; }
        }

        public string LogFileName { get; private set; }

        public string LogFileFullPath
        {
            get { return Path.Combine(LogsDirectory, LogFileName); }
        }

        private string GetUniqueLogFilename()
        {
            return DateTime.Now.ToString("MMddyyyy_HHmmss") + ".log";
        }

        public string LogsDirectory
        {
            get { return DirectoryHelper.For(_id).LogsDirectory; }
        }
    }
}
