using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reactive;
using Koffe.ViewModels;
using Koffe.Views;
using ReactiveUI;

namespace Koffe.Entities;

public partial class Dish : ViewModelBase
{
    public int IdDish { get; set; }
    public string Name { get; set; }

    public float Price { get; set; }
    
    [NotMapped] public int Count { get; set; }

    public ReactiveCommand<Unit, Unit> AddDishPreorder { get; }
    
    public Dish()
    {
        AddDishPreorder = ReactiveCommand.Create(DishChecking);
    }
    
    private void DishChecking()
    { 
        ProfileWindow profile_window = new ProfileWindow();
        profile_window.Show();
    }
    public virtual ICollection<DishList> DishLists { get; } = new List<DishList>();

    public virtual ICollection<RawOnDish> RawOnDishes { get; } = new List<RawOnDish>();
}