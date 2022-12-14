using System;
using System.Collections.Generic;

namespace Koffe.Entities;

public partial class Purveyor
{
    public int IdPurveyor { get; set; }

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual ICollection<Supply> Supplies { get; } = new List<Supply>();
}
