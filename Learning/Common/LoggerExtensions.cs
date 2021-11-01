using Serilog;
using Serilog.Events;

namespace Common
{
    public class LoggerExtensions
    {
        public static ILogger CreateLogger()
        {
            return new LoggerConfiguration()
                .WriteTo.NUnitOutput(LogEventLevel.Debug)
                .MinimumLevel.Verbose()
                .CreateLogger();
        }
    }
}