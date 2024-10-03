using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.PoC.ViewModels;

namespace Avalonia.PoC.Views;

public partial class FormSelectionView : UserControl
{
    public FormSelectionView()
    {
        InitializeComponent();
    }
    
    private void OpenButton_OnClick(object? sender, RoutedEventArgs e)
    {
        if (DataContext is FormSelectionViewModel vm && sender is Button { DataContext: FormViewModel fvm })
        {
            vm.Parent.CurrentPage = fvm;
        }
    }
}