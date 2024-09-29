using BlackhawksData.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlackhawksData;

internal static class ConfigureBhdExtensions
{
    public static IServiceCollection AddBlackhawksDataManager(this IServiceCollection services, IConfiguration config)
    {
        services
            .AddSingleton<MainWindow>()
            .AddSingleton<IMainWindowViewModel, MainWindowViewModel>()
            .AddSingleton(config);
        
        return services;
    }
}