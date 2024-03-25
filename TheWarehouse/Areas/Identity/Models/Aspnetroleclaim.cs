namespace TheWarehouse.Areas.Identity.Models;

public partial class Aspnetroleclaim : IdentityRoleClaim<string>
{

    public virtual Aspnetrole Role { get; set; } = null!;
}
