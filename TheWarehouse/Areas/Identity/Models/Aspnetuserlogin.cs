using System;
using System.Collections.Generic;

namespace TheWarehouse.Areas.Identity.Models;

public partial class Aspnetuserlogin : IdentityUserLogin<string>
{
    public virtual Aspnetuser User { get; set; } = null!;
}
