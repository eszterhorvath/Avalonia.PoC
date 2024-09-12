namespace Avalonia.PoC.ViewModels.Fields;

public class NumberViewModel(string title) : ViewModelBase, IFieldViewModel
{
    public NumberViewModel(IFieldGroupViewModel parent) : this("Number:")
    {
        Parent = parent;
    }
    
    public string Title { get; } = title;
    public IFieldGroupViewModel Parent { get; }
}