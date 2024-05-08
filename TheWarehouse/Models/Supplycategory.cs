using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace TheWarehouse.Models;

public partial class Supplycategory
{
    public int SupplycategoryId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Supply> Supplies { get; set; } = new List<Supply>();
}
