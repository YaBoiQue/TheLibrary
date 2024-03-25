using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace TheWarehouse.Areas.Identity.Models;

public partial class Aspnetuser : IdentityUser<string>
{
    [ScaffoldColumn(false)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    override public string Id { get; set; } = null!;

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    public DateTime? LockoutEndDateUtc { get; set; }
    public virtual ICollection<Aspnetuserclaim> Claims { get; set; } = [];
    public virtual ICollection<Aspnetuserlogin> Logins { get; set; } = [];
    public virtual ICollection<Aspnetusertoken> Tokens { get; set; } = [];
    public virtual ICollection<Aspnetuserrole> UserRoles { get; set; } = [];
}
