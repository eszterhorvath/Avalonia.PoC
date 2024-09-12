using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.PoC.ViewModels;

namespace Avalonia.PoC.Views;

public partial class FormView : UserControl
{
    public FormView()
    {
        InitializeComponent();
    }

    private void BackButton_OnClick(object? sender, RoutedEventArgs e)
    {
        if (DataContext is FormViewModel vm)
        {
            vm.Parent.NavigateBack();
        }
    }
}