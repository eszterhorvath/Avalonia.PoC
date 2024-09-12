namespace Avalonia.PoC.ViewModels.Fields;

public interface IFieldViewModel
{
    public string Title { get; }
    public IFieldGroupViewModel Parent { get; }
}