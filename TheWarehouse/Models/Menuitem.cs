using System;
using System.Collections.Generic;

namespace TheWarehouse.Models;

public partial class Menuitem
{
    public int MenuItemId { get; set; }

    public string Name { get; set; } = null!;

    public decimal? Price { get; set; }

    public int? MenucategoryId { get; set; }

    public DateTime CreatedTs { get; set; }

    public DateTime UpdatedTs { get; set; }

    public string UserId { get; set; } = null!;

    public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

    public virtual Menucategory? Menucategory { get; set; }

    public virtual ICollection<Transactionitem> Transactionitems { get; set; } = new List<Transactionitem>();
}
