using System;
using System.Collections.Generic;

namespace AutoRentalAPI.Models;

public partial class Client
{
    public int ClientId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? Adress { get; set; }

    public virtual ICollection<RentalContract> RentalContracts { get; set; } = new List<RentalContract>();
}
