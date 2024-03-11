namespace galaxypremiere.Application.Services.Comments.Queries.GetCommentsBySectionId
{
    public class RequestGetCommentsBySectionIdServiceDto
    {
        public Guid SectionId { get; set; } // for example: Photo Id or Post Id and so on.
        public byte Section { get; set; } // derived from SectionsConstants.cs
        public long UserId { get; set; } // getting UserId of person who wants to see or leave a comment
    }
}
