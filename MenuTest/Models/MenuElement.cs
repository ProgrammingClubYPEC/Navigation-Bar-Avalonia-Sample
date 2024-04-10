using System;
using MenuTest.ViewModels;

namespace MenuTest.Models;

public class MenuElement
{
    private Lazy<ViewModelBase> _viewModel;
    public MenuElement(string title, string kind, Func<ViewModelBase> viewModelCreateDelegate)
    {
        Title = title;
        Kind = kind;
        _viewModel = new(viewModelCreateDelegate);
    }
    public string Title { get; }
    public string Kind { get;}
    public ViewModelBase ViewModel => _viewModel.Value;
}