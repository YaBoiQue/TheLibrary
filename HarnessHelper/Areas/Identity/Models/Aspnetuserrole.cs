namespace HarnessHelper.Areas.Identity.Models
{
    public class Aspnetuserrole : IdentityUserRole<string>
    {
        public virtual Aspnetuser User { get; set; } = null!;
        public virtual Aspnetrole Role { get; set; } = null!;
    }
}
