using System;
using System.Collections.Generic;

namespace TheWarehouse.Models;

public partial class Stock
{
    public int StockId { get; set; }

    public int StockreceiptId { get; set; }

    public int SupplyId { get; set; }

    public int Count { get; set; }

    public decimal? Price { get; set; }

    public string UserId { get; set; } = null!;

    public string Code { get; set; } = null!;

    public DateTime Timestamp { get; set; }

    public virtual Stockreceipt Stockreceipt { get; set; } = new();

    public virtual Stockcode CodeNavigation { get; set; } = new();

    public virtual Supply Supply { get; set; } = new();
}
