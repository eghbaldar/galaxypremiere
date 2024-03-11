namespace galaxypremiere.Application.Services.Comments.Commands.DeleteComment
{
    public class RequestDeleteCommentServiceDto
    {
        public byte Section { get; set; } // Derived from SectionsConstants.cs
        public Guid Id { get; set; } // Section Id
        public long UserId { get; set; } // Who does want to remove the comment?
    }
}
