using System.Collections.Generic;

namespace Avalonia.PoC.ViewModels;

public class FormViewModel : ViewModelBase
{
    public FormViewModel(string title, Dictionary<string, List<string>> fieldGroups, MainViewModel parent)
    {
        Title = title;
        FieldGroups = fieldGroups;
        Parent = parent;
    }
    
    public string Title { get; }
    
    public new Dictionary<string, List<string>> FieldGroups { get; }
    
    public MainViewModel Parent { get; }
}