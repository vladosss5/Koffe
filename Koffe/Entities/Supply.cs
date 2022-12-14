using System;
using System.Collections.Generic;

namespace Koffe.Entities;

public partial class Supply
{
    public int IdSupply { get; set; }

    public int IdRaw { get; set; }

    public float Count { get; set; }

    public float Sum { get; set; }

    public DateTime Date { get; set; }

    public int IdPurveyor { get; set; }

    public virtual Purveyor IdPurveyorNavigation { get; set; } = null!;

    public virtual Raw IdRawNavigation { get; set; } = null!;
}
