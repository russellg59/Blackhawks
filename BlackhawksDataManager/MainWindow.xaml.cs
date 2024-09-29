using System.Windows;
using BlackhawksData.ViewModels;

namespace BlackhawksData;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(IMainWindowViewModel viewModel)
    {
        DataContext = viewModel;
        InitializeComponent();
    }
}