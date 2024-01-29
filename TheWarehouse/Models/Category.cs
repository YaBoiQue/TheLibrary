using System;
using System.Collections.Generic;

namespace TheWarehouse.Models;

public partial class Category
{
    public int IdCategories { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Menuitem> Menuitems { get; set; } = new List<Menuitem>();
}
