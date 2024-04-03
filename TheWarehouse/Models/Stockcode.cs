using System;
using System.Collections.Generic;

namespace TheWarehouse.Models;

public partial class Stockcode
{
    public string Code { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
}
