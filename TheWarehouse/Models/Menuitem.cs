using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace TheWarehouse.Models;

public partial class Menuitem
{
    public int MenuitemId { get; set; }

    [Display(Name = "Item Name")]
    public string Name { get; set; } = null!;

    [DataType(DataType.Currency)]
    public decimal? Price { get; set; }

    public int? MenucategoryId { get; set; }

    /// <summary>
    /// Bit value represents boolean
    /// 0 = true
    /// 1 = false
    /// </summary>
    public bool Active { get; set; }

    public string? ImageName { get; set; }

    [NotMapped]
    [AllowNull]
    [DisplayName("Upload File")]
    public IFormFile? ImageFile { get; set; }

    [NotMapped]
    [AllowNull]
    public string? ImagePath { get; set; }

    [AllowNull]
    public DateTime CreatedTs { get; set; }

    [AllowNull]
    public DateTime UpdatedTs { get; set; }

    [AllowNull]
    public string? CreatedUserId { get; set; }

    [AllowNull]
    public string? UpdatedUserId { get; set; }

    public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

    public virtual Menucategory? Menucategory { get; set; }

    public virtual ICollection<Transactionitem> Transactionitems { get; set; } = new List<Transactionitem>();
}
