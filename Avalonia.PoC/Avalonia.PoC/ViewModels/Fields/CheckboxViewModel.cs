using System;
using System.Collections.Generic;
using ReactiveUI;

namespace Avalonia.PoC.ViewModels.Fields;

public class CheckboxViewModel(string title) : ViewModelBase, IFieldViewModel
{
    private bool _isCheckboxVisible = true;

    public CheckboxViewModel(IFieldGroupViewModel parent) : this("Checkbox:")
    {
        Parent = parent;

        // randomize checkbox options
        Options = new List<string>();
        var r = new Random();
        var numberOfOptions =  r.Next(3, 20);
        for (var i = 1; i < numberOfOptions; i++)
        {
            Options.Add($"Option {i}");
        }
    }

    public List<string> Options { get; }
    public string Title { get; } = title;
    public IFieldGroupViewModel Parent { get; }

    public bool IsCheckBoxVisible
    {
        get => _isCheckboxVisible;
        set => this.RaiseAndSetIfChanged(ref _isCheckboxVisible, value);
    }
}