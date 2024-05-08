using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace TheWarehouse.Models;

public partial class Ingredient
{
    public int IngredientId { get; set; }

    public int MenuItemId { get; set; }

    public int SupplyId { get; set; }

    public DateTime CreatedTs { get; set; }

    public DateTime UpdatedTs { get; set; }

    public string CreatedUserId { get; set; } = null!;

    public string UpdatedUserId { get; set; } = null!;

    public virtual Menuitem? MenuItem { get; set; }

    public virtual Supply? Supply { get; set; }
}
