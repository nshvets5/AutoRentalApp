using System;
using System.Collections.Generic;

namespace AutoRentalAPI.Models;

public partial class RentalContract
{
    public int ContractId { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public decimal? TotalAmount { get; set; }

    public string? Status { get; set; }

    public int? ClientId { get; set; }

    public int? CarId { get; set; }

    public virtual Car? Car { get; set; }

    public virtual Client? Client { get; set; }

    public virtual Payment? Payment { get; set; }

    public virtual ICollection<ServicesContract> ServicesContracts { get; set; } = new List<ServicesContract>();
}
