namespace galaxypremiere.Application.Services.Comments.Commands.PostComment
{
    public class PostCommentServiceDto
    {
        public Guid Id { get; set; } // Back the section Id after adding the comment
        public string Avatar { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
    }
}
