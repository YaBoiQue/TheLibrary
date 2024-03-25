using System;
using System.Collections.Generic;

namespace TheWarehouse.Models;

public partial class Roleclaim : IdentityRoleClaim<string>
{

    public virtual Role? Role { get; set; }
}
