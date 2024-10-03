using System.ComponentModel;
using ReactiveUI;

namespace Avalonia.PoC.ViewModels;

public class MainViewModel : ViewModelBase
{
    private static ViewModelBase _currentPage = null!;

    public MainViewModel()
    {
        CurrentPage = new FormSelectionViewModel(this);
    }

    
    public ViewModelBase CurrentPage
    {
        get => _currentPage;
        set => this.RaiseAndSetIfChanged(ref _currentPage, value);
    }
}