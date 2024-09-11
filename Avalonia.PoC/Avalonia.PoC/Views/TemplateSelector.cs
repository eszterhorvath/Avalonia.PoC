using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Markup.Xaml.Templates;
using Avalonia.PoC.FieldControls;

namespace Avalonia.PoC.Views;

public class TemplateSelector : IDataTemplate
{
    private readonly Dictionary<string, IDataTemplate> _templates = new()
    {
        { "text", new DataTemplate { Content = new Func<IServiceProvider?, object?>(_ => new TemplateResult<Control>(new TextFieldControl(), null)) } },
        { "number", new DataTemplate { Content = new Func<IServiceProvider?, object?>(_ => new TemplateResult<Control>(new NumberFieldControl(), null)) } },
        { "image", new DataTemplate { Content = new Func<IServiceProvider?, object?>(_ => new TemplateResult<Control>(new ImageFieldControl(), null)) } },
        { "checkbox", new DataTemplate { Content = new Func<IServiceProvider?, object?>(_ => new TemplateResult<Control>(new CheckboxFieldControl(), null)) } }
    };

    public Control? Build(object? param)
    {
        var key = param?.ToString();
        if (key is null)
        {
            throw new ArgumentNullException(nameof(param));
        }
        return _templates[key].Build(param);
    }

    public bool Match(object? data)
    {
        var key = data?.ToString();
        if (key == null) return false;

        return _templates.ContainsKey(key);
    }
}