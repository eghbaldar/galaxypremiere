namespace galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileLinks
{
    public class GetUserProfileLinksDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } // The Title of link
        public string Link { get; set; } // The Link of link
        public DateTime InsertDate { get; set; }
    }
}
