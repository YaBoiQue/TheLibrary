namespace TheWarehouse.Models
{
    public class Userrole : IdentityUserRole<string>
    {
        public override string UserId { get => base.UserId; set => base.UserId = value; }
        public override string RoleId { get => base.RoleId; set => base.RoleId = value; }
        public virtual User User { get; set; } = null!;
        public virtual Role Role { get; set; } = null!;
    }
}
