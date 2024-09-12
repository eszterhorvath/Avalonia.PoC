using ReactiveUI;

namespace Avalonia.PoC.ViewModels.Fields;

public class ImageViewModel(string title) : ViewModelBase, IFieldViewModel
{
    private bool _isImageVisible;

    public ImageViewModel() : this("Checkbox:") { }
    
    public string Title { get; } = title;

    public bool IsImageVisible
    {
        get => _isImageVisible;
        set => this.RaiseAndSetIfChanged(ref _isImageVisible, value);
    }
}