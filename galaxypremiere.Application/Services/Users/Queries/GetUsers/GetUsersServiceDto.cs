namespace galaxypremiere.Application.Services.Users.Queries.GetUsers
{
    public class GetUsersServiceDto
    {
        public long Id { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; } = true;
        public string LoginDateTime { get; set; }
    }
}
