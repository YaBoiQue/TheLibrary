using System;
using System.Collections.Generic;

namespace TheWarehouse.Models;

public partial class Supply
{
    public int IdSupplies { get; set; }

    public string Name { get; set; } = null!;

    public string TypeId { get; set; } = null!;

    public int? SupplierId { get; set; }

    public DateTime CreatedTs { get; set; }

    public DateTime UpdatedTs { get; set; }

    public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();

    public virtual Supplier? Supplier { get; set; }

    public virtual Supplytype Type { get; set; } = null!;
}
