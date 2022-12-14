using System;
using System.Collections.Generic;

namespace Koffe.Entities;

public partial class Raw
{
    public int IdRaw { get; set; }

    public string Name { get; set; } = null!;

    public float Remainder { get; set; }

    public virtual ICollection<RawOnDish> RawOnDishes { get; } = new List<RawOnDish>();

    public virtual Supply? Supply { get; set; }
}
