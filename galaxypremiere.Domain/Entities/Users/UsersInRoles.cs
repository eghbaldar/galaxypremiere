namespace galaxypremiere.Domain.Entities.Users
{
    public class UsersInRoles
    {
        public long  Id { get; set; }
        public virtual Users Users { get; set; }
        public long UsersId { get; set; }
        public virtual Roles Roles { get; set; }
        public byte RolesId { get; set; }
    }
}
