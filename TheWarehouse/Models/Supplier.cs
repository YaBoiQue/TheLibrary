using System;
using System.Collections.Generic;

namespace TheWarehouse.Models;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedTs { get; set; }

    public DateTime UpdatedTs { get; set; }

    public string CreatedUserId { get; set; } = null!;

    public string UdatedUserId { get; set; } = null!;

    public virtual ICollection<Supply> Supplies { get; set; } = new List<Supply>();
}
