using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace TheWarehouse.Models;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public string Name { get; set; } = null!;

    public string? ImageName { get; set; }

    [NotMapped]
    [AllowNull]
    [DisplayName("Upload File")]
    public IFormFile ImageFile { get; set; }

    [DisplayName("Logo")]
    public string? ImagePath { get; set; }

    public DateTime CreatedTs { get; set; }

    public DateTime UpdatedTs { get; set; }

    public string CreatedUserId { get; set; } = null!;

    public string UpdatedUserId { get; set; } = null!;

    public virtual ICollection<Supply> Supplies { get; set; } = [];

    public virtual ICollection<Stockreceipt> Stockreceipts { get; set; } = [];
}
