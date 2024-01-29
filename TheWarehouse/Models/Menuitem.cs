using System;
using System.Collections.Generic;

namespace TheWarehouse.Models;

public partial class Menuitem
{
    public int IdMenuItems { get; set; }

    public string Name { get; set; } = null!;

    public decimal? Price { get; set; }

    public int? CategoryId { get; set; }

    public DateTime CreatedTs { get; set; }

    public DateTime UpdatedTs { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

    public virtual ICollection<Transactionitem> Transactionitems { get; set; } = new List<Transactionitem>();
}
