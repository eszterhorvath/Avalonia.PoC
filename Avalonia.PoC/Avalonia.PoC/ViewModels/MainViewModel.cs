using System.Collections.Generic;
using ReactiveUI;

namespace Avalonia.PoC.ViewModels;

public class MainViewModel : ViewModelBase
{
    public ViewModelBase _currentPage;

    public MainViewModel()
    {
        CurrentPage = this;
        SetupForms();
    }

    public ViewModelBase CurrentPage
    {
        get => _currentPage;
        set => this.RaiseAndSetIfChanged(ref _currentPage, value);
    }

    public string Greeting => "Welcome to Avalonia.PoC!";

    public List<FormViewModel> AvailableForms { get; } = [];

    public void NavigateBack()
    {
        CurrentPage = this;
    }

    private void SetupForms()
    {
        var form1Fields = new Dictionary<string, List<string>>
        {
            {"Headline 1", ["text", "checkbox", "text", "number"]},
            {"Headline 2", ["text", "number"]}
        };
        AvailableForms.Add(new FormViewModel("Form1", form1Fields, this));
        
        var form2Fields = new Dictionary<string, List<string>>
        {
            {"Headline 1", ["text", "number", "checkbox", "image"]},
            {"Headline 2", ["image", "number", "checkbox", "text", "text"]}
        };
        AvailableForms.Add(new FormViewModel("Form2", form2Fields, this));
        
        var hundredTextFields = new List<string>();
        for (int i = 0; i < 100; i++)
        {
            hundredTextFields.Add("text");
        }
        var form3Fields = new Dictionary<string, List<string>>
        {
            {"Headline 1", hundredTextFields},
            {"Headline 2", hundredTextFields},
            {"Headline 3", hundredTextFields},
            {"Headline 4", hundredTextFields},
            {"Headline 5", hundredTextFields}
        };
        AvailableForms.Add(new FormViewModel("Form3", form3Fields, this));
    }
}