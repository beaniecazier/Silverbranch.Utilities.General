using Gay.Silverbranch.Utilities.General.CommandLine;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace Gay.Silverbranch.Utilities.General.Logging;

public static class SerilogWebApplicationBuilderExtension
{
    public static void SetLogLevelFromOptions(this IHostApplicationBuilder builder, BaseCmdOptions options,
        LoggingLevelSwitch levelSwitch)
    {
        if (builder.Environment.IsDevelopment()) return;
        if (!CommandLineApplicationExtension.BeVerbose) return;
        if (options.Verbose < 0 || options.Verbose > 5)
        {
            throw new ArgumentOutOfRangeException("options.Verbose",
                options.Verbose,
                "Invalid Serilog logging level found while trying to set the log level");            
        }

        levelSwitch.MinimumLevel = (LogEventLevel)options.Verbose;
    }
    
    public static void AddLoggingWithSerilog(this IHostApplicationBuilder builder, LoggingLevelSwitch levelSwitch)
    {
        Serilog.ILogger logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .MinimumLevel.ControlledBy(levelSwitch)
            .CreateLogger();
        Log.Logger = logger;
    }
}