using Microsoft.Extensions.Hosting;

namespace Gay.Silverbranch.Utilities.General.BackgroundServices;

#pragma warning disable CS1591
public class StartupBackgroundService : BackgroundService
{
    public static int FakedStartupDurationInSeconds = 10;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Simulate the effect of a long-running task.
        await Task.Delay(TimeSpan.FromSeconds(FakedStartupDurationInSeconds), stoppingToken);
    }
}

#pragma warning restore CS1591