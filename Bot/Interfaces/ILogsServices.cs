using System.Runtime.CompilerServices;
using Bot.Configs;

namespace Bot.Interfaces
{
    /// <summary>
    /// log interface
    /// </summary>
    public interface ILogsServices
    {
        void Debug(string? logs = null, Exception? ex = null, EnumLogLevel logLevel = EnumLogLevel.Debug,
            [CallerMemberName] string memberName = "", [CallerLineNumber] int lineNumber = 0,
            [CallerFilePath] string filePath = "");
        
        void Info(string logs, Exception? ex = null, EnumLogLevel logLevel = EnumLogLevel.Information,
            [CallerMemberName] string memberName = "", [CallerLineNumber] int lineNumber = 0,
            [CallerFilePath] string filePath = "");

        void Warn(string logs, EnumLogLevel logLevel = EnumLogLevel.Warning,
            Exception? ex = null,
            [CallerMemberName] string memberName = "", [CallerLineNumber] int lineNumber = 0,
            [CallerFilePath] string filePath = "");

        void Error(string logs, Exception? ex = null, EnumLogLevel logLevel = EnumLogLevel.Debug,
            [CallerMemberName] string memberName = "", [CallerLineNumber] int lineNumber = 0,
            [CallerFilePath] string filePath = "");

        void Fatal(string logs, Exception? ex = null, EnumLogLevel logLevel = EnumLogLevel.Fatal,
            [CallerMemberName] string memberName = "", [CallerLineNumber] int lineNumber = 0,
            [CallerFilePath] string filePath = "");

        void SetLogLevel(EnumLogLevel logLevel);
    }
}