using System;
using System.Collections.Generic;

namespace TheWarehouse.Models;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public string? Code { get; set; }

    public DateTime Timestamp { get; set; }

    public string UserId { get; set; } = null!;

    public virtual Transactioncode? CodeNavigation { get; set; }

    public virtual ICollection<Transactionitem> Transactionitems { get; set; } = new List<Transactionitem>();
}
