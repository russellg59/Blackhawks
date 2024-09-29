using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace BlackhawksData;

public partial class App : Application
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger _logger;

    public App()
    {
        var services = new ServiceCollection();
        _ = services.AddBlackhawksDataManager();
        
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        ConfigureLogging(config);
        
        _logger = Log.ForContext<App>();
        _logger.Information("Application starting...");
        
        _serviceProvider = services.BuildServiceProvider();
        _logger.Information("Built service provider");
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var mainWindow = _serviceProvider.GetService<MainWindow>();
        _logger.Information("Showing main window...");   
        mainWindow!.Show();
        _logger.Information("Main window shown");
        _logger.Information("Application started successfully");
    }

    protected override void OnExit(ExitEventArgs e)
    {
        _logger.Information("Application exiting...");
        base.OnExit(e);
        _logger.Information("Application exited successfully");
    }
    

    private static void ConfigureLogging(IConfigurationRoot config)
    {
        Log.Logger = new LoggerConfiguration()
            .Enrich.WithThreadId()
            .ReadFrom.Configuration(config)
            .CreateLogger();
    }
}