using System;
using System.Collections.Generic;

namespace TheWarehouse.Models;

public partial class Transaction
{
    public int IdTransactions { get; set; }

    public int EmployeeId { get; set; }

    public string? Code { get; set; }

    public DateTime Timestamp { get; set; }

    public virtual Transactioncode? CodeNavigation { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<Transactionitem> Transactionitems { get; set; } = new List<Transactionitem>();
}
