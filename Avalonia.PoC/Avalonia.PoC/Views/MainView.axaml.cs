using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.PoC.ViewModels;

namespace Avalonia.PoC.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    private void HideCheckBoxButton_OnClick(object? sender, RoutedEventArgs e)
    {
        if (DataContext is MainViewModel vm)
        {
            vm.IsCheckBoxVisible = !vm.IsCheckBoxVisible;
        }
    }
}