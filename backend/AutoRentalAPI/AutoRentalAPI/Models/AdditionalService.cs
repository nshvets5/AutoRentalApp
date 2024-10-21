using System;
using System.Collections.Generic;

namespace AutoRentalAPI.Models;

public partial class AdditionalService
{
    public int ServiceId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal PricePerDay { get; set; }

    public virtual ICollection<ServicesContract> ServicesContracts { get; set; } = new List<ServicesContract>();
}
