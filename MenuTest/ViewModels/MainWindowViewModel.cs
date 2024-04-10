using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using MenuTest.Models;
using ReactiveUI;

namespace MenuTest.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private bool _isOpenPane; // состояние боковой панели
    private MenuElement _selectedMenuElement; //выбранный пункт меню
    public IList<MenuElement> MenuElements { get; } //пункты меню
    public MainWindowViewModel()
    {
        MenuElements = new List<MenuElement>()
        {
            new("DashBoard", "HomeAccount",()=>new DashBoardViewModel()),
            new("Messages","EmailMultipleOutline", () => new MessagesViewModel())
        };
        this.WhenAnyValue(x => x.SelectedMenuElement)
            .Where(x=>x !=null)
            .Subscribe(x => IsOpenPane = true);
    }
    public MenuElement SelectedMenuElement
    {
        get => _selectedMenuElement;
        set => this.RaiseAndSetIfChanged(ref _selectedMenuElement, value);
    }
    public bool IsOpenPane
    {
        get => _isOpenPane;
        set => this.RaiseAndSetIfChanged(ref _isOpenPane, value);
    }
}