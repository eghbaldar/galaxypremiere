namespace galaxypremiere.Application.Services.UsersPosts.Queries.GetUsersPosts
{
    public partial class GetUsersPostsService
    {
        public class GetPostPhotosByPostIdDto
        {
            public Guid PostId { get; set; } // Post Id
            public Guid Id { get; set; } // Photo Id
            public string Filename { get; set; }
            public DateTime InsertTime { get; set; }
        }
    }
}
