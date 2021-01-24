using System;

namespace Heikal.Lubricant.Core.Interfaces
{
    public interface ILoggerManager: IDisposable
    {
        ILoggerManager CreateLogger();
        void LogDebug(string message);
        void LogError(string message, Exception exception = null);
        void LogInformation(string message);
        void LogWarning(string message);
    }
}
