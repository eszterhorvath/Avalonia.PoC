using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.PoC.ViewModels.Fields;

namespace Avalonia.PoC.FieldControls;

public partial class CheckboxFieldControl : UserControl
{
    public CheckboxFieldControl()
    {
        InitializeComponent();
        DataContext = new CheckboxViewModel();
    }
    
    private void HideCheckBoxButton_OnClick(object? sender, RoutedEventArgs e)
    {
        if (DataContext is CheckboxViewModel vm)
        {
            vm.IsCheckBoxVisible = !vm.IsCheckBoxVisible;
        }
    }
}