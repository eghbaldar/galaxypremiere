namespace galaxypremiere.Application.Services.UsersPosts.Queries.GetUsersPosts
{
    public class ResultGetUsersPostsServiceDto
    {
        public List<GetUsersPostsServiceDto> resultGetUsersPostsServiceDto { get; set; }
        public int RowCount { get; set; } //  <---- Pagination
        public int RowsOnEachOage { get; set; } //  <---- Pagination
    }
}
