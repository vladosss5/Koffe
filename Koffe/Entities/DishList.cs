using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reactive;
using Koffe.ViewModels;
using Koffe.Views;
using ReactiveUI;

namespace Koffe.Entities;

public partial class DishList: ViewModelBase
{
    private Dish _dish;
    private int _count_dish;
    public Dish Dish
    {
        get => _dish;
        set
        {
            _dish = value;
            this.RaisePropertyChanged();
        }
    }
    public int CountDishs
    {
        get => _count_dish;
        set
        {
            _count_dish = value;
            this.RaisePropertyChanged();
        }
    }
    public int IdList { get; set; }

    public int IdOrder { get; set; }

    public int IdDish { get; set; }

    public virtual Dish IdDishNavigation { get; set; } = null!;

    public virtual Order IdOrderNavigation { get; set; } = null!;
}
