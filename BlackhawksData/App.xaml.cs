using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace BlackhawksData;

public partial class App : Application
{
    private readonly IServiceProvider _serviceProvider;
    
    public App()
    {
        var services = new ServiceCollection();

        _ = services.AddBlackhawksData();
        
        _serviceProvider = services.BuildServiceProvider();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var mainWindow = _serviceProvider.GetService<MainWindow>();
        mainWindow!.Show();
    }
}