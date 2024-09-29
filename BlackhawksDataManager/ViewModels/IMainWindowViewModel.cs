using System.Windows.Input;

namespace BlackhawksData.ViewModels;

public interface IMainWindowViewModel
{
    string VersionString { get; }
    
    string CurrentSeason { get; set;  }
    
    ICommand ExitCommand { get; }
}