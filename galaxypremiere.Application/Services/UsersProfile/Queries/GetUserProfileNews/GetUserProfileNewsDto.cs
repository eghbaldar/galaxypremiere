namespace galaxypremiere.Application.Services.UsersProfile.Queries.GetUserProfileNews
{
    public class GetUserProfileNewsDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } // The Title of news
        public string Reference { get; set; } // The Reference of news
        public string Link { get; set; } // The Link of news
        public DateTime PublishedDate { get; set; } // When did this news publish?
        public DateTime InsertDate { get; set; }
    }
}
