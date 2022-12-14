using System;
using System.Collections.Generic;

namespace Koffe.Entities;

public partial class User
{
    public int IdUser { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? Patronymic { get; set; }

    public double? HoursWorked { get; set; }

    public string Post { get; set; } = null!;
}
