using System;
using System.Collections.Generic;

namespace TheWarehouse.Models;

public partial class Userlogin : IdentityUserLogin<string>
{

    public virtual User User { get; set; } = null!;
}
