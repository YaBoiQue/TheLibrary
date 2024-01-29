using System;
using System.Collections.Generic;

namespace TheWarehouse.Models;

public partial class Inventory
{
    public int IdInventory { get; set; }

    public int SupplyId { get; set; }

    public int Amount { get; set; }

    public decimal? Price { get; set; }

    public int EmployeeId { get; set; }

    public int? ReceiptId { get; set; }

    public string Code { get; set; } = null!;

    public DateTime Timestamp { get; set; }

    public virtual Inventorycode CodeNavigation { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual Receipt? Receipt { get; set; }

    public virtual Supply Supply { get; set; } = null!;
}
