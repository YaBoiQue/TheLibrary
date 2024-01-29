using System;
using System.Collections.Generic;

namespace TheWarehouse.Models;

public partial class Inventorycode
{
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
}
