using BlackhawksData.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace BlackhawksData;

internal static class ConfigureBlackhawksExtensions
{
    public static IServiceCollection AddBlackhawksData(this IServiceCollection services)
    {
        services
            .AddSingleton<MainWindow>()
            .AddSingleton<IMainWindowViewModel, MainWindowViewModel>();
        
        return services;
    }
}