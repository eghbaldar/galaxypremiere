namespace galaxypremiere.Application.Services.UsersInformation.Queries.GetUsersInformationPhotosByUsername
{
    public class GetUsersInformationPhotosByUsernameServiceDto
    {
        public Guid Id { get; set; } // PhotoId
        public string Filename { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public long VisitorCounter { get; set; }
        public string CountComments { get; set; } // the number of all comments
        public bool Like { get; set; } // true: liked | false: unliked
        public string CountLikes { get; set; }
    }
}
