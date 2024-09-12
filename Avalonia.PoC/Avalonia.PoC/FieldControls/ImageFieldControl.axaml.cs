using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.PoC.ViewModels.Fields;

namespace Avalonia.PoC.FieldControls;

public partial class ImageFieldControl : UserControl
{
    public ImageFieldControl()
    {
        InitializeComponent();
    }
    
    protected override async void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);

        if (DataContext is ImageViewModel vm)
        {
            // imitate loading image
            await Task.Delay(TimeSpan.FromSeconds(3));
            vm.IsImageVisible = true;
        }
    }
}