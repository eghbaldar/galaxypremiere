namespace galaxypremiere.Application.Services.UsersPosts.Queries.GetUsersPosts
{
    public class RequestGetUsersPostsServiceDto
    {
        public string Username { get; set; }
        public long UserId { get; set; } // who are vising the page?
        public int CurrentPage { get; set; } //  <---- Pagination
    }
}
