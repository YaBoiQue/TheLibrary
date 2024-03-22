using System;
using System.Collections.Generic;

namespace TheWarehouse.Models;

public partial class Stock
{
    public int StockId { get; set; }

    public int SupplyId { get; set; }

    public int Count { get; set; }

    public decimal? Price { get; set; }

    public string UserId { get; set; } = null!;

    public int? ReceiptId { get; set; }

    public string Code { get; set; } = null!;

    public DateTime Timestamp { get; set; }

    public virtual Stockcode CodeNavigation { get; set; } = null!;

    public virtual Supply Supply { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
