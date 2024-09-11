using System.Collections.Generic;

namespace Avalonia.PoC.ViewModels;

public class FormViewModel
{
    public FormViewModel(string title, params string[] fields)
    {
        Title = title;

        foreach (var f in fields)
        {
            Fields.Add(f);
        }
    }
    
    public string Title { get; }
    
    public List<string> Fields { get; } = [];
}