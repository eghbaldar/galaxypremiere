namespace galaxypremiere.Application.Services.Comments.Commands.PostComment
{
    public class RequestPostCommentServiceDto
    {
        public long UsersId { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public byte Section { get; set; } // drived from "SectionsConstants.cs"
        public Guid SectionId { get; set; } // for example, when the section is related to USER-PHOTO, the ID of photo will be stored in it.
    }
}
