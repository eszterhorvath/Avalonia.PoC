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

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        if (DataContext is MainViewModel vm && sender is Button { DataContext: FormViewModel fvm })
        {
            vm.CurrentPage = fvm;
        }
    }
}