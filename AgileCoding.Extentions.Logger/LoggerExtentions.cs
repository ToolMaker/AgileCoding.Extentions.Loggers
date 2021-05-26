namespace AgileCoding.Extentions.Loggers
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using AgileCoding.Library.Enums.Logging;
    using AgileCoding.Library.Interfaces.Logging;
    using AgileCoding.Library.Loggers;

    public static class LoggerExtensions
    {
        public static ILogger CreateWindowsEventLoggerInstance(this ILogger logger, string LogName, string sourceName)
        {
            var applicatonLog = EventLog.GetEventLogs()
                .Where(x => x.Log.Equals(LogName))
                .Single();

            return new WindowsEventLogger(applicatonLog, sourceName);
        }

        public static ILogger CreateWindowsEventLoggerInstance(this ILogger logger, EventLog eventLog, string sourceName)
        {
            return new WindowsEventLogger(eventLog, sourceName);
        }

        public static void WriteVerbose(this ILogger logger, string data, int eventId)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }

            logger.WriteCore(LogTypeEnum.Verbose, eventId, data, null, null);
        }

        public static void WriteInformation(this ILogger logger, string message, int eventId)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }

            logger.WriteCore(LogTypeEnum.Information, 0, message, null, null);
        }

        public static void WriteWarning(this ILogger logger, string message, int eventId)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }

            logger.WriteCore(LogTypeEnum.Warning, eventId, message, null, null);
        }

        public static void WriteWarning(this ILogger logger, string message, Exception error, int eventId)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }
            logger.WriteCore(LogTypeEnum.Warning, eventId, message, error, null);
        }

        public static void WriteError(this ILogger logger, string message, int eventId)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }
            logger.WriteCore(LogTypeEnum.Error, eventId, message, null, null);
        }

        public static void WriteError(this ILogger logger, string message, Exception error, int eventId)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }
            logger.WriteCore(LogTypeEnum.Error, eventId, message, error, null);
        }

        public static void WriteCritical(this ILogger logger, string message, int eventId)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }
            logger.WriteCore(LogTypeEnum.Critical, eventId, message, null, null);
        }

        public static void WriteCritical(this ILogger logger, string message, Exception error, int eventId)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }
            logger.WriteCore(LogTypeEnum.Critical, eventId, message, error, null);
        }

        private static readonly Func<object, Exception, string> TheMessage = (object message, Exception error) => (string)message;

        private static readonly Func<object, Exception, string> TheMessageAndError = (object message, Exception error) => string.Format(CultureInfo.CurrentCulture, "{0}\r\n{1}", new object[2]
        {
        message,
        error
        });

        public static bool IsEnabled(this ILogger logger, LogTypeEnum eventType)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }
            return logger.WriteCore(eventType, 0, null, null, null);
        }

        public static void WriteVerbose(this ILogger logger, string data)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }
            logger.WriteCore(LogTypeEnum.Verbose, 0, data, null, TheMessage);
        }

        public static void WriteInformation(this ILogger logger, string message)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }
            logger.WriteCore(LogTypeEnum.Information, 0, message, null, TheMessage);
        }

        public static void WriteWarning(this ILogger logger, string message, params string[] args)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }
            logger.WriteCore(LogTypeEnum.Warning, 0, string.Format(CultureInfo.InvariantCulture, message, args), null, TheMessage);
        }

        public static void WriteWarning(this ILogger logger, string message, Exception error)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }
            logger.WriteCore(LogTypeEnum.Warning, 0, message, error, TheMessageAndError);
        }

        public static void WriteError(this ILogger logger, string message)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }
            logger.WriteCore(LogTypeEnum.Error, 0, message, null, TheMessage);
        }

        public static void WriteError(this ILogger logger, string message, Exception error)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }
            logger.WriteCore(LogTypeEnum.Error, 0, message, error, TheMessageAndError);
        }

        public static void WriteCritical(this ILogger logger, string message)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }
            logger.WriteCore(LogTypeEnum.Critical, 0, message, null, TheMessage);
        }

        public static void WriteCritical(this ILogger logger, string message, Exception error)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }
            logger.WriteCore(LogTypeEnum.Critical, 0, message, error, TheMessageAndError);
        }
    }
}
