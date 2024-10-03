using System.Collections.Generic;
using Avalonia.PoC.Templates;
using DynamicData.Binding;

namespace Avalonia.PoC.ViewModels.Fields;

public interface IFieldGroupViewModel
{
    public string Title { get; }
    public IObservableCollection<IFieldViewModel> Fields { get; }
    public HeadlineTemplate Template { get; }
    public FormViewModel Parent { get; }
    
    // this is for testing removing items
    void HideOrShowSecondField(bool b, TextViewModel textField);
}