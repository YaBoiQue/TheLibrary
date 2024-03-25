namespace TheWarehouse.Areas.Identity.Models;

public partial class Aspnetuserclaim : IdentityUserClaim<string>
{
    public virtual Aspnetuser User { get; set; } = null!;
}
