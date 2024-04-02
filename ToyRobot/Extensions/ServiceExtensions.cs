using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToyRobot.Interfaces;
using ToyRobot.Services;

namespace ToyRobot.Extensions;

public static class ServiceExtensions
{
    public static IHostBuilder AddApplicationServices(this IHostBuilder hostBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

        return hostBuilder.ConfigureServices((context, services) =>
        {
            // Register services with the DI container
            services.AddSingleton<IConfiguration>(configuration) // Add configuration to DI
                .AddSingleton<IOperateRobot, RobotOperations>()
                .AddSingleton<IProcessCommands, CommandProcessor>();
        });
    }
}