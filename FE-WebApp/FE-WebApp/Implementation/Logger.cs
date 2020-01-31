using System;
using FE_WebApp.Interfaces;
using log4net;
using log4net.Config;

namespace FE_WebApp.Implementation
{
    public class FileLogger : ILogger
    {
        private readonly ILog Logger;
        public FileLogger()
        {
            Logger = LogManager.GetLogger("RollingFile");
            XmlConfigurator.Configure();
        }

        public void Debug(string message)
        {
            Logger.Debug(message);
        }

        public void Error(string message, Exception exception)
        {
            Logger.Error(message, exception);
        }

        public void Info(string message)
        {
            Logger.Info(message);
        }

        public void Warn(string message)
        {
            Logger.Warn(message);
        }
    }
}