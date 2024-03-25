using System;
using System.Collections.Generic;

namespace TheWarehouse.Areas.Identity.Models;

public partial class Aspnetusertoken : IdentityUserToken<string>
{
    public virtual Aspnetuser User { get; set; } = null!;
}
