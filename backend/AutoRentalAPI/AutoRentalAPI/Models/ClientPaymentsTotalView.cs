using System;
using System.Collections.Generic;

namespace AutoRentalAPI.Models;

public partial class ClientPaymentsTotalView
{
    public int ClientId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public decimal? TotalPayments { get; set; }
}
