using Microsoft.AspNetCore.Http;

namespace galaxypremiere.Application.Services.UsersPosts.Commands.PostUsersPost
{
    public class RequestPostUsersPostServiceDto
    {
        public long UsersId { get; set; }
        public string Post { get; set; }
        public long From { get; set; }
        public List<IFormFile>? Photos { get; set; }
    }
}
