using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.PoC.ViewModels.Fields;

namespace Avalonia.PoC.Views;

public partial class HeadlineView : UserControl
{
    public HeadlineView()
    {
        InitializeComponent();
    }

    private void Repeat(object? sender, PointerPressedEventArgs e)
    {
        if (DataContext is HeadlineViewModel vm)
        {
            vm.Repeat();
        }
        
        // mark the event as handled to stop it from reaching the parent Grid's ExpandCollapseHeadline
        e.Handled = true;
    }

    private void ExpandCollapseHeadline(object? sender, PointerPressedEventArgs e)
    {
        if (DataContext is HeadlineViewModel vm)
        {
            vm.ExpandCollapseHeadline();
        }
    }
}