using System;
using System.Collections.Generic;

namespace TheWarehouse.Models;

public partial class Menucategory
{
    public int MenucategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public virtual ICollection<Menuitem> Menuitems { get; set; } = new List<Menuitem>();
}
