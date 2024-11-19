using AppLogging.Internal;
using Entities;
using LoggingRepository;
using Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

/*
(1) Log info / error cand pot aparea exceptii

(2) Extinde libraria cu posibilitatea stocarii log-urilor intr-o tabela
dintr-o baza de date (Log)
 */

namespace AppLogging
{
    public interface ILog
    {
        void Log(LogModel log);
    }
}

namespace AppLogging.Internal
{
    internal class DatabaseLogging : ILog
    {
        public void Log(LogModel log)
        {
            //Console.WriteLine("log.Level: " + log.Output);
            //Console.WriteLine("(int)LogOuput.Database: " + (int)LogOuput.Database);

            if (log.Output == (int)LogOuput.Database)
            {
                //Console.WriteLine("LOG!");

                var repository = new LogRepository();
                var service = new LogService(repository);

                Log currentLog = new Log
                {
                    LogDate = DateTime.Now.ToString(),
                    LogMessage = log.Message
                };

                //Service -> DatabaseRepository -> Database
                service.CreateLog(currentLog);

                List<Log> allLogs = service.GetAllLogs();
                foreach (var item in allLogs)
                {
                    Console.WriteLine(item.Id + " " + item.LogDate + " " + item.LogMessage);
                }
            }

        }
    }
}

namespace AppLogging.Internal
{
    internal class ConsoleLogging : ILog
    {
        public void Log(LogModel log)
        {
            Console.WriteLine(log);
        }
    }
}

//Observatie: formatul json!
namespace AppLogging.Internal
{
    internal class FileLogging : ILog
    {
        private string FilePath;

        public FileLogging()
        {
            var filePath = ConfigurationManager.AppSettings["LogFileDirectory"];

            if (string.IsNullOrEmpty(filePath))
            {
                filePath = "AppLogs";
            }

            if (!System.IO.Directory.Exists(filePath))
            {
                System.IO.Directory.CreateDirectory(filePath);
            }

            FilePath = Path.Combine(filePath, "Log.txt");
        }

        public void Log(LogModel log)
        {
            File.AppendAllText(FilePath, log.ToString() + "\n");
        }
    }
}

namespace AppLogging
{
    public class LogFactory
    {
        private static ILog _instance;

        public static ILog Instance
        {
            get
            {
                if (_instance == null)
                {
                    //get from app.config (if exists)
                    var logType = ConfigurationManager.AppSettings["logType"];

                    if (string.IsNullOrWhiteSpace(logType))
                    {
                        logType = "Database";
                    }

                    LogOuput output = (LogOuput)Enum.Parse(typeof(LogOuput), logType);

                    switch (output)
                    {
                        case LogOuput.Console:
                            _instance = new ConsoleLogging();
                            break;
                        case LogOuput.File:
                            _instance = new FileLogging();
                            break;
                        case LogOuput.Database:
                            _instance = new DatabaseLogging();
                            break;
                    }
                }

                return _instance;
            }
        }
    }
}


namespace AppLogging
{
    public class LogModel
    {
        public string Message { get; set; }
        public int Level { get; set; }
        public int Output { get; set; }

        public override string ToString()
        {
            return $"[{DateTime.Now}: [{((LogLevel)Level).ToString()}]] - {Message};";
        }
    }
}

namespace AppLogging
{
    public enum LogLevel
    {
        Info = 1,
        Warn = 2,
        Error = 3,
        Debug = 4
    }
}

namespace AppLogging
{
    public enum LogOuput
    {
        Console = 1,
        File = 2,
        Database = 3
    }
}