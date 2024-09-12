using ReactiveUI;

namespace Avalonia.PoC.ViewModels.Fields;

public class TextViewModel(string title) : ViewModelBase, IFieldViewModel
{
    private string _value;

    public TextViewModel(IFieldGroupViewModel parent) : this("Text:")
    {
        Parent = parent;
    }

    public string Title { get; } = title;
    public IFieldGroupViewModel Parent { get; }

    public string Value
    {
        get => _value;
        set
        {
            this.RaiseAndSetIfChanged(ref _value, value);
            Parent.HideOrShowSecondField(value != string.Empty);
            
        }
    }
}