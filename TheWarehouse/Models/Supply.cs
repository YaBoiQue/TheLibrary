using System;
using System.Collections.Generic;

namespace TheWarehouse.Models;

public partial class Supply
{
    public int SupplyId { get; set; }

    public string Name { get; set; } = null!;

    public int SupplyCategoryId { get; set; }

    public int? SupplierId { get; set; }

    public DateTime CreatedTs { get; set; }

    public DateTime UpdatedTs { get; set; }

    public virtual Supplycategory Supplycategory { get; set; } = null!;

    public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();

    public virtual Supplier? Supplier { get; set; }
}
