using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Layout;
using Avalonia.Markup.Xaml.Templates;
using Avalonia.PoC.FieldControls;
using Avalonia.PoC.ViewModels.Fields;

namespace Avalonia.PoC.Views;

public class TemplateCreator : IDataTemplate
{
    private readonly List<string> _controls = ["text", "number", "image", "checkbox"];

    public Control? Build(object? param)
    {
        if (param is not KeyValuePair<string, List<string>> headline)
        {
            throw new ArgumentNullException(nameof(param));
        }

        var fieldTemplatesStackPanel = new StackPanel();
        foreach (var fieldTemplate in headline.Value)
        {
            fieldTemplatesStackPanel.Children.Add(GetFieldInstance(fieldTemplate));
        }
        var template = new Expander
        {
            Header = headline.Key,
            Content = fieldTemplatesStackPanel,
            HorizontalAlignment = HorizontalAlignment.Stretch,
            IsExpanded = true
        };

        var dataTemplate = new DataTemplate
        {
            Content = new Func<IServiceProvider?, object?>(_ =>
                new TemplateResult<Control>(template, null))
        };
        return dataTemplate.Build(param);
    }

    public bool Match(object? data)
    {
        if (data is KeyValuePair<string, List<string>> headline)
        {
            return headline.Value.All(f => _controls.Contains(f));
        }
        return false;
    }

    private Control GetFieldInstance(string key)
    {
        switch (key)
        {
            case "text":
            default:
                return new TextFieldControl();
            case "number":
                return new NumberFieldControl();
            case "checkbox":
                return new CheckboxFieldControl
                {
                    DataContext = new CheckboxViewModel()
                };
            case "image":
                return new ImageFieldControl
                {
                    DataContext = new ImageViewModel()
                };
        }
    }
}