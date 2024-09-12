using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reactive.Linq;
using Avalonia.PoC.Templates;
using DynamicData;
using DynamicData.Binding;
using ReactiveUI;

namespace Avalonia.PoC.ViewModels.Fields;

public class HeadlineViewModel : ViewModelBase, IFieldGroupViewModel
{
    private bool _isExpanded;

    public HeadlineViewModel(HeadlineTemplate template, FormViewModel form)
    {
        Title = template.Title;
        Template = template;
        Parent = form;
        
        Fields = new ObservableCollectionExtended<IFieldViewModel>();
        VisibleFields = new ObservableCollectionExtended<IFieldViewModel>(Fields);
        
        var listChangedObservable =
            Observable.FromEventPattern<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>(
                handler => Fields.CollectionChanged += handler,
                handler => Fields.CollectionChanged -= handler
            );
        listChangedObservable
            .Select(e => e.EventArgs.NewItems)
            .Subscribe(newItems =>
            {
                if (newItems != null)
                {
                    foreach (var newItem in newItems)
                    {
                        if (newItem is IFieldViewModel t) VisibleFields.Add(t);
                    }
                }
            });
        
        IsExpanded = template.IsExpandedByDefault;
        CanRepeat = template.CanRepeat;
    }
    
    public string Title { get; }
    public IObservableCollection<IFieldViewModel> Fields { get; }
    public IObservableCollection<IFieldViewModel> VisibleFields { get;}
    public HeadlineTemplate Template { get; }
    public FormViewModel Parent { get; }
    public bool CanRepeat { get; }

    public bool IsExpanded
    {
        get => _isExpanded;
        private set => this.RaiseAndSetIfChanged(ref _isExpanded, value);
    }

    public void ExpandCollapseHeadline()
    {
        if (IsExpanded)
        {
            VisibleFields.Clear();
            IsExpanded = false;
        }
        else
        {
            VisibleFields.AddRange(Fields);
            IsExpanded = true;
        }
    }
    
    public void Expand()
    {
        if (!IsExpanded)
        {
            VisibleFields.AddRange(Fields);
            IsExpanded = true;
        }
    }
    
    public void Collapse()
    {
        if (IsExpanded)
        {
            VisibleFields.Clear();
            IsExpanded = false;
        }
    }

    public void Repeat()
    {
        var t = Template.Repeat();
        Parent.AddHeadline(t);
    }

    private bool _isSecondHidden = false;
    public void HideOrShowSecondField(bool hide)
    {
        if (hide)
        {
            if (_isSecondHidden) return;
            
            VisibleFields.RemoveAt(1);
            _isSecondHidden = true;
        }
        else
        {
            VisibleFields.Clear();
            VisibleFields.AddRange(Fields);
            _isSecondHidden = false;
        }
    }
}