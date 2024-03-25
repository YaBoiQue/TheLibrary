using System;
using System.Collections.Generic;

namespace TheWarehouse.Models;

public partial class Role : IdentityRole<string>
{

    public virtual ICollection<IdentityRoleClaim<string>> Roleclaims { get; set; } = new List<IdentityRoleClaim<string>>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();

    public virtual ICollection<IdentityUserRole<string>> Userroles { get; set; } = new List<IdentityUserRole<string>>();
}
