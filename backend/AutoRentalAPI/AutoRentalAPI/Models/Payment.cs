using System;
using System.Collections.Generic;

namespace AutoRentalAPI.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public DateOnly? PaymentDate { get; set; }

    public decimal? Amount { get; set; }

    public string? PaymentType { get; set; }

    public int? ContractId { get; set; }

    public virtual RentalContract? Contract { get; set; }
}
