using System;

namespace FE_WebApp.Interfaces
{
    public interface ILogger
    {
        void Debug(string message);        
        void Info(string message);        
        void Warn(string message);        
        void Error(string message, Exception exception);
    }
}