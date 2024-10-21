using System;
using System.Collections.Generic;

namespace AutoRentalAPI.Models;

public partial class ConcludingContractsView
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public decimal? TotalAmount { get; set; }

    public string? Status { get; set; }
}
