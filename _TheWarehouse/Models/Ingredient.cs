using System;
using System.Collections.Generic;

namespace TheWarehouse.Models;

public partial class Ingredient
{
    public int IngredientId { get; set; }

    public int MenuItemId { get; set; }

    public int SupplyId { get; set; }

    public DateTime CreatedTs { get; set; }

    public DateTime UpdatedTs { get; set; }

    public virtual Menuitem MenuItem { get; set; } = null!;

    public virtual Supply Supply { get; set; } = null!;
}
