using System.Collections.Generic;
using System.ComponentModel;
using Avalonia.Controls.Templates;
using Avalonia.PoC.Views;
using ReactiveUI;

namespace Avalonia.PoC.ViewModels;

public class MainViewModel : ViewModelBase, INotifyPropertyChanged
{
    private bool _isCheckboxVisible = true;

    public MainViewModel()
    {
        Fields.Add("text");
        Fields.Add("checkbox");
        Fields.Add("number");
        Fields.Add("checkbox");
    }

    public string Greeting => "Welcome to Avalonia.PoC!";

    public bool IsCheckBoxVisible
    {
        get => _isCheckboxVisible;
        set
        {
            if (_isCheckboxVisible == value) return;

            _isCheckboxVisible = value;
            this.RaisePropertyChanged();
        }
    }
    public List<string> Fields { get; } = [];
}