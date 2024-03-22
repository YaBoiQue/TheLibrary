using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheWarehouse.Models;

public partial class User : IdentityUser<string>
{
    [PersonalData]
    public string FirstName { get; set; } = null!;
    [PersonalData]
    public string LastName { get; set; } = null!;


    public DateTime? LockoutEndDateUtc { get; set; }

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual ICollection<IdentityUserClaim<string>> Userclaims { get; set; } = new List<IdentityUserClaim<string>>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();

    public virtual ICollection<IdentityUserRole<string>> Userroles { get; set; } = new List<IdentityUserRole<string>>();
}
