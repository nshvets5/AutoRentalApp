using System;
using System.Collections.Generic;

namespace AutoRentalAPI.Models;

public partial class CarType
{
    public int CarTypeId { get; set; }

    public string? Category { get; set; }

    public string? BodyType { get; set; }

    public int? SeatingCapacity { get; set; }

    public string? Brand { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
