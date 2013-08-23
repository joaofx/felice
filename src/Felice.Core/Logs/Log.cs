namespace Felice.Core.Logs
{
    using System.IO;
    using log4net;
    using log4net.Appender;
    using log4net.Core;
    using log4net.Layout;
    using log4net.Repository.Hierarchy;

    public class Log
    {
        private static Logger root;
        private static ILog frameworkLog;
        private static ILog applicationLog;

        private static Logger Root
        {
            get
            {
                return root ?? (root = ((Hierarchy)LogManager.GetRepository()).Root);
            }
        }

        public static ILog Framework
        {
            get
            {
                return frameworkLog ?? (frameworkLog = LogManager.GetLogger("Framework"));
            }
        }

        public static ILog App
        {
            get
            {
                return applicationLog ?? (applicationLog = LogManager.GetLogger("App"));
            }
        }

        public static void Initialize()
        {
            Root.Repository.ResetConfiguration();

            var consoleAppender = BuildConsoleAppender();
            var hibernateConsoleAppender = BuildConsoleHibernateAppender();
            var fileAppender = BuildFileAppender();

            var hibernateLogger = GetHibernateSqlLogger();
            var frameworkLogger = GetFrameworkLogger();
            var applicationLogger = GetApplicationLogger();

            hibernateLogger.AddAppender(hibernateConsoleAppender);
            frameworkLogger.AddAppender(consoleAppender);
            applicationLogger.AddAppender(consoleAppender);

            hibernateLogger.AddAppender(fileAppender);
            frameworkLogger.AddAppender(fileAppender);
            applicationLogger.AddAppender(fileAppender);

            Root.Repository.Configured = true;
        }

        private static RollingFileAppender BuildFileAppender()
        {
            var fileAppender = new RollingFileAppender
            {
                Name = "FileAppender",
                AppendToFile = true,
                File = Path.Combine("Logs", "Web.log"),
                Layout = new PatternLayout("%date;%-5thread;%-5level;%message %newline"),
                Threshold = Level.Debug,
                RollingStyle = RollingFileAppender.RollingMode.Date,
                StaticLogFileName = true,
                MaxSizeRollBackups = 3
            };

            fileAppender.ActivateOptions();

            return fileAppender;
        }

        private static ConsoleAppender BuildConsoleAppender()
        {
            var consoleAppender = new ConsoleAppender
            {
                Name = "ConsoleAppender",
                Layout = new PatternLayout("%message %newline"),
                Threshold = Level.Debug
            };

            consoleAppender.ActivateOptions();

            return consoleAppender;
        }

        private static RollingFileAppender BuildConsoleHibernateAppender()
        {
            var consoleAppender = new RollingFileAppender
            {
                Name = "NHibernateSqlAppender",
                AppendToFile = true,
                File = Path.Combine("Logs", "Web.log"),
                Layout = new PatternLayout("%date; %-5thread; %-5level; %message %newline"),
                Threshold = Level.Debug,
                RollingStyle = RollingFileAppender.RollingMode.Date,
                StaticLogFileName = true,
                MaxSizeRollBackups = 3
            };

            consoleAppender.ActivateOptions();

            return consoleAppender;
        }

        private static Logger GetHibernateSqlLogger()
        {
            return (Logger)Root.Repository.GetLogger("NHibernate.SQL");
        }

        private static Logger GetFrameworkLogger()
        {
            return (Logger)Root.Repository.GetLogger("Framework");
        }

        private static Logger GetApplicationLogger()
        {
            return (Logger)Root.Repository.GetLogger("App");
        }
    }
}