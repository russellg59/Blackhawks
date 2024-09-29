using System.Reflection;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Configuration;

namespace BlackhawksData.ViewModels;

public partial class MainWindowViewModel : ObservableObject, IMainWindowViewModel
{
    public MainWindowViewModel(IConfiguration configuration)
    {
        _currentSeason = configuration["DataManager:DefaultSeason"] ?? "unknown";
    }
    
    public string VersionString { get; } = GetVersion();
    
    public ICommand ExitCommand { get; } = new RelayCommand(() => Application.Current.Shutdown());

    [ObservableProperty] private string _currentSeason;

    private static string GetVersion()
    {
        var version = Assembly.GetExecutingAssembly()?.GetName()?.Version ?? default;

        return version is not null 
            ? $"{version.Major}.{version.Minor}.{version.Build}.{version.Revision}" 
            : "unknown";
    }
}