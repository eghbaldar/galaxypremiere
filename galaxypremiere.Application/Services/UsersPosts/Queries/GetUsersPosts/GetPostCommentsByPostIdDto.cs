namespace galaxypremiere.Application.Services.UsersPosts.Queries.GetUsersPosts
{
    public class GetPostCommentsByPostIdDto
    {
        public Guid PostId { get; set; } // Post Id
        public Guid Id { get; set; } // Photo Id
        public Guid Parent { get; set; }
        public string Comment { get; set; }
        public long UserId { get; set; }
        public string NicknameCommenter { get; set; }
        public string Headshot { get; set; }
        public bool AllowToRemove { get; set; }
        public DateTime InsertTime { get; set; }
    }
}
