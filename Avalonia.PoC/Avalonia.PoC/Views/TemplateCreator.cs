using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Markup.Xaml.Templates;
using Avalonia.PoC.ViewModels.Fields;

namespace Avalonia.PoC.Views;

public class TemplateCreator : IDataTemplate
{
    public Control? Build(object? param)
    {
        if (param is not HeadlineViewModel headline)
        {
            throw new ArgumentNullException(nameof(param));
        }

        var dataTemplate = new DataTemplate
        {
            Content = new Func<IServiceProvider?, object?>(_ =>
                new TemplateResult<Control>(new HeadlineView { DataContext = headline }, null))
        };
        return dataTemplate.Build(param);
    }

    public bool Match(object? data)
    {
        return data is HeadlineViewModel;
    }
}