namespace galaxypremiere.Application.Services.UsersPosts.Commands.PostUsersPost
{
    public partial class PostUsersPostService
    {
        public class PostUsersPostServiceDto
        {
            public Guid Id { get; set; }
            public string Post { get; set; }
            public DateTime InsertDate { get; set; }
            public List<Dictionary<Guid, string>> PhotosToReturn { get; set; }
        }
    }
}
