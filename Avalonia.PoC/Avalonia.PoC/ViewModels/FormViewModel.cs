using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reactive.Linq;
using Avalonia.Interactivity;
using Avalonia.PoC.Templates;
using Avalonia.PoC.ViewModels.Fields;
using DynamicData;
using DynamicData.Binding;
using ReactiveUI;

namespace Avalonia.PoC.ViewModels;

public class FormViewModel : ViewModelBase
{
    public FormViewModel(string title, List<HeadlineTemplate> fieldGroupTemplates, MainViewModel parent)
    {
        Title = title;
        Parent = parent;
        
        FieldGroupTemplates = new ObservableCollectionExtended<HeadlineTemplate>();
        FieldGroups = new ObservableCollectionExtended<IFieldGroupViewModel>();
        
        var listChangedObservable =
            Observable.FromEventPattern<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>(
                handler => FieldGroupTemplates.CollectionChanged += handler,
                handler => FieldGroupTemplates.CollectionChanged -= handler
            );
        listChangedObservable
            .Select(e => e.EventArgs.NewItems)
            .Subscribe(newItems =>
            {
                if (newItems != null)
                {
                    foreach (var newItem in newItems)
                    {
                        if (newItem is HeadlineTemplate t) CreateHeadline(t);
                    }
                }
            });
        FieldGroupTemplates.AddRange(fieldGroupTemplates);

    }

    public string Title { get; }

    public IObservableCollection<HeadlineTemplate> FieldGroupTemplates { get; }
    public IObservableCollection<IFieldGroupViewModel> FieldGroups { get; }

    public MainViewModel Parent { get; }

    public void AddHeadline(HeadlineTemplate template)
    {
        FieldGroupTemplates.Add(template);
    }

    private void CreateHeadline(HeadlineTemplate template)
    {
        var headline = new HeadlineViewModel(template, this);
        
        var fields = new List<IFieldViewModel>();
        foreach (var f in template.Fields)
        {
            switch (f)
            {
                case "text":
                    fields.Add(new TextViewModel(headline));
                    break;
                case "number":
                    fields.Add(new NumberViewModel(headline));
                    break;
                case "checkbox":
                    fields.Add(new CheckboxViewModel(headline));
                    break;
                case "image":
                    fields.Add(new ImageViewModel(headline));
                    break;
            }
        }
        
        headline.Fields.AddRange(fields);
        FieldGroups.Add(headline);
    }
}