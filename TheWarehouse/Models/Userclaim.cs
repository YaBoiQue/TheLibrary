using System;
using System.Collections.Generic;

namespace TheWarehouse.Models;

public partial class Userclaim : IdentityUserClaim<string>
{

    public virtual User? User { get; set; }
}
