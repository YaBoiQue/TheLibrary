using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace TheWarehouse.Models;

public partial class Menuitem
{
    public int MenuItemId { get; set; }

    public string Name { get; set; } = null!;

    public decimal? Price { get; set; }

    public int? MenucategoryId { get; set; }

    /// <summary>
    /// Bit value represents boolean
    /// 0 = true
    /// 1 = false
    /// </summary>
    public ulong Active { get; set; }

    public string? ImageName { get; set; }

    [NotMapped]
    [AllowNull]
    [DisplayName("Upload File")]
    public IFormFile ImageFile { get; set; }

    [NotMapped]
    [AllowNull]
    public string? ImagePath { get; set; }

    public DateTime CreatedTs { get; set; }

    public DateTime UpdatedTs { get; set; }

    public string CreatedUserId { get; set; } = null!;

    public string UpdatedUserId { get; set; } = null!;

    public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

    public virtual Menucategory? Menucategory { get; set; }

    public virtual ICollection<Transactionitem> Transactionitems { get; set; } = new List<Transactionitem>();
}
