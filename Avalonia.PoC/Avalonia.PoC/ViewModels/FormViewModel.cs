using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reactive.Linq;
using Avalonia.PoC.Templates;
using Avalonia.PoC.ViewModels.Fields;
using DynamicData;
using DynamicData.Binding;

namespace Avalonia.PoC.ViewModels;

public class FormViewModel : ViewModelBase, IFormViewModel
{
    public FormViewModel(string title, List<HeadlineTemplate> fieldGroupTemplates, FormSelectionViewModel parent)
    {
        Title = title;
        Parent = parent;
        
        FieldGroupTemplates = new ObservableCollectionExtended<HeadlineTemplate>();
        FieldGroups = new ObservableCollectionExtended<IFieldGroupViewModel>();
        VisibleFields = new ObservableCollectionExtended<IFormPartViewModel>();
        
        var headlineTemplatesListChangedObservable =
            Observable.FromEventPattern<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>(
                handler => FieldGroupTemplates.CollectionChanged += handler,
                handler => FieldGroupTemplates.CollectionChanged -= handler
            );
        headlineTemplatesListChangedObservable
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
    public ObservableCollectionExtended<IFormPartViewModel> VisibleFields { get;}

    public FormSelectionViewModel Parent { get; }
    
    public void ExpandCollapseHeadline(HeadlineViewModel headline)
    {
        if (headline.IsExpanded)
        {
            var toRemove = VisibleFields.Where(f => f is IFieldViewModel field && field.Parent == headline);
            VisibleFields.RemoveMany(toRemove);
            headline.IsExpanded = false;
        }
        else
        {
            // IF ADDING A LOT OF FIELDS IS SLOW:
            // IF COUNT > 25: SUSPEND NOTIFICATIONS => RESET
            //var count = headline.Fields.Count;
            //using var _ = VisibleFields.SuspendNotifications();
            
            var headlineIndex = VisibleFields.IndexOf(headline);
            VisibleFields.InsertRange(headline.Fields, headlineIndex + 1);
            headline.IsExpanded = true;
        }
    }
    
    public void AddHeadline(HeadlineTemplate template)
    {
        FieldGroupTemplates.Add(template);
    }

    private void CreateHeadline(HeadlineTemplate template)
    {
        var headline = new HeadlineViewModel(template, this);
        VisibleFields.Add(headline);
        
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
    
    // this imitates scripted IsVisible on next field
    private bool _isNextHidden;
    private IFieldViewModel _hiddenField;
    public void HideOrShowNextField(bool hide, TextViewModel textField)
    {
        var index = VisibleFields.IndexOf(textField) + 1;
        if (hide)
        {
            if (_isNextHidden) return;
            
            var next = VisibleFields[index];
            // if textField is last field of headline, next is a headline which cannot be hidden
            if (next is not IFieldViewModel nextField) return;
            _hiddenField = nextField;
            VisibleFields.Remove(_hiddenField);
            _isNextHidden = true;
        }
        else
        {
            VisibleFields.Insert(index, _hiddenField);
            _isNextHidden = false;
        }
    }
}