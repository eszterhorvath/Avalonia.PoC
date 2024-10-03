using System;
using System.Collections.Specialized;
using System.Reactive.Linq;
using Avalonia.PoC.Templates;
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
                        if (newItem is IFieldViewModel { Parent: HeadlineViewModel { IsExpanded: true } } t) Parent.VisibleFields.Add(t);
                    }
                }
            });
        
        IsExpanded = template.IsExpandedByDefault;
        CanRepeat = template.CanRepeat;
    }
    
    public string Title { get; }
    public IObservableCollection<IFieldViewModel> Fields { get; }
    public HeadlineTemplate Template { get; }
    public FormViewModel Parent { get; }

    public bool CanRepeat { get; }

    public bool IsExpanded
    {
        get => _isExpanded;
        internal set => this.RaiseAndSetIfChanged(ref _isExpanded, value);
    }

    public void Repeat()
    {
        var t = Template.Repeat();
        Parent.AddHeadline(t);
    }
    
    public void HideOrShowSecondField(bool b, TextViewModel textField)
    {
        Parent.HideOrShowNextField(b, textField);
    }
}