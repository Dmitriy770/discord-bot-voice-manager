using DiscordBot.Api.Services;

namespace DiscordBot.Api;

class Program
{
    public static Task Main(string[] args)
    {
        var host = Host
            .CreateDefaultBuilder(args)
            .ConfigureServices(
                (hostBuilderContext, serviceCollection) =>
                    new Startup(hostBuilderContext.Configuration).ConfigureServices(serviceCollection)
            ).Build();

        host.Services.GetService<StartupService>()?.RunAsync();
        host.Services.GetService<LogService>()?.Run();

        return host.RunAsync();
    }
}