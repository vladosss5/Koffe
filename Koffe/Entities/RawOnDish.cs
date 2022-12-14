using System;
using System.Collections.Generic;

namespace Koffe.Entities;

public partial class RawOnDish
{
    public int IdList { get; set; }

    public int IdDishes { get; set; }

    public float Count { get; set; }

    public int IdRaw { get; set; }

    public virtual Dish IdDishesNavigation { get; set; } = null!;

    public virtual Raw IdRawNavigation { get; set; } = null!;
}
