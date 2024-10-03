using Avalonia.PoC.ViewModels.Fields;
using DynamicData.Binding;

namespace Avalonia.PoC.ViewModels;

public interface IFormViewModel : IFormPartViewModel
{
    public ObservableCollectionExtended<IFormPartViewModel> VisibleFields { get; }
    
    // this is for testing removing items
    void HideOrShowNextField(bool b, TextViewModel textField);
}