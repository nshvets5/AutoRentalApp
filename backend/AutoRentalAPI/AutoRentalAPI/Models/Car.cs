using System;
using System.Collections.Generic;

namespace AutoRentalAPI.Models;

public partial class Car
{
    public int CarId { get; set; }

    public string? Model { get; set; }

    public int? YearOfManufacture { get; set; }

    public string? Color { get; set; }

    public string? Condition { get; set; }

    public decimal? PricePerDay { get; set; }

    public bool? Availability { get; set; }

    public int? CarTypeId { get; set; }

    public virtual CarType? CarType { get; set; }

    public virtual ICollection<RentalContract> RentalContracts { get; set; } = new List<RentalContract>();
}
