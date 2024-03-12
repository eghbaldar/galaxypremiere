namespace galaxypremiere.Application.Services.Comments.Queries.GetCommentsBySectionId
{
    public class GetCommentsBySectionIdServiceDto
    {
        public Guid SectionId { get; set; } // Section Id
        public string Comment { get; set; }
        public DateTime InsertDate { get; set; }
        public string? Username { get; set; } // "The username of the person who made the comment (if applicable)"
        public string Email { get; set; } // the main email
        public string Nickname { get; set; } 
        public string? Avatar { get; set; } // "The avatar of the person who made the comment (if applicable)"
        public bool AllowToRemove { get; set; } // if the user is allowed to remove his or her comments or not   
    }
}
