using System;
using System.Collections.Generic;
using Avalonia.PoC.Templates;

namespace Avalonia.PoC.ViewModels;

public class FormSelectionViewModel : ViewModelBase
{
    public FormSelectionViewModel(MainViewModel parent)
    {
        Parent = parent;
        SetupForms();
    }
    
    public string Greeting => "Welcome to Avalonia.PoC!";

    public List<FormViewModel> AvailableForms { get; } = [];
    public MainViewModel Parent { get; }

    public void NavigateBack()
    {
        Parent.CurrentPage = this;
    }

    private void SetupForms()
    {
        var form1Headlines = new List<HeadlineTemplate>
        {
            new()
            {
                Title = "The one and only headline", Fields = ["text", "number", "checkbox", "image"], CanRepeat = false
            }
        };
        AvailableForms.Add(new FormViewModel("Form1", form1Headlines, this));

        var form2Headlines = new List<HeadlineTemplate>
        {
            new() { Title = "Headline 1", Fields = ["text", "number", "checkbox", "image"] },
            new() { Title = "Headline 2", Fields = ["image", "number", "checkbox", "text", "text"] }
        };
        AvailableForms.Add(new FormViewModel("Form2", form2Headlines, this));
        
        var hundredRandomFields = new List<string>();
        var r = new Random();
        string[] fields = ["text", "number", "checkbox", "image"];
        for (var i = 0; i < 100; i++)
        {
            var x = r.Next(0, 4);
            hundredRandomFields.Add(fields[x]);
        }

        var form3Headlines = new List<HeadlineTemplate>
        {
            new() { Title = "Headline 1", Fields = hundredRandomFields, IsExpandedByDefault = false },
            new() { Title = "Headline 2", Fields = hundredRandomFields, IsExpandedByDefault = false },
            new() { Title = "Headline 3", Fields = hundredRandomFields, IsExpandedByDefault = false },
            new() { Title = "Headline 4", Fields = hundredRandomFields, IsExpandedByDefault = false },
            new() { Title = "Headline 5", Fields = hundredRandomFields, IsExpandedByDefault = false }
        };
        AvailableForms.Add(new FormViewModel("Form3", form3Headlines, this));
    }
}