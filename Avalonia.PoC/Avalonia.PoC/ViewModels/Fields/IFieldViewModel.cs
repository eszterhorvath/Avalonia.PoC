namespace Avalonia.PoC.ViewModels.Fields;

public interface IFieldViewModel : IFormPartViewModel
{
    public IFieldGroupViewModel Parent { get; }
}