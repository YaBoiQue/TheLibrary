using System;
using System.Collections.Generic;

namespace TheWarehouse.Models;

public partial class Supplytype
{
    public string Name { get; set; } = null!;

    public virtual ICollection<Supply> Supplies { get; set; } = new List<Supply>();
}
