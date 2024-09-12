using ReactiveUI;

namespace Avalonia.PoC.ViewModels.Fields;

public class ImageViewModel(string title) : ViewModelBase, IFieldViewModel
{
    private bool _isImageVisible;

    public ImageViewModel(IFieldGroupViewModel parent) : this("Image:")
    {
        Parent = parent;
    }
    
    public string Title { get; } = title;
    public IFieldGroupViewModel Parent { get; }

    public bool IsImageVisible
    {
        get => _isImageVisible;
        set => this.RaiseAndSetIfChanged(ref _isImageVisible, value);
    }
}