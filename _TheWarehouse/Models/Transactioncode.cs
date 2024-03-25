using System;
using System.Collections.Generic;

namespace TheWarehouse.Models;

public partial class Transactioncode
{
    public string Code { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
