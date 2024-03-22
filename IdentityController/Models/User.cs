using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityController.Models;

public partial class User : IdentityUser<string>
{
    [ScaffoldColumn(false)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    override public string Id { get; set; } = null!;

    override public string? Email { get; set; }

    override public bool EmailConfirmed { get; set; }

    override public string? PasswordHash { get; set; }

    override public string? SecurityStamp { get; set; }

    override public string? PhoneNumber { get; set; }

    override public bool PhoneNumberConfirmed { get; set; }

    override public bool TwoFactorEnabled { get; set; }

    public DateTime? LockoutEndDateUtc { get; set; }

    override public bool LockoutEnabled { get; set; }

    override public int AccessFailedCount { get; set; }

    override public string UserName { get; set; } = null!;

    public virtual ICollection<IdentityUserClaim<string>> Userclaims { get; set; } = new List<IdentityUserClaim<string>>();

    public virtual ICollection<IdentityUserLogin<string>> Userlogins { get; set; } = new List<IdentityUserLogin<string>>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
