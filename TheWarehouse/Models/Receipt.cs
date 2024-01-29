using System;
using System.Collections.Generic;

namespace TheWarehouse.Models;

public partial class Receipt
{
    public int IdReceipts { get; set; }

    public string? Store { get; set; }

    public string? ReceiptNum { get; set; }

    public double? Total { get; set; }

    public int? EmployeeId { get; set; }

    public DateTime Timestamp { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
}
