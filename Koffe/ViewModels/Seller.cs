using System.Collections.ObjectModel;
using System.Reactive;
using Avalonia.Controls;
using Koffe.Entities;
using Koffe.Views;
using ReactiveUI;
using System.Linq;
using MessageBox.Avalonia.ViewModels.Commands;

namespace Koffe.ViewModels;

public class Seller : ViewModelBase
{
    private ObservableCollection<Dish> _dish;
    private ObservableCollection<Order> _order;
    // private Order _order = new Order();
    private static ObservableCollection<Dish> _dishList = new ObservableCollection<Dish>();
    public RelayCommand AddNewDish { get; set; }
    public static ObservableCollection<Dish> Dishes => _dishList;
    private Dish _dishAddInOrder;
    private ObservableCollection<Dish> _ordering = new ObservableCollection<Dish>();
    private Dish _count;

    public ObservableCollection<Dish> Dish
    {
        get => _dish;
        set => this.RaiseAndSetIfChanged(ref _dish, value);
    }

    public ObservableCollection<Order> Order
    {
        get => _order;
        set => this.RaiseAndSetIfChanged(ref _order, value);
    }

    public ObservableCollection<Dish> DishLists
    {
        get => _dishList;
        set => this.RaiseAndSetIfChanged(ref _dishList, value);
    }

    public ReactiveCommand<Window, Unit> ButtonProfile { get; }
    public ReactiveCommand<Window, Unit> ButtonCreateOrder { get; }

    public Seller()
    {
        ButtonProfile = ReactiveCommand.Create<Window>(OpenProfileWindow);
        ButtonCreateOrder = ReactiveCommand.Create<Window>(CreateOrder);

        Dish = new ObservableCollection<Dish>(Helper.GetContext().Dishes.ToList());
        Order = new ObservableCollection<Order>(Helper.GetContext().Orders.ToList());
    }

    private void OpenProfileWindow(Window obj)
    {
        ProfileWindow profile_window = new ProfileWindow();
        profile_window.Show();
    }

    private void CreateOrder(Window obj)
    {
        ProfileWindow profile_window = new ProfileWindow();
        profile_window.Show();
    }

    private void DishChecking()
    {
        ProfileWindow profile_window = new ProfileWindow();
        profile_window.Show();
    }

    public void AddDishPreorderImpl(Dish dish)
    {
        var edentity = _dishList.SingleOrDefault(x => x.Name == dish.Name);
        if (edentity == null)
        {
            _dishList.Add(new Dish
            {
                IdDish = dish.IdDish,
                Name = dish.Name,
                Price = dish.Price * dish.Count,
                Count = dish.Count
            });
        }
        else
        {
            _dishList.Remove(edentity);
            _dishList.Add(new Dish
            {
                IdDish = dish.IdDish,
                Name = dish.Name,
                Price = dish.Price * dish.Count,
                Count = dish.Count
            });
        }
    }

    public void RemoveDishPreorderImpl(Dish dish)
    {
        _dishList.Remove(dish);
    }
}