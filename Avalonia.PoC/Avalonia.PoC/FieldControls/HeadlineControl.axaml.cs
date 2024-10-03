using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.PoC.ViewModels.Fields;

namespace Avalonia.PoC.FieldControls;

public partial class HeadlineControl : UserControl
{
    public HeadlineControl()
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
            vm.Parent.ExpandCollapseHeadline(vm);
        }
    }
}