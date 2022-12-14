using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using Avalonia.Controls;
using Koffe.Entities;
using Koffe.Views;
using ReactiveUI;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Avalonia.Interactivity;
using DynamicData.Kernel;
using MessageBox.Avalonia;
using MessageBox.Avalonia.Enums;
using MessageBox.Avalonia.ViewModels.Commands;
using Microsoft.CodeAnalysis;

namespace Koffe.ViewModels;

public class Seller : ViewModelBase
{
    private ObservableCollection<Dish> _dish;
    private ObservableCollection<Order> _order;
    private ObservableCollection<DishList> _dishList = new ObservableCollection<DishList>();
    public RelayCommand AddNewDish { get; set; }
    private Dish _dishAddInOrder;
    private ObservableCollection<Dish> _ordering = new ObservableCollection<Dish>();
    private Dish _count;
    // public Dictionary<Order, List<Dish>> OrderDishes = new Dictionary<Order, List<Dish>>();

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
    public ObservableCollection<DishList> DishLists
    {
        get => _dishList;
        set => this.RaiseAndSetIfChanged(ref _dishList, value);
    }
    
    public Dish DishAddInOrder //свойство выбранного блюда на добавление
    {
        get
        {
            return _dishAddInOrder;
        }
        set
        {
            _dishAddInOrder = value;
            // MethodAddDishInOrder(_dishAddInOrder); //вызов метода на добавление выбранного блюда в заказ
            _dishAddInOrder = null;
            // this.RaiseAndSetIfChanged(); 
        }
    }

    // public ObservableCollection<Dish> Ordering
    // {
    //     get => _ordering;
    //     set => this.RaiseAndSetIfChanged(ref _ordering, value);
    // }
    
    public ReactiveCommand<Window, Unit> ButtonProfile { get; }
    public ReactiveCommand<Window, Unit> ButtonCreateOrder { get; }
    // public ReactiveCommand<Unit, Unit> AddDishPreorder { get; }

    public Seller()
    {
        ButtonProfile = ReactiveCommand.Create<Window>(OpenProfileWindow);
        ButtonCreateOrder = ReactiveCommand.Create<Window>(CreateOrder);
        // AddDishPreorder = ReactiveCommand.Create(DishChecking);

        Dish = new ObservableCollection<Dish>(Helper.GetContext().Dishes.ToList());
        Order = new ObservableCollection<Order>(Helper.GetContext().Orders.ToList());

        // foreach (var OrderDishes1 in _dishList)
        // {
        //     if (OrderDishes.Keys.Any(x => x.IdOrder == OrderDishes1.IdOrder))
        //     {
        //         continue;
        //     }
        //     var Order1 = Order.FirstOrDefault(x => x.IdOrder == OrderDishes1.IdOrder);
        //     var Dishes1 = Dish.Where(x => Order1.IdOrder == OrderDishes1.IdOrder).ToList();
        //     OrderDishes.Add(Order1, Dishes1);
        // }
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
    
    // public void MethodAddDishInOrder(Dish dishAddInOrder) //добавление нового блюда к заказу
    // {
    //     var duplicateDish = SelectedDishs.SingleOrDefault(x => x.Dish == dishAddInOrder); //ищем дупликат если он есть
    //     if (duplicateDish == null) //дупликата нет
    //     {
    //         SelectedDishs.Add(new DishsOrder { Dish = dishAddInOrder, CountDishs = 1 }); //создаем экземляр и добовляем его в заказ, приравнивая его блюдо в выбранному блюдо и  задаем его количесто на 1
    //     }
    //     else //дупликат есть
    //     {
    //         duplicateDish.CountDishs++; //ничего не добавляем, а просто увеличиваем количество блюд в этом дупликате на один
    //     }
    // }
} 