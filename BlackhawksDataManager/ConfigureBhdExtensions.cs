using BlackhawksData.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace BlackhawksData;

internal static class ConfigureBhdExtensions
{
    public static IServiceCollection AddBlackhawksDataManager(this IServiceCollection services)
    {
        services
            .AddSingleton<MainWindow>()
            .AddSingleton<IMainWindowViewModel, MainWindowViewModel>();
        
        return services;
    }
}