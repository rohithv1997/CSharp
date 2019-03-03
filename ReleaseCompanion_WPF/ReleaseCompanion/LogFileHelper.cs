using System.IO;

namespace ReleaseCompanion
{
    internal class LogFileHelper
    {
        private string _logFilePath;

        public LogFileHelper(string logFilePath)
        {
            _logFilePath = logFilePath;
        }

        public void AppendToLogFile(string text)
        {
            File.AppendAllLines(_logFilePath, new string[] { text });
        }
    }
}
