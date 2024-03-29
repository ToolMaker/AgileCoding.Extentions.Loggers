﻿namespace AgileCoding.Extentions.Loggers
{
    using AgileCoding.Library.Enums.Logging;
    using AgileCoding.Library.Interfaces.Logging;
    using System;
    using System.Globalization;

    public static class LoggerExtensions
    {
        public static void WriteVerbose(this ILogger logger, int eventId, string data)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }

            logger.WriteCore(LogTypeEnum.Verbose, eventId, data, null, null);
        }

        public static void WriteInformation(this ILogger logger, int eventId, string message)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }

            logger.WriteCore(LogTypeEnum.Information, eventId, message, null, null);
        }

        public static void WriteWarning(this ILogger logger, int eventId, string message)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }

            logger.WriteCore(LogTypeEnum.Warning, eventId, message, null, null);
        }

        public static void WriteWarning(this ILogger logger, int eventId, string message, Exception error)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }
            logger.WriteCore(LogTypeEnum.Warning, eventId, message, error, null);
        }

        public static void WriteError(this ILogger logger, int eventId, string message)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }
            logger.WriteCore(LogTypeEnum.Error, eventId, message, null, null);
        }

        public static void WriteError(this ILogger logger, int eventId, string message, Exception error)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }
            logger.WriteCore(LogTypeEnum.Error, eventId, message, error, null);
        }

        public static void WriteCritical(this ILogger logger, int eventId, string message)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }
            logger.WriteCore(LogTypeEnum.Critical, eventId, message, null, null);
        }

        public static void WriteCritical(this ILogger logger, int eventId, string message, Exception error)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }

            logger.WriteCore(LogTypeEnum.Critical, eventId, message, error, null);
        }

        private static readonly Func<object, Exception, string> justTheMessage = (object message, Exception error) => (string)message;

        private static readonly Func<object, Exception, string> theMessageAndError = (object message, Exception error) => string.Format(CultureInfo.CurrentCulture, "{0}\r\n{1}", new object[2]
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
            logger.WriteCore(LogTypeEnum.Verbose, 0, data, null, justTheMessage);
        }

        public static void WriteInformation(this ILogger logger, string message)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }
            logger.WriteCore(LogTypeEnum.Information, 0, message, null, justTheMessage);
        }

        public static void WriteWarning(this ILogger logger, string message, params string[] args)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }
            logger.WriteCore(LogTypeEnum.Warning, 0, string.Format(CultureInfo.InvariantCulture, message, args), null, justTheMessage);
        }

        public static void WriteWarning(this ILogger logger, string message, Exception error)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }
            logger.WriteCore(LogTypeEnum.Warning, 0, message, error, theMessageAndError);
        }

        public static void WriteError(this ILogger logger, string message)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }
            logger.WriteCore(LogTypeEnum.Error, 0, message, null, justTheMessage);
        }

        public static void WriteError(this ILogger logger, string message, Exception error)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }
            logger.WriteCore(LogTypeEnum.Error, 0, message, error, theMessageAndError);
        }

        public static void WriteCritical(this ILogger logger, string message)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }
            logger.WriteCore(LogTypeEnum.Critical, 0, message, null, justTheMessage);
        }

        public static void WriteCritical(this ILogger logger, string message, Exception error)
        {
            if (logger == null)
            {
                throw new ArgumentNullException("logger");
            }
            logger.WriteCore(LogTypeEnum.Critical, 0, message, error, theMessageAndError);
        }
    }
}
