using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HarnessHelper.Areas.Identity.Models;

public partial class Aspnetrole : IdentityRole<string>
{
    [ScaffoldColumn(false)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    override public string Id { get; set; } = null!;

    public virtual ICollection<Aspnetuserrole> UserRoles { get; set; } = [];
    public virtual ICollection<Aspnetroleclaim> RoleClaims { get; set; } = [];
    public virtual ICollection<Aspnetuser> UsersNavigation { get; set; } = [];
}
