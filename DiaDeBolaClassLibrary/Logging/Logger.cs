using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DiaDeBolaClassLibrary
{
    public static class Logger
    {
        private static long lineCount;
        private static readonly object ThisLock = new object();

        private static void WriteHeader(string fileName)
        {
            FileManager.EnsureDirectoryExists(fileName);
            string applicationName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            string headerLine = $"####################   Welcome to {applicationName}!  ####################\n";

            StreamToLog(headerLine, fileName);
        }

        private static string UpdateFilename(DateTime fileDateTime, string fileName = "MainLog")
        {
            return $"Log\\{fileName}_{fileDateTime:yyyy_MM_dd}.txt";
        }

        private static void StreamToLog(string message, string filename = "MainLog")
        {
            using (StreamWriter logFile = new StreamWriter(filename, true))
            {
                logFile.WriteLine(message);
                logFile.Close();
            }
        }

        public static void Log(string messageContent, string logName = "MainLog")
        {
            DateTime fileDateTime = DateTime.Now;
            string fileName = UpdateFilename(fileDateTime, logName);
            string lineToWrite = $"[{lineCount++}] {fileDateTime:HH:mm:ss} - {messageContent}";

            lock (ThisLock)
            {
                if (!File.Exists(fileName))
                {
                    WriteHeader(fileName);
                    
                }
                StreamToLog(lineToWrite, fileName);
            }
        }
    }
}
