using Microsoft.AspNetCore.Http;

namespace galaxypremiere.Application.Services.UsersProfile.Commands.PostUserProfileAttachments
{
    public class RequestPostUserProfileAttachmentServiceDto
    {
        public long UsersId { get; set; }
        public string Title { get; set; }
        public IFormFile File { get; set; }
    }
}
