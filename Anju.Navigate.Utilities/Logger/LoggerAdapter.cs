using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Anju.Navigate.Utilities.Logger
{
    public class LoggerAdapter<T> : IAppLogger<T>
    {
        private readonly ILogger logger;

        public LoggerAdapter(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<T>();
        }

        public void LogInformation(string infoCode, string message, params object[] args)
        {
            logger.LogInformation($"{infoCode}${message}${JsonConvert.SerializeObject(args)}");
        }

        public void LogWarning(string warningCode, string message, params object[] args)
        {
            logger.LogWarning($"{warningCode}${message}${JsonConvert.SerializeObject(args)}");
        }

        public void LogError(string errorCode, string message, params object[] args)
        {
            logger.LogError($"{errorCode}${message}${JsonConvert.SerializeObject(args)}");
        }

        public void LogCritical(string errorCode, string message, params object[] args)
        {
            logger.LogCritical($"{errorCode}${message}${JsonConvert.SerializeObject(args)}");
        }

        public void LogTrace(string errorCode, string message, params object[] args)
        {
            logger.LogTrace($"{errorCode}${message}${JsonConvert.SerializeObject(args)}");
        }

        public void LogDebug(string errorCode, string message, params object[] args)
        {
            logger.LogDebug($"{errorCode}${message}${JsonConvert.SerializeObject(args)}");
        }
    }
}
