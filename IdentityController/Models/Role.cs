using System;
using System.Collections.Generic;

namespace IdentityController.Models;

public partial class Role : IdentityRole<string>
{
    override public string Id { get; set; } = null!;

    override public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
