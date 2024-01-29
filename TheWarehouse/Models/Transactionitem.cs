using System;
using System.Collections.Generic;

namespace TheWarehouse.Models;

public partial class Transactionitem
{
    public int IdTransactionItems { get; set; }

    public int TransactionId { get; set; }

    public int MenuItemId { get; set; }

    public int Count { get; set; }

    public double Price { get; set; }

    public DateTime? Timestamp { get; set; }

    public virtual Menuitem MenuItem { get; set; } = null!;

    public virtual Transaction Transaction { get; set; } = null!;
}
