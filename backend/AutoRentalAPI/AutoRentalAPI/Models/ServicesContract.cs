using System;
using System.Collections.Generic;

namespace AutoRentalAPI.Models;

public partial class ServicesContract
{
    public int ServiceContractId { get; set; }

    public int? ContractId { get; set; }

    public int? ServiceId { get; set; }

    public virtual RentalContract? Contract { get; set; }

    public virtual AdditionalService? Service { get; set; }
}
