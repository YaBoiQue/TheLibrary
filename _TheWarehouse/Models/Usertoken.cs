using System;
using System.Collections.Generic;

namespace TheWarehouse.Models;

public partial class Usertoken : IdentityUserToken<string>
{

    public virtual User User { get; set; } = null!;
}
