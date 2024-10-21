using System;
using System.Collections.Generic;

namespace AutoRentalAPI.Models;

public partial class RentalCountByModelView
{
    public string? Model { get; set; }

    public int? RentalCount { get; set; }
}
