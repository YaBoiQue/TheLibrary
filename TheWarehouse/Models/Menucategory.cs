using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace TheWarehouse.Models;

public partial class Menucategory
{

    public Menucategory() { }

    public int MenucategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string? ImageName { get; set; }

    [NotMapped]
    [AllowNull]
    [DisplayName("Upload File")]
    public IFormFile? ImageFile {  get; set; }

    [NotMapped]
    [AllowNull]
    public string? ImagePath { get; set; }

    public virtual ICollection<Menuitem> Menuitems { get; set; } = [];
}
