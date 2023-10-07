namespace galaxypremiere.Application.Services.Users.Queries.GetUsers
{
    public class GetUsersServiceDto
    {
        public long Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        //public List<galaxypremiere.Domain.Entities.Users.Roles> Roles { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
