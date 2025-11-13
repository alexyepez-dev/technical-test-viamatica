using Serilog;

namespace VMT.TechnicalTest.Api.Logging
{
    public static class LoggingProvider
    {
        public static void Serilog()
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .Enrich.FromLogContext()
            .WriteTo.Console
            (
                outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}"
            ).CreateLogger();
        }
    }
}