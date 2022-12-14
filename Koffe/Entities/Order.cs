using System;
using System.Collections.Generic;

namespace Koffe.Entities;

public partial class Order
{
    public int IdOrder { get; set; }

    public int IdUser { get; set; }

    public float Price { get; set; }
    public DateTime Date { get; set; }

    public virtual ICollection<DishList> DishLists { get; } = new List<DishList>();
}
