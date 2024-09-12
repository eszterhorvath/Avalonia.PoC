using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Markup.Xaml.Templates;
using Avalonia.PoC.FieldControls;
using Avalonia.PoC.ViewModels.Fields;

namespace Avalonia.PoC.Views;

public class FieldTemplateSelector : IDataTemplate
{
    private readonly List<string> _controls = ["text", "number", "image", "checkbox"];
    
    public Control? Build(object? param)
    {
        if (param is not IFieldViewModel vm)
        {
            throw new ArgumentNullException(nameof(param));
        }

        Control? template = vm.GetType().Name.Split('.').Last().Replace("ViewModel", "").ToLower() switch
        {
            "text" => new TextFieldControl(),
            "number" => new NumberFieldControl(),
            "checkbox" => new CheckboxFieldControl(),
            "image" => new ImageFieldControl(),
            _ => null
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
        if (data is IFieldViewModel vm)
        {
            var type = vm.GetType().Name.Split('.').Last().Replace("ViewModel", "");
            return _controls.Contains(type, StringComparer.InvariantCultureIgnoreCase);
        }
        return false;
    }
}