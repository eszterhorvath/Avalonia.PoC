using ReactiveUI;

namespace Avalonia.PoC.ViewModels.Fields;

public class CheckboxViewModel(string title) : ViewModelBase, IFieldViewModel
{
    private bool _isCheckboxVisible = true;

    public CheckboxViewModel(IFieldGroupViewModel parent) : this("Checkbox:")
    {
        Parent = parent;
    }

    public string Title { get; } = title;
    public IFieldGroupViewModel Parent { get; }

    public bool IsCheckBoxVisible
    {
        get => _isCheckboxVisible;
        set => this.RaiseAndSetIfChanged(ref _isCheckboxVisible, value);
    }
}